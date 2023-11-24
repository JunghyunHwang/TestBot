using System.Diagnostics;
using System.Text;

namespace Training1
{
    public static class TestBot
    {
        private const uint MAX_SCORE = 100;
        private const uint TOTAL_TEST_COUNT = 11;
        private static uint failTestCount = 0;

        private static readonly StringBuilder failTest = new StringBuilder(512);

        public static void StartTest()
        {
            failTestCount = 0;
            uint totalScore = 0;

            totalScore += testGetAdd();
            totalScore += testGetAverage();
            totalScore += testMultiply();
            totalScore += testSubtract();

            Debug.Assert(failTestCount <= TOTAL_TEST_COUNT);
            Debug.Assert(totalScore <= MAX_SCORE);

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

        private static uint testGetAdd()
        {
            uint score = 0;

            uint temp = getAdd0();
            if (temp == 0)
            {
                failTest.AppendLine("A00: Positive nubmer");
                ++failTestCount;
            }
            score += temp;

            temp = getAdd1();
            if (temp == 0)
            {
                failTest.AppendLine("A01: Negative number");
                ++failTestCount;
            }
            score += temp;

            temp = getAdd2();
            if (temp == 0)
            {
                failTest.AppendLine("A02: Mixed number");
                ++failTestCount;
            }
            score += temp;

            return  score;
        }

        private static uint testGetAverage()
        {
            uint score = 0;

            uint temp = getAverage0();
            if (temp == 0)
            {
                failTest.AppendLine("B00: Remainder zero");
                ++failTestCount;
            }
            score += temp;

            temp = getAverage1();
            if (temp == 0)
            {
                failTest.AppendLine("B01: Remainder not zero");
                ++failTestCount;
            }
            score += temp;

            return score;
        }

        private static uint testMultiply()
        {
            uint score = 0;

            uint temp = multiply0();
            if (temp == 0)
            {
                failTest.AppendLine("C00: Two positive number");
                ++failTestCount;
            }
            score += temp;

            temp = multiply1();
            if (temp == 0)
            {
                failTest.AppendLine("C01: Two negative number");
                ++failTestCount;
            }
            score += temp;

            temp = multiply2();
            if (temp == 0)
            {
                failTest.AppendLine("Multiply1: Mixed number");
                ++failTestCount;
            }
            score += temp;

            return score;
        }

        private static uint testSubtract()
        {
            uint score = 0;

            uint temp = subtract0();
            if (temp == 0)
            {
                failTest.AppendLine("D00: Positive nubmer");
                ++failTestCount;
            }
            score += temp;

            temp = subtract1();
            if (temp == 0)
            {
                failTest.AppendLine("D01: Negative number");
                ++failTestCount;
            }
            score += temp;

            temp = subtract2();
            if (temp == 0)
            {
                failTest.AppendLine("D02: Mixed number");
                ++failTestCount;
            }
            score += temp;

            return score;
        }

        // Total Test
        private static uint getAdd0()
        {
            const uint SCORE = 8;
            bool bExpectedSame = 10 == Calculator.GetSum(1, 2, 3, 4);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = 24210 == Calculator.GetSum(56, 29, 23843, 282);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = Int32.MinValue == Calculator.GetSum(Int32.MaxValue, 1, 0, 0);

            if (!bExpectedSame)
            {
                return 0;
            }

            Debug.Assert(SCORE == 8);
            return SCORE;
        }

        private static uint getAdd1()
        {
            const uint SCORE = 8;
            bool bExpectedSame = -10 == Calculator.GetSum(-1, -2, -3, -4);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = -24210 == Calculator.GetSum(-56, -29, -23843, -282);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = Int32.MaxValue == Calculator.GetSum(Int32.MinValue, -1, 0, 0);

            if (!bExpectedSame)
            {
                return 0;
            }

            Debug.Assert(SCORE == 8);
            return SCORE;
        }

        private static uint getAdd2()
        {
            const uint SCORE = 9;
            bool bExpectedSame = -2 == Calculator.GetSum(1, -2, 3, -4);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = -23588 == Calculator.GetSum(-56, 29, -23843, 282);

            if (!bExpectedSame)
            {
                return 0;
            }

            Debug.Assert(SCORE == 9);
            return SCORE;
        }

        // Remainder zero
        private static uint getAverage0()
        {
            const uint SCORE = 12;

            bool bExpectedSame = 20.0 == Calculator.GetAverage(12, 2, 29, 37); // sum1: 20.0
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = 2709.0 == Calculator.GetAverage(5657, 310, 87, 4782); // sum2: 2709.0
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = 10.0 == Calculator.GetAverage(10, 10, 10, 10); // sum2: 10.0
            if (!bExpectedSame)
            {
                return 0;
            }

            Debug.Assert(SCORE == 12);
            return SCORE;
        }

        // Remainder not zero
        private static uint getAverage1()
        {
            const uint SCORE = 13;

            bool bExpectedSame = 5.5 == Calculator.GetAverage(2, 3, 8, 9); // 5.5;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = 473.75 == Calculator.GetAverage(234, 873, 117, 671); // 473.75
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = 8125.25 == Calculator.GetAverage(7673, 8841, 6116, 9871); // 8125.25
            if (!bExpectedSame)
            {
                return 0;
            }

            Debug.Assert(SCORE == 13);
            return SCORE;
        }

        private static uint multiply0()
        {
            const uint SCORE = 8;
            bool bExpectedSame = 8 == Calculator.Multiply(2, 4);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = 504 == Calculator.Multiply(12, 42);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = 164088 == Calculator.Multiply(424, 387);

            if (!bExpectedSame)
            {
                return 0;
            }

            Debug.Assert(SCORE == 8);
            return SCORE;
        }

        private static uint multiply1()
        {
            const uint SCORE = 8;
            bool bExpectedSame = 8 == Calculator.Multiply(-2, -4);

            if (!bExpectedSame)
            {
                return 0;
            }
            
            bExpectedSame = 504 == Calculator.Multiply(-12, -42);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = 164088 == Calculator.Multiply(-424, -387);

            if (!bExpectedSame)
            {
                return 0;
            }

            Debug.Assert(SCORE == 8);
            return SCORE;
        }

        private static uint multiply2()
        {
            const uint SCORE = 9;
            bool bExpectedSame = -8 == Calculator.Multiply(2, -4);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = -504 == Calculator.Multiply(-12, 42);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = -164088 == Calculator.Multiply(424, -387);

            if (!bExpectedSame)
            {
                return 0;
            }

            Debug.Assert(SCORE == 9);
            return SCORE;
        }

        private static uint subtract0()
        {
            const uint SCORE = 8;
            bool bExpectedSame = -2 == Calculator.Subtract(2, 4);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = -30 == Calculator.Subtract(12, 42);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = 37 == Calculator.Subtract(424, 387);

            if (!bExpectedSame)
            {
                return 0;
            }

            Debug.Assert(SCORE == 8);
            return SCORE;
        }

        private static uint subtract1()
        {
            const uint SCORE = 8;
            bool bExpectedSame = 2 == Calculator.Subtract(-2, -4);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = 30 == Calculator.Subtract(-12, -42);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = -37 == Calculator.Subtract(-424, -387);

            if (!bExpectedSame)
            {
                return 0;
            }

            Debug.Assert(SCORE == 8);
            return SCORE;
        }

        private static uint subtract2()
        {
            const uint SCORE = 9;
            bool bExpectedSame = 6 == Calculator.Subtract(2, -4);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = -54 == Calculator.Subtract(-12, 42);

            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = 811 == Calculator.Subtract(424, -387);

            if (!bExpectedSame)
            {
                return 0;
            }

            Debug.Assert(SCORE == 9);
            return SCORE;
        }
    }
}