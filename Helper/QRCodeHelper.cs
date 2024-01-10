using QRCoder;
namespace QRCodeDemp.Helpers;
public static class QRCodeHelper
{
    public static byte[] GenQRCode(string url)
    {
        using QRCodeGenerator qrGenerator = new();
        using QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
        using PngByteQRCode qrCode = new(qrCodeData);
        var qrCodeImage = qrCode.GetGraphic(20);
        return qrCodeImage;
    }
}
