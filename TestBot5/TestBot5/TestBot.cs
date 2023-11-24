using System.Diagnostics;
using System.Text;

namespace Training5
{
    public class TestBot
    {
        private static readonly StringBuilder failTest = new StringBuilder(1024);
        private static Random random = new Random();
        private const int MAX_STUDENT_COUNT = 100;

        public static void StartTest()
        {
            uint totalScore = 0;

            totalScore += testRotate90Degrees();
            totalScore += testHorizontalMirror();
            totalScore += testVerticalMirror();
            totalScore += testDiagonalShift();

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

        private static bool IsSameArray(int[,] expected, int[,] actual)
        {
            if (expected.GetLength(0) != actual.GetLength(0))
            {
                return false;
            }
            else if (expected.GetLength(1) != actual.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < expected.GetLength(0); ++i)
            {
                for (int j = 0; j < expected.GetLength(1); ++j)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static uint testRotate90Degrees()
        {
            uint score = 25;

            if (!A00())
            {
                failTest.Append("A00: 1x1 Array");
                score -= 3;
            }

            if (!A01())
            {
                failTest.Append("A01: Only row array");
                score -= 3;
            }

            if (!A02())
            {
                failTest.Append("A02: Only column array");
                score -= 3;
            }

            if (!A03())
            {
                failTest.Append("A03: NxN Array");
                score -= 3;
            }

            if (!A04())
            {
                failTest.Append("A04: Longer column array");
                score -= 4;
            }

            if (!A05())
            {
                failTest.Append("A05: Longer row array");
                score -= 4;
            }

            return score;
        }

        private static uint testHorizontalMirror()
        {
            uint score = 25;

            if (!B00())
            {
                failTest.Append("B00: 1x1 Array");
                score -= 4;
            }

            if (!B01())
            {
                failTest.Append("B01: Only row array");
                score -= 4;
            }

            if (!B02())
            {
                failTest.Append("B02: Only column array");
                score -= 4;
            }

            if (!B03())
            {
                failTest.Append("B03: NxN Array");
                score -= 4;
            }

            if (!B04())
            {
                failTest.Append("B04: Longer column array");
                score -= 4;
            }

            if (!B05())
            {
                failTest.Append("B05: Longer row array");
                score -= 5;
            }

            return score;
        }

        private static uint testVerticalMirror()
        {
            uint score = 25;

            if (!C00())
            {
                failTest.Append("C00: 1x1 Array");
                score -= 4;
            }

            if (!C01())
            {
                failTest.Append("C01: Only row array");
                score -= 4;
            }

            if (!C02())
            {
                failTest.Append("C02: Only column array");
                score -= 4;
            }

            if (!C03())
            {
                failTest.Append("C03: NxN Array");
                score -= 4;
            }

            if (!C04())
            {
                failTest.Append("C04: Longer column array");
                score -= 4;
            }

            if (!C05())
            {
                failTest.Append("C05: Longer row array");
                score -= 5;
            }

            return score;
        }

        private static uint testDiagonalShift()
        {
            uint score = 25;

            if (!D00())
            {
                failTest.Append("D00: 1x1 Array");
                score -= 4;
            }

            if (!D01())
            {
                failTest.Append("D01: Only row array");
                score -= 4;
            }

            if (!D02())
            {
                failTest.Append("D02: Only column array");
                score -= 4;
            }

            if (!D03())
            {
                failTest.Append("D03: NxN Array");
                score -= 4;
            }

            if (!D04())
            {
                failTest.Append("D04: Longer column array");
                score -= 4;
            }

            if (!D05())
            {
                failTest.Append("D05: Longer row array");
                score -= 5;
            }

            return score;
        }

        private static bool A00()
        {
            int[,] onlyOneData = { { 3 } };

            var result = Transform.Rotate90Degrees(onlyOneData);

            if (result[0, 0] != 3)
            {
                return false;
            }

            onlyOneData[0, 0] = 7;
            result = Transform.Rotate90Degrees(onlyOneData);

            if (result[0, 0] != 7)
            {
                return false;
            }

            onlyOneData[0, 0] = 9;
            result = Transform.Rotate90Degrees(onlyOneData);

            if (result[0, 0] != 9)
            {
                return false;
            }

            return true;
        }

        private static bool A01()
        {
            int[,] table1 =
            {
                { 205, 149, 23, 104, 55, 190, 39, 87, 73, 155, 220, },
            };

            int[,] expected1 =
            {
                { 205, },
                { 149, },
                { 23, },
                { 104, },
                { 55, },
                { 190, },
                { 39, },
                { 87, },
                { 73, },
                { 155, },
                { 220, },
            };

            var result = Transform.Rotate90Degrees(table1);

            if (!IsSameArray(expected1, result))
            {
                return false;
            }

            int[,] table2 =
            {
                { 61, 32, 122, 212, 42, 36, 187, 172, 179, 189, 204, 80, 69, 56, 93, },
            };

            int[,] expected2 =
            {
                { 61, },
                { 32, },
                { 122, },
                { 212, },
                { 42, },
                { 36, },
                { 187, },
                { 172, },
                { 179, },
                { 189, },
                { 204, },
                { 80, },
                { 69, },
                { 56, },
                { 93, },
            };

            result = Transform.Rotate90Degrees(table2);
            if (!IsSameArray(expected2, result))
            {
                return false;
            }

            int[,] table3 =
            {
                { 132, 226, 223, 76, 32, 116, 186, 149, 11, 179, 214, 67, 176, 41, 124, 24, 120, 131, 218, 50, },
            };

            int[,] expected3 =
            {
                { 132, },
                { 226, },
                { 223, },
                { 76, },
                { 32, },
                { 116, },
                { 186, },
                { 149, },
                { 11, },
                { 179, },
                { 214, },
                { 67, },
                { 176, },
                { 41, },
                { 124, },
                { 24, },
                { 120, },
                { 131, },
                { 218, },
                { 50, },
            };

            result = Transform.Rotate90Degrees(table3);
            if (!IsSameArray(expected3, result))
            {
                return false;
            }

            return true;
        }

        private static bool A02()
        {
            int[,] table4 =
            {
                { 15, },
                { 140, },
                { 139, },
                { 202, },
                { 73, },
                { 16, },
                { 20, },
                { 165, },
                { 20, },
                { 222, },
                { 247, },
            };

            int[,] expected4 =
            {
                { 247, 222, 20, 165, 20, 16, 73, 202, 139, 140, 15, },
            };

            var result = Transform.Rotate90Degrees(table4);
            if (!IsSameArray(expected4, result))
            {
                return false;
            }

            int[,] table5 =
            {
                { 232, },
                { 29, },
                { 181, },
                { 117, },
                { 54, },
                { 126, },
                { 156, },
                { 88, },
                { 28, },
                { 97, },
                { 50, },
                { 143, },
                { 238, },
                { 156, },
                { 52, },
            };

            int[,] expected5 =
            {
                { 52, 156, 238, 143, 50, 97, 28, 88, 156, 126, 54, 117, 181, 29, 232, },
            };

            result = Transform.Rotate90Degrees(table5);
            if (!IsSameArray(expected5, result))
            {
                return false;
            }

            int[,] table6 =
            {
                { 246, },
                { 88, },
                { 168, },
                { 170, },
                { 41, },
                { 41, },
                { 33, },
                { 239, },
                { 149, },
                { 133, },
                { 252, },
                { 74, },
                { 72, },
                { 239, },
                { 148, },
                { 176, },
                { 38, },
                { 24, },
                { 45, },
                { 36, },
            };

            int[,] expected6 =
            {
                { 36, 45, 24, 38, 176, 148, 239, 72, 74, 252, 133, 149, 239, 33, 41, 41, 170, 168, 88, 246, },
            };

            result = Transform.Rotate90Degrees(table6);
            if (!IsSameArray(expected6, result))
            {
                return false;
            }
            return true;
        }

        private static bool A03()
        {
            return true;
        }

        private static bool A04()
        {
            return false;
        }

        private static bool A05()
        {
            return false;
        }

        private static bool B00()
        {
            return false;
        }

        private static bool B01()
        {
            return false;
        }

        private static bool B02()
        {
            return false;
        }

        private static bool B03()
        {
            int[,] table =
            {
                { -46, -40, -76, -77, -31, 42, -15, -68, 4, 50, -33, 60, -94, 78, -80, },
                { -93, -21, -38, 59, -78, 13, 43, 70, 27, 95, -5, -92, -35, -13, 78, },
                { 94, -18, -7, -73, -45, -39, 77, 34, -75, 18, 41, -16, -52, 32, -79, },
                { -82, 63, 78, 95, 70, -8, 92, 99, 78, -50, 93, -56, 68, -59, -1, },
                { -86, 51, 29, -71, 39, -50, 5, 45, 5, 28, 72, -77, -84, 27, -40, },
                { 22, 80, -98, 98, 19, 9, 24, 23, -64, 29, -94, 82, -19, 10, -90, },
                { 94, -63, 71, -99, -44, -21, -80, 90, 35, 30, 56, 48, -20, -34, 89, },
                { 35, 92, 34, -35, -93, -20, -43, 69, 91, 41, -2, -3, 1, -25, -50, },
                { -96, -23, 88, -67, 24, 68, 0, -57, 80, 80, 78, -46, -17, -46, 54, },
                { -92, 23, -37, -64, 28, -76, -81, -8, -87, 81, -15, 75, -43, 19, -66, },
            };

            int[,] copy =
            {
                { -46, -40, -76, -77, -31, 42, -15, -68, 4, 50, -33, 60, -94, 78, -80, },
                { -93, -21, -38, 59, -78, 13, 43, 70, 27, 95, -5, -92, -35, -13, 78, },
                { 94, -18, -7, -73, -45, -39, 77, 34, -75, 18, 41, -16, -52, 32, -79, },
                { -82, 63, 78, 95, 70, -8, 92, 99, 78, -50, 93, -56, 68, -59, -1, },
                { -86, 51, 29, -71, 39, -50, 5, 45, 5, 28, 72, -77, -84, 27, -40, },
                { 22, 80, -98, 98, 19, 9, 24, 23, -64, 29, -94, 82, -19, 10, -90, },
                { 94, -63, 71, -99, -44, -21, -80, 90, 35, 30, 56, 48, -20, -34, 89, },
                { 35, 92, 34, -35, -93, -20, -43, 69, 91, 41, -2, -3, 1, -25, -50, },
                { -96, -23, 88, -67, 24, 68, 0, -57, 80, 80, 78, -46, -17, -46, 54, },
                { -92, 23, -37, -64, 28, -76, -81, -8, -87, 81, -15, 75, -43, 19, -66, },
            };

            int[,] expected =
            {
                { -80, 78, -94, 60, -33, 50, 4, -68, -15, 42, -31, -77, -76, -40, -46, },
                { 78, -13, -35, -92, -5, 95, 27, 70, 43, 13, -78, 59, -38, -21, -93, },
                { -79, 32, -52, -16, 41, 18, -75, 34, 77, -39, -45, -73, -7, -18, 94, },
                { -1, -59, 68, -56, 93, -50, 78, 99, 92, -8, 70, 95, 78, 63, -82, },
                { -40, 27, -84, -77, 72, 28, 5, 45, 5, -50, 39, -71, 29, 51, -86, },
                { -90, 10, -19, 82, -94, 29, -64, 23, 24, 9, 19, 98, -98, 80, 22, },
                { 89, -34, -20, 48, 56, 30, 35, 90, -80, -21, -44, -99, 71, -63, 94, },
                { -50, -25, 1, -3, -2, 41, 91, 69, -43, -20, -93, -35, 34, 92, 35, },
                { 54, -46, -17, -46, 78, 80, 80, -57, 0, 68, 24, -67, 88, -23, -96, },
                { -66, 19, -43, 75, -15, 81, -87, -8, -81, -76, 28, -64, -37, 23, -92, },
            };

            Transform.TransformArray(table, EMode.HorizontalMirror);

            if (!IsSameArray(expected, table))
            {
                return false;
            }

            Transform.TransformArray(table, EMode.HorizontalMirror);

            return IsSameArray(copy, table);
        }

        private static bool B04()
        {
            return false;
        }

        private static bool B05()
        {
            return false;
        }

        private static bool C00()
        {
            return false;
        }

        private static bool C01()
        {
            return false;
        }

        private static bool C02()
        {
            return false;
        }

        private static bool C03()
        {
            return false;
        }

        private static bool C04()
        {
            return false;
        }

        private static bool C05()
        {
            return false;
        }

        private static bool D00()
        {
            return false;
        }

        private static bool D01()
        {
            return false;
        }

        private static bool D02()
        {
            return false;
        }

        private static bool D03()
        {
            return false;
        }

        private static bool D04()
        {
            return false;
        }

        private static bool D05()
        {
            return false;
        }

        static void TestVerticalMirror()
        {
            int[,] table =
            {
                { -46, -40, -76, -77, -31, 42, -15, -68, 4, 50, -33, 60, -94, 78, -80, },
                { -93, -21, -38, 59, -78, 13, 43, 70, 27, 95, -5, -92, -35, -13, 78, },
                { 94, -18, -7, -73, -45, -39, 77, 34, -75, 18, 41, -16, -52, 32, -79, },
                { -82, 63, 78, 95, 70, -8, 92, 99, 78, -50, 93, -56, 68, -59, -1, },
                { -86, 51, 29, -71, 39, -50, 5, 45, 5, 28, 72, -77, -84, 27, -40, },
                { 22, 80, -98, 98, 19, 9, 24, 23, -64, 29, -94, 82, -19, 10, -90, },
                { 94, -63, 71, -99, -44, -21, -80, 90, 35, 30, 56, 48, -20, -34, 89, },
                { 35, 92, 34, -35, -93, -20, -43, 69, 91, 41, -2, -3, 1, -25, -50, },
                { -96, -23, 88, -67, 24, 68, 0, -57, 80, 80, 78, -46, -17, -46, 54, },
                { -92, 23, -37, -64, 28, -76, -81, -8, -87, 81, -15, 75, -43, 19, -66, },
            };

            int[,] copy =
            {
                { -46, -40, -76, -77, -31, 42, -15, -68, 4, 50, -33, 60, -94, 78, -80, },
                { -93, -21, -38, 59, -78, 13, 43, 70, 27, 95, -5, -92, -35, -13, 78, },
                { 94, -18, -7, -73, -45, -39, 77, 34, -75, 18, 41, -16, -52, 32, -79, },
                { -82, 63, 78, 95, 70, -8, 92, 99, 78, -50, 93, -56, 68, -59, -1, },
                { -86, 51, 29, -71, 39, -50, 5, 45, 5, 28, 72, -77, -84, 27, -40, },
                { 22, 80, -98, 98, 19, 9, 24, 23, -64, 29, -94, 82, -19, 10, -90, },
                { 94, -63, 71, -99, -44, -21, -80, 90, 35, 30, 56, 48, -20, -34, 89, },
                { 35, 92, 34, -35, -93, -20, -43, 69, 91, 41, -2, -3, 1, -25, -50, },
                { -96, -23, 88, -67, 24, 68, 0, -57, 80, 80, 78, -46, -17, -46, 54, },
                { -92, 23, -37, -64, 28, -76, -81, -8, -87, 81, -15, 75, -43, 19, -66, },
            };

            int yLength = table.GetLength(0);
            int xLength = table.GetLength(1);

            Transform.TransformArray(table, EMode.VerticalMirror);
            for (int i = 0; i < yLength; ++i)
            {
                for (int j = 0; j < xLength; ++j)
                {
                    Debug.Assert(table[i, j] == copy[yLength - 1 - i, j]);
                }
            }

            Transform.TransformArray(table, EMode.VerticalMirror);
            for (int i = 0; i < yLength; ++i)
            {
                for (int j = 0; j < xLength; ++j)
                {
                    Debug.Assert(table[i, j] == copy[i, j]);
                }
            }
        }

        static void TestDiagonalShift()
        {
            // 6 x 6
            {
                int[,] table1 =
                {
                    { 41, 31, 21, 11, 1, 3 },
                    { 42, 32, 22, 12, 2, 50 },
                    { 43, 33, 23, 13, 3, 71},
                    { 44, 34, 24, 14, 4, 88 },
                    { 45, 35, 25, 15, 5, 0 },
                    { 46, 36, 26, 16, 6, 77 }
                };

                int[,] copyTable1 =
                {
                    { 41, 31, 21, 11, 1, 3 },
                    { 42, 32, 22, 12, 2, 50 },
                    { 43, 33, 23, 13, 3, 71},
                    { 44, 34, 24, 14, 4, 88 },
                    { 45, 35, 25, 15, 5, 0 },
                    { 46, 36, 26, 16, 6, 77 }
                };

                for (int i = 0; i < table1.Length; ++i)
                {
                    Transform.TransformArray(table1, EMode.DiagonalShift);
                }

                for (int i = 0; i < table1.GetLength(0); ++i)
                {
                    for (int j = 0; j < table1.GetLength(1); ++j)
                    {
                        Debug.Assert(table1[i, j] == copyTable1[i, j]);
                    }
                }

                int[,] oneShift =
                {
                    { 77, 46, 36, 26, 16, 6 },
                    { 3, 41, 31, 21, 11, 1 },
                    { 50, 42, 32, 22, 12, 2 },
                    { 71, 43, 33, 23, 13, 3 },
                    { 88, 44, 34, 24, 14, 4 },
                    { 0, 45, 35, 25, 15, 5 },
                };

                Transform.TransformArray(table1, EMode.DiagonalShift);

                for (int i = 0; i < table1.GetLength(0); ++i)
                {
                    for (int j = 0; j < table1.GetLength(1); ++j)
                    {
                        Debug.Assert(table1[i, j] == oneShift[i, j]);
                    }
                }
            }

            // 7 x 5
            {
                int[,] table1 =
                {
                    { 68, 75, 40, 94, 60, },
                    { 20, 76, 26, 71, 86, },
                    { 1, 1, 19, 45, 29, },
                    { 45, 39, 42, 71, 74, },
                    { 9, 1, 71, 98, 89, },
                    { 17, 50, 63, 86, 7, },
                    { 41, 91, 57, 91, 8, },
                };

                int[,] expected1 =
                {
                    { 8, 41, 91, 57, 91 },
                    { 60, 68, 75, 40, 94 },
                    { 86, 20, 76, 26, 71 },
                    { 29, 1, 1, 19, 45 },
                    { 74, 45, 39, 42, 71 },
                    { 89, 9, 1, 71, 98 },
                    { 7, 17, 50, 63, 86 }
                };

                Transform.TransformArray(table1, EMode.DiagonalShift);

                for (int i = 0; i < table1.GetLength(0); ++i)
                {
                    for (int j = 0; j < table1.GetLength(1); ++j)
                    {
                        Debug.Assert(table1[i, j] == expected1[i, j]);
                    }
                }

                int[,] table2 =
                {
                    { 37, 3, 7, 20, 54, },
                    { 12, 46, 91, 46, 87, },
                    { 25, 23, 10, 38, 4, },
                    { 9, 35, 39, 36, 59, },
                    { 6, 73, 82, 61, 52, },
                    { 23, 34, 60, 11, 99, },
                    { 15, 85, 38, 40, 12, },
                };

                int[,] expected2 =
                {
                    { 12, 15, 85, 38, 40 },
                    { 54, 37, 3, 7, 20 },
                    { 87, 12, 46, 91, 46 },
                    { 4, 25, 23, 10, 38 },
                    { 59, 9, 35, 39, 36 },
                    { 52, 6, 73, 82, 61 },
                    { 99, 23, 34, 60, 11 }
                };

                Transform.TransformArray(table2, EMode.DiagonalShift);

                for (int i = 0; i < table2.GetLength(0); ++i)
                {
                    for (int j = 0; j < table2.GetLength(1); ++j)
                    {
                        Debug.Assert(table2[i, j] == expected2[i, j]);
                    }
                }
            }

            // 6 x 8
            {
                int[,] table1 =
                {
                    { 55, 90, 87, 18, 78, 89, 47, 72, },
                    { 33, 83, 20, 70, 92, 18, 70, 53, },
                    { 74, 70, 32, 8, 82, 76, 10, 31, },
                    { 3, 29, 17, 83, 38, 8, 97, 2, },
                    { 23, 52, 90, 38, 39, 56, 56, 24, },
                    { 89, 58, 39, 97, 13, 94, 34, 73, },
                };

                int[,] expected1 =
                {
                    { 73, 89, 58, 39, 97, 13, 94, 34 },
                    { 72, 55, 90, 87, 18, 78, 89, 47 },
                    { 53, 33, 83, 20, 70, 92, 18, 70 },
                    { 31, 74, 70, 32, 8, 82, 76, 10 },
                    { 2, 3, 29, 17, 83, 38, 8, 97 },
                    { 24, 23, 52, 90, 38, 39, 56, 56 }
                };

                Transform.TransformArray(table1, EMode.DiagonalShift);

                for (int i = 0; i < table1.GetLength(0); ++i)
                {
                    for (int j = 0; j < table1.GetLength(1); ++j)
                    {
                        Debug.Assert(table1[i, j] == expected1[i, j]);
                    }
                }

                int[,] table2 =
                {
                    { 3, 26, 61, 98, 29, 82, 13, 21, },
                    { 56, 3, 11, 81, 26, 35, 7, 95, },
                    { 10, 17, 28, 27, 23, 34, 90, 56, },
                    { 80, 36, 48, 75, 2, 85, 56, 81, },
                    { 92, 32, 44, 70, 11, 71, 34, 12, },
                    { 19, 15, 17, 63, 1, 53, 27, 74, },
                };

                int[,] expected2 =
                {
                    { 74, 19, 15, 17, 63, 1, 53, 27 },
                    { 21, 3, 26, 61, 98, 29, 82, 13 },
                    { 95, 56, 3, 11, 81, 26, 35, 7 },
                    { 56, 10, 17, 28, 27, 23, 34, 90 },
                    { 81, 80, 36, 48, 75, 2, 85, 56 },
                    { 12, 92, 32, 44, 70, 11, 71, 34 }
                };

                Transform.TransformArray(table2, EMode.DiagonalShift);
                for (int i = 0; i < table2.GetLength(0); ++i)
                {
                    for (int j = 0; j < table2.GetLength(1); ++j)
                    {
                        Debug.Assert(table2[i, j] == expected2[i, j]);
                    }
                }
            }
        }

        static void TestRotate90Degrees()
        {
            int[,] table1 =
            {
                { 41, 31, 21, 11, 1 },
                { 42, 32, 22, 12, 2 },
                { 43, 33, 23, 13, 3 },
                { 44, 34, 24, 14, 4 },
                { 45, 35, 25, 15, 5 },
                { 46, 36, 26, 16, 6 }
            };

            int[,] expected1 =
            {
                { 46, 45, 44, 43, 42, 41 },
                { 36, 35, 34, 33, 32, 31 },
                { 26, 25, 24, 23, 22, 21 },
                { 16, 15, 14, 13, 12, 11 },
                { 6, 5, 4, 3, 2, 1 },
            };

            var result = Transform.Rotate90Degrees(table1);

            Debug.Assert(result.GetLength(0) == expected1.GetLength(0));
            Debug.Assert(result.GetLength(1) == expected1.GetLength(1));

            for (int i = 0; i < result.GetLength(0); ++i)
            {
                for (int j = 0; j < result.GetLength(1); ++j)
                {
                    Debug.Assert(result[i, j] == expected1[i, j]);
                }
            }

            result = Transform.Rotate90Degrees(result);

            int[,] expected2 =
            {
                { 6, 16, 26, 36, 46 },
                { 5, 15, 25, 35, 45 },
                { 4, 14, 24, 34, 44 },
                { 3, 13, 23, 33, 43 },
                { 2, 12, 22, 32, 42 },
                { 1, 11, 21, 31, 41 }
            };

            Debug.Assert(result.GetLength(0) == expected2.GetLength(0));
            Debug.Assert(result.GetLength(1) == expected2.GetLength(1));

            for (int i = 0; i < result.GetLength(0); ++i)
            {
                for (int j = 0; j < result.GetLength(1); ++j)
                {
                    Debug.Assert(result[i, j] == expected2[i, j]);
                }
            }
        }
    }
}