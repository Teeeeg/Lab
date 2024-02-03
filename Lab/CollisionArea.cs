using System.Drawing;

namespace Lab;

public class CollisionArea
{

    private Bitmap myPreSetTopCollisionArea;
    private Bitmap myPreSetSideCollisionArea;
    private int height;
    private int width;
    private int yellowLineWidth = 3;
    private int grayLineWidth = 2;
    private int spacing = 10;

    public CollisionArea(int width, int height)
    {
        this.width = width;
        this.height = height;
        myPreSetTopCollisionArea = new Bitmap(width, height);
        myPreSetSideCollisionArea = new Bitmap(width, height);
    }


    public void CarveCollisionArea()
    {
        // Assuming GetCollisionArea returns a Bitmap
        Bitmap collisionArea = GetCollisionArea();
        DrawPreSetTopCollisionArea();
        DrawPreSetSideCollisionArea();

        for (int x = 0; x < collisionArea.Width; x++)
        {
            for (int y = 0; y < collisionArea.Height; y++)
            {
                int pixelColor = collisionArea.GetPixel(x, y).ToArgb();

                // Check if the pixel is black and exists in the collision area
                if (pixelColor == Color.Black.ToArgb())
                {
                    continue;
                }

                // Set the pixel to transparent
                myPreSetTopCollisionArea.SetPixel(x, y, Color.Transparent);
            }
        }

        myPreSetTopCollisionArea.Save("C:\\Users\\z004tfzp\\Desktop\\Media\\collsion.png");
    }

    private void DrawPreSetTopCollisionArea()
    {
        using (Graphics graphic = Graphics.FromImage(myPreSetTopCollisionArea))
        {
            var yellowPen = new Pen(Color.FromArgb(230, ColorTranslator.FromHtml("#FFD200")), yellowLineWidth);
            var grayPen = new Pen(Color.FromArgb(180, Color.Black), grayLineWidth);

            for (int i = 0; i < height + width; i += spacing + grayLineWidth + yellowLineWidth)
            {
                // Draw yellow line
                graphic.DrawLine(yellowPen, 0, i, width, i - width);

                // Draw gray line
                graphic.DrawLine(grayPen, grayLineWidth, i + grayLineWidth, width + grayLineWidth, i - width + grayLineWidth);
            }

        }
        // myPreSetTopCollisionArea.Save("C:\\Users\\z004tfzp\\Desktop\\Media\\top.png");
    }

    private void DrawPreSetSideCollisionArea()
    {
        myPreSetSideCollisionArea = new Bitmap(myPreSetTopCollisionArea);
        myPreSetSideCollisionArea.RotateFlip(RotateFlipType.RotateNoneFlipX);
        // myPreSetSideCollisionArea.Save("C:\\Users\\z004tfzp\\Desktop\\Media\\side.png");
    }

    private Bitmap GetCollisionArea()
    {
        Random rand = new Random();

        // Generate random positions and sizes for the rectangles
        int rect1X = rand.Next(width);
        int rect1Y = rand.Next(height);
        int rect1Width = rand.Next(width - rect1X);
        int rect1Height = rand.Next(height - rect1Y);

        int rect2X = rand.Next(width);
        int rect2Y = rand.Next(height);
        int rect2Width = rand.Next(width - rect2X);
        int rect2Height = rand.Next(height - rect2Y);

        Bitmap bitmap = new Bitmap(width, height);

        // Draw the rectangles on the bitmap
        using (Graphics graphic = Graphics.FromImage(bitmap))
        {
            graphic.Clear(Color.White);
            graphic.FillRectangle(Brushes.Black, rect1X, rect1Y, rect1Width, rect1Height);
            graphic.FillRectangle(Brushes.Black, rect2X, rect2Y, rect2Width, rect2Height);
        }

        bitmap.Save("C:\\Users\\z004tfzp\\Desktop\\Media\\collisionArea.png");

        return bitmap;
    }
}
