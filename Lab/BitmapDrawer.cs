using System.Drawing;

namespace Lab;

public class BitmapDrawer
{
    public void DrawLines(Bitmap bitmap)
    {
        if (bitmap == null)
        {
            return;
        }
        bitmap.MakeTransparent();

        int yellowLineWidth = 3;
        int grayLineWidth = 2;
        int spacing = 10;

        using (Graphics graphic = Graphics.FromImage(bitmap))
        {
            var yellowPen = new Pen(Color.FromArgb(230, ColorTranslator.FromHtml("#FFD200")), yellowLineWidth);
            var grayPen = new Pen(Color.FromArgb(180, Color.Black), grayLineWidth);

            for (int i = 0; i < bitmap.Height + bitmap.Width; i += spacing + grayLineWidth + yellowLineWidth)
            {
                // Draw yellow line
                graphic.DrawLine(yellowPen, 0, i, bitmap.Width, i - bitmap.Width);

                // Draw gray line
                graphic.DrawLine(grayPen, grayLineWidth, i + grayLineWidth, bitmap.Width + grayLineWidth, i - bitmap.Width + grayLineWidth);
            }
        }

        bitmap.Save("C:\\Users\\z004tfzp\\Desktop\\Video\\Test.png");
    }
}
