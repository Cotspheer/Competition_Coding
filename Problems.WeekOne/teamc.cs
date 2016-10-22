using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class cteam
{
    public static void CMain(string[] args)
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

        //matrix[0][0] = UInt16.Parse(personOne[0]);
        //matrix[0][1] = UInt16.Parse(personTwo[0]);
        //matrix[0][2] = UInt16.Parse(personThree[0]);

        //matrix[1][0] = UInt16.Parse(personOne[1]);
        //matrix[1][1] = UInt16.Parse(personTwo[1]);
        //matrix[1][2] = UInt16.Parse(personThree[1]);

        //matrix[2][0] = UInt16.Parse(personOne[2]);
        //matrix[2][1] = UInt16.Parse(personTwo[2]);
        //matrix[2][2] = UInt16.Parse(personThree[2]);

        //matrix[0][0] = UInt16.Parse(personOne[0]);
        //matrix[0][1] = UInt16.Parse(personOne[1]);
        //matrix[0][2] = UInt16.Parse(personOne[2]);

        //matrix[1][0] = UInt16.Parse(personTwo[0]);
        //matrix[1][1] = UInt16.Parse(personTwo[1]);
        //matrix[1][2] = UInt16.Parse(personTwo[2]);

        //matrix[2][0] = UInt16.Parse(personThree[0]);
        //matrix[2][1] = UInt16.Parse(personThree[1]);
        //matrix[2][2] = UInt16.Parse(personThree[2]);

        //var columns = 3;
        //double output = 0f;

        //double[] points = new double[columns];
        //int[] indexes = new int[3];

        //var selectedX = new List<int>();

        //for (int i = 0; i < columns; i++)
        //{
        //    var taken = matrix[i][0];
        //    var y = i;
        //    var x = 0;

        //    for (int k = i; k < columns; k++)
        //    {
        //        if (selectedPoints.ContainsKey(k))
        //        {
        //            continue;
        //        }

        //        var z = matrix[k][0];

        //        if (z > taken)
        //        {
        //            taken = z;
        //            rowIndex = k;
        //        }

        //        for (int j = 1; j < 3; j++) {
        //            var bestSkill = matrix[k][j];

        //            if (bestSkill > taken) {
        //                taken = bestSkill;
        //                columnIndex = j;
        //            }
        //        }
        //    }

        //    selectedColums.Add(columnIndex);
        //}

        //for (int i = 0; i < columns; i++)
        //{
        //    output += Math.Pow(points[i], 2d);
        //}

        //output = Math.Sqrt(output);

        //using (var stream = new StreamWriter(new System.IO.FileInfo("team.out").OpenWrite()))
        //{
        //    stream.Write(output);
        //    stream.Flush();
        //}
    }
}