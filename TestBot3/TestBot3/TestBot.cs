using System.Text;

namespace Training3
{
    public static class TestBot
    {
        private static uint failTestCount = 0;

        private static readonly StringBuilder failTest = new StringBuilder(512);
        private static Random random = new Random();

        public static void StartTest()
        {
            failTestCount = 0;
            uint totalScore = 0;

            totalScore += testIsLeapYear();
            totalScore += testGetDaysInMonth();

            Console.WriteLine($"Your score: {totalScore}/100");

            if (failTestCount == 0)
            {
                Console.WriteLine("Good job!");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("===== Fail test list =====");
            Console.WriteLine(failTest.ToString());
        }

        private static uint testIsLeapYear()
        {
            uint score = 0;

            uint temp = A00();
            if (temp == 0)
            {
                failTest.AppendLine("A00: Year zero");
                ++failTestCount;
            }
            score += temp;

            temp = A01();
            if (temp == 0)
            {
                failTest.AppendLine("A01: Year indivisible by 4");
                ++failTestCount;
            }
            score += temp;

            temp = A02();
            if (temp == 0)
            {
                failTest.AppendLine("A02: Year 4Divisible 100 indivisible");
                ++failTestCount;
            }
            score += temp;

            temp = A03();
            if (temp == 0)
            {
                failTest.AppendLine("A03: Year 4 and 100 divisible 400 indivisible");
                ++failTestCount;
            }
            score += temp;

            temp = A04();
            if (temp == 0)
            {
                failTest.AppendLine("A04: Year 4 and 100 and 400 divisible");
                ++failTestCount;
            }
            score += temp;

            return score;
        }

        private static uint testGetDaysInMonth()
        {
            uint score = 0;

            uint temp = B00();
            if (temp == 0)
            {
                failTest.AppendLine("B00: Year out of range");
                ++failTestCount;
            }
            score += temp;

            temp = B01();
            if (temp == 0)
            {
                failTest.AppendLine("B01: Month out of range");
                ++failTestCount;
            }
            score += temp;

            temp = B02();
            if (temp == 0)
            {
                failTest.AppendLine("B02: Month with 31 days");
                ++failTestCount;
            }
            score += temp;

            temp = B03();
            if (temp == 0)
            {
                failTest.AppendLine("B03: Month with 30 days");
                ++failTestCount;
            }
            score += temp;

            temp = B04();
            if (temp == 0)
            {
                failTest.AppendLine("B04: Leap year February");
                ++failTestCount;
            }
            score += temp;

            temp = B05();
            if (temp == 0)
            {
                failTest.AppendLine("B05: Non Leap year Februar");
                ++failTestCount;
            }
            score += temp;

            return score;
        }

        private static uint A00()
        {
            const uint SCORE = 9;
            if (Calendar.IsLeapYear(0))
            {
                return 0;
            }

            return SCORE;
        }

        private static uint A01()
        {
            const uint SCORE = 9;

            for (int i = 0; i < 10; ++i)
            {
                uint year = (uint)random.Next(1, 2001) * 4 + 1;

                if (Calendar.IsLeapYear(year))
                {
                    return 0;
                }
            }

            return SCORE;
        }

        private static uint A02()
        {
            const uint SCORE = 9;
            int testCount = 0;

            while (testCount < 10)
            {
                uint year = (uint)random.Next(100, 10000) * 4;

                if (year % 100 == 0)
                {
                    continue;
                }

                if (!Calendar.IsLeapYear(year))
                {
                    return 0;
                }

                ++testCount;
            }

            return SCORE;
        }

        private static uint A03()
        {
            const uint SCORE = 9;

            uint[] years = { 200, 300, 500, 600, 700, 900, 1000, 1100, 1300, 1400, 9000 };
            
            foreach (uint year in years)
            {
                if (Calendar.IsLeapYear(year))
                {
                    return 0;
                }
            }

            return SCORE;
        }

        private static uint A04()
        {
            const uint SCORE = 9;

            uint[] years = { 400, 800, 1200, 1600, 2000, 2400, 2800, 3200, 3600, 4000, 4400 };

            foreach (uint year in years)
            {
                if (!Calendar.IsLeapYear(year))
                {
                    return 0;
                }
            }

            return SCORE;
        }

        private static uint B00()
        {
            const uint SCORE = 9;
            
            for (int i = 0; i < 10; ++i)
            {
                if (-1 != Calendar.GetDaysInMonth((uint)random.Next(10000, 99999), 2))
                {
                    return 0;
                }
            }

            return SCORE;
        }

        private static uint B01()
        {
            const uint SCORE = 9; 

            if (-1 != Calendar.GetDaysInMonth(2023, 0))
            {
                return 0;
            }

            for (int i = 0; i < 10; ++i)
            {
                if (-1 != Calendar.GetDaysInMonth(2023, (uint)random.Next(12, 100)))
                {
                    return 0;
                }
            }

            return SCORE;
        }

        private static uint B02()
        {
            const uint SCORE = 9;

            uint[] months = { 1, 3, 5, 7, 8, 10, 12 };

            for (int i = 0; i < months.Length; ++i)
            {
                if (31 != Calendar.GetDaysInMonth(2023, months[i]))
                {
                    return 0;
                }
            }

            return SCORE;
        }

        private static uint B03()
        {
            const uint SCORE = 9;

            uint[] months = { 4, 6, 9, 11 };

            for (int i = 0; i < months.Length; ++i)
            {
                if (30 != Calendar.GetDaysInMonth(2023, months[i]))
                {
                    return 0;
                }
            }

            return SCORE;
        }

        private static uint B04()
        {
            const uint SCORE = 9;
            uint testCount = 0;

            while (testCount < 10)
            {
                uint year = (uint)random.Next(1, 2001) * 4;

                if (29 != Calendar.GetDaysInMonth(year, 2))
                {
                    return 0;
                }

                ++testCount;
            }

            return SCORE;
        }

        private static uint B05()
        {
            const uint SCORE = 10;
            uint testCount = 0;

            while (testCount < 10)
            {
                uint year = (uint)random.Next(1, 2001) * 4 + 1;

                if (28 != Calendar.GetDaysInMonth(year, 2))
                {
                    return 0;
                }

                ++testCount;
            }

            return SCORE;
        }
    }
}