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
    Random r = new Random();

    public MainWindow()
    {
      InitializeComponent();
    }

    private void btnRandom_Click(object sender, RoutedEventArgs e)
    {
      txtResult.Text = "";
      N = int.Parse(txtData.Text);
      txtBubble.Text = "버블 정렬 : ";
      txtQuick.Text = "퀵 정렬 : ";
      txtMerge.Text = "합병 정렬 : ";
      Randomize();
      PrintData("랜덤 숫자");
    }

    private void Randomize()
    {      
      for (int i = 0; i < N; i++)
        a[i] = r.Next(5 * N);   // 데이터 갯수의 5배까지의 랜덤 숫자 생성
    }

    private void PrintData(string s)
    {
      txtResult.Text += "\n" + s + "\n";
      for (int i = 0; i < N; i++)
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
      PrintData("버블 정렬");
      long tickBubble = watch.ElapsedTicks;
      long msBubble = watch.ElapsedMilliseconds;
      txtBubble.Text = "버블 정렬 : " + tickBubble + " Ticks, "
          + msBubble + " ms";

      Randomize();
      watch = System.Diagnostics.Stopwatch.StartNew();
      QuickSort(a, 0, N-1);      
      watch.Stop();
      PrintData("퀵 정렬");
      long tickQuick = watch.ElapsedTicks;
      long msQuick = watch.ElapsedMilliseconds;
      txtQuick.Text = "퀵 정렬 : " + tickQuick + " Ticks, "
          + msQuick + " ms";

      Randomize();
      watch = System.Diagnostics.Stopwatch.StartNew();
      MergeSort(a, 0, N - 1);      
      watch.Stop();
      PrintData("합병 정렬");
      long tickMerge = watch.ElapsedTicks;
      long msMerge = watch.ElapsedMilliseconds;
      txtMerge.Text = "합병 정렬 : " + tickMerge + " Ticks, "
          + msMerge + " ms";
    }

    private void MergeSort(int[] a, int left, int right)
    {

    }

    private void QuickSort(int[] a, int left, int right)
    {
  
    }

    private void BubbleSort()
    {
    
    }
  }
}
