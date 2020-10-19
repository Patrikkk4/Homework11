using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Homework11
{
    class Collections
    {
        #region Коллекции

        // Коллекция заполнения ComboBox cmbDep
        public static List<string> dep { get; set; } = new List<string>() { "Департамент 1", "Департамент 2", "Департамент 3", "Департамент 4" };

        // Коллекция заполнения ComboBox cmbDivision
        public static List<string> division { get; set; } = new List<string>() { "Отдел 1", "Отдел 2", "Отдел 3", "Отдел 4" };

        // Коллекция, содержащая всех сотрудников
        public static ObservableCollection<Worker> allPositions { get; set; } = new ObservableCollection<Worker>();

        // // Коллекция, содержащая всех сотрудниковдиректоров
        public static ObservableCollection<Worker> dirCol { get; set; } = new ObservableCollection<Worker>();

        // Коллекция департаментов
        public static ObservableCollection<Worker> depCol;

        // Коллекция отделов
        public static ObservableCollection<Worker> divCol;

        #endregion
    }
}
