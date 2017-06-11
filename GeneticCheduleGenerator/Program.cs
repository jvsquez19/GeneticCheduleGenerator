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


		public static void printProfessorsSchedule(Course[,,] matrix)
		{
			String[] days = new string[] { "lunes", "martes", "miercoles", "jueves", "viernes" };
			String[] hours = new string[] { "\n7:00 a 9:15", "\n9:15 a 11:30", "\n12:30 a 2:45", "\n2:45 a 4:30" };
			Console.WriteLine("IMPRIMIENDO HORARIOS POR PROFESOR");
			for (int professor = 0; professor < DefaultData.professors.Count; professor++)
			{
                Console.WriteLine(" Profesor: " + DefaultData.professors[professor].name);
				for (int i = 0; i < 5; i++)
				{
					Console.WriteLine("\n" + days[i]);
					for (int j = 0; j < 4; j++)
					{
						Course actual = matrix[i, j, professor];
                        if (actual != null)
                        {
                            Console.WriteLine("\n" + hours[j] + ": " + actual.name + ", Grupo" + actual.groupe + " Aula: " + actual.classroom);
                        }
					}

				}

			}
		}

        public static void printSemesterSchedule(Course[,,] matrix)
		{
			String[] semesters = new string[] { "Primer", "Segundo", "Tercer", "Cuarto", "Quinto" };
			String[] days = new string[] { "lunes", "martes", "miercoles", "jueves", "viernes" };
			String[] hours = new string[] { "\n7:00 a 9:15", "\n9:15 a 11:30", "\n12:30 a 2:45", "\n2:45 a 4:30" };
			Console.WriteLine("IMPRIMIENDO HORARIOS POR SEMESTRE");
			for (int semester = 0; semester < 5; semester++)
			{
				Console.WriteLine(semesters[semester] + " Semestre");
				for (int i = 0; i < 5; i++)
				{
					Console.WriteLine("\n" + days[i]);
					for (int j = 0; j < 4; j++)
					{
                        Course actual = matrix[i, j, semester];
                        if (actual != null)
                        {
                            
                            Console.WriteLine("\n" + hours[j] + ": " + actual.name + ", Grupo" + actual.groupe + " Aula: " + actual.classroom);
                        }
					}

				}

			}
		}

		public static void printAll(Schedule basic)
		{
			Tuple<Course[,,], Course[,,]> aux = basic.CreateAlternativeMatrixes();
			Course[,,] matrixProfessors = aux.Item1;
			Course[,,] matrixSemesters = aux.Item2;
			Schedule.printSchedule(basic.best);
			printProfessorsSchedule(matrixProfessors);
			printSemesterSchedule(matrixSemesters);
		}

        public static void Main(string[] args)
        {
            /* int asig = 0, comp = 0;
             DefaultData.InsertDefaultData();

             Schedule parent1 = new Schedule();

             padre =  new List<Course>(parent1.MatrixToList()); // punto debug aqui

             hijo = new List<Course>(padre);


             Schedule parent2 = new Schedule();

             madre = new List<Course>(parent2.MatrixToList());

             hija = new List<Course>(madre);

             parent1.GeneticPMX(hijo,hija);
             /*=    =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =
             Console.WriteLine("---------------- PMX genetic algorithm ----------------\n");
             Schedule.PrintList(hijo, "Padre 1");
             Console.WriteLine();
             Schedule.PrintList(hija, "Padre 2");
             */
            /* Schedule.CrossWithPMX(hijo, hija, ref asig, ref comp);  // llamada al algoritmo PMX
             Console.WriteLine("\n\nCantidad de asignaciones: {0}, cantidad de compraciones: {1}", asig, comp);

             parent1.ListToMatrix(hijo);
             parent2.ListToMatrix(hija);

             parent1.Mutations();
             parent2.Mutations();

             Schedule.printSchedule(parent1.matrix);
             Schedule.printSchedule(parent2.matrix);

             //Console.WriteLine("\n\nCantidad de asignaciones: {0}, cantidad de compraciones: {1}", asig, comp);


             /*
             Console.WriteLine("\n--------------- Hijo 1 ---------------");
             Schedule.PrintList(hijo, "Hijo 1");
 =======
             parent2.BrandAndBound();

                 // Main de JAFETH 
 >>>>>>> Stashed changes

             Console.WriteLine();

             Console.WriteLine("\n--------------- Hijo 2 ---------------");
             Schedule.PrintList(hija, "Hijo 2");
             */
            /*Schedule.printSchedule(parent1.matrix);
            Schedule.printSchedule(parent2.matrix);

            /*=    =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =   =*/

            /*Console.ReadKey();
            asig = 0;
            comp = 0;
            
            // reseteo los mismos padres que se enviaron al PMX para que usen los mismos horarios padre
            hijo = new List<Course>(padre);
            hija = new List<Course>(madre);
            Console.WriteLine("\n\n---------------- OX genetic algorithm ----------------\n");
                        
            Schedule.PrintList(hijo, "Padre 1");
            Console.WriteLine();
            Schedule.PrintList(hija, "Padre 2");

            Schedule.OrderOneCrossover(hijo, hija, ref asig, ref comp); // llamada a OX

            Console.WriteLine("\n\nCantidad de asignaciones: {0}, cantidad de compraciones: {1}", asig, comp);

            parent1.ListToMatrix(hijo);
            parent1.Mutations();
            Schedule.printSchedule(parent1.matrix);

            parent2.ListToMatrix(hija);
            parent2.Mutations();
            Schedule.printSchedule(parent2.matrix);
            */

            DefaultData.InsertDefaultData();
            Schedule parent1 = new Schedule();
            Schedule parent2 = new Schedule();
            hijo = parent1.MatrixToList();
            hija = parent2.MatrixToList();

            Schedule.PrintList(hijo,"Padre 1: ");
            Console.WriteLine();
            Schedule.PrintList(hija, "Padre 2: ");

            Console.WriteLine("FIT: "+parent1.getFitness());

            parent1.GeneticPMX(hijo,hija);

            Schedule.PrintList(hijo,"Padre 1: ");
            Console.WriteLine();
            Schedule.PrintList(hija, "Padre 2: ");

            //printAll(parent1);
            Console.WriteLine("FIT: " + parent1.getFitness());

            printAll(parent1);

			hijo = parent1.MatrixToList();
			hija = parent2.MatrixToList();

			Console.WriteLine("FIT: " + parent1.getFitness());

            parent1.GeneticOX(hijo, hija);

			printAll(parent1);
			Console.WriteLine("FIT: " + parent1.getFitness());

            parent1.BrandAndBound();
            printAll(parent1);
            
            Console.ReadKey();            
        }
    }
}
