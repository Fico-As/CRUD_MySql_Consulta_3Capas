using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arreglos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el largo del listado: ");
            var dato = Console.ReadLine();
            if (dato == null)
                dato = "";
            int n = int.Parse(dato);
            int[] miVector = new int[n];
            Random aleatorio = new Random();
            for(int i = 0; i < miVector.Length; i++)
            {
                miVector[i] = aleatorio.Next(100);
            }
            int contador = 0;
            foreach (var i in miVector)
            {
                contador++;
                Console.WriteLine("[" + contador + "] : " + i);               
            }
            Console.WriteLine();
            Console.WriteLine("Ingrese pocision a modificar");
            var k = int.Parse(Console.ReadLine());
            if (k > miVector.Length || k < 0)
            {
                Console.WriteLine("Indice incorrecto");
            }
            else
            {
                Console.WriteLine("Ingrese nuevo valor: ");
                miVector[k - 1] = int.Parse(Console.ReadLine());
                contador = 0;
                foreach(var i in miVector)
                {
                    contador++;
                    Console.WriteLine("[" + contador + "] : " + i);
                }
            }
            Console.ReadKey();
        }
    }
}
