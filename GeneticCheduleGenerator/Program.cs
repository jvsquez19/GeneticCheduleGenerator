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
        public static List<Course> padre = new List<Course>();
        public static List<Course> madre = new List<Course>();
        public static List<Course> hijo;// = new List<Course>();
        public static List<Course> hija;



        public static void Main(string[] args)
        {
            int asig = 0, comp = 0;
            DefaultData.InsertDefaultData();
            
            Schedule parent1 = new Schedule();
            padre =  new List<Course>(parent1.MatrixToList()); // punto debug aqui

            List<Course> parent1list = parent1.MatrixToList();
            parent1.ListToMatrix(parent1list);
            
            hijo = new List<Course>(padre);

            Schedule parent2 = new Schedule();
            
            madre = new List<Course>(parent2.MatrixToList());
                        
            hija = new List<Course>(madre);
            Console.WriteLine("---------------- PMX genetic algorithm ----------------\n");
            Schedule.PrintList(hijo, "Padre 1");
            Console.WriteLine();
            Schedule.PrintList(hija, "Padre 2");

            Schedule.CrossWithPMX(hijo, hija, ref asig, ref comp);
            Console.WriteLine("\n\nCantidad de asignaciones: {0}, cantidad de compraciones: {1}", asig, comp);

            parent1.ListToMatrix(hijo);
            parent2.ListToMatrix(hija);

            /*parent1.FixIfThereIsCrash();
            parent2.FixIfThereIsCrash();*/

            Console.ReadKey();
            asig = 0;
            comp = 0;
            
            // reseteo los mismos padres que se enviaron al PMX para que usen los mismos horarios padre
            hijo = new List<Course>(padre);
            hija = new List<Course>(madre);
            Console.WriteLine("---------------- OX genetic algorithm ----------------\n");
                        
            Schedule.PrintList(hijo, "Padre 1");
            Console.WriteLine();
            Schedule.PrintList(hija, "Padre 2");

            Schedule.OrderOneCrossover(hijo, hija, ref asig, ref comp);
            Console.WriteLine("\n\nCantidad de asignaciones: {0}, cantidad de compraciones: {1}", asig, comp);

            parent1.ListToMatrix(hijo);
            parent2.ListToMatrix(hija);

            parent1.FixIfThereIsCrash();
            parent2.FixIfThereIsCrash();

            Console.ReadKey();            
        }
    }
}
