// Escriba una función que reciba una cantidad entera de segundos y retorne un string que muestre esa cantidad en formato HH:MM:SS. NO utilizar la clase DateTime.

namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese una cantidad de segundos: ");
            int totalSegundos = Convert.ToInt32(Console.ReadLine());

            // Calcular horas, minutos y segundos restantes
            int horas = totalSegundos / 3600;
            int minutos = (totalSegundos % 3600) / 60;
            int segundos = totalSegundos % 60;

            // Mostrar resultado de forma: HH:MM:SS
            Console.WriteLine($"{horas:D2}:{minutos:D2}:{segundos:D2}");
        }
    }
}
