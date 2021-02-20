using System;
using System.Collections.Generic;
using System.Linq;
namespace ArraysCoordinates
{
  

    
        class Program
        {
              // From the sample multi-dimensional array to find same value and print the coordinates.

            public static int[,] matrix = new int[,] { { 1, 3, 2, 2, 2, 4 },
                                                 { 3, 3, 3, 2, 4, 4 },
                                                 { 4, 3, 1, 2, 3, 3 },
                                                 { 4, 3, 1, 3, 3, 1 },
                                                 { 4, 3, 3, 3, 1, 1,}
                                   };

            public static int[] UpAndDownLeftAndRight(int[] coordinates)
            {
                int[] upAndDown = new int[coordinates.Length];
                for (int i = 0; i < coordinates.Length - 1; i++)
                {
                    for (int j = 0; j < coordinates.Length - 1; j++)
                    {


                        if (coordinates[i] + 10 == coordinates[i + 1] || coordinates[i] + 10 == coordinates[j + 1] || coordinates[i] + 1 == coordinates[i + 1])
                        {
                            upAndDown[i] = coordinates[i];
                            upAndDown[i + 1] = coordinates[i + 1];

                        }
                    }
                }
                return upAndDown;
            }


            public static int[] LeftandRight(int[] coordinates)
            {
                int[] leftRight = new int[15];
                for (int i = 0; i < coordinates.Length - 1; i++)
                {
                    if (coordinates[i] + 1 == coordinates[i + 1])
                    {
                        leftRight[i] = coordinates[i];
                        leftRight[i + 1] = coordinates[i + 1];
                    }
                }
                return leftRight;
            }

            public static void PrintArray(int[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != 0)
                    {
                        Console.WriteLine(i + ". " + array[i]);
                    }

                }
            }

            public static void PrintDictionary(IDictionary<int, int> number)
            {
                foreach (var item in number)
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }
            }

            public static IDictionary<int, int> FillWithCoordinates()
            {
                IDictionary<int, int> threes = new Dictionary<int, int>();
                int value = 0;
                int counter = 1;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {

                        string a = i.ToString() + j.ToString();
                        value = Convert.ToInt32(a);
                        int key = counter;
                        threes.TryAdd(key, value);


                    }
                    counter++;
                }
                return threes;
            }

            public static IDictionary<int, int> FillTheDictionary(int value)
            {
                IDictionary<int, int> numbersCoordinates = new Dictionary<int, int>();

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == value)
                        {
                            string a = i.ToString() + j.ToString();
                            int convert = Convert.ToInt32(a);
                            numbersCoordinates.TryAdd(convert, value);
                        }
                    }
                }

                return numbersCoordinates;
            }

            public static int[] GetDistictInts(int[,] matrix)
            {
                int[] tempDistictInts = new int[matrix.Length];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (!IsExistingInArray(matrix[i, j], tempDistictInts))
                        {
                            AddInArray(matrix[i, j], tempDistictInts);
                        }
                    }
                }
                return FilterZeroItems(tempDistictInts);

                throw new NotImplementedException();
            }

            public static int[] FilterZeroItems(int[] numbers)
            {
                int numbersNotZeroCounter = 0;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] != 0)
                    {
                        numbersNotZeroCounter++;
                    }
                }
                int[] notZeroArray = new int[numbersNotZeroCounter];
                for (int i = 0, j = 0; i < numbers.Length; i++, j++)
                {
                    if (numbers[i] != 0)
                    {
                        notZeroArray[j] = numbers[i];
                    }
                }
                return notZeroArray;
            }

            public static bool IsExistingInArray(int number, int[] numbers)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == number)
                    {
                        return true;
                    }
                }
                return false;
            }

            public static void AddInArray(int number, int[] numbers)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == 0)
                    {
                        numbers[i] = number;
                        return;
                    }
                }
                throw new ArgumentException("Array is full");
            }

            public static int[] SortedArray(int[] numbers)
            {
                Array.Sort(numbers);
                return numbers;
            }

            public static int[,] GetAllCoordinatesForNumber(int number, int[,] matrix)
            {
                int[,] currentNumberCoordinates = new int[matrix.Length, 2];
                int coordinatesCounter = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)

                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == number)
                        {
                            coordinatesCounter++;
                            currentNumberCoordinates[coordinatesCounter, 0] = i;
                            currentNumberCoordinates[coordinatesCounter, 1] = j;
                        }
                    }
                }
                return currentNumberCoordinates;
            }

            public static int[] ValidNeighbours(int[] validN)
            {
                int[] validNei = new int[validN.Length];

                for (int i = 0; i < validN.Length - 1; i++)
                {
                    for (int j = 0; j < validN.Length - 2; j++)
                    {
                        if (validN[i] + 1 == validN[i + 1] || validN[i] + 10 == validN[j])
                        {
                            validNei.Append(validN[i]);
                        }
                        else
                        {

                        }
                    }
                }

                return validNei;

            }

            public static bool CheckAllNeighbours(int[] myarray)
            {
                bool validNeighbours = false;
                for (int i = 0; i < myarray.Length - 1; i++)
                {
                    for (int j = 1; j < myarray.Length - 1; j++)
                    {
                        for (int k = 2; k < myarray.Length - 2; k++)
                        {
                            if (myarray[i] + 1 == myarray[j] || myarray[i] + 10 == myarray[j] || myarray[i] + 10 == myarray[k])
                            {
                                validNeighbours = true;
                            }
                        }

                    }

                }
                return validNeighbours;
            }



            static void Main()
            {
                // 
                int[] distinctInts = GetDistictInts(matrix);
                IDictionary<int, int> threes = FillTheDictionary(3);
                IDictionary<int, int> twos = FillTheDictionary(2);
                IDictionary<int, int> ones = FillTheDictionary(1);
                IDictionary<int, int> fours = FillTheDictionary(4);
                int[] coordinatesOfThrees = threes.Keys.ToArray();
                PrintArray(coordinatesOfThrees);
                Console.WriteLine();
                int[] threesUpDown = UpAndDownLeftAndRight(coordinatesOfThrees);
                bool checkedNeighOfThrees = CheckAllNeighbours(coordinatesOfThrees);
                Console.WriteLine("Are all the coordinates connected?:" + checkedNeighOfThrees);
                Console.WriteLine("The maximal sequence of elements in the given area is {0} with value 3.", threesUpDown.Count());

                Console.WriteLine();
                Console.WriteLine();


                int[] coordOfTwos = twos.Keys.ToArray();
                PrintArray(coordOfTwos);
                int[] twosUpOrDown = UpAndDownLeftAndRight(coordOfTwos);
                bool checkedNeighOfTwos = CheckAllNeighbours(coordOfTwos);
                Console.WriteLine("Are all the coordinates connected?:" + checkedNeighOfTwos);
                Console.WriteLine();
                Console.WriteLine("The maximal sequence of elements in the given area is {0} with value 2.", twosUpOrDown.Count());






            }




        }

    }



