using System.Collections.Generic;
using System.Linq;

namespace ComputerConstructor
{
    public class UserElementHaveLine : UserElementToPlate, IDrawLine
    {
        private readonly System.Drawing.Pen _pen;

        public List<System.Drawing.Point> PointsOfLine { get; }

        public bool StartDraw { get; set; } = false;

        public bool EndDraw { get; set; } = false;

        public UserElementHaveLine(int frequency = 0, int memory = 0)
            : base(frequency, memory)
        {
            _pen = new System.Drawing.Pen(System.Drawing.Color.SteelBlue, 8);

            PointsOfLine = new List<System.Drawing.Point>
            {
                default,
                default,
            };
        }

        public void LineFix()
        {
            PointsOfLine[0] = new System.Drawing.Point(Visual.Coordinate.X, Visual.Coordinate.Y);
        }

        public void Draw(System.Drawing.Graphics graphics)
        {
            for (int i = 0; i < PointsOfLine.Count - 1; i++)
            {
                graphics.DrawLine(_pen, PointsOfLine[i], PointsOfLine[i + 1]);
            }
        }
        
        public void SetLast(System.Drawing.Point point)
        {
            PointsOfLine[PointsOfLine.Count - 1] = point;
        }

        public void FixFirst()
        {
            PointsOfLine[0] = new System.Drawing.Point(Visual.Coordinate.X, Visual.Coordinate.Y);
        }

        public void AddPointToLine(System.Drawing.Point point)
        {
            var tmp = PointsOfLine.Last();
            PointsOfLine[PointsOfLine.Count - 1] = point;
            PointsOfLine.Add(tmp);
        }
    }
}
