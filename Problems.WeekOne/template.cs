using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class template
{
    public static int lineCounter = 0;
    public static int width;
    public static byte height;
    public static char[,] keyboard;
    public static List<string> templates = new List<string>();
    public static List<int> templateScores = new List<int>();
    public static string currentLine = null;
    public static int[] lastPoint = null;

    public static void bMain(string[] args)
    {
        var output = 0;

        var inputStream = new StreamReader(new System.IO.FileInfo("template.in").OpenRead());
        var coords = inputStream.ReadLine().Split(' ');

        width = int.Parse(coords[0]);
        height = byte.Parse(coords[1]);

        keyboard = new char[height, width];

        generateKeyboard(inputStream);

        inputStream.ReadLine(); // read empty line

        var templateScore = 0;

        var condition = true;

        while (condition)
        {
            currentLine = inputStream.ReadLine(); // read language;
            templates.Add(currentLine);

            if (currentLine == null) {
                condition = false;
                break;
            }

            if (string.IsNullOrWhiteSpace(currentLine))
            {
                templateScores.Add(templateScore);
                lastPoint = null;

                continue;
            }

            var str = readUntilBlankLine(inputStream);

            var score = calcScore(str);

            templateScores.Add(score);
        }

        var bestScore = 0;
        var index = 0;

        foreach (var score in templateScores)
        {
            if (bestScore == 0 || bestScore > score) {
                bestScore = score;
                index = templateScores.IndexOf(score);
            }
        }

        var template = templates[index];
        output = bestScore;

        using (var stream = new StreamWriter(new System.IO.FileInfo("template.out").OpenWrite()))
        {
            stream.WriteLine(template);
            stream.Write(output);
            stream.Flush();
        }
    }

    public static void generateKeyboard(StreamReader stream)
    {
        for (int i = 0; i < height; i++)
        {
            var line = stream.ReadLine();

            for (int j = 0; j < line.Length; j++)
            {
                keyboard[i, j] = line[j];
            }

        }
    }

    public static string readUntilBlankLine(StreamReader stream)
    {
        var str = "";

        while ((currentLine = stream.ReadLine()) != null && !string.IsNullOrWhiteSpace(currentLine))
        {
            str += currentLine;
        }

        return str;
    }

    public static int calcScore(string str) {
        var templateScore = 0;

        for (int i = 0; i < str.Length; i++)
        {            
            var point = findKey(str[i]);
            var next = i + 1 < str.Length ? findKey(str[i + 1]) : null;

            if (next == null) {
                continue;
            }

            var score = max(point, next);

            templateScore += score;

            lastPoint = point;
        }

        return templateScore;
    }

    public static int[] findKey(char key)
    {
        var result = new int[2];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {

                if (keyboard[i, j] != key)
                {
                    continue;
                }

                result[0] = i; // x
                result[1] = j; // y
            }
        }

        return result;
    }

    public static int max(int[] pointA, int[] pointB)
    {
        var deltaX = Math.Abs(pointA[0] - pointB[0]); //Xa - Xb
        var deltaY = Math.Abs(pointA[1] - pointB[1]);//Ya - Yb

        return Math.Max(deltaX, deltaY);
    }
}
