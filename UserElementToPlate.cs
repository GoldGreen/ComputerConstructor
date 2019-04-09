using System.Collections.Generic;
using System.Linq;

namespace ComputerConstructor
{
    public class UserElementToPlate
    {
        /// <summary>
        /// Счетчик для изменения внешнего вида и параметров объекта.
        /// </summary>
        protected int _i;

        /// <summary>
        /// Визуальная часть объекта содержащая картинку, область,
        /// высоту, ширину, координаты.
        /// </summary>
        public VisualObject Visual { get; private set; }

        /// <summary>
        /// Объект тащат?
        /// </summary>
        public bool FlagClick { get; set; } = false;

        /// <summary>
        /// Объект используется?
        /// </summary>
        public bool IsUsed { get; set; } = false;

        /// <summary>
        /// Парамаетры которые зависят от картинки, логичней делать наоборот,
        /// но с недавнего времени я боюсь кортежей.
        /// </summary>
        private Dictionary<System.Drawing.Bitmap, (object frequency, object memory, string name)> _parametrs;

        public (object frequency, object memory, string name) parametr;

        /// <summary>
        /// Просто дать значение частоты и памяти для элемента.
        /// </summary>
        /// <param name="frequency"></param>
        /// <param name="memory"></param>
        public UserElementToPlate(object frequency = null, object memory = null, string name = null)
        {
            parametr = (frequency, memory, name);
        }

        /// <summary>
        /// Инициализация визуальной части объекта - без нее все будет работать,
        /// но без смысла,так как это визуально взаимодествующая программа.
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void InicializeVisual(System.Drawing.Bitmap picture, int width, int height, int x, int y)
        {
            Visual = new VisualObject(picture, width, height, x, y);

            _parametrs = new Dictionary<System.Drawing.Bitmap, (object frequency, object memory,string name)>
            {
                { picture, parametr}
            };

            _i = 0;
        }

        /// <summary>
        /// Добавить новый тип для элемента. Только этой функцией.
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="frequency"></param>
        /// <param name="memory"></param>
        public void AddNewType(System.Drawing.Bitmap picture, object frequency, object memory, string name)
        {
            if (!Visual.IsNull())
            {
                _parametrs.Add(picture, (frequency, memory, name));
            }
        }

        /// <summary>
        /// Взять следующий элемент из листа параметров с картинкой
        /// и применить его. Если достигнут конец, взять первый - и так по кругу.
        /// </summary>
        public void Aply()
        {
            parametr = _parametrs[_parametrs.ElementAt(++_i % _parametrs.Count).Key];
            Visual.Picture = _parametrs.ElementAt(_i % _parametrs.Count).Key;
        }
    }
}
