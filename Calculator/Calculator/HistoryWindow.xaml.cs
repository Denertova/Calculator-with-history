using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Calculator.MainWindow;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        public HistoryWindow(List<Equation> eqHistory)
        {
            InitializeComponent();
            history.ItemsSource = eqHistory;
        }
    }
}
