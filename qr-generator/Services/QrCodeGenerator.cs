using QRCoder;
using System.Drawing;
using System.IO;

public static class QrCodeGenerator
{
    public static byte[] GenerateByteArray(string url) 
        => ImageToByte(GenerateImage(url));

    public static Bitmap GenerateImage(string url) 
        => new QRCode(
            new QRCodeGenerator().CreateQrCode(url, QRCodeGenerator.ECCLevel.Q))
            .GetGraphic(10);

    private static byte[] ImageToByte(Image img)
    {
        using var stream = new MemoryStream();
        img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        return stream.ToArray();
    }
}
