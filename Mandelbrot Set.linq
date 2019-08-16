<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

public class MandelbrotSetForm : Form
{
    private const double MaxValueExtent = 2.0;
    private Thread thread;

    private static double CalcMandelbrotSetColor(ComplexNumber c)
    {
        const int maxIterations = 1024;
        const double maxNormal = MaxValueExtent*MaxValueExtent;

        int iteration = 0;
        var z = new ComplexNumber();
        do
        {
            z = z*z + c;
            iteration++;
        } while (z.Norm() < maxNormal && iteration < maxIterations);

        if (iteration < maxIterations)
        {
            return (double) iteration/maxIterations;
        }
        return 0; // black
    }

    private static void GenerateBitmap(Bitmap bitmap)
    {
        double scale = 2*MaxValueExtent/Math.Min(bitmap.Width, bitmap.Height);
        for (int i = 0; i < bitmap.Height; i++)
        {
            double y = (bitmap.Height/2 - i)*scale;
            for (int j = 0; j < bitmap.Width; j++)
            {
                double x = (j - bitmap.Width/2)*scale;
                double color = CalcMandelbrotSetColor(new ComplexNumber(x, y));
                bitmap.SetPixel(j, i, GetColor(color));
            }
        }
    }

    private static Color GetColor(double value)
    {
        const double MaxColor = 256;
        const double ContrastValue = 0.2;
        return Color.FromArgb(
            (int) (MaxColor*Math.Pow(value, ContrastValue)), 0, 0);
    }

    public MandelbrotSetForm()
    {
        Text                  = "Mandelbrot Set";
        BackColor             = Color.Black;
        BackgroundImageLayout = ImageLayout.Stretch;
        MaximizeBox           = false;
        StartPosition         = FormStartPosition.CenterScreen;
        FormBorderStyle       = FormBorderStyle.FixedDialog;
        ClientSize            = new Size(1024, 1024);
        Load += this.MainForm_Load;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        thread = new Thread(thread_Proc) {IsBackground = true};
        thread.Start((object)ClientSize);
    }

    private void thread_Proc(object args)
    {
        // start from small image to provide instant display for user
        Size size = (Size) args;
        int width = 16;
        while (width*2 < size.Width)
        {
            int height    = width*size.Height/size.Width;
            var bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            GenerateBitmap(bitmap);
            BeginInvoke(new SetNewBitmapDelegate(SetNewBitmap), bitmap);
            width *= 2;
            Thread.Sleep(200);
        }
        // then generate final image
        Bitmap finalBitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format24bppRgb);
        GenerateBitmap(finalBitmap);
        BeginInvoke(new SetNewBitmapDelegate(SetNewBitmap), finalBitmap);
    }

    private void SetNewBitmap(Bitmap image)
    {
        BackgroundImage?.Dispose();
        BackgroundImage = image;
    }

    private delegate void SetNewBitmapDelegate(Bitmap image);

    private static void Main()
    {
        Application.Run(new MandelbrotSetForm());
    }
}

internal struct ComplexNumber
{
    public double Re;
    public double Im;

    public ComplexNumber(double re, double im)
    {
        Re = re;
        Im = im;
    }

    public static ComplexNumber operator +(ComplexNumber x, ComplexNumber y)
    {
        return new ComplexNumber(x.Re + y.Re, x.Im + y.Im);
    }

    public static ComplexNumber operator *(ComplexNumber x, ComplexNumber y)
    {
        return new ComplexNumber(
            x.Re*y.Re - x.Im*y.Im,
            x.Re*y.Im + x.Im*y.Re
            );
    }

    public double Norm()
    {
        return Re*Re + Im*Im;
    }
}