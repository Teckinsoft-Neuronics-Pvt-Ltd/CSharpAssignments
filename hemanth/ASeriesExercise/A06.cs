using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASeriesExercise; 
public class A06 {
    public void QueensProblem() {
        List<int[]> queenTables = [];
        int[] actualRow = [-1, -1, -1, -1, -1, -1, -1, -1];
        int[] sumDiagonal = [-1, -1, -1, -1, -1, -1, -1, -1];
        int[] diffDiagonal = [10, 10, 10, 10, 10, 10, 10, 10];
        int j = 0;

        bool NotContains(int[] arr) {
            foreach (var table in queenTables) {
                bool isSame = true;
                for (int m = 0; m < 8; m++)
                    if (table[m] != arr[m]) {
                        isSame = false;
                        break;
                    }

                if (isSame) return false;
            }
            return true;
        }

        void SetInfo(int index, int value, int diff, int sum) {
            actualRow[index] = value;
            diffDiagonal[index] = diff;
            sumDiagonal[index] = sum;
        }

        for (int i = 0; i < 8; i++) {
            for (; j < 8; j++) 
                if (!actualRow.Contains(j) && 
                    !diffDiagonal.Contains(i - j) && 
                    !sumDiagonal.Contains(i + j)) {
                    SetInfo(i, j, i - j, i + j);
                    break;
                }

            if (actualRow[i] == -1) {
                if (i == 0) break;
                j = actualRow[i - 1] + 1;
                SetInfo(i - 1, -1, 10, -1);
                i -= 2;
            }
            else if (i == 7) {
                RotatedTables(actualRow, out int[] rightArr,
                    out int[] leftArr, out int[] reverseArr);

                if (NotContains(rightArr) 
                    && NotContains(leftArr)
                    && NotContains(reverseArr))
                    queenTables.Add(actualRow.ToArray());
                j = actualRow[i - 1] + 1;
                SetInfo(i - 1, -1, 10, -1);
                i -= 2;
            }
            else j = 0;
        }

        PrintAll(queenTables);
    }

    private void PrintAll(List<int[]> queenTables) {
        foreach (var table in queenTables)
            PrintBoard(table);

        foreach (var table in queenTables) {
            Console.WriteLine();
            Console.Write($"{queenTables.IndexOf(table) + 1,-4}- ");
            foreach (var row in table) {
                Console.Write(row + " ");
            }
        }
    }

    private void RotatedTables(int[] actualRow, out int[] rightArr, out int[] leftArr, out int[] reverseArr) {
        rightArr = new int[8];
        leftArr = new int[8];
        reverseArr = new int[8];
        for (int k = 0; k < 8; k++)
            rightArr[actualRow[k]] = 7 - k;

        for (int k = 0; k < 8; k++)
            leftArr[k] = 7 - rightArr[7 - k];

        for (int k = 0; k < 8; k++)
            reverseArr[k] = 7 - actualRow[7 - k];
    }

    private void PrintBoard(int[] queens) {
        Console.OutputEncoding = new UnicodeEncoding();

        Console.WriteLine("┌───┬───┬───┬───┬───┬───┬───┬───┐");                 //Top Border
        for (int row = 0; row < 8; row++) {
            Console.Write("\u2502");                                            //Left Border
            for (int col = 0; col < 8; col++)
                if (queens[row] == col) Console.Write(" \u2655 \u2502");        //Queen Box
                else Console.Write("   \u2502");                                //Empty Box

            Console.WriteLine();
            if (row < 7) Console.WriteLine("├───┼───┼───┼───┼───┼───┼───┼───┤");//Row Seperator
        }
        Console.WriteLine("└───┴───┴───┴───┴───┴───┴───┴───┘");                 //Bottom Border
        Console.WriteLine();
    }
}
