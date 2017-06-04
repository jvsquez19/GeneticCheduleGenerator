using System;
using System.Collections.Generic;

namespace GeneticCheduleGenerator
{
    class MainClass
    {
        public static int asig = 0, comp = 0;
        /// <summary>
        /// Matriz de tres dimensiones la cual contiene en la primer dimension el dia de la semana (Lunes a Viernes), 
        /// en la segunda dimension se encuentran las horas de clases (7am a 9pm) y por ultimo,
        /// en la tercer dimension se encuentra el aula en la cual se imparte el curso
        /// </summary>
        public static List<Course> padre = new List<Course>();
        public static List<Course> madre = new List<Course>();
        public static List<Course> hijo;// = new List<Course>();
        public static List<Course> hija = new List<Course>();

        
        

        public static void Main(string[] args)
        {

            //horario1 = creaarhorario();
            //padre = toList(horario1);
            //madre = toList(horario2);
            /*Console.ReadKey();
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
            }*/
            /*
            DefaultData.InsertDefaultData();
            Schedule parent1 = new Schedule();
            Schedule parent2 = new Schedule();
            padre = parent1.matrixToList();
            madre = parent2.matrixToList();
            */
            Professor p1 = new Professor("Diego Rojas", 1, 38);
            Professor p4 = new Professor("Rocio Quiros", 4, 40);
            Professor p3 = new Professor("Karina Gonzales", 3, 38);
            Professor p9 = new Professor("Carlos Guillen", 9, 40);
            Professor p2 = new Professor("Vera Gamboa", 2, 40);
            Professor p11 = new Professor("Erick Salas", 11, 40);

            Course c1 = new Course("Fundamentos de computacion", 1, p1, 50, 1, 1);
            Course c2 = new Course("Fundamentos de computacion", 2, p4, 51, 1, 1);
            Course c3 = new Course("Matematica General", 3, p3, 50, 1, 1);
            Course c4 = new Course("Matematica General", 4, p9, 51, 1, 1);
            Course c5 = new Course("Introduccion a la programacion", 5, p2, 50, 1, 1);
            Course c6 = new Course("Comunicacion tecnica", 6, p11, 50, 1, 1);
            Course c7 = new Course("Matematica discreta", 7, p3, 50, 1, 1);
            
            hijo = new List<Course> { c1, c2, c3, c4, c5, c6, c7 };

            hija = new List<Course> { c6, c5, c7, c1, c4, c3, c2 };

            Schedule.printParent(hijo, 1);
            Schedule.printParent(hija, 2);

            Schedule.CrossWithPMX(hijo, hija,ref asig,ref comp);

            Schedule.printSon(hijo, 1);
            Schedule.printSon(hija, 2);

            Console.WriteLine("\nCantidad de asignaciones: {0}, cantidad de compraciones: {1}",asig,comp);
            
            Console.ReadKey();
        }
    }
}
