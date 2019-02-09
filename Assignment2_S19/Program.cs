using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assignment2_S19
{
    class Program
    {
        static void Main(string[] args)
        {
            // left rotation
            Console.WriteLine("Left Rotation");
            int d = 4;
            int[] a = { 1, 2, 3, 4, 5 };
            int[] r = rotLeft(a, d);
            displayArray(r);

            // Maximum toys
            Console.WriteLine("\n\nMaximum toys");
            int k = 50;
            int[] prices = { 1, 12, 5, 111, 200, 1000, 10 };
            Console.WriteLine(maximumToys(prices, k));

            // Balanced sums
            Console.WriteLine("\n\nBalanced sums");
            List<int> arr = new List<int> { 1, 2, 3 };
            Console.WriteLine(balancedSums(arr));

            // Missing numbers
            Console.WriteLine("\n\nMissing numbers");
            Debug.WriteLine("\n\nMissing numbers");
            //int[] arr1 = { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206};
            int[] arr1 = { 203, 204, 205, 206, 208, 203, 204, 205, 206 };
            int[] brr = {203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204};
            int[] r2 = missingNumbers(arr1, brr);
            displayArray(r2);

            // grading students
            Console.WriteLine("\n\nGrading students");
            Debug.WriteLine("\n\nGrading students");
            int[] grades = { 73, 67, 38, 33 };
            int[] r3 = gradingStudents(grades);
            displayArray(r3);

            // find the median
            Console.WriteLine("\n\nFind the median");
            Debug.WriteLine("\n\nFind the median");
            int[] arr2 = { 0, 1, 2, 4, 6, 5, 3};
            Console.WriteLine(findMedian(arr2));
            Debug.WriteLine(findMedian(arr2));

            // closest numbers
            Console.WriteLine("\n\nClosest numbers");
            Debug.WriteLine("\n\nClosest numbers");
            int[] arr3 = { 5, 4, 3, 2 };
            /*{ -20, -3916237, -357920, -3620601,
               7374819, -7330761, 30, 6246457,
                -6461594, 266854, -520, -470 };*/
            int[] r4 = closestNumbers(arr3);
            displayArray(r4);

            // Day of programmer
            Console.WriteLine("\n\nDay of Programmer");
            Debug.WriteLine("\n\nDay of Programmer");
            int year = 2017;
            Console.WriteLine(dayOfProgrammer(year));
            Debug.WriteLine(dayOfProgrammer(year));
        }

        static void displayArray(int []arr) {
            Console.WriteLine();
            foreach(int n in arr) {
                Console.Write(n + " ");
                Debug.Write(n + " ");
            }
        }

        // Complete the rotLeft function below.
        static int[] rotLeft(int[] a, int d)
        {
            return new int[] {};
        }

        // Complete the maximumToys function below.
        static int maximumToys(int[] prices, int k)
        {
            return 0;
        }

        // Complete the balancedSums function below.
        static string balancedSums(List<int> arr)
        {
            return "";
        }

        // Complete the missingNumbers function below.
        static int[] missingNumbers(int[] arr, int[] brr)
        {
            List<int> missingNumberList = new List<int>();

            if (brr == null || brr.Length == 0)        //make sure the array has values. Otherwise, return an error message
            {
                Console.WriteLine("Please provide a non-empty array of integers");
                return missingNumberList.ToArray();
            }

            //TODO: find difference between min max elements of B whether it's less than or equal 100


            try
            {
                Dictionary<int, int> dicA = frequencyMap(arr);
                Dictionary<int, int> dicB = frequencyMap(brr);
                
                foreach (int keyB in dicB.Keys)
                {
                    int occurrenceKeyBInA = 0;
                    if(dicA.ContainsKey(keyB))
                    {
                        occurrenceKeyBInA = dicA[keyB];
                    }

                    int occurrenceKeyBInB = dicB[keyB];

                    if(occurrenceKeyBInB > occurrenceKeyBInA)
                    {
                        missingNumberList.Add(keyB);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing missingNumber()");
            }

            return missingNumberList.ToArray();
        }


        static Dictionary<int, int> frequencyMap(int[] a)
        {
            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            for (int i = 0; i < a.Length; i++)     //loop through the ptovided array of integers
            {
                if (freqMap.ContainsKey(a[i]))      //if the current integer is already in the dictionary, increase the frequency by 1
                {
                    freqMap[a[i]] = freqMap[a[i]] + 1;
                }
                else
                {
                    freqMap.Add(a[i], 1);           //otherwise, add the current integer to the dictionary and set its frequency to 1
                }
            }
            return freqMap;
        }

        // Complete the gradingStudents function below.
        static int[] gradingStudents(int[] grades)
        {
            if (grades == null || grades.Length == 0)        //make sure the array has values. Otherwise, return an error message
            {
                Console.WriteLine("Please provide a non-empty array of integers");
            }
            try
            {
                int[] roundedGrades = new int[grades.Length];
                for (int i = 0; i < grades.Length; i++)
                {
                    if (grades[i] > 38)
                    {
                        int q = grades[i] / 5;
                        int r = grades[i] % 5;
                        if (r >= 3)
                        {
                            roundedGrades[i] = 5 * (q + 1);
                        }
                        else
                        {
                            roundedGrades[i] = grades[i];
                        }
                    }
                    else
                    {
                        roundedGrades[i] = grades[i];
                    }
                }
                return roundedGrades;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing gradingStudents()");
            }
            return new int[] { };
        }

        // Complete the findMedian function below.
        static int findMedian(int[] arr)
        {
            try
            {
                int arrSize = arr.Length;
                // At least one element to find Median
                if (arrSize > 0)
                {
                    Array.Sort(arr); //TODO
                    //n is odd, then return the middle element
                    if (arrSize % 2 != 0) 
                    {
                        return arr[(arrSize - 1) / 2];
                    }
                    //n is even, then return mean of two middle values
                    else
                    {
                        int mean = (arr[(arrSize / 2 - 1)] + arr[arrSize / 2]) / 2;
                        return mean;
                    }
                }
                else if (arrSize == 0)
                {
                    Debug.WriteLine("Bad input. The array is empty");
                }
            }
            catch
            {
                Debug.WriteLine("Exception occured while computing findMedian()");
            }
            return 0;
        }

        // Complete the closestNumbers function below.
        static int[] closestNumbers(int[] arr)
        {
            try
            {
                int arrSize = arr.Length;
                // At least two element to find smallest absolute difference
                if (arrSize >= 2)
                {
                    List<int> result = new List<int>();
                    Array.Sort(arr); //TODO

                    //Initialize smallestDifference with first two elements abs difference
                    int smallestDifference = Math.Abs(arr[1] - arr[0]); 
                    result.Add(arr[0]);
                    result.Add(arr[1]);

                    if (arrSize == 2)
                    {
                        return result.ToArray();
                    }
                    else
                    {
                        for (int i = 1; i < arrSize - 1; i++)
                        {
                            int absDifference = Math.Abs(arr[i + 1] - arr[i]);

                            //A smallestDifference was found
                            if (absDifference < smallestDifference)
                            {
                                smallestDifference = absDifference;
                                //Reset result and add new pair
                                result = new List<int>();
                                result.Add(arr[i]);
                                result.Add(arr[i + 1]);
                            }
                            //Found a new pair that matches the current smallesDifference
                            else if (absDifference == smallestDifference)
                            {
                                //Add new pair
                                result.Add(arr[i]);
                                result.Add(arr[i + 1]);
                            }
                        }
                        return result.ToArray();
                    }
                }
                else
                {
                    Debug.WriteLine("Bad input. The array should have at least two elements");
                }
            }
            catch
            {
                Debug.WriteLine("Exception occured while computing closestNumbers()");
            }
            return new int[] { };
        }

        // Complete the dayOfProgrammer function below.
        static string dayOfProgrammer(int year)
        {
            try
            {
                //Check Calendar (Julian, Gregorian or Transition Year 1918) 
                if (1700 <= year && year <= 1917) //Julian
                {
                    if (checkJulianLeapYear(year))
                    {
                        //If leap Feb has 29 days
                        int sumFirst8MonthsDays = 31 + 29 + 31 + 30 + 31 + 30 + 31 + 31;
                        int toReach256Day = 256 - sumFirst8MonthsDays;
                        return toReach256Day.ToString() + ".09." + year.ToString();
                    }
                    else
                    {
                        //If no leap Feb has 28 days
                        int sumFirst8MonthsDays = 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31;
                        int toReach256Day = 256 - sumFirst8MonthsDays;
                        return toReach256Day.ToString() + ".09." + year.ToString();
                    }
                }
                else if (1919 <= year && year <= 2700) //Gregorian
                {
                    if (checkGregorianLeapYear(year))
                    {
                        //If leap Feb has 29 days
                        int sumFirst8MonthsDays = 31 + 29 + 31 + 30 + 31 + 30 + 31 + 31;
                        int toReach256Day = 256 - sumFirst8MonthsDays;
                        return toReach256Day.ToString() + ".09." + year.ToString();
                    }
                    else
                    {
                        //If no leap Feb has 28 days
                        int sumFirst8MonthsDays = 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31;
                        int toReach256Day = 256 - sumFirst8MonthsDays;
                        return toReach256Day.ToString() + ".09." + year.ToString();
                    }
                }
                else if (year == 1918) //Transition Year 1918
                {
                    //1918 is not a leap year neither under Julian or 
                    //Gregorian rules, this means that in 1918 February had 28 days.
                    //Considering Feb 14th was the 32nd day of the 1918, 
                    //February only had 14 days left that year (28-14).
                    //Therefore, the 256th day of that year was: 
                    // 31 (Jan) + 14 (Feb) + 31 (Mar) + 30 (Apr)
                    // 31 (May) + 30 (Jun) + 31 (Jul) + 31 (Ago) 
                    // Totals = 229 days 
                    // Minus 256, (256 - 229 = 27 days) 
                    // Then, the 256th day of the Transition year 
                    // was Sept 27th
                    int sumFirst8MonthsDays = 31 + 14 + 31 + 30 + 31 + 30 + 31 + 31;
                    int toReach256Day = 256 - sumFirst8MonthsDays;
                    return toReach256Day.ToString() + ".09." + year.ToString();
                }
                else //Year out of range 1700 to 2700
                {
                    Debug.WriteLine("Bad Input - Year out of range 1700-2700");
                }
            }
            catch
            {
                Debug.WriteLine("Exception occured while computing dayOfProgrammer()");
            }
            return "";
        }

        static bool checkJulianLeapYear(int year)
        {
            //All years divisible by 4 are leap years under the Julian calendar
            if (year % 4 == 0)
            {
                return true;
            }
            return false;
        }

        static bool checkGregorianLeapYear(int year)
        {
            // All years either 
            // - Divisible by 400 or 
            // - Divisible by 4 but not by 100 
            // are leap years
            if ((year % 400 == 0) || ((year % 4 == 0) && (year % 100 != 0)))
            {
                return true;
            }
            return false;
        }
    }
}
