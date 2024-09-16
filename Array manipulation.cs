using System;

class Program
{
    static void Main()
    {
        int[] array = null;
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Array Manipulation Program");
            Console.WriteLine("1. Enter Array");
            Console.WriteLine("2. Find Minimum and Maximum");
            Console.WriteLine("3. Calculate Sum and Average");
            Console.WriteLine("4. Reverse Array");
            Console.WriteLine("5. Sort Array");
            Console.WriteLine("6. Add Element");
            Console.WriteLine("7. Remove Element");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    array = EnterArray();
                    break;
                case "2":
                    FindMinMax(array);
                    break;
                case "3":
                    CalculateSumAverage(array);
                    break;
                case "4":
                    ReverseArray(ref array);
                    break;
                case "5":
                    SortArray(ref array);
                    break;
                case "6":
                    AddElement(ref array);
                    break;
                case "7":
                    RemoveElement(ref array);
                    break;
                case "8":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
        }
    }

    static int[] EnterArray()
    {
        Console.Write("Enter the size of the array: ");
        int size = int.Parse(Console.ReadLine());

        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            Console.Write($"Enter element {i + 1}: ");
            array[i] = int.Parse(Console.ReadLine());
        }

        return array;
    }

    static void FindMinMax(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            Console.WriteLine("Array is empty or not initialized.");
            return;
        }

        int min = array[0];
        int max = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min) min = array[i];
            if (array[i] > max) max = array[i];
        }

        Console.WriteLine($"Minimum value: {min}");
        Console.WriteLine($"Maximum value: {max}");
    }

    static void CalculateSumAverage(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            Console.WriteLine("Array is empty or not initialized.");
            return;
        }

        int sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        double average = (double)sum / array.Length;

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average}");
    }

    static void ReverseArray(ref int[] array)
    {
        if (array == null || array.Length == 0)
        {
            Console.WriteLine("Array is empty or not initialized.");
            return;
        }

        int length = array.Length;
        for (int i = 0; i < length / 2; i++)
        {
            int temp = array[i];
            array[i] = array[length - 1 - i];
            array[length - 1 - i] = temp;
        }

        Console.WriteLine("Array reversed.");
        PrintArray(array);
    }

    static void SortArray(ref int[] array)
    {
        if (array == null || array.Length == 0)
        {
            Console.WriteLine("Array is empty or not initialized.");
            return;
        }

        // Simple bubble sort algorithm
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Array sorted.");
        PrintArray(array);
    }

    static void AddElement(ref int[] array)
    {
        Console.Write("Enter the element to add: ");
        int newElement = int.Parse(Console.ReadLine());

        int newSize = array.Length + 1;
        int[] newArray = new int[newSize];

        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }
        newArray[newSize - 1] = newElement;

        array = newArray;

        Console.WriteLine("Element added.");
        PrintArray(array);
    }

    static void RemoveElement(ref int[] array)
    {
        Console.Write("Enter the element to remove: ");
        int elementToRemove = int.Parse(Console.ReadLine());

        int index = -1;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == elementToRemove)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("Element not found.");
            return;
        }

        int newSize = array.Length - 1;
        int[] newArray = new int[newSize];

        for (int i = 0, j = 0; i < array.Length; i++)
        {
            if (i != index)
            {
                newArray[j++] = array[i];
            }
        }

        array = newArray;

        Console.WriteLine("Element removed.");
        PrintArray(array);
    }

    static void PrintArray(int[] array)
    {
        Console.Write("Current array: ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
