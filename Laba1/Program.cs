using System;
using System.Linq;

class SimpleArrayOperations
{
    private int[] array;

    // Метод для получения элемента по индексу
    public int GetIndex(int index)
    {
        if (index >= 0 && index < array.Length)
        {
            return array[index];
        }
        else
        {
            Console.WriteLine("Индекс вне диапазона.");
            return -1; // или выбросить исключение
        }
    }

    // Метод для проверки существования элемента в массиве
    public bool Exist(int value)
    {
        return array.Contains(value);
    }

    // Метод для добавления элемента в массив
    public void Add(int value)
    {
        if (array == null)
        {
            array = new int[] { value };
        }
        else
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = value;
        }
    }

    // Метод для удаления элемента по значению
    public void RemoveByValue(int value)
    {
        if (array != null)
        {
            array = array.Where(x => x != value).ToArray();
        }
    }

    // Метод для удаления элемента по индексу
    public void RemoveByIndex(int index)
    {
        if (array != null && index >= 0 && index < array.Length)
        {
            array = array.Where((x, i) => i != index).ToArray();
        }
        else
        {
            Console.WriteLine("Индекс вне диапазона.");
        }
    }

    // Метод для вывода массива в консоль с его размером
    public void PrintArrayWithSize()
    {
        Console.WriteLine("Массив: " + string.Join(", ", array ?? new int[0]));
        Console.WriteLine("Размер: " + (array?.Length ?? 0));
    }

    // Метод для объединения двух массивов
    public static int[] UnionArrays(int[] array1, int[] array2)
    {
        if (array1 == null) array1 = new int[0];
        if (array2 == null) array2 = new int[0];

        return array1.Union(array2).ToArray();
    }
}

class Program
{
    static void Main()
    {
        SimpleArrayOperations arrayOperations = new SimpleArrayOperations();

        // Пример использования методов
        arrayOperations.Add(10);
        arrayOperations.Add(20);
        arrayOperations.Add(30);
        arrayOperations.PrintArrayWithSize();

        arrayOperations.RemoveByValue(20);
        arrayOperations.PrintArrayWithSize();

        arrayOperations.RemoveByIndex(0);
        arrayOperations.PrintArrayWithSize();
    }
}
