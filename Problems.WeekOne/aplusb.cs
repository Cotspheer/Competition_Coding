using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class aplusb
{
    public static void BMain(string[] args)
    {
        var inputFile = new StreamReader(new System.IO.FileInfo("aplusb.in").OpenRead()).ReadToEnd();
        using (var stream = new StreamWriter(new System.IO.FileInfo("aplusb.out").OpenWrite()))
        {
            var numbers = inputFile.Split(' ');
            stream.Write(int.Parse(numbers[0]) + int.Parse(numbers[1]));
            stream.Flush();
        }
    }
}
