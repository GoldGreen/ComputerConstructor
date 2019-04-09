namespace ComputerConstructor
{
    public class VisualObject
    {
        public System.Drawing.Bitmap Picture;

        public System.Drawing.Rectangle Region;

        public System.Drawing.Point StartLocation;

        public (int X, int Y) Coordinate;

        public readonly int Width;

        public readonly int Height;


        /// <summary>
        /// Визуальная часть любого объекта состоит из:
        /// <param name="picture"> Картинка, </param>
        /// <param name="width"> Ширина, </param>
        /// <param name="height">Высота, </param>
        /// <param name="x">Координата X,</param>
        /// <param name="y">Координта Y.</param>
        /// </summary>
        public VisualObject(System.Drawing.Bitmap picture, int width, int height, int x, int y)
        {
            Picture = picture;
            Width = width;
            Height = height;

            Coordinate.X = x;
            Coordinate.Y = y;

            StartLocation = new System.Drawing.Point(Coordinate.X, Coordinate.Y);

            Region = new System.Drawing.Rectangle(Coordinate.X - (Width / 2), Coordinate.Y - (Height / 2), Width, Height);
        }

        /// <summary>
        /// Изменение Координат объекта.
        /// <param name="xNew"> Новая координата X.</param>
        /// <param name="yNew"> Новая координата Y.</param>
        /// </summary>
        public void ChangeXY(int xNew, int yNew)
        {
            if (!this.IsNull())
            {
                Region.Offset(xNew - Coordinate.X, yNew - Coordinate.Y);

                Coordinate.X = xNew;
                Coordinate.Y = yNew;
            }
        }

        public  void ChangeXY(System.Drawing.Point New)
        {
            if (!this.IsNull())
            {
                Region.Offset(New.X - Coordinate.X, New.Y - Coordinate.Y);

                Coordinate.X = New.X;
                Coordinate.Y = New.Y;
            }
        }

        public void Draw(System.Drawing.Graphics e)
        {
            if (!this.IsNull() && !Program.mainForm.IsNull())
                e.DrawImage(Picture, Region);
        }
    }
}
