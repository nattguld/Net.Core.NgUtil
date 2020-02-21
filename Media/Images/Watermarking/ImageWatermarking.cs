using NgUtil.Debugging.Contracts;
using NgUtil.Files;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System;

namespace NgUtil.Media.Images.Watermarking {
    public static class ImageWatermarking {


        public static FileLink WatermarkImage(FileLink imgFileLink, string text, WatermarkSettings wmSettings, FileLink outputFileLink = null) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(text) && wmSettings != null && imgFileLink != null);

            if (outputFileLink is null) {
                outputFileLink = imgFileLink;
            }
            using (Image image = Image.Load(imgFileLink.Path)) {
                image.Mutate(ctx => ctx.ApplyScalingWaterMark(text, wmSettings));
                image.Save(outputFileLink.Path);
            }
            return outputFileLink;
        }

        private static IImageProcessingContext ApplyScalingWaterMark(this IImageProcessingContext processingContext, string text, WatermarkSettings wmSettings) {
            if (wmSettings.IsWordWrap) {
                return processingContext.ApplyScalingWaterMarkWordWrap(text, wmSettings);
            } else {
                return processingContext.ApplyScalingWaterMarkSimple(text, wmSettings);
            }
        }

        private static IImageProcessingContext ApplyScalingWaterMarkSimple(this IImageProcessingContext processingContext, string text, WatermarkSettings wmSettings) {
            Size imgSize = processingContext.GetCurrentSize();

            // measure the text size
            SizeF size = TextMeasurer.Measure(text, new RendererOptions(wmSettings.Font));

            //find out how much we need to scale the text to fill the space (up or down)
            float scalingFactor = Math.Min(imgSize.Width / size.Width, imgSize.Height / size.Height);

            //create a new font
            Font scaledFont = new Font(wmSettings.Font, scalingFactor * wmSettings.Font.Size);

            var center = new PointF(imgSize.Width / 2, imgSize.Height / 2);
            var textGraphicOptions = new TextGraphicsOptions(true) {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            return processingContext.DrawText(textGraphicOptions, text, scaledFont, wmSettings.Color, center);
        }

        private static IImageProcessingContext ApplyScalingWaterMarkWordWrap(this IImageProcessingContext processingContext, string text, WatermarkSettings wmSettings) {
            Size imgSize = processingContext.GetCurrentSize();

            float targetWidth = imgSize.Width - (wmSettings.Padding * 2);
            float targetHeight = imgSize.Height - (wmSettings.Padding * 2);

            float targetMinHeight = imgSize.Height - (wmSettings.Padding * 3); // must be with in a margin width of the target height

            // now we are working i 2 dimensions at once and can't just scale because it will cause the text to
            // reflow we need to just try multiple times

            var scaledFont = wmSettings.Font;
            SizeF s = new SizeF(float.MaxValue, float.MaxValue);

            float scaleFactor = (scaledFont.Size / 2); // every time we change direction we half this size
            int trapCount = (int)scaledFont.Size * 2;
            if (trapCount < 10) {
                trapCount = 10;
            }

            bool isTooSmall = false;

            while ((s.Height > targetHeight || s.Height < targetMinHeight) && trapCount > 0) {
                if (s.Height > targetHeight) {
                    if (isTooSmall) {
                        scaleFactor = scaleFactor / 2;
                    }

                    scaledFont = new Font(scaledFont, scaledFont.Size - scaleFactor);
                    isTooSmall = false;
                }

                if (s.Height < targetMinHeight) {
                    if (!isTooSmall) {
                        scaleFactor = scaleFactor / 2;
                    }
                    scaledFont = new Font(scaledFont, scaledFont.Size + scaleFactor);
                    isTooSmall = true;
                }
                trapCount--;

                s = TextMeasurer.Measure(text, new RendererOptions(scaledFont) {
                    WrappingWidth = targetWidth
                });
            }

            var center = new PointF(wmSettings.Padding, imgSize.Height / 2);
            var textGraphicOptions = new TextGraphicsOptions(true) {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                WrapTextWidth = targetWidth
            };
            return processingContext.DrawText(textGraphicOptions, text, scaledFont, wmSettings.Color, center);
        }

    }

}
