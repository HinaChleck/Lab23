using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab33
{
    //1.    Разработать асинхронный метод для вычисления факториала числа.В методе Main выполнить проверку работы метода.
    internal class Program
    {
        static async Task<ulong> FactorialAsync(uint x)
        {
            ulong result = await Task.Run(() =>
            {
                ulong f = 1;
                for (ulong i = 1; i <= x; i++)
                {
                    f *= i;
                    if (i < x)
                    {
                        Console.WriteLine("{0}!={1}", i, f);
                    }
                    Thread.Sleep(100);
                }
                return f;
            });
            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите число для вычисления факториала (целое, положительное, до 20 включительно):");
            string numS = Console.ReadLine();

            if (uint.TryParse(numS, out uint num) & num <= 20)
            {
                Console.WriteLine("Факториал {0}!={1}", num, FactorialAsync(num).Result);
            }
            else
            {
                Console.WriteLine("Введенное число не соответствует заданным условиям");
            }

            Console.ReadKey();
        }
    }
}
