using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace Practice
{
    #region 14. TurningLightOn

    class TurningLightOn
    {
        public int minFlips(string[] board)
        {
            int m = board.Length;
            int n = board[0].Length;
            int[] operations = new int[n];
            bool isZero = true;
            for (int i = m - 1; i >= 0; i--)
            {
                int curOperations = 0;
                bool[] curStringBits = new bool[n];
                for (int j = 0; j < n; j++)
                {
                    curStringBits[j] = board[i][j] == '1' ? true : false;
                }
                for (int j = 0; j < n; j++)
                {
                    curStringBits[j] = ((operations[j] & 1) == 0 ? curStringBits[j] : !curStringBits[j]);
                }
                isZero = true;
                for (int j = n - 1; j >= 0; j--)
                {
                    if (isZero && !curStringBits[j])
                    {
                        curOperations++;
                    }
                    else if (!isZero && curStringBits[j])
                    {
                        curOperations++;
                    }
                    else
                    {
                        operations[j] += curOperations;
                        continue;
                    }
                    isZero = !isZero;
                    operations[j] += curOperations;
                }
            }

            return operations[0];
        }
    }

    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            #region 14. TurningLightOn

            TurningLightOn turningLightOn = new TurningLightOn();
            Console.WriteLine(turningLightOn.minFlips(["0001111", "0001111", "1111111"]));
            Console.WriteLine(turningLightOn.minFlips(["1111111", "1111111", "1111111"]));
            Console.WriteLine(turningLightOn.minFlips(["01001"]));
            Console.WriteLine(turningLightOn.minFlips(["0101", "1010", "0101", "1010"]));
            #endregion
        }
    }
}