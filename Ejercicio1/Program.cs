// 1. Escriba una función que imprima únicamente los números primos de la serie de Fibonacci hasta el n-ésimo término.

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double NumeroInicial = 1;
            double NumeroActual = 1;

            while (true) 
            { 
                NumeroActual += NumeroInicial; // El siguiente numero es igual a la suma de los 2 numeros anteriores
                NumeroInicial = NumeroActual - NumeroInicial; 

                if(Check(NumeroActual) == true) // Si es primo entonces:
                {
                    Console.WriteLine(NumeroActual); // Se muestra en pantalla
                }
            }
        }

        static bool Check(double n)
        {
            int contador = 0; // cuenta las divisiones exactas

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0) { contador++; } 
            }

            if (contador == 2) { return true; } // Si el contador es dos es primo
            else { return false; } 
        }
    }
}