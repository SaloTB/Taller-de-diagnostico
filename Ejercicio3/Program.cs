/* Genérico compra un chance en el cual se juega eligiendo un número de 4 dígitos, que se compara con el número resultado del sorteo semanal de los viernes. 
Genérico apuesta $1000 a un número num, esperando que sea igual al número resultado que se conocerá el viernes.
Escriba una función para determinar si el jugador ganó el sorteo */

namespace Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numeroGanador = new int[4];
            int[] apuestaUsuario = new int[4];
            int apuesta = 1000;
            Random aleatorio = new Random();

            // Generar numero ganador aleatorio
            for (int i = 0; i < 4; i++)
            {
                numeroGanador[i] = aleatorio.Next(10); // entre 0 y 9
            }

            // Mostrar el numero ganador (para pruebas)
            Console.WriteLine("Numero ganador:");
            foreach (int digito in numeroGanador)
            {
                Console.Write(digito);
            }
            Console.WriteLine();

            // Solicitar al usuario su numero
            for (int i = 0; i < 4; i++)
            {
                int entrada;
                while (true)
                {
                    Console.Write($"Ingrese el numero #{i + 1} (entre 0 y 9): ");
                    if (int.TryParse(Console.ReadLine(), out entrada) && entrada >= 0 && entrada <= 9)
                    {
                        apuestaUsuario[i] = entrada;
                        break;
                    }
                    Console.WriteLine("numero invalido. Intente nuevamente.");
                }
            }

            // Calcular el premio
            int premio = CalcularPremio(numeroGanador, apuestaUsuario, apuesta);

            Console.WriteLine($"Ganaste ${premio}.");
        }

        static int CalcularPremio(int[] ganador, int[] jugador, int monto)
        {
            int aciertosOrdenados = 0;

            // Comprobar cuantos numeros coinciden en el orden exacto
            for (int i = 3; i >= 0; i--)
            {
                if (ganador[i] == jugador[i])
                    aciertosOrdenados++;
                else
                    break;
            }

            switch (aciertosOrdenados)
            {
                case 4: return monto * 4500;
                case 3: return monto * 400;
                case 2: return monto * 50;
                case 1: return monto * 5;
            }

            // Comprobar todos los digitos, incluso en otro orden
            int coincidencias = 0;
            bool[] usados = new bool[4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (!usados[j] && ganador[i] == jugador[j])
                    {
                        usados[j] = true;
                        coincidencias++;
                        break;
                    }
                }
            }

            if (coincidencias == 4)
                return monto * 200;

            return 0;
        }
    }
}

