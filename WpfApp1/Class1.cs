using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Class1
    {
        public static void createTable(char[,] anyTable, int row, char[] anyAlph)
        {
            for (int i = 0; i < anyAlph.Length; i++)
            {
                for (int j = 0; j < anyAlph.Length; j++)
                {
                    row = i + j;
                    if (row >= 32)
                    {
                        row %= 32;
                    }
                    anyTable[i, j] = anyAlph[row];
                }
            }
        }
        public static void createRusAlph(char[] anyAlph)
        {
            int num = 1;
            anyAlph[0] = System.Convert.ToChar(1103);
            for (int i = 1072; i <= 1102; i++)
            {
                anyAlph[num] = System.Convert.ToChar(i);
                num++;
            }
        }
    }
}
