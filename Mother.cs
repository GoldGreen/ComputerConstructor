namespace ComputerConstructor
{
    public class Mother
    {
        public class ElementOnPlate
        {
            public System.Drawing.Rectangle Region;
            public bool isUsed;
            public bool Show;

            public System.Drawing.Pen DefoltPen = new System.Drawing.Pen(System.Drawing.Color.Red, 5);

            public System.Drawing.Pen UnderPen = new System.Drawing.Pen(System.Drawing.Color.Blue, 5);

            public System.Drawing.Pen Pen;

            public ElementOnPlate(System.Drawing.Rectangle rectangle, bool isUsed, bool Show)
            {
                Region = rectangle;
                this.isUsed = isUsed;
                this.Show = Show;
                Pen = DefoltPen;
            }
        }

        public VisualObject Visual;

        public ElementOnPlate RAM1 = new ElementOnPlate(new System.Drawing.Rectangle(530, 102, 562 - 530, 393 - 102), false, false);

        public ElementOnPlate RAM2 = new ElementOnPlate(new System.Drawing.Rectangle(576, 102, 607 - 576, 393 - 102), false, false);

        public ElementOnPlate Video = new ElementOnPlate(new System.Drawing.Rectangle(206, 552, 496 - 206, 584 - 552), false, false);

        public ElementOnPlate Ventilation1 = new ElementOnPlate(new System.Drawing.Rectangle(208, 600, 112, 112), false, false);

        public ElementOnPlate Ventilation2 = new ElementOnPlate(new System.Drawing.Rectangle(437, 421, 112, 112), false, false);

        public ElementOnPlate Ventilation3 = new ElementOnPlate(new System.Drawing.Rectangle(293 + 14, 156 + 15, 112, 112), false, false);

        public ElementOnPlate BP = new ElementOnPlate(new System.Drawing.Rectangle(478, 218, 514 - 478, 392 - 218), false, false);

        public ElementOnPlate Hard = new ElementOnPlate(new System.Drawing.Rectangle(445, 604, 496 - 445, 698 - 604), false, false);

        public ElementOnPlate Proc = new ElementOnPlate(new System.Drawing.Rectangle(293, 156, 434 - 293, 300 - 156), false, false);

        public ElementOnPlate LineZone1 = new ElementOnPlate(new System.Drawing.Rectangle(207, 275, 39, 39), false, false);

        public ElementOnPlate LineZone2 = new ElementOnPlate(new System.Drawing.Rectangle(207, 484, 39, 39), false, false);

        public ElementOnPlate LineZone3 = new ElementOnPlate(new System.Drawing.Rectangle(567, 482, 39, 39), false, false);

        public ElementOnPlate[] All;

        public ElementOnPlate[] AllVentilation;

        public System.Drawing.Rectangle[] AllRectangle;

        public Mother()
        {
            All = new ElementOnPlate[]
            { RAM1, RAM2, Video, Ventilation1, Ventilation2, Ventilation3, BP, Hard, Proc,LineZone1,LineZone2,LineZone3 };

            AllRectangle = new System.Drawing.Rectangle[]
            {
                 RAM1.Region, RAM2.Region, Video.Region, Ventilation1.Region,
                Ventilation2.Region, Ventilation3.Region, BP.Region, Hard.Region, Proc.Region,
                LineZone1.Region,LineZone2.Region,LineZone3.Region
            };

            AllVentilation = new ElementOnPlate[]
            {
                LineZone1,
                LineZone2,
                LineZone3,
            };
        }

        public void InicializeVisual(System.Drawing.Bitmap picture, int width, int height, int x, int y)
        {
            Visual = new VisualObject(picture, width, height, x, y);
        }

        public ElementOnPlate[] GetAllComponent() => All;

        public System.Drawing.Rectangle[] GetAllComponentRectangle() => AllRectangle;

        public void HideAllComponents()
        {
            RAM1.Show = false;
            RAM2.Show = false;

            Video.Show = false;

            BP.Show = false;

            Hard.Show = false;
            Proc.Show = false;

            Ventilation1.Show = false;
            Ventilation2.Show = false;
            Ventilation3.Show = false;
        }

        public void HideLineZone()
        {
            LineZone1.Show = false;
            LineZone2.Show = false;
            LineZone3.Show = false;
        }
    }
}
