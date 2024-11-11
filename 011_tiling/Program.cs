using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011_tiling
{
  internal class Program
  {
    static int[] a = new int[100];
    static void Main(string[] args)
    {
      // 1부터 30까지 2xn Tile 경우의수
      for(int i=1; i<=30; i++)
      {
        Console.WriteLine(i + " : " + Tile(i));
      }

      for (int i = 0; i < a.Length; i++)
        a[i] = 0;

      // 1부터 30까지 2xn Tile 경우의 수(Tile2)
      for (int i = 1; i <= 30; i++)
      {
        Console.WriteLine(i + " : " + Tile2(i));
      }

      for (int i = 0; i < a.Length; i++)
        a[i] = 0;

      // 1부터 30까지 3xn Tile 경우의 수(Tile3)
      for (int i = 1; i <= 30; i++)
      {
        Console.WriteLine("Tile3({0}) : {1}", i, Tile3(i));
      }
    }

    // 2xn 타일링 문제    
    private static int Tile(int i)
    {
      if (i == 1)
        return 1;
      else if (i == 2)
        return 2;
      else if (a[i] != 0)
        return a[i];
      else
        return a[i] = Tile(i - 1) + Tile(i - 2);
    }

    // 두번째 2xn 타일링 문제(타일의 종류가 3가지)
    private static int Tile2(int i)
    {
      if (i == 1)
        return 1;
      else if (i == 2)
        return 3;
      else if (a[i] != 0)
        return a[i];
      else
        return a[i] = Tile2(i - 1) + 2*Tile2(i - 2);
    }


    // 세번째 3xn 타일링 문제(타일의 종류가 3가지)
    private static int Tile3(int n)
    {
      if (n % 2 == 1)
        return 0;
      else if (n == 0)
        return 1;
      else if (n == 2)
        return 3;

      if (a[n] != 0)
        return a[n];  // 이미 계산된 결과를 사용(Dynamic Programming)

      //Tile(n) = 3*Tile(n-2)+2*(Tile(n-4) + Tile(n-6) + … + Tile(0))
      int x = 3 * Tile3(n - 2);
      for (int i = n - 4; i >= 0; i -= 2)
        x += 2 * Tile3(i);
     
      return a[n] = x;
    }
  }
}
