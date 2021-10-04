using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerScienceDistilled
{
    class SortingAlgorithms
    {

        private static void Quick_Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }

        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        public static void Quick_Sort_Main(int[] newArgs)
        {
            Console.WriteLine("Commencing Quick Sort");
            int[] args = newArgs;

            Console.WriteLine("Original array is: [{0}]", string.Join(", ", args));

            Quick_Sort(args, 0, args.Length - 1);

            Console.WriteLine("Sorted array is: [{0}]", string.Join(", ", args));

            Console.ReadLine();
        }
    }
}

