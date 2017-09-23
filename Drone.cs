using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Algorithm.Logic
{
    public class Drone
    {
        private int[,] map { get; set; }
        const string coords = "N,S,L,O";
        const int LIMIT = 2147483647;

        public Drone()
        {
            map = new int[,] { { 0, 0 } };
        }

        public void SetDirection(char operation, int value = 1)
        {
            if (operation == 'N')
            {
                this.map[0, 1] += value;
            }
            if (operation == 'S')
            {
                this.map[0, 1] -= value;
            }
            if (operation == 'L')
            {
                this.map[0, 0] += value;
            }
            if (operation == 'O')
            {
                this.map[0, 0] -= value;
            }
        }

        public String GetCartesian()
        {
            return "(" + map[0, 0] + ", " + map[0, 1] + ")";
        }

        public Boolean IsValidCoord(char c)
        {
            return coords.Contains(c.ToString());
        }

        public Boolean IsDigit(char c)
        {
            return c.ToString().All(char.IsDigit);
        }

        public Boolean IsValidCharacter(char c)
        {
            if (IsValidCoord(c) || IsDigit(c) || c == 'X')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public String Fly(string input)
        {
            if (input == null || input == "")
            {
                return "(999, 999)";
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!IsValidCharacter(input[i]))
                {
                    return "(999, 999)";
                }

                if (i == 0 && IsDigit(input[i]))
                {
                    return "(999, 999)";
                }

                SetAxis(input, input[i]);
                if (input[i] == 'X')
                {
                    var countSteps = true;
                    var position = i;
                    if(i < input.Length-1 && IsDigit(input[i + 1]))
                        return "(999, 999)";
                    if (position < input.Length - 1 && input[position + 1] == 'X')
                    {
                        var qtdX = 0;
                        var validCoord = input.Length - 1;
                        for (int j = position; j < input.Length; j++)
                        {
                            if (IsValidCoord(input[j]))
                            {
                                validCoord = j;
                                break;
                            }
                            qtdX++;
                        }
                        for (int j = position - 1; j >= position - qtdX; j--)
                        {
                            SetDirection(input[j], -1);
                            WriteLine(input[j]);
                        }
                        continue;
                    }
                    while (countSteps)
                    {
                        if (position - 1 > 0 && IsValidCoord(input[position - 1]))
                        {
                            SetDirection(input[position - 1], -1);
                            countSteps = false;
                            break;
                        }
                        else if (IsDigit(input[position - 1]))
                        {
                            string num = "";
                            char lastOperation = input[i - 1];
                            int pos = i - 1;

                            for (int p = i - 1; p >= 0; p--)
                            {
                                if (IsValidCoord(input[p]))
                                {
                                    lastOperation = input[p];
                                    break;
                                }
                                else
                                {
                                    num = num.Insert(0, input[p].ToString());
                                }
                            }

                            int.TryParse(num, out int valNum);
                            if (valNum >= LIMIT)
                                SetDirection(lastOperation, -valNum);
                            else
                                SetDirection(lastOperation, -valNum);
                            break;
                        }
                        else
                        {
                            break;
                        }

                    }
                }

                if (IsDigit(input[i]))
                {
                    string num = "";
                    char operation = input[i - 1];
                    for (int j = i; j < input.Length; j++)
                    {
                        if (!IsDigit(input[j]))
                        {
                            i = j - 1;
                            break;
                        }
                        num += input[j];
                    }

                    int.TryParse(num, out int valNum);
                    if ((valNum < 1 || valNum >= LIMIT) && (i < input.Length - 1 && input[i + 1] != 'X'))
                    {

                        return "(999, 999)";
                    }
                    if (i < input.Length - 1 && input[i + 1] == 'X')
                    {
                        SetDirection(operation, valNum - 1);
                        continue;
                    }
                    SetDirection(operation, valNum - 1);

                }
            }
            SetAxis(input)
            return GetCartesian();
        }
    }
}
