using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class win
{
    public static int secondsInAMinute = 60;
    public static int timeLimitInMinutes = 300;

    public static int timeLimit = secondsInAMinute * timeLimitInMinutes; // 18'000

    public static void Main(string[] args)
    {
        var inputStream = new StreamReader(new System.IO.FileInfo("win.in").OpenRead());
        var amoutOfProblemsToSolve = int.Parse(inputStream.ReadLine().Split(' ')[0]);
        var timePerProblem = new List<int>();

        foreach (var time in inputStream.ReadLine().Split(' '))
        {
            var t = int.Parse(time);

            timePerProblem.Add(t);
        }

        timePerProblem = timePerProblem.OrderBy(x => x).ToList();

        int sum = 0;
        var cnt = 0;

        while (sum <= timeLimit)
        {

            if (cnt >= timePerProblem.Count) {
                break;
            }

            sum += timePerProblem[cnt];

            if (sum > timeLimit)
            {
                break;
            }

            cnt++;
        }

        using (var stream = new StreamWriter(new System.IO.FileInfo("win.out").OpenWrite()))
        {
            stream.Write(cnt);
            stream.Flush();
        }
    }
}
