using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11
{
    /// <summary>
    /// Вспомогательный класс для загрузки информации из файла json
    /// </summary>
    class HelpClass : Worker
    {

        public HelpClass(string Name, string Dep, string Division, string Position, double WorkHour, double WorkDays) 
            : base(Name, Dep, Division, Position, WorkHour, WorkDays)
        {           
        }
    }
}
