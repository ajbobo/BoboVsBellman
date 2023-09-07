namespace BoboVsBellman;

public class Methods
{
    public delegate int MethodFunc(double percent, bool display);

    /***************************************************************************************************************
     * NOTE: In these functions the variable cnt is used to count the number of direct comparisions that are made. *
     *       My goal was to see which algorithm has fewer comparisons.                                             *
     *       I wasn't concerned with readability or maintainability.                                               *
     ***************************************************************************************************************/

    public static int BadMethod(double percent, bool display)
    {
        char grade;
        int cnt = 1;
        if (percent >= 60)
        {
            cnt++;
            if (percent >= 80)
            {
                cnt++;
                if (percent >= 90)
                    grade = 'A';
                else
                    grade = 'B';
            }
            else
            {
                cnt++;
                if (percent >= 70)
                    grade = 'C';
                else
                    grade = 'D';
            }
        }
        else
        {
            grade = 'F';
        }

        if (display)
            Console.WriteLine("{0} => {1}", percent, grade);

        return cnt;
    }

    public static int GoodMethod(double percent, bool display)
    {
        char grade;
        int cnt = 1;
        if (percent >= 90)
        {
            grade = 'A';
        }
        else
        {
            cnt++;
            if (percent >= 80)
            {
                grade = 'B';
            }
            else
            {
                cnt++;
                if (percent >= 70)
                {
                    grade = 'C';
                }
                else
                {
                    cnt++;
                    if (percent >= 60)
                    {
                        grade = 'D';
                    }
                    else
                    {
                        grade = 'F';
                    }
                }
            }
        }

        if (display)
            Console.WriteLine("{0} => {1}", percent, grade);

        return cnt;
    }
}