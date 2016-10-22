using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class bteam
{
    public static void bMain(string[] args)
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

        var mat = 3;
        double output = 0f;

        var selectedCols = new List<int>();

        for (int row = 0; row < mat; row++)
        {
            var score = 0;
            var takenCol = 0;

            for (int col = 0; col < mat; col++)
            {
                var colScore = matrix[row][col];

                if (colScore > score && !selectedCols.Contains(col))
                {
                    score = colScore;
                    takenCol = col;
                }
                else
                {
                    var t = selectedCols.IndexOf(col);

                    if (t != -1)
                    {
                        var val = matrix[t][col];

                        if (colScore > val)
                        {
                            selectedCols[t] = -1;

                            score = colScore;
                            takenCol = col;
                        }
                    }
                }
                //TODO else with swap!
            }

            selectedCols.Add(takenCol);
        }

        //for (int i = 0; i < columns; i++)
        //{
        //    output += Math.Pow(points[i], 2d);
        //}

        //output = Math.Sqrt(output);

        using (var stream = new StreamWriter(new System.IO.FileInfo("team.out").OpenWrite()))
        {
            stream.Write(output);
            stream.Flush();
        }
    }
}