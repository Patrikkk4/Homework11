using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Homework11
{
    class Methods
    {
        #region Методы

        /// <summary>
        /// Метод добавления нового работника
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Worker> AddWorker()
        {
            // Условие добавления директора
            if (MainWindow.Self.txbPosition.Text.Contains("директор"))
            {
                try
                {
                    // Заполнение конструктора добавления директора
                    Director addDirector = new Director(MainWindow.Self.txbName.Text,
                        MainWindow.Self.cmbDep.Text,
                        MainWindow.Self.txbPosition.Text);

                    // Добавление в коллекцию нового директора
                    Collections.allPositions.Add(addDirector);
                }
                catch
                {
                    MessageBox.Show("Проверьте корректность заполнения необходимых полей");
                }

                return Collections.dirCol;
            }
            // Условие добавления стажера
            else if (MainWindow.Self.txbPosition.Text.Contains("стажер") || MainWindow.Self.txbPosition.Text.Contains("интерн"))
            {
                try
                {
                    Intern intern = new Intern(MainWindow.Self.txbName.Text,
                        MainWindow.Self.cmbDep.Text,
                            MainWindow.Self.cmbDivision.Text,
                            MainWindow.Self.txbPosition.Text,
                            0, 0);

                    // Добавление в коллекцию нового сотрудника
                    Collections.allPositions.Add(intern);
                }
                catch
                {
                    MessageBox.Show("Проверьте корректность заполнения необходимых полей");
                }

                return Collections.allPositions;
            }
            // Условие добавления сотрудника
            else
            {
                try
                {
                    // Заполнение конструктора добавления сотрудника
                    Employee addEmploee = new Employee(MainWindow.Self.txbName.Text,
                        MainWindow.Self.cmbDep.Text,
                            MainWindow.Self.cmbDivision.Text,
                            MainWindow.Self.txbPosition.Text,
                            Int32.Parse(MainWindow.Self.txbWorkHour.Text), double.Parse(MainWindow.Self.txbWorkDays.Text));

                    // Добавление в коллекцию нового сотрудника
                    Collections.allPositions.Add(addEmploee);
                }
                catch
                {
                    MessageBox.Show("Проверьте корректность заполнения необходимых полей");
                }

                return Collections.allPositions;
            }
        }

        /// <summary>
        /// Метод извлечения из общей коллекции необходимого департамента
        /// </summary>
        /// <returns></returns>
        static ObservableCollection<Worker> OutputWorkers()
        {
            // Извлечение департамента соответственно выбору cmbDepShow
            Collections.depCol = new ObservableCollection<Worker>
                (
                from p in Collections.allPositions where p.Dep == MainWindow.Self.cmbDepShow.SelectedItem.ToString() select p
                );

            // Извлечение отдела соответственно выбору cmbDivisionShow
            Collections.divCol = new ObservableCollection<Worker>
                (
                from p in Collections.depCol where p.Division == MainWindow.Self.cmbDivisionShow.SelectedItem.ToString() select p
                );

            Collections.dirCol = new ObservableCollection<Worker>
                (
                from p in Collections.allPositions where p.Position == "директор" select p
                );
            return Collections.divCol;
        }

        /// <summary>
        /// Метод вывода добавленных работников в таблицу
        /// </summary>
        public static void ShowWorkers()
        {
            try
            {
                // Источник вывода работников в таблицу DataGrid allDepWorkers
                MainWindow.Self.allDepWorkers.ItemsSource = OutputWorkers();

                // Источник вывода директора
                MainWindow.Self.txtDirector.Text = Collections.dirCol.Where(x => x.Dep == MainWindow.Self.cmbDepShow.SelectedItem.ToString()).First().Position + 
                    " " + MainWindow.Self.cmbDepShow.SelectedItem.ToString();

                Director director = new Director();

                // Источник вывода зарплаты директора
                MainWindow.Self.txtDirectorSalary.Text = director.SalaryCalculation(0).ToString() + "$";

                // Вывод имени директора департамента
                MainWindow.Self.txtDirectorName.Text = Collections.dirCol.First().Name;
            }
            catch
            {
                MainWindow.Self.txtDirector.Text = "Директор не назначен";
            }
        }

        /// <summary>
        /// Метод сохранения всех работников в Json
        /// </summary>
        public static void SaveCollection()
        {
            // Сериализация в файл json
            string json = JsonConvert.SerializeObject(Collections.allPositions);

            // Запись в файл по выбранному пути
            File.WriteAllText(@"saveAll.json", json);
        }

        // Загрузка из файла Json
        public static void LoadFile()
        {
            if (File.Exists(@"saveAll.json"))
            {
                // Инициализация считывания json файла
                string loadJson = File.ReadAllText(@"saveAll.json");

                // Заполненение временной коллекции из файла json
                var temp = JsonConvert.DeserializeObject<ObservableCollection<HelpClass>>(loadJson);

                foreach (var t in temp)
                {
                    Collections.allPositions.Add(t);
                }
            }
            else 
            { 
                MessageBox.Show("Файл отсутствует"); 
            }
        }

        #endregion
    }
}
