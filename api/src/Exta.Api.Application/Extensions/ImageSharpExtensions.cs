using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Exta.Api.Application.Extensions;

public static class ImageSharpExtensions
{
    public static IImageProcessingContext Text(this IImageProcessingContext ctx, int x, int y, string text)
    {
        return ctx.DrawText(text, Font, Color, At(x, y));
    }

    private static readonly Color Color = new Rgba32(127, 126, 132);

    private static readonly Font Font = SystemFonts.CreateFont("Arial", 28, FontStyle.Regular);

    private static PointF At(int x, int y) => new PointF(x, y);
}
