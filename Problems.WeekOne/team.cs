using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class team
{
    public static bool swapped = false;
    public static int recursionCount = 0;
    public static int maxRecCount = 10;

    public static void Main(string[] args)
    {
        var inputStream = new StreamReader(new System.IO.FileInfo("team.in").OpenRead());

        var personOne = inputStream.ReadLine().Split(' ');
        var personTwo = inputStream.ReadLine().Split(' ');
        var personThree = inputStream.ReadLine().Split(' ');

        double output = 0f;

        var score = 0d;

        for (int i = 0; i < 3; i++)
        {
            var a = UInt16.Parse(personOne[i]);

            for (int j = 0; j < 3; j++)
            {
                var b = UInt16.Parse(personTwo[j]);

                if (j == i) {
                    continue;
                }

                for (int k = 0; k < 3; k++)
                {

                    if (k == j || k == i) {
                        continue;
                    }

                    var c = UInt16.Parse(personThree[k]);

                    var res = Math.Sqrt((a * a) + (b * b) + (c * c));

                    if (res > score) {
                        score = res;
                    }
                }
            }
        }

        output = score;

        using (var stream = new StreamWriter(new System.IO.FileInfo("team.out").OpenWrite()))
        {
            stream.Write(output);
            stream.Flush();
        }
    }
}