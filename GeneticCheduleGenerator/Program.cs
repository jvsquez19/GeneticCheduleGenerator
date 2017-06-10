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
        public static List<Course> hija;


        public static void Main(string[] args)
        {
            DefaultData.InsertDefaultData();
            
            Schedule parent1 = new Schedule();
<<<<<<< HEAD
            padre =  new List<Course>(parent1.MatrixToList());
=======
            List<Course> parent1list = parent1.matrixToList();
            parent1.listToMatrix(parent1list);
            String[] days = new string[]{ "lunes", "martes", "miercoles", "jueves", "viernes" };
            String[] hours = new string[]{ "7 a 9", "9:10 a 11:10", "12:10 a 2:10", "2:20 a 4:20" };
>>>>>>> df21e4e... little changes

            hijo = new List<Course>(padre);

            Schedule parent2 = new Schedule();
            
            madre = new List<Course>(parent2.MatrixToList());
                        
            hija = new List<Course>(madre);
            Console.WriteLine("PMX genetic algorithm\n");
            Schedule.PrintList(hijo, "Padre 1");
            Console.WriteLine();
            Schedule.PrintList(hija, "Padre 2");

            Schedule.CrossWithPMX(hijo, hija, asig, comp);
            asig = 0;
            comp = 0;

            //Console.WriteLine("\n\nOrder One Crossover genetic algorithm\n");

            Schedule.OrderOneCrossover(hijo, hija, asig, comp);

            //Console.WriteLine("\n\nCantidad de asignaciones: {0}, cantidad de compraciones: {1}", asig, comp);

            Console.ReadKey();
        }
    }
}
