using System;
using System.Collections.Generic;

namespace GeneticCheduleGenerator
{
    class MainClass
    {
        /// <summary>
        /// Matriz de tres dimensiones la cual contiene en la primer dimension el dia de la semana (Lunes a Viernes), 
        /// en la segunda dimension se encuentran las horas de clases (7am a 9pm) y por ultimo,
        /// en la tercer dimension se encuentra el aula en la cual se imparte el curso
        /// </summary>
        public static Course[][][] horario;
        public static List<Course> list = new List<Course>();
        

        public static void Main(string[] args)
        {
            Console.WriteLine("Hola, how are usted? ");
            Course c1 = new Course("curso 1", 1, 1, 1);
            Course c2 = new Course("curso 2", 1, 1, 1);
            list.Add(c1);
            list.Add(c1);
            list.Add(c1);
            list.Add(c1);

            list.Add(c2);
            
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].Equals(list[0]))
                    Console.WriteLine(list[i].name);
                else
                    Console.WriteLine("Diferente obj# "+i);
            }
            Console.ReadKey();
        }
    }
}
