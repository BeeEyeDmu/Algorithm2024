using System;
using System.Collections.Generic;
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

namespace _002_factorial
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(txtData.Text);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            long rfact = rFactorial(n);
            lstBox.Items.Add("\nrecursive = " + rfact);
            
            watch.Stop();
            var elapsedTicks = watch.ElapsedTicks;
            string result = elapsedTicks + " Ticks, " +
                elapsedTicks / 10000.0 + " ms";
            lstBox.Items.Add(result);

            watch = System.Diagnostics.Stopwatch.StartNew();

            long fact = Factorial(n);
            lstBox.Items.Add("\nloop = " + fact);

            watch.Stop();
            elapsedTicks = watch.ElapsedTicks;
            result = elapsedTicks + " Ticks, " +
                elapsedTicks / 10000.0 + " ms";
            lstBox.Items.Add(result);
        }

        private long Factorial(int n)
        {
            long f = 1;
            for (int i = 2; i <= n; i++)
                f *= i;
            return f;
        }

        private long rFactorial(int n)
        {
            if (n == 1)
                return 1;
            else
                return rFactorial(n - 1) * n;
        }
    }
}
