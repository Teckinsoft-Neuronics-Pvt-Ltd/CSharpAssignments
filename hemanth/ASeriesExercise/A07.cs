using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ASeriesExercise; 
public class A07 {
    public void ParseDouble() {
        string value = Console.ReadLine()!;
        double number = 0;
        int i = 0;
        bool isMinus = false;
        if (i < value.Length && value[i] is '+' or '-')
            isMinus = value[i++] == '-';

        for (; i < value.Length && value[i] is >= '0' and <= '9'; i++)
            number = number * 10 + (value[i] - '0');

        if (i < value.Length && value[i] == '.') {
            i++;
            double decimalNumber = 0;
            for (double j = 0.1; i < value.Length && value[i] is >= '0' and <= '9'; j /= 10, i++)
                decimalNumber += (value[i] - '0') * j;
            number += decimalNumber;
        }

        if (isMinus) number *= -1;

        if (i < value.Length && value[i++] == 'e') {
            bool isEMinus = false;
            if (i < value.Length && value[i] is '+' or '-') {
                isEMinus = value[i] == '-';
                i++;
            }

            int eNumber = 0;
            for (; i < value.Length && value[i] is >= '0' and <= '9'; i++)
                eNumber = eNumber * 10 + (value[i] - '0');
            
            if (isEMinus) eNumber *= -1;
            number *= Math.Pow(10, eNumber);
        }

        Console.WriteLine(number);
    }
}
