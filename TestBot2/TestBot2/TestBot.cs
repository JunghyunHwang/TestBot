using System.Diagnostics;
using System.Text;

namespace Training2
{
    public static class TestBot
    {
        private const uint MAX_SCORE = 100;
        private const uint TOTAL_TEST_COUNT = 16;
        private static uint failTestCount = 0;

        private static readonly StringBuilder failTest = new StringBuilder(512);

        public static void StartTest()
        {
            failTestCount = 0;
            uint totalScore = 0;

            totalScore += testInvalidOperator(); // 19
            totalScore += testAddOperator(); // 19
            totalScore += testSubtractOperator(); // 19
            totalScore += testMultiplyOperator(); // 19
            totalScore += testDivideOperator(); // 19
            totalScore += testRemainderOperator(); // 5

            Debug.Assert(failTestCount <= TOTAL_TEST_COUNT);
            Debug.Assert(totalScore <= MAX_SCORE);

            Console.WriteLine($"Your score: {totalScore}/100");

            if (failTestCount == 0)
            {
                Console.WriteLine("Good job!");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("========== Fail test list ==========");
            Console.WriteLine(failTest.ToString());
        }

        private static uint testInvalidOperator()
        {
            const uint COUNT = 22;
            const uint SCORE = 19;
            char[] invalidOp = { '!', '@', '#', '$', '^', '&', '(', ')', '=', '~', '`', '{', '}', ';', ':', '\'', '\"', '?', '>', '<', ',', '.' }; // 22

            for (int i = 0; i < COUNT; ++i)
            {
                if (SmartCalculator.Calculate(-1, -1, invalidOp[i]) != -1)
                {
                    failTest.AppendLine("A00: Invalid operator");
                    ++failTestCount;
                    return 0;
                }
            }

            return SCORE;
        }

        private static uint testAddOperator()
        {
            uint score = 0;

            uint temp = positiveNumberWithAddOperator();
            if (temp == 0)
            {
                failTest.AppendLine("A01: Positive number with + operator");
                ++failTestCount;
            }
            score += temp;

            temp = negativeNumberWithAddOperator();
            if (temp == 0)
            {
                failTest.AppendLine("A02: Negative number with + operator");
                ++failTestCount;
            }
            score += temp;

            temp = mixedNumberWithAddOperator();
            if (temp == 0)
            {
                failTest.AppendLine("A03: Mixed number with + operator");
                ++failTestCount;
            }
            score += temp;

            return score;
        }

        private static uint testSubtractOperator()
        {
            uint score = 0;

            uint temp = positiveNumberWithSubtractOperator();
            if (temp == 0)
            {
                failTest.AppendLine("A04: Positive number with - operator");
                ++failTestCount;
            }
            score += temp;

            temp = negativeNumberWithSubtractOperator();
            if (temp == 0)
            {
                failTest.AppendLine("A05: Negative number with - operator");
                ++failTestCount;
            }
            score += temp;

            temp = mixedNumberWithSubtractOperator();
            if (temp == 0)
            {
                failTest.AppendLine("A06: Mixed number with - operator");
                ++failTestCount;
            }
            score += temp;

            return score;
        }

        private static uint testMultiplyOperator()
        {
            uint score = 0;

            uint temp = positiveNumberWithMultiplyOperator();
            if (temp == 0)
            {
                failTest.AppendLine("A07: Positive number with * operator");
                ++failTestCount;
            }
            score += temp;

            temp = negativeNumberWithMultiplyOperator();
            if (temp == 0)
            {
                failTest.AppendLine("A08: Negative number with * operator");
                ++failTestCount;
            }
            score += temp;

            temp = mixedNumberWithMultiplyOperator();
            if (temp == 0)
            {
                failTest.AppendLine("A09: Mixed number with * operator");
                ++failTestCount;
            }
            score += temp;

            return score;
        }

        private static uint testDivideOperator()
        {
            uint score = 0;

            uint temp = positiveNumberWithDivideOperator();
            if (temp == 0)
            {
                failTest.AppendLine("A10: Positive number with / operator");
                ++failTestCount;
            }
            score += temp;

            temp = negativeNumberWithDivideOperator();
            if (temp == 0)
            {
                failTest.AppendLine("A11: Negative number with / operator");
                ++failTestCount;
            }
            score += temp;

            temp = mixedNumberWithDivideOperator();
            if (temp == 0)
            {
                failTest.AppendLine("A12: Mixed number with / operator");
                ++failTestCount;
            }
            score += temp;

            return score;
        }

        private static uint testRemainderOperator()
        {
            uint score = 0;

            uint temp = positiveNumberWithRemainOperator();
            if (temp == 0)
            {
                failTest.AppendLine("A13: Positive number with % operator");
                ++failTestCount;
            }
            score += temp;

            return score;
        }

        private static uint positiveNumberWithAddOperator()
        {
            const uint SCORE = 6;
            const char OP = '+';
            bool bExpectedSame = SmartCalculator.Calculate(1, 2, OP) == 3.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(23, 17, OP) == 40.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(230, 917, OP) == 1147.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(6230, 5917, OP) == 12147.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            return SCORE;
        }

        private static uint negativeNumberWithAddOperator()
        {
            const uint SCORE = 6;
            const char OP = '+';
            bool bExpectedSame = SmartCalculator.Calculate(-1, -2, OP) == -3.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-23, -17, OP) == -40.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-230, -917, OP) == -1147.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-6230, -5917, OP) == -12147.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            return SCORE;
        }

        private static uint mixedNumberWithAddOperator()
        {
            const uint SCORE = 7;
            const char OP = '+';
            bool bExpectedSame = SmartCalculator.Calculate(1, -2, OP) == -1.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-23, 17, OP) == -6.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-230, 917, OP) == 687.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-6230, 5917, OP) == -313.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            return SCORE;
        }

        private static uint positiveNumberWithSubtractOperator()
        {
            const uint SCORE = 6;
            const char OP = '-';

            bool bExpectedSame = SmartCalculator.Calculate(1, 2, OP) == -1.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(2, 1, OP) == 1.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(23, 17, OP) == 6.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(230, 917, OP) == -687.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(6230, 5917, OP) == 313.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            return SCORE;
        }

        private static uint negativeNumberWithSubtractOperator()
        {
            const uint SCORE = 6;
            const char OP = '-';
            bool bExpectedSame = SmartCalculator.Calculate(-1, -2, OP) == 1.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-23, -17, OP) == -6.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-230, -917, OP) == 687.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-6230, -5917, OP) == -313.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            return SCORE;
        }

        private static uint mixedNumberWithSubtractOperator()
        {
            const uint SCORE = 7;
            const char OP = '-';
            bool bExpectedSame = SmartCalculator.Calculate(1, -2, OP) == 3.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-23, 17, OP) == -40.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-230, 917, OP) == -1147.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-6230, 5917, OP) == -12147.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            return SCORE;
        }

        private static uint positiveNumberWithMultiplyOperator()
        {
            const uint SCORE = 6;
            const char OP = '*';

            bool bExpectedSame = SmartCalculator.Calculate(1, 2, OP) == 2.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(23, 17, OP) == 391.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(230, 917, OP) == 210910.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(6230, 5917, OP) == 36862910.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            return SCORE;
        }

        private static uint negativeNumberWithMultiplyOperator()
        {
            const uint SCORE = 6;
            const char OP = '*';
            bool bExpectedSame = SmartCalculator.Calculate(-1, -2, OP) == 2.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-23, -17, OP) == 391.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-230, -917, OP) == 210910.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-6230, -5917, OP) == 36862910.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            return SCORE;
        }

        private static uint mixedNumberWithMultiplyOperator()
        {
            const uint SCORE = 7;
            const char OP = '*';
            bool bExpectedSame = SmartCalculator.Calculate(1, -2, OP) == -2.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-23, 17, OP) == -391.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-230, 917, OP) == -210910.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-6230, 5917, OP) == -36862910.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            return SCORE;
        }

        private static uint positiveNumberWithDivideOperator()
        {
            const uint SCORE = 6;
            const char OP = '/';

            bool bExpectedSame = SmartCalculator.Calculate(1, 2, OP) == 0.5;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(23, 17, OP) == 1.3529411764705883;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(230, 917, OP) == 0.25081788440567065;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(6230, 5917, OP) == 1.0528984282575629;
            if (!bExpectedSame)
            {
                return 0;
            }

            return SCORE;
        }

        private static uint negativeNumberWithDivideOperator()
        {
            const uint SCORE = 6;
            const char OP = '/';
            bool bExpectedSame = SmartCalculator.Calculate(-1, -2, OP) == 0.5;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-23, -17, OP) == 1.3529411764705883;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-230, -917, OP) == 0.25081788440567065;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-6230, -5917, OP) == 1.0528984282575629;
            if (!bExpectedSame)
            {
                return 0;
            }

            return SCORE;
        }

        private static uint mixedNumberWithDivideOperator()
        {
            const uint SCORE = 7;
            const char OP = '/';
            bool bExpectedSame = SmartCalculator.Calculate(1, -2, OP) == -0.5;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-23, 17, OP) == -1.3529411764705883;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-230, 917, OP) == -0.25081788440567065;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(-6230, 5917, OP) == -1.0528984282575629;
            if (!bExpectedSame)
            {
                return 0;
            }

            return SCORE;
        }

        private static uint positiveNumberWithRemainOperator()
        {
            const uint SCORE = 5;
            const char OP = '%';

            bool bExpectedSame = SmartCalculator.Calculate(1, 2, OP) == 1.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(23, 17, OP) == 6.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(230, 917, OP) == 230.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            bExpectedSame = SmartCalculator.Calculate(6230, 5917, OP) == 313.0;
            if (!bExpectedSame)
            {
                return 0;
            }

            return SCORE;
        }
    }
}