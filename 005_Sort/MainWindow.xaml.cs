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

namespace _005_Sort
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        static int MAX = 1000000; // 백만
        int[] a = new int[MAX];
        int N = 0;      // 데이터 갯수

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            N = int.Parse(txtData.Text);
            Randomize();
            PrintData();

        }

        private void Randomize()
        {
            Random r = new Random();
            for (int i = 0; i < N; i++)
                a[i] = r.Next(3 * N);            
        }

        private void PrintData()
        {
            for(int i=0; i<N; i++)
            {
                txtResult.Text += a[i] + " ";
            }
            txtResult.Text += "\n";
        }

        private void btnTime_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            BubbleSort();
            watch.Stop();
            long tickBubble = watch.ElapsedTicks;
            long msBubble = watch.ElapsedMilliseconds;
            txtBubble.Text = "버블 정렬 : " + tickBubble + " Ticks, "
                + msBubble + " ms";

            Randomize();
            watch = System.Diagnostics.Stopwatch.StartNew();
            QuickSort();
            watch.Stop();
            long tickQuick = watch.ElapsedTicks;
            long msQuick = watch.ElapsedMilliseconds;
            txtBubble.Text = "퀵 정렬 : " + tickQuick + " Ticks, "
                + msQuick + " ms";

            Randomize();
            watch = System.Diagnostics.Stopwatch.StartNew();
            MergeSort();
            watch.Stop();
            long tickMerge = watch.ElapsedTicks;
            long msMerge = watch.ElapsedMilliseconds;
            txtBubble.Text = "합병 정렬 : " + tickMerge + " Ticks, "
                + msMerge + " ms";
        }

        private void MergeSort()
        {
            
        }

        private void QuickSort()
        {
            
        }

        private void BubbleSort()
        {
            for(int i=0; i<N; i++) 
                for(int j=0; j<i; j++)
                    if (a[i] < a[j])
                    {
                        int tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                    }
            PrintData();
        }
    }
}
