
namespace QRCodeDemp.Helpers;
public static class FileHelper
{
    /// <summary>
    /// OverLoading:
    /// <list type="bullet">
    /// <item><description>WriteImgFile(imageData, saveQRCodePath)</description></item>
    /// <item><description>WriteImgFile(imageData, saveQRCodePath, logoImagePath)</description></item>
    /// </list>
    /// </summary>
    public static void WriteImgFile(byte[] imageData, string saveQRCodePath, string? logoImagePath = null)
    {
        using MemoryStream ms = new(imageData);
        using Image<Rgba32> qrCodeImage = Image.Load<Rgba32>(ms);
        if (logoImagePath != null)
        {
            using Image<Rgba32> logoImage = Image.Load<Rgba32>(logoImagePath);
            int logoSize = qrCodeImage.Width / 4; // 圖片大小為 QR 碼寬度的四分之一
            int x = (qrCodeImage.Width - logoSize) / 2; // 圖片在 x 軸上的位置
            int y = (qrCodeImage.Height - logoSize) / 2; // 圖片在 y 軸上的位置

            logoImage.Mutate(ctx => ctx.Resize(new ResizeOptions
            {
                Size = new Size(logoSize, logoSize),
                Mode = ResizeMode.Stretch
            }));

            qrCodeImage.Mutate(ctx => ctx.DrawImage(logoImage, new Point(x, y), 1f));
        }

        qrCodeImage.Save(saveQRCodePath);
        Console.WriteLine("Image saved successfully.");
    }

    public static string? GetYTLogoImagePath(string imgDir, string searchPattern)
    {
        var files = Directory.GetFiles(imgDir, searchPattern, SearchOption.TopDirectoryOnly);
        return files.Length == 0
            ? null
            : files[0];
    }
}
