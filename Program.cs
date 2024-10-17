using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int[] array = GenerateRandomArray(10000);

        // Сортировка пузырьком
        int[] bubbleSortArray = (int[])array.Clone();
        MeasureExecutionTime(() => BubbleSort(bubbleSortArray), "Bubble Sort");

        // Сортировка выбором
        int[] selectionSortArray = (int[])array.Clone();
        MeasureExecutionTime(() => SelectionSort(selectionSortArray), "Selection Sort");

        // Быстрая сортировка
        int[] quickSortArray = (int[])array.Clone();
        MeasureExecutionTime(() => QuickSort(quickSortArray, 0, quickSortArray.Length - 1), "Quick Sort");
    }

    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(1, 10000);
        }
        return array;
    }

    static void MeasureExecutionTime(Action action, string algorithmName)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        action();
        stopwatch.Stop();
        Console.WriteLine($"{algorithmName} took: {stopwatch.ElapsedMilliseconds} ms");
    }

    // Сортировка пузырьком
    static void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Swap
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    // Сортировка выбором
    static void SelectionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            // Swap
            int temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }
    }

    // Быстрая сортировка
    static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(array, low, high);
            QuickSort(array, low, pi - 1);
            QuickSort(array, pi + 1, high);
        }
    }

    static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                // Swap
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        // Swap
        int temp1 = array[i + 1];
        array[i + 1] = array[high];
        array[high] = temp1;

        return i + 1;
    }
}
