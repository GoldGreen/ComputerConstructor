namespace ComputerConstructor
{
    public static class FunctionsBGD
    {
        public static bool IsNull<T>(this T self)
            where T : class => self == null;

        /// <summary>
        /// Возвращает координату курсора, как кортеж.
        /// </summary>
        /// <returns></returns>
        public static (int x, int y) GetCursorCoordinate()
            => (Program.mainForm.PointToClient(System.Windows.Forms.Cursor.Position).X,
                Program.mainForm.PointToClient(System.Windows.Forms.Cursor.Position).Y);

        /// <summary>
        /// Возвращает коориднату курсора, как System.Drawing.Point.
        /// </summary>
        /// <returns></returns>
        public static System.Drawing.Point GetCursorCoordinatePoint()
            => Program.mainForm.PointToClient(System.Windows.Forms.Cursor.Position);

        /// <summary>
        /// Рисует все Элементы массива типа ElementOnPlate.
        /// </summary>
        /// <param name="Element"></param>
        /// <param name="graphics"></param>
        public static void DrawRec(this System.Drawing.Rectangle region, System.Drawing.Graphics graphics, System.Drawing.Pen pen)
        {
            {
                graphics.DrawRectangle(pen, region);
            }
        }

        public static bool InRectangles(this System.Drawing.Point point, params System.Drawing.Rectangle[] rectangles)
        {
            bool tmp = false;

            foreach (var i in rectangles)
            {
                if (i.Contains(point))
                {
                    tmp = true;
                }
            }

            return tmp;
        }

    }
}
