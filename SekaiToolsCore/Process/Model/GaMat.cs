using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace SekaiToolsCore.Process.Model;

public class GaMat // Gray and Alpha Mat
{
    public readonly Mat Alpha;
    public readonly Mat Gray;

    public GaMat()
    {
        Alpha = new Mat();
        Gray = new Mat();
    }
    
    public GaMat(IInputArray src, bool resize = true)
    {
        var grayImage = new Mat();
        var alphaChannel = new Mat();
        CvInvoke.CvtColor(src, grayImage, ColorConversion.Bgra2Gray);
        CvInvoke.ExtractChannel(src, alphaChannel, 3);
        if (resize)
        {
            const int scaleRatio = 5;
            var size = new Size(grayImage.Size.Width / scaleRatio, grayImage.Size.Height / scaleRatio);
            CvInvoke.Resize(grayImage, grayImage, size);
            CvInvoke.Resize(alphaChannel, alphaChannel, size);
        }

        Gray = grayImage;
        Alpha = alphaChannel;
    }

    public void ResizeTo(GaMat dst, float scaling)
    {
        CvInvoke.Resize(Alpha, dst.Alpha, new Size(
            (int)(Alpha.Width * scaling), (int)(Alpha.Height * scaling)), scaling, scaling);
        CvInvoke.Resize(Gray, dst.Gray, new Size(
            (int)(Alpha.Width * scaling), (int)(Alpha.Height * scaling)), scaling, scaling);
    }

    public Size Size => Gray.Size;
}