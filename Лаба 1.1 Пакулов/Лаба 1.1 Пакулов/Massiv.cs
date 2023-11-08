using System;

class Program
{
    /// <summary>
    /// Главный метод программы
    /// </summary>
    static void Main()
    {
        int[,] array = new int[4, 5]; // Создаем двумерный целочисленный массив размером 4x5
        int value = 1; // Устанавливаем начальное значение для заполнения массива

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                array[i, j] = value; // Заполняем массив значениями
                value++; // Увеличиваем значение для следующего элемента
            }
        }

        Console.WriteLine("Исходный массив:"); // Выводим исходный массив на экран
        PrintArray(array); // Выводим массив на экран

        // Меняем местами строки, симметричные относительно середины массива
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                int temp = array[i, j];
                array[i, j] = array[3 - i, j]; // Обмениваем значения в симметричных строках
                array[3 - i, j] = temp; // Присваиваем временное значение правильной ячейке
            }
        }

        Console.WriteLine("Массив после обмена строк:"); // Выводим массив после обмена строк на экран
        PrintArray(array); // Выводим массив на экран
    }

    /// <summary>
    /// Метод для вывода двумерного массива на экран
    /// </summary>
    /// <param name="arr">Двумерный массив для вывода</param>
    static void PrintArray(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i, j] + " "); // Выводим элемент массива с пробелом
            }
            Console.WriteLine(); // Переходим на новую строку для новой строки массива
        }
    }
}