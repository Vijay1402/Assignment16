using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment16
{
    internal class Program
    {
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }
        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }
        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }
        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            int i, j;
            for (i = 0; i < n1; ++i)
            {
                leftArray[i] = arr[left + i];
            }
            for (j = 0; j < n2; ++j)
            {
                rightArray[j] = arr[mid + 1 + j];
            }
            i = 0;
            int k = left;
            j = 0;
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }
        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }
        public static int[] arrInput()
        {
            Console.WriteLine("Enter the number of elements in the array");
            int len = int.Parse(Console.ReadLine());
            int[] arr = new int[len];
            Console.WriteLine("Enter the elements one after the other");
            for (int i = 0; i < len; i++)
            {
                arr[i] = int.Parse(Console.ReadLine()) ;
            }
            Console.WriteLine("\n");
            return arr;
        }
        public static void element20()
        {
            int[] arr20 = new int[20];
            Random rnd = new Random();
            for (int i = 0; i < arr20.Length; i++)
            {
                arr20[i] = rnd.Next(0,100);
            }
            Console.WriteLine("Array of 20 elements");
            Print(arr20);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSort(arr20);
            stopwatch.Stop();
            double quickTime = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine($"For ArraySize of 20 elements: Time Taken {quickTime} milliseconds using Quick Sort");
        }
        public static void element30()
        {
            int[] arr30 = new int[30];
            Random rnd = new Random();
            for (int i = 0; i < arr30.Length; i++)
            {
                arr30[i] = rnd.Next(0, 100);
            }
            Console.WriteLine("Array of 20 elements");
            Print(arr30);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSort(arr30);
            stopwatch.Stop();
            double quickTime = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine($"For ArraySize of 30 elements: Time Taken {quickTime} milliseconds using Quick Sort");
        }
        public static void element50()
        {
            int[] arr50 = new int[50];
            Random rnd = new Random();
            for (int i = 0; i < arr50.Length; i++)
            {
                arr50[i] = rnd.Next(0, 100);
            }
            Console.WriteLine("Array of 20 elements");
            Print(arr50);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSort(arr50);
            stopwatch.Stop();
            double quickTime = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine($"For ArraySize of 50 elements: Time Taken {quickTime} milliseconds using Quick Sort");
        }
        static void Main(string[] args)
        {
            int[] array = arrInput();
            int[] array2 = array;
            Console.WriteLine("Orignal Array");
            Print(array);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSort(array);
            stopwatch.Stop();
            double quickTime = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine("After Quick Sort");
            Print(array);
            Console.WriteLine($"ArraySize {array.Length} Time Taken {quickTime} milliseconds using Quick Sort");
            stopwatch.Start();
            MergeSort(array2);
            stopwatch.Stop();
            double mergeTime = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine("\nAfter Merge Sort");
            Print(array);
            Console.WriteLine($"ArraySize {array.Length} Time Taken {mergeTime} milliseconds using Merge Sort");
            Console.WriteLine($"The difference in time elapsed for Quick sort and Merge sort is {quickTime-mergeTime}");
            element20();
            element30();
            element50();
            Console.ReadKey();
        }
    }
}
