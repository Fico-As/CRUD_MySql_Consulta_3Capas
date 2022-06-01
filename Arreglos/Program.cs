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
            if (dato == null)// en caso de que no introduscan nada
                dato = "";// nullo es distinto de basio 
            //null es no tener la hoja, basio es tener la hoja pero basio
            int n = int.Parse(dato);//convierte el dato a entero
            int[] miVector = new int[n];
            Random aleatorio = new Random();//random tiene tres formas 
            //Random() Sin argumentos
            //Random(limite) Con argumentos desde 1 hasta limite
            //Random(min, max) Con argumentos desde minimo a maximo
            for(int i = 0; i < miVector.Length; i++)
            {
                //almacena los datos aleatorios en el vector
                miVector[i] = aleatorio.Next(100);
            }
            int contador = 0;
            foreach (var i in miVector)//muestra todos los datos
            {
                contador++;
                Console.WriteLine("[" + contador + "] : " + i);               
            }
            Console.WriteLine();
            Console.WriteLine("Ingrese pocision a modificar");
            //El método Parse() puede utilizarse para convertir una representación de
            //cadena de un número en un entero
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
            //Espera hasta presionar una tecla.
            Console.ReadKey();
        }
    }
}
