using System.Collections.Generic;

namespace ComputerConstructor
{
    public interface IDrawLine
    {
        VisualObject Visual { get; }

        List<System.Drawing.Point> PointsOfLine { get; }

        bool StartDraw { get; set; }

        bool EndDraw { get; set; }

        bool IsUsed { get; set; }

        void SetLast(System.Drawing.Point point);

        void Draw(System.Drawing.Graphics graphics);

        void FixFirst();
    }
}
