using NgUtil.Debugging.Contracts;
using NgUtil.Files;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Primitives;
using SixLabors.Shapes;
using System;

namespace NgUtil.Media.Images {
    public static class ImageUtil {


        public static FileLink TransformImage(string imgFilePath, AspectRatio aspectRatio, FileLink outputFileLink = null) {
            EmptyParamContract.Validate(imgFilePath);
            return TransformImage(new FileLink(imgFilePath), aspectRatio, ResizeMode.Crop, outputFileLink);
        }

        public static FileLink TransformImage(FileLink imgFileLink, AspectRatio aspectRatio, FileLink outputFileLink = null) {
            return TransformImage(imgFileLink, aspectRatio, ResizeMode.Crop, outputFileLink);
        }

        public static FileLink TransformImage(string imgFilePath, AspectRatio aspectRatio, ResizeMode resizeMode = ResizeMode.Crop, FileLink outputFileLink = null) {
            EmptyParamContract.Validate(imgFilePath);
            return TransformImage(new FileLink(imgFilePath), aspectRatio, resizeMode, outputFileLink);
        }

        public static FileLink TransformImage(FileLink imgFileLink, AspectRatio aspectRatio, ResizeMode resizeMode = ResizeMode.Crop, FileLink outputFileLink = null) {
            return TransformImage(imgFileLink, default, aspectRatio, resizeMode, outputFileLink);
        }

        public static FileLink TransformImage(string imgFilePath, Size size, FileLink outputFileLink = null) {
            EmptyParamContract.Validate(imgFilePath);
            return TransformImage(new FileLink(imgFilePath), size, ResizeMode.Crop, outputFileLink);
        }

        public static FileLink TransformImage(string imgFilePath, Size size, ResizeMode resizeMode = ResizeMode.Crop, FileLink outputFileLink = null) {
            EmptyParamContract.Validate(imgFilePath);
            return TransformImage(new FileLink(imgFilePath), size, resizeMode, outputFileLink);
        }

        public static FileLink TransformImage(FileLink imgFileLink, Size size, ResizeMode resizeMode = ResizeMode.Crop, FileLink outputFileLink = null) {
            return TransformImage(imgFileLink, size, resizeMode, outputFileLink);
        }

        private static FileLink TransformImage(FileLink imgFileLink, Size size, AspectRatio aspectRatio, ResizeMode resizeMode, FileLink outputFileLink = null) {
            EmptyParamContract.Validate(imgFileLink != null && ((size != null && size != default) || aspectRatio != null));

            if (outputFileLink is null) {
                outputFileLink = imgFileLink;
            }
            using (Image image = Image.Load(imgFileLink.Path)) {
                if (size == null || size == default) {
                    size = GetCroppedSize(image.Size(), aspectRatio);
                }
                ResizeOptions resizeOptions = new ResizeOptions {
                    Size = size,
                    Mode = resizeMode
                };
                image.Mutate(ctx => ctx.Resize(resizeOptions));

                image.Save(outputFileLink.Path);
            }
            return outputFileLink;
        }

        public static Size GetCroppedSize(Size original, AspectRatio aspectRatio) {
            EmptyParamContract.Validate(original != null && aspectRatio != null);

            double originalRatio = original.Width / original.Height;

            if (originalRatio < aspectRatio.getRatio()) {
                int newWidth = original.Width;
                int newHeight = (int)Math.Round(original.Width / aspectRatio.getRatio());
                return new Size(newWidth, newHeight);
            } else {
                int newWidth = (int)Math.Round(original.Height * aspectRatio.getRatio());
                int newHeight = original.Height;
                return new Size(newWidth, newHeight);
            }
        }

        public static Size GetScaledSize(Size original, Size targetDimension) {
            EmptyParamContract.Validate(original != null && targetDimension != null);

            double originalRatio = original.Width / original.Height;
            double targetRatio = targetDimension.Width / targetDimension.Height;

            if (originalRatio < targetRatio) {
                int newWidth = targetDimension.Width;
                int newHeight = (int)Math.Round((double)(targetDimension.Height / original.Height) * original.Height);
                return new Size(newWidth, newHeight);
            } else {
                int newWidth = (int)Math.Round((double)(targetDimension.Width / original.Width) * original.Height);
                int newHeight = targetDimension.Height;
                return new Size(newWidth, newHeight);
            }
        }

        public static FileLink RoundImageCorners(FileLink imgFileLink, FileLink outputFileLink = null) {
            EmptyParamContract.Validate(imgFileLink);

            if (outputFileLink is null) {
                outputFileLink = imgFileLink;
            }
            using (Image image = Image.Load(imgFileLink.Path)) {
                //Dimension dim = new Dimension(image.Width, image.Height);
                Size size = new Size(image.Width, image.Height);
                int cornerRadius = ((image.Width / 10) + (image.Height / 10)) / 2;

                // first create a square
                RectangularPolygon rect = new RectangularPolygon(-0.5f, -0.5f, cornerRadius, cornerRadius);

                // then cut out of the square a circle so we are left with a corner
                IPath cornerTopLeft = rect.Clip(new EllipsePolygon(cornerRadius - 0.5f, cornerRadius - 0.5f, cornerRadius));

                // corner is now a corner shape positions top left
                //lets make 3 more positioned correctly, we can do that by translating the original around the center of the image
                float rightPos = image.Width - cornerTopLeft.Bounds.Width + 1;
                float bottomPos = image.Height - cornerTopLeft.Bounds.Height + 1;

                // move it across the width of the image - the width of the shape
                IPath cornerTopRight = cornerTopLeft.RotateDegree(90).Translate(rightPos, 0);
                IPath cornerBottomLeft = cornerTopLeft.RotateDegree(-90).Translate(0, bottomPos);
                IPath cornerBottomRight = cornerTopLeft.RotateDegree(180).Translate(rightPos, bottomPos);

                // retrieve our corners
                PathCollection pathColl = new PathCollection(cornerTopLeft, cornerBottomLeft, cornerTopRight, cornerBottomRight);

                GraphicsOptions graphicOptions = new GraphicsOptions(true) {
                    AlphaCompositionMode = PixelAlphaCompositionMode.DestOut // enforces that any part of this shape that has color is punched out of the background
                };
                image.Mutate(ctx => ctx.Fill(graphicOptions, Rgba32.LimeGreen, pathColl));

                image.Save(outputFileLink.Path);
            }
            return outputFileLink;
        }

    }
}
