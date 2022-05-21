using System;

namespace SkillFactory_Module_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите первое слагаемое"); // Ввод слагаемых
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите второе слагаемое");
                int y = Convert.ToInt32(Console.ReadLine());

                ISum sum = new Calculator();          
                ILogger logger = new Calculator();

                logger.Event("Выполнена операция сложения");

                Console.WriteLine($"Сумма равна: {sum.Sum(x, y)}");
            }
            catch (Exception ex)                                     // ОБрабатывем исключения
            {
                ILogger logger = new Calculator();
                logger.Error("Произошла ошибка");
                Console.WriteLine("Некорректный формат введенного числа");
                Console.WriteLine(ex.ToString());
            }

        }

    }

    public interface ISum     // Определяем интерфейсы сложения и вывода сообщения
    {
        int Sum(int x, int y);
    }
    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }

    public class Calculator : ISum, ILogger    //Создаем класс сложения двух чисел и вывода текста ошибки или выполнения операции
    {
        int ISum.Sum(int x, int y)
        {
            return (x + y);
        }
        void ILogger.Event(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
        }
        void ILogger.Error(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }
    }
}
