using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
           var result = new List<int>();  // To store missing numbers
                var set = new HashSet<int>(nums);  // Using set to track numbers
                int n = nums.Length;

                for (int i = 1; i <= n; i++)  // Checking for missing numbers in range 1 to n
                {
                    if (!set.Contains(i))
                    {
                        result.Add(i);
                    }
                }
                return result;
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
           // Initializing two lists to hold the even and odd numbers
        var evenNumbers = new List<int>();  // List to store even numbers
        var oddNumbers = new List<int>();   // List to store odd numbers

        // Looping through the input array to separate even and odd numbers
        foreach (var num in nums)
        {
            if (num % 2 == 0)
                evenNumbers.Add(num);  // Adding even numbers to the 'evenNumbers' list
            else
                oddNumbers.Add(num);   // Adding odd numbers to the 'oddNumbers' list
        }

        // Combining the 'evenNumbers' list and 'oddNumbers' list. Even numbers come first.
        // Concatinating the two lists and converting the result to an array.
        return evenNumbers.Concat(oddNumbers).ToArray();
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();  // HashMap to store complements

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };  // Returning the pair of indices
                }
                map[nums[i]] = i;  // Storing the index of each number
            }
            return new int[0];  // No solution found
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);  // Sorting the array to easily find the maximum and minimum numbers
            int n = nums.Length;
            // Checking for two smallest (negative) numbers and the largest number
            return Math.Max(nums[0] * nums[1] * nums[n - 1], nums[n - 1] * nums[n - 2] * nums[n - 3]);
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            if (decimalNumber == 0) return "0";  // Special case for zero
            var binary = new Stack<int>();  // Stack to store binary digits

            while (decimalNumber > 0)  // Loop until the number is reduced to zero
            {
                binary.Push(decimalNumber % 2);  // Pushing the remainder
                decimalNumber /= 2;  // Dividing the number by 2
            }

            return string.Join("", binary);  // Joining the digits and returning the binary string
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            int left = 0, right = nums.Length - 1;  // Binary search boundaries

            while (left < right)  // Binary search loop
            {
                int mid = left + (right - left) / 2;  // Calculating mid to avoid overflow

                if (nums[mid] > nums[right])  // If the middle element is greater, the min is to the right
                {
                    left = mid + 1;
                }
                else  // If the middle element is less or equal, the min is to the left
                {
                    right = mid;
                }
            }

            return nums[left];  // Returning the minimum element
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            
            if (x < 0) return false;  // Negative numbers cannot be palindromes
            int original = x, reversed = 0;

            while (x > 0)
            {
                reversed = reversed * 10 + x % 10;  // Reverseing the number
                x /= 10;
            }

            return original == reversed;  // Checking if the reversed number equals the original
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
           
            if (n == 0) return 0;  // Return 0 for the 0th Fibonacci number
            if (n == 1) return 1;  // Return 1 for the 1st Fibonacci number

            int a = 0, b = 1;  // Start with the first two Fibonacci numbers
            for (int i = 2; i <= n; i++)
            {
                int temp = a + b;  // Calculating the next Fibonacci number
                a = b;  // Updating a to b
                b = temp;  // Updating b to the new Fibonacci number
            }

            return b;  // Returning the nth Fibonacci number
        }
    }
}
