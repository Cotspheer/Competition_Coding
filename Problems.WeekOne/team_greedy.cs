using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class team_greedy
{
    public static bool swapped = false;
    public static int recursionCount = 0;
    public static int maxRecCount = 10;

    public static void GMain(string[] args)
    {
        var inputStream = new StreamReader(new System.IO.FileInfo("team.in").OpenRead());

        var personOne = inputStream.ReadLine().Split(' ');
        var personTwo = inputStream.ReadLine().Split(' ');
        var personThree = inputStream.ReadLine().Split(' ');

        var matrix = new int[][] {
            new int[] {  0, 0, 0 },
            new int[] {  0, 0, 0 },
            new int[] {  0, 0, 0 }
        };

        matrix[0][0] = UInt16.Parse(personOne[0]);
        matrix[0][1] = UInt16.Parse(personOne[1]);
        matrix[0][2] = UInt16.Parse(personOne[2]);

        matrix[1][0] = UInt16.Parse(personTwo[0]);
        matrix[1][1] = UInt16.Parse(personTwo[1]);
        matrix[1][2] = UInt16.Parse(personTwo[2]);

        matrix[2][0] = UInt16.Parse(personThree[0]);
        matrix[2][1] = UInt16.Parse(personThree[1]);
        matrix[2][2] = UInt16.Parse(personThree[2]);

        double output = 0f;

        var scores = new int[][] {
            new int[] {  0, 0, 0 }
        };

        calcMatrix(matrix, scores);


        for (int i = 0; i < 3; i++)
        {
            output += Math.Pow(scores[0][i], 2d);
        }

        output = Math.Sqrt(output);

        using (var stream = new StreamWriter(new System.IO.FileInfo("team.out").OpenWrite()))
        {
            stream.Write(output);
            stream.Flush();
        }
    }

    public static void calcMatrix(int[][] matrix, int[][] scores) {
        recursionCount += 1;

        if (recursionCount > maxRecCount) {
            return;
        }

        for (int row = 0; row < 3; row++)
        {
            var score = 0;
            var takenCol = 0;
            var bestScore = 0;
            var setValue = false;

            for (int col = 0; col < 3; col++)
            {
                var colScore = matrix[row][col];

                if (colScore > score)
                {
                    score = colScore;
                    bestScore = colScore;
                }
            }

            score = 0;

            for (int col = 0; col < 3; col++)
            {
                var colScore = matrix[row][col];

                if (colScore > score && scores[0][col] == 0)
                {
                    score = colScore;
                    takenCol = col;

                    setValue = true;

                    continue;
                }
                else if (bestScore > colScore)
                {
                    continue;
                }
                else if (!swapped && scores[0][col] < colScore)
                {
                    score = colScore;
                    takenCol = col;
                    swapped = true;
                    setValue = true;

                    continue;
                }
                else if (scores[0][col] == colScore)
                {
                    continue;
                }

                swapped = false;
            }

            if (setValue)
            {
                scores[0][takenCol] = score;
            }
        }

        if (swapped) {
            calcMatrix(matrix, scores);
        }

        if (scores[0].Contains(0)) {
            calcMatrix(matrix, scores);
        }
        
    }
}