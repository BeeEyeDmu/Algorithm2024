using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014_Sorting
{
  internal class Program
  {
    static int N = 100;
    static int[] a = new int[N];
    static void Main(string[] args)
    {
      RandomInit();
      PrintArray();

      Console.WriteLine("\nArray.Sort()");
      RandomInit();
      Array.Sort(a);
      PrintArray();

      // 버블정렬
      RandomInit();
      BubbleSort();
      PrintArray();

      // 선택정렬
      RandomInit();
      SelectionSort();
      PrintArray();

      // 삽입정렬
      RandomInit();
      InsertionSort();
      PrintArray();

      // 쉘정렬
      RandomInit();
      ShellSort();
      PrintArray();

      // 힙정렬
      RandomInit();
      HeapSort();
      PrintArray();

      // 기수정렬
      RandomInit();
      RadixSort();
      PrintArray();
    }

    private static void RadixSort()
    {
      Console.WriteLine("\nRadixSort");

      int max = GetMax();

      // 자리수에 따라 CountingSort() 호출
      for (int exp = 1; max / exp > 0; exp *= 10)
        CountingSort(a, exp);

    }

    private static void CountingSort(int[] a, int exp)
    {
      int[] count = new int[10];
      int[] output = new int[N];

      for (int i = 0; i < N; i++)
        count[(a[i] / exp) % 10]++;

      // count[]의 누적 계산
      for (int i = 1; i < 10; i++)
        count[i] += count[i - 1];

      // a[]을 뒤에서부터 해당 자리수를 count[] 위치에 저장
      for(int i=N-1; i>=0; i--)
      {
        int pos = count[(a[i] / exp) % 10] - 1;
        output[pos] = a[i];
        count[(a[i] / exp) % 10]--;
      }

      // output[]을 a[]로 복사
      for (int i = 0; i < N; i++)
        a[i] = output[i];
    }

    private static int GetMax()
    {
      int max = a[0];

      for (int i = 1; i < N; i++)
      {
        if (a[i] > max)
          max = a[i];
      }
      return max;
    }

    private static void HeapSort()
    {
      Console.WriteLine("\nHeapSort");

      // 힙 자료구조를 만든다
      for (int i = N / 2 - 1; i >= 0; i--)
        DownHeap(a, N, i);

      // 정렬
      for(int i=N-1; i>=0; i--)
      {
        swap(0, i);
        DownHeap(a, i, 0);  // i개의 원소를 갖는 배열 a[]에서
                            // 0번 노드에서 downheap
      } 
    }

    // n개의 값을 가진 배열 a[]에서 i번째 노드에서 다운힙한다
    private static void DownHeap(int[] a, int n, int i)
    {
      int largest = i;
      int left = 2 * i + 1; // 0에서 시작하는 배열 인덱스 경우
      int right = 2 * i + 2;

      if(left < n && a[left] > a[largest])
        largest = left;
      if (right < n && a[right] > a[largest])
        largest = right;

      if(largest != i)
      {
        swap(i, largest);
        DownHeap(a, n, largest);
      }

    }

    private static void ShellSort()
    {
      Console.WriteLine("\n쉘정렬 :");
      int[] h = { 0, 1, 4, 10, 23, 57, 132, 201, 701, 1750 };
      int index = 0;
      while (h[index] < N / 2)
        index++;
      int gap = h[--index];

      while(gap > 0)
      {
        Console.WriteLine("gap = " + gap);
        for(int i=gap; i<N; i++)
        {
          int current = a[i];
          int j = i;
          while(j>=gap && a[j-gap] > current)
          {
            a[j] = a[j - gap];
            j = j - gap;
          }
          a[j] = current;
        }
        PrintArray();
        gap = h[--index];
      }
    }

    private static void InsertionSort()
    {
      Console.WriteLine("\n삽입정렬");
      for (int i=1; i<=N-1; i++)
      {
        int current = a[i];
        int j = i - 1;
        while(j >= 0 && a[j] > current)
        {
          a[j + 1] = a[j];
          j--;
        }
        a[j + 1] = current;
      }
    }

    private static void SelectionSort()
    {
      Console.WriteLine("\n선택정렬 :");
      for(int i=0; i<N-1; i++)
      {
        int min = i;
        for(int j=i+1; j<N; j++)
          if(a[j] < a[min])
            min = j;
        swap(i, min);
      }
    }

    private static void BubbleSort()
    {
      Console.WriteLine("\n버블정렬: ");

      //for (int pass = 1; pass <= N - 1; pass++)
      //  for (int i = 1; i <= N - pass; i++)
      //    if (a[i - 1] > a[i])
      //      swap(i - 1, i);

      for (int i = 1; i <= N - 1; i++)
        for (int j = 1; j <= N - i; j++)
          if (a[j - 1] > a[j])
            swap(j - 1, j);
    }

    private static void swap(int i, int j)
    {
      int t = a[i];
      a[i] = a[j];
      a[j] = t;
    }

    private static void PrintArray()
    {
      foreach (var i in a)
      {
        Console.Write(i + " ");
      }
      Console.WriteLine();
    }

    private static void RandomInit()
    {
      Random r = new Random();
      for(int i=0; i<N; i++)
      {
        a[i] = r.Next(1000);
      }
    }
  }
}
