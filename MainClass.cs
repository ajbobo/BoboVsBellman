using System.Reflection;
using MathNet.Numerics.Distributions;

namespace BoboVsBellman;

public class MainClass
{
    public delegate List<int> GradeFunc(Methods.MethodFunc func);

    static List<int> GetAllGrades(Methods.MethodFunc func)
    {
        var values = new List<int>();
        for (float x = 0; x <= 100; x++)
        {
            values.Add(func(x, false));
        }
        return values;
    }

    static List<int> UniformDistribution(Methods.MethodFunc func)
    {
        int numGrades = 1000;
        var values = new List<int>();
        var dist = new ContinuousUniform(0, 100);

        for (int x = 0; x < numGrades; x++)
        {
            double percent = dist.Sample();
            values.Add(func(percent, false));
        }

        return values;
    }

    static List<int> NormalWithMeanStdDev(double mean, double stdDev, Methods.MethodFunc func)
    {
        int numGrades = 1000;
        var values = new List<int>();
        var dist = new Normal(mean, stdDev);

        for (int x = 0; x < numGrades; x++)
        {
            double percent = dist.Sample();
            values.Add(func(percent, false));
        }

        return values;
    }

    static List<int> NormalAroundA(Methods.MethodFunc func)
    {
        return NormalWithMeanStdDev(95, 5, func);
    }

    static List<int> NormalAroundB(Methods.MethodFunc func)
    {
        return NormalWithMeanStdDev(85, 5, func);
    }

    static List<int> NormalAroundC(Methods.MethodFunc func)
    {
        return NormalWithMeanStdDev(75, 5, func);
    }

    static List<int> NormalAroundD(Methods.MethodFunc func)
    {
        return NormalWithMeanStdDev(65, 5, func);
    }

    static List<int> NormalAroundF(Methods.MethodFunc func)
    {
        return NormalWithMeanStdDev(55, 5, func);
    }

    static void PrintResults(Methods.MethodFunc method, GradeFunc grades)
    {
        var res = grades(method);
        double avg = res.Average();
        Console.WriteLine("{0,-20} | {1,-10} | {2:f2}", grades.GetMethodInfo().Name, method.GetMethodInfo().Name, avg);
    }

    public static void Main(string[] args)
    {
        PrintResults(Methods.BadMethod, GetAllGrades);
        PrintResults(Methods.GoodMethod, GetAllGrades);

        PrintResults(Methods.BadMethod, UniformDistribution);
        PrintResults(Methods.GoodMethod, UniformDistribution);

        PrintResults(Methods.BadMethod, NormalAroundA);
        PrintResults(Methods.GoodMethod, NormalAroundA);

        PrintResults(Methods.BadMethod, NormalAroundB);
        PrintResults(Methods.GoodMethod, NormalAroundB);

        PrintResults(Methods.BadMethod, NormalAroundC);
        PrintResults(Methods.GoodMethod, NormalAroundC);

        PrintResults(Methods.BadMethod, NormalAroundD);
        PrintResults(Methods.GoodMethod, NormalAroundD);

        PrintResults(Methods.BadMethod, NormalAroundF);
        PrintResults(Methods.GoodMethod, NormalAroundF);
    }
}