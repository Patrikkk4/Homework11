using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework11
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Главное окно

        public static MainWindow Self { get; set; }

        public MainWindow()
        {
            Self = this;

            InitializeComponent();

            if(File.Exists(@"saveAll.json"))
            {
                Methods.LoadFile();
            }
        }

        #endregion

        #region События

        /// <summary>
        /// Событие нажатия кнопки "Показать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            Methods.ShowWorkers();
        }

        /// <summary>
        /// Событие нажатия кнопки "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Methods.AddWorker();      
        }

        private void txbPosition_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            txbPosition.Text = txbPosition.Text.ToLower();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Methods.SaveCollection();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Methods.LoadFile();
        }

        #endregion
    }
}
