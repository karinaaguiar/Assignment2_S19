using System;
using System.Collections.Generic;

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
            int[] arr1 = { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206};
            int[] brr = {203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204};
            int[] r2 = missingNumbers(arr1, brr);
            displayArray(r2);

            // grading students
            Console.WriteLine("\n\nGrading students");
            int[] grades = { 73, 67, 38, 33};
            int[] r3 = gradingStudents(grades);
            displayArray(r3);

            // find the median
            Console.WriteLine("\n\nFind the median");
            int[] arr2 = { 0, 1, 2, 4, 6, 5, 3};
            Console.WriteLine(findMedian(arr2));

            // closest numbers
            Console.WriteLine("\n\nClosest numbers");
            int[] arr3 = { 5, 4, 3, 2 };
            int[] r4 = closestNumbers(arr3);
            displayArray(r4);

            // Day of programmer
            Console.WriteLine("\n\nDay of Programmer");
            int year = 2017;
            Console.WriteLine(dayOfProgrammer(year));

            //To display results in the console
            Console.ReadKey(true);
        }

        static void displayArray(int []arr) {
            Console.WriteLine();
            foreach(int n in arr) {
                Console.Write(n + " ");
            }
        }

        //Sort function for array using Bubble sort
        static int[] Sort(int[] a)
        {
            int len = a.Length;
            int temp = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = i; j < len; j++)
                {
                    if (a[i] > a[j])
                    {
                        temp = a[j];
                        a[j] = a[i];
                        a[i] = temp;
                    }
                }
            }
            return a;
        }

        // Complete the rotLeft function below.
        static int[] rotLeft(int[] a, int d)
        {
            int len = a.Length;
            int[] b = new int[len];
            int n = 1;
            try
            {
                while (n <= d)                                  //loop executes until n is less than or equal to the number of rotations
                {
                    int i = 0;
                    b[len - 1] = a[i];
                    for (i = 0; i < len - 1; i++)
                    {
                        b[i] = a[i + 1];                        
                    }
                    for (int j = 0; j < len; j++)
                    {
                        a[j] = b[j];
                    }
                    n++;
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing rotLeft()");
            }
            return b;
        }

        // Complete the maximumToys function below.
        static int maximumToys(int[] prices, int k)
        {
            int count = 0;
            try
            {
                int[] array = Sort(prices);         //call the sort function to sort the array first
                int len = array.Length;
                int sum = 0;
                for (int i = 0; i < len; i++)
                {
                    if (array[i] > k)
                        continue;
                    sum = sum + array[i];           //compute the sum for Max toys
                    if (sum < k)
                    {
                        count = count + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing maximumToys()");
            }
            return count;
        }

        // Complete the balancedSums function below.
        static string balancedSums(List<int> arr)
        {
            try
            {
                int len = arr.Count;
                if (len == 1)                        //if array contains only one element, then balanced sum is YES
                {
                    return "YES";
                }
                if (arr[1] == 0)                     //if second element of array is 0, then balanced sum is YES
                {
                    return "YES";
                }
                for (int j = 1; j < len; j++)
                {
                    int i = 0;
                    int k = j + 1;
                    int sum_before = 0;
                    int sum_after = 0;
                    while (i < j)
                    {
                        sum_before += arr[i];           //compute the sum for before half of a particular element in array
                        i++;
                    }
                    while (k < len)
                    {
                        sum_after += arr[k];            //compute the sum for after half of a particular element in array
                        k++;
                    }
                    if (sum_after == sum_before)        //check whether the sum in the before half is equal to sum in the after half
                    {

                        return "YES";

                    }
                    continue;
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing balancedSums()");
            }
            return "NO";
        }

        // Complete the missingNumbers function below.
        static int[] missingNumbers(int[] arr, int[] brr)
        {
            List<int> missingNumberList = new List<int>();
            Dictionary<int, int> dicA = frequencyMap(arr);   //convert the target array to dicA using the frequencyMap method
            Dictionary<int, int> dicB = frequencyMap(brr);   //convert the original array to dicB using the frequencyMap method

            if (brr == null || brr.Length == 0)        //make sure the orginal array has values
            {
                Console.WriteLine("Bad input. Please provide a non-empty array of integers");
                return new int[] { };
            }

            if (arr.Length > brr.Length)               //make sure the missing array has less number of elements than the orignal array
            {
                Console.WriteLine("Bad input. The missing array should be smaller than the original array");
                return new int[] { };
            }

            foreach (int keyA in dicA.Keys)             //make sure the missing array doesn't contain any number that doesn't exist in the original array
            {
                if (!dicB.ContainsKey(keyA))
                {
                    Console.WriteLine("Bad input. The missing array should not have any number that doesn't exist in the original array");
                    return new int[] { };
                }
            }

            Sort(brr);                                  //Sort the original array using the Sort function to have the min at index 0 and the max at the last index
            int diff = brr[brr.Length - 1] - brr[0];    //Find difference between min max elements of B and check whether it's less than or equal 100
            if (diff > 100)
            {
                Console.WriteLine("Bad input. The difference between min and max should be equal or less than 100");
                return new int[] { };
            }

            try
            {
                foreach (int keyB in dicB.Keys)                 //loop through the keys in the dicB and compare the frequency (occurence) for each key in dicA and dicB
                {
                    int occurrenceKeyBInA = 0;                  //the occurence of key B in dicA get inital value of 0      
                    if (dicA.ContainsKey(keyB))                 //if the key is in dicA, its occurence is equal to its frequency in dicA. Otherwise, remains 0.
                    {
                        occurrenceKeyBInA = dicA[keyB];
                    }

                    int occurrenceKeyBInB = dicB[keyB];

                    if (occurrenceKeyBInB > occurrenceKeyBInA)   //if the frequency of a keyB in dicB is greater than in dicA, it is a missing value 
                    {
                        missingNumberList.Add(keyB);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing missingNumber()");
            }
       
            //convert list to array and sort it using Sort function
            int[] result = Sort(missingNumberList.ToArray());
            return result;
        }

        //create frequencyMap method to convert array to dictionary. The keys are the unique elements of the array and the values are the frequency of each unique element
        static Dictionary<int, int> frequencyMap(int[] a)
        {
            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            for (int i = 0; i < a.Length; i++)      //loop through the provided array of integers
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
            if (grades == null || grades.Length == 0)           //make sure the array has values. Otherwise, return an error message
            {
                Console.WriteLine("Please provide a non-empty array of integers");
            }
            for (int i = 0; i < grades.Length; i++)             //make sure grades are >=0 and <=100
            {
                if (grades[i] < 0 || grades[i] > 100)
                {
                    Console.WriteLine("Bad input. Grades should be equal or greater than 0 and equal or less than 100");
                    return new int[] { };
                }
            }
            try
            {
                int[] roundedGrades = new int[grades.Length];   //create new array to store the grounded grades
                for (int i = 0; i < grades.Length; i++)
                {
                    if (grades[i] >= 38)                        //only consider the rounding for grades greater than or equal 38
                    {
                        int q = grades[i] / 5;
                        int r = grades[i] % 5;
                        if (r >= 3)                             //if the remainder is equal or greater than 3, round up to the next multiplle of 5
                        {
                            roundedGrades[i] = 5 * (q + 1);
                        }
                        else
                        {
                            roundedGrades[i] = grades[i];       //otherwise, add the same number to the new array without rounding
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
                    arr = Sort(arr);
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
                    Console.WriteLine("Bad input. The array is empty");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing findMedian()");
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
                    arr = Sort(arr); 

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
                    Console.WriteLine("Bad input. The array should have at least two elements");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing closestNumbers()");
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
                    //Considering Feb 14th was the 1st February day on 1918, 
                    //Then, February only had 15 days that year (28-14+1).
                    //Therefore, the 256th day of that year was: 
                    // 31 (Jan) + 15 (Feb) + 31 (Mar) + 30 (Apr)
                    // 31 (May) + 30 (Jun) + 31 (Jul) + 31 (Ago) 
                    // Totals = 229 days 
                    // Minus 256, (256 - 229 = 27 days) 
                    // Then, the 256th day of the Transition year 
                    // was Sept 27th
                    int sumFirst8MonthsDays = 31 + 15 + 31 + 30 + 31 + 30 + 31 + 31;
                    int toReach256Day = 256 - sumFirst8MonthsDays;
                    return toReach256Day.ToString() + ".09." + year.ToString();
                }
                else //Year out of range 1700 to 2700
                {
                    Console.WriteLine("Bad Input - Year out of range 1700-2700");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing dayOfProgrammer()");
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
