using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class aplusbb
{
    public static void BMain(string[] args)
    {
        var inputFile = new StreamReader(new System.IO.FileInfo("aplusbb.in").OpenRead()).ReadToEnd();
        using (var stream = new StreamWriter(new System.IO.FileInfo("aplusbb.out").OpenWrite()))
        {
            var numbers = inputFile.Split(' ');
            var b = long.Parse(numbers[1]);
            stream.Write(long.Parse(numbers[0]) + b * b);
            stream.Flush();
        }
    }
}
