using System.Runtime.InteropServices;
using System.Text;

namespace Training4
{
    public static class TestBot
    {
        private static readonly StringBuilder failTest = new StringBuilder(1024);
        private static Random random = new Random();
        private const int MAX_STUDENT_COUNT = 100;
        private static bool bIsModified = false;

        public static void StartTest()
        {
            uint totalScore = 0;

            totalScore += testGetUnsubmittedCount();
            totalScore += testGetStudentScore();
            totalScore += testGetAverage();

            if (!bIsModified)
            {
                ++totalScore;
            }
            else
            {
                failTest.AppendLine("D00: Not modified array");
            }

            Console.WriteLine($"Your score: {totalScore}/100");

            if (failTest.Length == 0)
            {
                Console.WriteLine("Good job!");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("========== Fail test list ==========");
            Console.WriteLine(failTest.ToString());
        }

        private static uint testGetUnsubmittedCount()
        {
            uint score = 33;

            if (!A00())
            {
                failTest.AppendLine("A00: Only one student");
                score -= 9;
            }

            if (!A01())
            {
                failTest.AppendLine("A01: Many students");
                score -= 8;
            }

            if (!A02())
            {
                failTest.AppendLine("A02: All unsubmitted");
                score -= 8;
            }

            if (!A03())
            {
                failTest.AppendLine("A03: All submitted");
                score -= 8;
            }

            return score;
        }

        private static uint testGetStudentScore()
        {
            uint score = 33;

            if (!B00())
            {
                failTest.AppendLine("B00: Only one student");
                score -= 5;
            }

            if (!B01())
            {
                failTest.AppendLine("B01: Many students");
                score -= 7;
            }

            if (!B02())
            {
                failTest.AppendLine("B02: Many students get first student");
                score -= 7;
            }

            if (!B03())
            {
                failTest.AppendLine("B03: Many students get last student");
                score -= 7;
            }

            if (!B04())
            {
                failTest.AppendLine("B04: Out of index");
                score -= 7;
            }

            return score;
        }

        private static uint testGetAverage()
        {
            uint score = 33;

            if (!C00())
            {
                failTest.AppendLine("C00: All unsubmitted");
                score -= 11;
            }

            if (!C01())
            {
                failTest.AppendLine("C01: All submitted");
                score -= 11;
            }

            if (!C02())
            {
                failTest.AppendLine("C02: Serveral unsubmitted");
                score -= 11;
            }

            return score;
        }

        private static void getSubmittedArray(int[] scores, int submitCount)
        {
            if (scores.Length == submitCount)
            {
                for (int i = 0; i < submitCount; ++i)
                {
                    scores[i] = random.Next(101);
                }

                return;
            }

            for (int i = 0; i < scores.Length; ++i)
            {
                scores[i] = -1;
            }

            if (submitCount == 0)
            {
                return;
            }

            HashSet<int> submittedIndexes = new HashSet<int>(submitCount);

            while (submittedIndexes.Count < submitCount)
            {
                submittedIndexes.Add(random.Next(scores.Length));
            }

            foreach (int i in submittedIndexes)
            {
                scores[i] = random.Next(101);
            }
        }

        private static void checkModified(int[] scores, int[] copy)
        {
            for (int i = 0; i < scores.Length; ++i)
            {
                if (scores[i] != copy[i])
                {
                    bIsModified = true;
                    break;
                }
            }
        }

        private static void arrayCopy(int[] scores, int[] copy)
        {
            for (int i = 0; i < scores.Length; ++i)
            {
                copy[i] = scores[i];
            }
        }

        private static bool A00()
        {
            int[] scores = { 92 };

            int result = AssignmentManager.GetUnsubmittedCount(scores);

            if (scores[0] != 92)
            {
                bIsModified = true;
            }

            if (result != 0)
            {
                return false;
            }

            scores[0] = -1;

            result = AssignmentManager.GetUnsubmittedCount(scores);

            if (scores[0] != -1)
            {
                bIsModified = true;
            }

            if (result != 1)
            {
                return false;
            }

            return true;
        }

        private static bool A01()
        {
            int submitCount = 90;
            int unsubmitCount = MAX_STUDENT_COUNT - submitCount;

            int[] scores = new int[MAX_STUDENT_COUNT];
            int[] copy = new int[MAX_STUDENT_COUNT];

            getSubmittedArray(scores, submitCount);
            arrayCopy(scores, copy);
            int result = AssignmentManager.GetUnsubmittedCount(scores);
            checkModified(scores, copy);
            if (result != unsubmitCount)
            {
                return false;
            }

            submitCount = 80;
            unsubmitCount = MAX_STUDENT_COUNT - submitCount;

            getSubmittedArray(scores, submitCount);
            arrayCopy(scores, copy);
            result = AssignmentManager.GetUnsubmittedCount(scores);
            checkModified(scores, copy);
            if (result != unsubmitCount)
            {
                return false;
            }

            submitCount = 57;
            unsubmitCount = MAX_STUDENT_COUNT - submitCount;

            getSubmittedArray(scores, submitCount);
            arrayCopy(scores, copy);
            result = AssignmentManager.GetUnsubmittedCount(scores);
            checkModified(scores, copy);
            if (result != unsubmitCount)
            {
                return false;
            }

            return true;
        }

        private static bool A02()
        {
            int[] scores = new int[MAX_STUDENT_COUNT];
            int[] copy = new int[MAX_STUDENT_COUNT];

            getSubmittedArray(scores, 0);
            arrayCopy(scores, copy);
            int result = AssignmentManager.GetUnsubmittedCount(scores);
            checkModified(scores, copy);
            if (result != scores.Length)
            {
                return false;
            }

            return true;
        }

        private static bool A03()
        {
            int[] scores = new int[MAX_STUDENT_COUNT];
            int[] copy = new int[MAX_STUDENT_COUNT];

            getSubmittedArray(scores, scores.Length);
            arrayCopy(scores, copy);
            int result = AssignmentManager.GetUnsubmittedCount(scores);
            checkModified(scores, copy);
            if (result != 0)
            {
                return false;
            }

            scores = new int[50];
            copy = new int[50];

            getSubmittedArray(scores, scores.Length);
            arrayCopy(scores, copy);
            result = AssignmentManager.GetUnsubmittedCount(scores);
            checkModified(scores, copy);
            if (result != 0)
            {
                return false;
            }

            return true;
        }

        private static bool B00()
        {
            int[] tempScores = { 78 };

            int result = AssignmentManager.GetStudentScore(tempScores, 1);

            if (tempScores[0] != 78)
            {
                bIsModified = true;
            }

            if (result != tempScores[0])
            {
                return false;
            }

            tempScores[0] = 88;

            result = AssignmentManager.GetStudentScore(tempScores, 1);

            if (tempScores[0] != 88)
            {
                bIsModified = true;
            }

            if (result != tempScores[0])
            {
                return false;
            }

            tempScores[0] = 100;

            result = AssignmentManager.GetStudentScore(tempScores, 1);

            if (tempScores[0] != 100)
            {
                bIsModified = true;
            }

            if (result != tempScores[0])
            {
                return false;
            }

            return true;
        }

        private static bool B01()
        {
            int[] scores = new int[50];
            int[] copy = new int[50];

            getSubmittedArray(scores, 40);
            arrayCopy(scores, copy);

            int expected = scores[32];
            int actual = AssignmentManager.GetStudentScore(scores, 33);
            checkModified(scores, copy);

            if (expected != actual)
            {
                return false;
            }

            expected = scores[29];
            actual = AssignmentManager.GetStudentScore(scores, 30);

            if (expected != actual)
            {
                return false;
            }

            return true;
        }

        private static bool B02()
        {
            int[] scores = new int[50];
            int[] copy = new int[50];

            getSubmittedArray(scores, 40);
            arrayCopy(scores, copy);

            int expected = scores[0];
            int actual = AssignmentManager.GetStudentScore(scores, 1);
            checkModified(scores, copy);

            if (expected != actual)
            {
                return false;
            }

            return true;
        }

        private static bool B03()
        {
            int[] scores = new int[50];
            int[] copy = new int[50];

            getSubmittedArray(scores, 50);
            arrayCopy(scores, copy);

            int expected = scores[49];
            int actual = AssignmentManager.GetStudentScore(scores, 50);
            checkModified(scores, copy);

            if (expected != actual)
            {
                return false;
            }

            scores = new int[MAX_STUDENT_COUNT];
            copy = new int[MAX_STUDENT_COUNT];
            getSubmittedArray(scores, MAX_STUDENT_COUNT);
            arrayCopy(scores, copy);

            expected = scores[MAX_STUDENT_COUNT - 1];
            actual = AssignmentManager.GetStudentScore(scores, MAX_STUDENT_COUNT);
            checkModified(scores, copy);

            if (expected != actual)
            {
                return false;
            }

            return true;
        }

        private static bool B04()
        {
            int[] scores = new int[50];
            int[] copy = new int[50];

            getSubmittedArray(scores, 50);
            arrayCopy(scores, copy);

            if (AssignmentManager.GetStudentScore(scores, 51) != -100)
            {
                return false;
            }

            if (AssignmentManager.GetStudentScore(scores, 100) != -100)
            {
                return false;
            }

            if (AssignmentManager.GetStudentScore(scores, 200) != -100)
            {
                return false;
            }

            return true;
        }

        private static double getAverage(int[] scores)
        {
            int sum = 0;
            for (int i = 0; i < scores.Length; ++i)
            {
                int val = scores[i] == -1 ? 0 : scores[i];
                sum += val;
            }

            return (double)sum / scores.Length;
        }

        private static bool C00()
        {
            int[] scores = new int[MAX_STUDENT_COUNT];
            int[] copy = new int[MAX_STUDENT_COUNT];

            getSubmittedArray(scores, 0);
            arrayCopy(scores, copy);

            double actual = AssignmentManager.GetAverage(scores);
            checkModified(scores, copy);

            if (actual != 0.0)
            {
                return false;
            }

            actual = AssignmentManager.GetAverage(scores);
            checkModified(scores, copy);

            if (actual != 0.0)
            {
                return false;
            }

            return true;
        }

        private static bool C01()
        {
            int[] scores = new int[MAX_STUDENT_COUNT];
            int[] copy = new int[MAX_STUDENT_COUNT];

            getSubmittedArray(scores, scores.Length);
            arrayCopy(scores, copy);
            double expected = getAverage(scores);
            double actual = AssignmentManager.GetAverage(scores);
            checkModified(scores, copy);

            if (expected != actual)
            {
                return false;
            }

            getSubmittedArray(scores, scores.Length);
            arrayCopy(scores, copy);
            expected = getAverage(scores);
            actual = AssignmentManager.GetAverage(scores);
            checkModified(scores, copy);

            if (expected != actual)
            {
                return false;
            }

            getSubmittedArray(scores, scores.Length);
            arrayCopy(scores, copy);
            expected = getAverage(scores);
            actual = AssignmentManager.GetAverage(scores);
            checkModified(scores, copy);
            
            if (expected != actual)
            {
                return false;
            }

            return true;
        }

        private static bool C02()
        {
            int[] scores = new int[MAX_STUDENT_COUNT];
            int[] copy = new int[MAX_STUDENT_COUNT];

            getSubmittedArray(scores, 90);
            arrayCopy(scores, copy);
            double expected = getAverage(scores);
            double actual = AssignmentManager.GetAverage(scores);
            checkModified(scores, copy);

            if (expected != actual)
            {
                return false;
            }

            getSubmittedArray(scores, 80);
            arrayCopy(scores, copy);
            expected = getAverage(scores);
            actual = AssignmentManager.GetAverage(scores);
            checkModified(scores, copy);

            if (expected != actual)
            {
                return false;
            }

            getSubmittedArray(scores, 70);
            arrayCopy(scores, copy);
            expected = getAverage(scores);
            actual = AssignmentManager.GetAverage(scores);
            checkModified(scores, copy);

            if (expected != actual)
            {
                return false;
            }

            return true;
        }
    }
}