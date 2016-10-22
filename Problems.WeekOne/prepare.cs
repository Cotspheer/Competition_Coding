using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class prepare
{
    public static void BMain(string[] args)
    {
        var inputStream = new StreamReader(new System.IO.FileInfo("prepare.in").OpenRead());
        var days = byte.Parse(inputStream.ReadLine());
        var practic = inputStream.ReadLine().Split(' ');
        var theory = inputStream.ReadLine().Split(' ');
        var output = 0;

        var hasPractice = false;
        var hasTheory = false;

        int[][] points = new int[days][];

        for (int i = 0; i < days; i++)
        {
            var p = UInt16.Parse(practic[i]);
            var t = UInt16.Parse(theory[i]);

            points[i] = new int[] { p, t };
        }

        for (int i = 0; i < days; i++)
        {
            var p = points[i][0];
            var t = points[i][1];

            if (p == t) {
                output += p;

                hasPractice = true;
                hasTheory = true;

                continue;
            }

            if (p > t) {
                output += p;
                hasPractice = true;

                continue;
            }

            output += t;
            hasTheory = true;
        }

        if (!hasTheory) {
            var optimalPointp = points[0][0];
            var optimalPointt = points[0][1];

            for (int i = 0; i < days; i++)
            {
                var p = points[i][0];
                var t = points[i][1];

                if (t >= optimalPointt && p <= optimalPointp) {
                    optimalPointp = p;
                    optimalPointt = t;
                }
            }

            output -= optimalPointp;
            output += optimalPointt;
        }

        if (!hasPractice)
        {
            var optimalPointp = points[0][0];
            var optimalPointt = points[0][1];

            for (int i = 0; i < days; i++)
            {
                var p = points[i][0];
                var t = points[i][1];

                if (p >= optimalPointp && t <= optimalPointt)
                {
                    optimalPointp = p;
                    optimalPointt = t;
                }
            }

            output += optimalPointp;
            output -= optimalPointt;
        }

        using (var stream = new StreamWriter(new System.IO.FileInfo("prepare.out").OpenWrite()))
        {
            stream.Write(output);
            stream.Flush();
        }
    }
}
