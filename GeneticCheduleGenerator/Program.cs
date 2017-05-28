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
        

        public static void Main(string[] args)
        {
            /*Console.WriteLine("Hola, how are usted? ");
            Course c1 = new Course("curso 1", 1, DefaultData.professors[1], 1);
            Course c2 = new Course("curso 2", 1, DefaultData.professors[1], 1);
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
            Console.ReadKey();*/
            Console.WriteLine("Iniciando");
            DefaultData.InsertDefaultData();
            Schedule parent1 = new Schedule();
            List<Course> seed = parent1.prepareListForCreate(DefaultData.courses);
            parent1.createParent(seed);
            String[] days = new string[]{ "lunes", "martes", "miercoles", "jueves", "viernes" };
            String[] hours = new string[]{ "7 a 9", "9:10 a 11:10", "12:10 a 2:10", "2:20 a 4:20" };

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(days[i]);
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine(hours[j]);
                    for (int k = 0; k < Schedule.aulas; k++)
                    {
                        if (parent1.matrix[i, j, k] != null)
                        {
                            Console.WriteLine(parent1.matrix[i, j, k].name + "Aula" + k);
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
