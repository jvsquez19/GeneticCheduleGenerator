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

            padre =  new List<Course>(parent1.MatrixToList());

            List<Course> parent1list = parent1.MatrixToList();
            parent1.listToMatrix(parent1list);
            String[] days = new string[]{ "lunes", "martes", "miercoles", "jueves", "viernes" };
            String[] hours = new string[]{ "7 a 9", "9:10 a 11:10", "12:10 a 2:10", "2:20 a 4:20" };


            hijo = new List<Course>(padre);

		//horario1 = creaarhorario();
		//padre = toList(horario1);
		//madre = toList(horario2);
		/*Console.ReadKey();
		Console.WriteLine("Iniciando");
		DefaultData.InsertDefaultData();
		Schedule parent1 = new Schedule();
		List<Course> parent1list = parent1.matrixToList();
		parent1.listToMatrix(parent1list);
		String[] days = new string[]{ "lunes", "martes", "miercoles", "jueves", "viernes" };
		String[] hours = new string[]{ "7 a 9", "9:10 a 11:10", "12:10 a 2:10", "2:20 a 4:20" };
		
		for (int i = 0; i < list.Count; i++)
		{
			if (found==null)
			{
				if (list[i].Item2 == null)
					return i;
				else
					return -1;
			}
			if (found.Equals(list[i].Item2)){

				return i ;
			}
		}
		return -1;
	}


	public static Tuple<List<Course>, List<Course>> PmxCrossover(List<Course>p1, List<Course>p2)
	{
		List<Tuple<Course,Course>> map = new List<Tuple<Course,Course>>(); //
		Random rand = new Random();
		int cursor = rand.Next(p1.Count - 1);
		int crossoverLong = rand.Next(p1.Count - cursor - 1);
		Course Aux;
		for (int i = cursor; i < cursor+crossoverLong; i++)
		{
			Aux = p1[i];
			p1[i] = p2[i];
			p2[i] = Aux;
			Aux = null;
			if (p1[i] == null && p2[i] == null)
				continue;
			int threeChange = checkTheTuple(map, p2[i]); //

			if(threeChange != -1)
			{
				Tuple<Course, Course> intercambio = new Tuple<Course, Course>(map[threeChange].Item1, p1[i]); //
			}
			else
			{
				Tuple<Course, Course> intercambio = new Tuple<Course, Course>(p1[i], p2[i]); //
				map.Add(intercambio);
			}
		}
		foreach (Tuple<Course,Course> element in map)
		{
			for (int j = 0; j < p1.Count; j++)
			{
				if (j >= cursor && j <= (cursor + crossoverLong))
				{
					continue;
				}
				if(p1[j] == null)
				{
					if(element.Item1==null){
						p1[j] = element.Item2;
					}
				}
				else
				{
					if (p1[j].Equals(element.Item1))
					{
						p1[j] = element.Item2;
					}
				}
				if (p2[j] == null)
				{
					if (element.Item2 == null)
					{
						p2[j] = element.Item1;
					}
				}
				else
				{
					if (p2[j].Equals(element.Item2))
					{
						p2[j] = element.Item1;
					}
				}




			}

		}
		return new Tuple<List<Course>, List<Course>>(p1, p2);

	}


	public static void printSchedule(Schedule Sch)
	{
		String[] days = new string[] { "lunes", "martes", "miercoles", "jueves", "viernes" };
		String[] hours = new string[] { "7 a 9", "9:10 a 11:10", "12:10 a 2:10", "2:20 a 4:20" };

		for (int i = 0; i < 5; i++)
		{
			Console.WriteLine(days[i]);
			for (int j = 0; j < 4; j++)
			{
				Console.WriteLine(hours[j]);
				for (int k = 0; k < Schedule.aulas; k++)
				{
					if (Sch.matrix[i, j, k] != null)
					{
						Console.WriteLine(Sch.matrix[i, j, k].name + " Aula " + k);
					}
				}
			}
		}*/
		/*
		}   
	}


		//horario1 = creaarhorario();
		//padre = toList(horario1);
		//madre = toList(horario2);
		Console.ReadKey();
		Console.WriteLine("Iniciando");
>>>>>>> Stashed changes
		DefaultData.InsertDefaultData();
		Schedule parent1 = new Schedule();
		Schedule parent2 = new Schedule();
		printSchedule(parent1);
		Tuple<List<Course>, List<Course>> response = PmxCrossover(parent1.matrixToList(),parent2.matrixToList());
		Console.WriteLine("\n despues de aplicar genéticos\n\n");
		parent1.listToMatrix(response.Item1);
		parent2.listToMatrix(response.Item2);
		printSchedule(parent1);
		Console.ReadKey();
		/*DefaultData.InsertDefaultData();
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



            Schedule.OrderOneCrossover(hijo, hija, asig, comp);

    
                // Main de JAFETH 

            /*Console.WriteLine("\nCantidad de asignaciones: {0}, cantidad de compraciones: {1}",asig,comp);
            DefaultData.InsertDefaultData();
            Schedule parent = new Schedule();
            Schedule parent2 = new Schedule();
            Schedule.printSchedule(parent.matrix);
                Schedule.printSchedule(parent2.matrix);
            Console.ReadKey();*/

        }
    }
}
