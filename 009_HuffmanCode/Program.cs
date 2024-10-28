using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_HuffmanCode
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string input = "Yesterday all my troubles seemed so far away. Now it looks as though they're here to stay. Oh, I believe in yesterday. Suddenly I'm not half the man I used to be. There's a shadow hanging over me. Oh, yesterday came suddenly. Why she had to go, I don't know, she wouldn't say. I said something wrong, now I long for yesterday. Yesterday love was such an easy game to play. Now I need a place to hide away. Oh, I believe in yesterday. Why she had to go, I don't know, she wouldn't say. I said something wrong, now I long for yesterday. Yesterday love was such an easy game to play. Now I need a place to hide away. Oh, I believe in yesterday.  Mm mm mm mm mm mm mm";

      HuffmanTree hTree = new HuffmanTree();

      hTree.Build(input);

      BitArray encoded = hTree.Encode(input);

      Console.Write("Encoded : ");
      foreach(bool bit in encoded) 
        Console.Write((bit ? 1 : 0));  // 조건연산자
      Console.WriteLine();

      // Decode

    }
  }
}
