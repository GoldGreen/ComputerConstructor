using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ComputerConstructor
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Гланый элемент формы.
        /// </summary>
        public Mother Mother;

        /// <summary>
        /// Элемент, которым управляет пользователь - Оперативная память.
        /// </summary>
        public UserElementToPlate RAM1;

        /// <summary>
        /// Элемент, которым управляет пользователь - Оперативная память.
        /// </summary>
        public UserElementToPlate RAM2;

        /// <summary>
        /// Элемент, которым управляет пользователь - Процессор.
        /// </summary>
        public UserElementToPlate Proc1;

        /// <summary>
        /// Элемент, которым управляет пользователь - Видеокарта.
        /// </summary>
        public UserElementToPlate Video;

        public UserElementHaveLine Ventilation1;

        public UserElementHaveLine Ventilation2;

        public UserElementHaveLine Ventilation3;

        /// <summary>
        /// Лист элементов, управляемых пользователем.
        /// </summary>
        public List<(UserElementToPlate Element, Action Doing)> UserElements;

        public List<(IDrawLine Element, Action Doing)> ElementsWithLine;

        //public List<UserElementToPlate> UsedVentilation;

        public MainForm()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer
                   | ControlStyles.AllPaintingInWmPaint
                   | ControlStyles.UserPaint, true);

            UpdateStyles();

            InitializeComponent();
        }

        private void Initialize()
        {
            Mother = new Mother();

            RAM1 = new UserElementToPlate("1800 МГц", "8 Гб", "HyperX");
            RAM2 = new UserElementToPlate("1800 МГц", "8 Гб", "HyperX");
            Proc1 = new UserElementToPlate("3.6 * 8 Ггц", "8 Мб L3", "Ryzen 7");
            Video = new UserElementToPlate("1480 МГц", "11 Гб", "GTX 1080 Ti");

            Ventilation1 = new UserElementHaveLine();
            Ventilation2 = new UserElementHaveLine();
            Ventilation3 = new UserElementHaveLine();

            Ventilation1.InicializeVisual(new Bitmap("Pictures\\Ventilation.png"),
                112, 112, 1008, 161);

            Ventilation2.InicializeVisual(new Bitmap("Pictures\\Ventilation.png"),
                112, 112, 1008, 161 + 116);

            Ventilation3.InicializeVisual(new Bitmap("Pictures\\Ventilation.png"),
                112, 112, 1008, 161 + 116 + 116);

            RAM1.InicializeVisual(new Bitmap( "Pictures\\HyperXJoveLoh.png"),
                45, 291, 1100, 250);

            RAM2.InicializeVisual(new Bitmap("Pictures\\HyperXJoveLoh.png"),
               45, 291, 1200, 250);

            Proc1.InicializeVisual(new Bitmap("Pictures\\Ryzen7.png"),
               130, 130, 1150, 500);

            Video.InicializeVisual(new Bitmap("Pictures\\Gtx1080Ti.png"),
                290, 34, 1100, 650);

            Mother.InicializeVisual(new Bitmap("Pictures\\MotherModern.png"),
                650, 650, 400, 400);

            Proc1.AddNewType(new Bitmap("Pictures\\GyperPen.png"), "3.5 * 2ГГц", "3 Мб L3", "G4560 Лучший в мире процессор");

            RAM1.AddNewType(new Bitmap("Pictures\\Pirat.png"), "2400 МГц", "16 Гб", "Corsair");

            RAM2.AddNewType(new Bitmap("Pictures\\Pirat.png"), "2400 МГц", "16 Гб", "Corsair");

            Video.AddNewType(new Bitmap("Pictures\\TitanX.png"), "1000 МГц", "12 Гб", "TitanX");

            UserElements = new List<(UserElementToPlate, Action)>
            {
                (Proc1, ()=> { Mother.Proc.Show  = true;  Proc1.FlagClick  = true; }),

                (Ventilation1, ()=>
                {
                    if (Mother.Proc.isUsed)
                        Mother.Ventilation3.Show = true;

                        Mother.Ventilation1.Show=true;
                        Mother.Ventilation2.Show= true;
                        Ventilation1.FlagClick  = true;
                }),

                (Ventilation2, ()=>
                {
                    if (Mother.Proc.isUsed)
                        Mother.Ventilation3.Show = true;

                        Mother.Ventilation1.Show=true;
                        Mother.Ventilation2.Show= true;
                        Ventilation2.FlagClick  = true;
                }),

                (Ventilation3, ()=>
                {
                    if (Mother.Proc.isUsed)
                        Mother.Ventilation3.Show = true;

                        Mother.Ventilation1.Show=true;
                        Mother.Ventilation2.Show= true;
                        Ventilation3.FlagClick  = true;
                }),

                (RAM1,  ()=>
                {
                    Mother.RAM1.Show  = true;
                    Mother.RAM2.Show = true;
                    RAM1.FlagClick = true;
                }),

                (RAM2,  ()=>
                {
                    Mother.RAM1.Show  = true;
                    Mother.RAM2.Show = true;
                    RAM2.FlagClick = true;
                }),

                (Video, ()=>
                {
                    Mother.Video.Show = true;
                    Video.FlagClick  = true;
                }),
            };

            ElementsWithLine = new List<(IDrawLine Element, Action Doing)>
            {
                (Ventilation1, ()=>
                {
                    Mother.LineZone1.Show = true;
                    Mother.LineZone2.Show = true;
                    Mother.LineZone3.Show = true;
                }),

                (Ventilation2, ()=>
                {
                    Mother.LineZone1.Show = true;
                    Mother.LineZone2.Show = true;
                    Mother.LineZone3.Show = true;
                }),

                (Ventilation3, ()=>
                {
                    Mother.LineZone1.Show = true;
                    Mother.LineZone2.Show = true;
                    Mother.LineZone3.Show = true;
                }),
            };

        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            //Рисуем мат плату.
            Mother?.Visual?.Draw(e.Graphics);


            if (!UserElements.IsNull())
            {
                foreach (var (Element, Doing) in UserElements.Where(x => !x.Element.IsNull()))
                {

                    Element.Visual.Draw(e.Graphics);

                }
            }

            //Отрисовка всех неиспользованных регионов у мат платы.(Rectangle).
            if (!Mother.IsNull() && !Mother.All.IsNull())
            {
                foreach (var i in Mother.All.Where(i => i.Show && !i.isUsed))
                {
                    i.Region.DrawRec(e.Graphics, i.Pen);
                }
            }

            if (!ElementsWithLine.IsNull())
            {
                foreach (var i in ElementsWithLine)
                {
                    if (i.Element.StartDraw)
                    {
                        i.Element.SetLast(FunctionsBGD.GetCursorCoordinatePoint());
                        i.Element.Draw(e.Graphics);
                    }
                    else if (i.Element.EndDraw)
                    {
                        i.Element.Draw(e.Graphics);
                    }
                }

            }
        }

        private void MainRefresh_Tick(object sender, EventArgs e)
        {
            //Если какой-то элемент, управляемый пользователем существует
            //и у элемента есть FlagClick то идёт его изменение координат на курсор.
            if (!UserElements.IsNull() && UserElements.Count(x => x.Element.FlagClick) != 0)
            {
                for (int i = 0; i < UserElements.Count; i++)
                {
                    //Чтобы изменить цвет регионов когда над ними соотвествующий элемент.
                    foreach (var j in Mother.All.Where(j => !j.IsNull()))
                    {
                        if (!UserElements[i].Element.IsUsed
                            && UserElements[i].Element.Visual.Region.Contains(FunctionsBGD.GetCursorCoordinatePoint())
                            && j.Region.Contains(FunctionsBGD.GetCursorCoordinatePoint()))
                        {
                            j.Pen = j.UnderPen;
                        }
                        else
                        {
                            j.Pen = j.DefoltPen;
                        }
                    }

                    if (!UserElements[i].Element.IsNull() && UserElements[i].Element.FlagClick)
                    {
                        UserElements[i].Element.Visual.ChangeXY(FunctionsBGD.GetCursorCoordinatePoint());
                        break;
                    }
                }
            }
            if (!Mother.IsNull())
            {
                foreach (var l in Mother.AllVentilation.Where(x => x.Show))
                {
                    if (l.Region.Contains(FunctionsBGD.GetCursorCoordinatePoint()))
                    {
                        l.Pen = l.UnderPen;
                    }
                    else
                    {
                        l.Pen = l.DefoltPen;
                    }
                }
            }
            Refresh();
        }

        /// <summary>
        /// Начало программы, её перезапуск.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtStartProgram_Click(object sender, EventArgs e)
        {
            Initialize();
            btStartProgram.Text = "Refresh";
            Refresh();
            this.Focus();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Text = FunctionsBGD.GetCursorCoordinatePoint().ToString();



            if (!UserElements.IsNull() && (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left))
            {
                //Если нажимается правая кнопка на элемент пользователя, который не используется,
                //то элемент сменит модель, если она есть, и соответствующие модели параметры.
                if (e.Button == MouseButtons.Right)
                {
                    foreach (var (Element, Doing) in UserElements.Where(i => !i.Element.IsNull() && !i.Element.Visual.IsNull()
                    && !i.Element.FlagClick && !i.Element.IsUsed
                    && i.Element.Visual.Region.Contains(FunctionsBGD.GetCursorCoordinatePoint())))
                    {
                        Element.Aply();
                        MessageBox.Show(Element.parametr.ToString());
                    }
                }
                //Для всех элементов у которых возможна линия, если кликнута кнопка над зоной в которую можно закрепить
                //линию то она будет закреплена.
                foreach (var i in ElementsWithLine.Where(x => x.Element.IsUsed && !x.Element.EndDraw))
                {
                    if (i.Element.StartDraw)
                    {
                        foreach (var j in Mother.AllVentilation.Where(x => !x.isUsed))
                        {
                            if (j.Region.Contains(FunctionsBGD.GetCursorCoordinatePoint()))
                            {
                                i.Element.EndDraw = true;
                                i.Element.SetLast(new Point(j.Region.Location.X + (j.Region.Width / 2),
                                                            j.Region.Location.Y + (j.Region.Height / 2)));
                                j.isUsed = true;
                                break;
                            }
                            else
                            {
                                i.Element.EndDraw = false;
                            }
                        }
                    }

                    //Момент когда линия только только появится.
                    if (i.Element.Visual.Region.Contains(FunctionsBGD.GetCursorCoordinatePoint()))
                    {
                        i.Doing();
                        i.Element.FixFirst();
                        i.Element.StartDraw = true;
                    }

                    //Скрыть линию, а если ничто не используется всё скрыть!
                    else
                    {
                        i.Element.StartDraw = false;

                        if (ElementsWithLine.Count(x => !x.Element.StartDraw) == ElementsWithLine.Count)
                        {
                            Mother.HideLineZone();
                        }
                    }
                }

            }
        }

        //Место захвата пользователем элементов.
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !UserElements.IsNull())
            {
                foreach (var i in UserElements.Where(x => !x.Element.Visual.IsNull()
               && x.Element.Visual.Region.Contains(FunctionsBGD.GetCursorCoordinatePoint())
               && !x.Element.IsUsed
                ))
                {
                    i.Doing();
                }
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            //Идёт проход по всем элементам, которымы может управлять пользователь и которые есть на плате.
            //Если пользовательский элемент помещается в зону соответствующего элемента на плате,
            //то оба элемента помечаются как  задействованные и двигать текущий пользовательский элемент нельзя.
            //Свободная зона для вставки пользовательского элемента перестает подсвечиваться.
            if (!Mother.IsNull() && e.Button == MouseButtons.Left)
            {
                var AllComponetsOnMother = Mother.GetAllComponent();

                for (int i = 0; i < UserElements.Count; i++)
                {
                    if (!UserElements[i].Element.IsNull() && UserElements[i].Element.FlagClick)
                    {
                        UserElements[i].Element.FlagClick = false;

                        for (int j = 0; j < AllComponetsOnMother.Length; j++)
                        {
                            if (UserElements[i].Element.Visual.Region.IntersectsWith(AllComponetsOnMother[j].Region)
                                && !AllComponetsOnMother[j].isUsed
                                && AllComponetsOnMother[j].Region.Contains(FunctionsBGD.GetCursorCoordinatePoint())
                                && AllComponetsOnMother[j].Show)
                            {
                                //Все объекты классов в моём понимаю работают через координату в центре объекта,
                                //так просто удобнее, но области на Мат плате через левый верхний угол,
                                //поэтому стоит прибавлять половину ширины и половину высоты к координате области.
                                UserElements[i].Element.Visual.ChangeXY
                                    (AllComponetsOnMother[j].Region.Location.X + (AllComponetsOnMother[j].Region.Width / 2),
                                     AllComponetsOnMother[j].Region.Location.Y + (AllComponetsOnMother[j].Region.Height / 2));

                                UserElements[i].Element.IsUsed = true;
                                AllComponetsOnMother[j].isUsed = true;

                                break;
                            }
                        }

                        if (!UserElements[i].Element.IsUsed)
                        {
                            UserElements[i].Element.Visual.ChangeXY(UserElements[i].Element.Visual.StartLocation.X,
                                                                    UserElements[i].Element.Visual.StartLocation.Y);
                        }
                    }
                }

                //После одпускания кнопки мыши все светящиеся зоны исчезают.
                if (!Mother.IsNull())
                {
                    Mother.HideAllComponents();
                }
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Mother.IsNull() && !Mother.Visual.Region.Contains(e.Location))
            {
                foreach (var i in ElementsWithLine.Where(x => !x.Element.EndDraw))
                {
                    i.Element.StartDraw = false;
                }

                Mother.HideLineZone();
            }
        }

        private void CheckEnd_Tick(object sender, EventArgs e)
        {
            if (!Mother.IsNull() && !UserElements.IsNull() && UserElements.Count(x => !x.Element.IsUsed) == 0
                && ElementsWithLine.Count(x => !x.Element.EndDraw) == 0)
            {
                btnComp.Show();
            }
            else
            {
                btnComp.Hide();
            }
        }

        private void btnComp_Click(object sender, EventArgs e)
        {
            int Freq = (int.Parse(RAM1.parametr.frequency.ToString().Split(' ')[0]) + int.Parse(RAM2.parametr.frequency.ToString().Split(' ')[0])) / 2;
            string FreqRam = Freq + " * 2 МГц";

            int Memory = int.Parse(RAM1.parametr.memory.ToString().Split(' ')[0]) + int.Parse(RAM2.parametr.memory.ToString().Split(' ')[0]);
            string MemoryRam = Memory + " Гб";

            string namesRam = RAM1.parametr.name == RAM2.parametr.name ? RAM2.parametr.name + "* 2" : $"{ RAM1.parametr.name} {RAM2.parametr.name}";

            string tmp = $"Процессор - {Proc1.parametr}\n Видеокарта - {Video.parametr}\n Оперативная память - {Tuple.Create(FreqRam, MemoryRam, namesRam)}";

            MessageBox.Show(tmp);
        }
    }
}
