﻿﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GeneticCheduleGenerator
{
    public class Schedule
    {
        public static int aulas = 10;
        public Course[,,] matrix = new Course[5,4,aulas];// days, hours (1 space in the matrix is equal to 2 hours and 15 minutes)
        public Course[,,] best = new Course[5, 4, aulas];
        public Process currentProcess = Process.GetCurrentProcess();
        public float bestFit = 0;

        public Schedule()
        {
            List<Course> seed = PrepareListForCreate(DefaultData.courses);
            CreateParent(seed);
        }        
        
        /// <summary>
        /// Generates a list respect to a matrix
        /// </summary>
        /// <returns>List with all elements of the matrix</returns>
        public List<Course> MatrixToList()
        {
            List<Course> response = new List<Course>();

            for (int i = 0; i < 5; i++)
            {
				for (int j = 0; j < 4; j++)
				{
					for (int k = 0; k < aulas; k++)
					{
                        response.Add(matrix[i,j,k]);
					}
				}
			}
            return response;
        }
        
        /// <summary>
        /// Converts a received list in matrix
        /// </summary>
        /// <param name="list">List to convert</param>
        public void ListToMatrix(List<Course>list)
        {
            int count = 0;
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					for (int k = 0; k < aulas; k++)
					{
                        matrix[i, j, k] = list[count];
                        count++;
					}
				}
			}
        }

		public Course[,,] ListToMatrixR(List<Course> list)
		{
            Course[,,] response = new Course[5, 4, aulas];
			int count = 0;
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					for (int k = 0; k < aulas; k++)
					{
                        response[i, j, k] = list[count];
						count++;
					}
				}
			}
            return response;
		}
        
        /// <summary>
        /// Print a received list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="n">Name of the list</param>
        public static void PrintList(List<Course> list,string n)
        {
            Console.Write("\n"+n+": ");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                    Console.Write(" " + list[i].idCourse);
            }
        }
                                                                                    
        /// <summary>
        /// Function that cross two parents and be obtained two son
        /// </summary>
        public static void CrossWithPMX(List<Course> hijo, List<Course> hija, ref int asig, ref int comp)
        {
            Random rnd = new Random();

            int crossPoint = rnd.Next(hijo.Count);  // point to start to select elements of the mutation

            asig += 2;
            comp++;
            while (crossPoint >= hijo.Count) // el punto de cruce no puede quedar al final porque sino no puede seleccionar una subcadena y por ende no habria nada para intercambiar
                crossPoint = rnd.Next(hijo.Count);

            int cantToSelec = rnd.Next(0, hijo.Count - crossPoint); // number of items to select


            Console.WriteLine("\n\nPunto cruce: {0}   Cantidad: {1}", crossPoint, cantToSelec+"\n");
            asig += 3;
            for (int i = crossPoint; i < cantToSelec + crossPoint; i++) // realiza el cruce genetico CROSS-OVER
            {
                comp++;
                asig += 4;
                Course course = hijo[i];
                hijo[i] = hija[i];
                hija[i] = course;
            }
            comp++;
            Crashes(crossPoint, cantToSelec, hijo, hija, ref asig, ref comp);
        }

        /// <summary>
        /// Fixed crashes produced by crossing chromosome segments
        /// </summary>
        /// <param name="croPo">Cross point</param>
        /// <param name="cant">Number of elements interchanged</param>
        /// <param name="hijo"></param>
        /// <param name="hija"></param>
        public static void Crashes(int croPo, int cant, List<Course> hijo, List<Course> hija, ref int asig, ref int comp)
        {
            bool parar;
            int vecesHijo = 0, vecesHija = 0; // cantidad de veces que aparece el obj
            asig += 7;
            Course cursoRespaldo;

            for (int i = croPo; i < croPo + cant; i++) // comparo los elementos seleccionados (cruzados) para ver si hay algun error y corregirlo
            {
                comp++;
                asig += 3;
                parar = false;
                for (int j = croPo; j < croPo + cant; j++) // cuento cuantas veces aparece el hijo de la posicion i en el segmento de cromosomas seleccionado
                {
                    asig++;
                    comp += 5;
                    if (hijo[i] != null)
                    {
                        comp += 4;
                        if ((j >= croPo | j <= croPo + cant) & hijo[i].Equals(hijo[j]))
                        {
                            vecesHijo++;
                            asig++;
                        }
                    }
                }
                asig++;
                for (int j = 0; j < hijo.Count; j++) // ciclo para comprar el elemento del segmento intercambiado que esta en la pos i con los que estan fuera del segmento
                {
                    asig++;
                    comp += 2;
                    if (hijo[i] != null) // en caso de ser un espacio vacio
                    {
                        comp += 4; ;
                        if ((j < croPo | j > croPo + cant - 1) & hijo[i].Equals(hijo[j]))   // si el elemento esta repetido pero es diferente al que se encuentra en la posicion i quiere decir que hay 
                        {                                                               // mas de 1 y si hay mas de 1 de ese tipo de curso quiere decir que esta ahi por el cruce realizado
                            asig++;
                            vecesHijo++;
                            comp++;
                            if (vecesHijo > hijo[i].lections) // TENGO EL ELEMENTO REPETIDO QUE VOY A CAMBIAR CON LA OTRA CADENA
                            {
                                asig += 2;
                                cursoRespaldo = hijo[j]; // curso ubicado fuera del segmento de cromosomas intercambiados en el CROSS-OVER
                                for (int o = croPo; o < croPo + cant; o++)
                                {
                                    comp++;
                                    asig += 2;
                                    if (hija[o] != null)
                                    {
                                        for (int n = croPo; n < croPo + cant; n++) // cuento cuantas veces aparece el hijo de la posicion i en el segmento de cromosomas seleccionado
                                        {
                                            asig++;
                                            comp += 5;
                                            if ((n >= croPo | n <= croPo + cant) & hija[o].Equals(hija[n]))
                                            {
                                                vecesHija++;
                                                asig++;
                                            }
                                        }
                                        comp++;
                                        for (int n = 0; n < hija.Count; n++)
                                        {
                                            asig++;
                                            comp += 2;
                                            if (hija[n] != null) // en caso de ser un espacio vacio
                                            {
                                                comp += 4;
                                                if ((n < croPo | n > croPo + cant - 1) & hija[o].Equals(hija[n]))
                                                {
                                                    asig++;
                                                    vecesHija++;
                                                    comp++;
                                                    if (vecesHija > hija[o].lections)
                                                    {
                                                        // HIJA[N] ES LA REPETIDA FUERA DEL SEGMENTO
                                                        asig += 5;
                                                        hijo[j] = hija[n];
                                                        hija[n] = cursoRespaldo;
                                                        Console.WriteLine("Intercambiando curso " + cursoRespaldo.idCourse + ", Padre 1 con curso " + hijo[j].idCourse + ", Padre 2");
                                                        vecesHija = 0;
                                                        parar = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }// end for
                                        asig++;
                                        comp += 2;
                                        vecesHija = 0;
                                        if (parar)
                                        {
                                            asig++;
                                            break;
                                        }
                                    }// end for    
                                }            
                            }
                            
                        }
                    }
                    comp++;
                    if (parar)
                    {
                        asig++;
                        break;
                    }
                }// end for  
                comp++;
                vecesHijo = 0;
                asig++;
            }// end for   
            comp++;
            //Console.WriteLine("\n\nCantidad de asignaciones: {0}, cantidad de compraciones: {1}", asig, comp);
        }

        public void GeneticPMX(List<Course> hijo, List<Course> hija)
        {
            int comp = 0, asig = 0;
            for (int i = 0; i < 10000; i++) // cantidad de generaciones
            {
                //Schedule parent2 = new Schedule();
                //List<Course> list = parent2.MatrixToList();
                CrossWithPMX(hijo, hija, ref asig, ref comp);
                Course[,,] hijom = ListToMatrixR(hijo);
                Course[,,] hijam = ListToMatrixR(hija);
                float aFit = getFitness(hijam);
                float oFit = getFitness(hijom);
                if(aFit>bestFit)
                {
                    bestFit = aFit;
                    best = Clone(hijam);

                }
                if (oFit>bestFit)
                {
                    bestFit = oFit;
                    best = Clone(hijom);

                }
                Console.WriteLine("Cantidad de Asignaciones: {0}, Cantidad de Comprobaciones: {1}",asig,comp);
                comp = 0; asig = 0;
            }


        }

		public void GeneticOX(List<Course> hijo, List<Course> hija)
		{
			int comp = 0, asig = 0;
			for (int i = 0; i < 10; i++) // cantidad de generaciones
			{
                OrderOneCrossover(hijo, hija, ref asig, ref comp);
				Course[,,] hijom = ListToMatrixR(hijo);
				Course[,,] hijam = ListToMatrixR(hija);
				float aFit = getFitness(hijam);
				float oFit = getFitness(hijom);
				if (aFit > bestFit)
				{
					bestFit = aFit;
					best = Clone(hijam);

				}
				if (oFit > bestFit)
				{
					bestFit = oFit;
					best = Clone(hijom);

				}
				Console.WriteLine("Cantidad de Asignaciones: {0}, Cantidad de Comprobaciones: {1}", asig, comp);
				comp = 0; asig = 0;

			}

		}


        /// <summary>
        /// Genetic Algorithm named Order One Crossover
        /// </summary>
        /// <param name="padre1"></param>
        /// <param name="padre2"></param>
        /// <param name="asig"></param>
        /// <param name="comp"></param>
        public static void OrderOneCrossover(List<Course> padre1, List<Course> padre2, ref int asig, ref int comp)
        {
            asig += 5;
            List<Course> hijo1 = new List<Course>(padre1);
            List<Course> hijo2 = new List<Course>(padre2);

            Random rnd = new Random();
            //FillSon(padre1, hijo1);

            int crossPoint = rnd.Next(hijo1.Count-1);  // point to start to select elements of the mutation


            while (crossPoint >= hijo1.Count)// el punto de cruce no puede quedar al final porque sino no puede seleccionar una subcadena y por ende no habria nada para intercambiar
            {
                comp++;
                asig++;
                crossPoint = rnd.Next(hijo1.Count);
            }
            comp++;

            int cantToSelec = rnd.Next(1, hijo1.Count - crossPoint); // number of items to select

            asig++;
            for (int i = 0; i < padre1.Count; i++)
            {
                asig++;
                comp += 4;
                if (i < crossPoint | i >= crossPoint + cantToSelec)
                {
                    asig += 2;
                    hijo1[i] = null;
                    hijo2[i] = null;
                }
            }
            comp++;

            Console.WriteLine("\n\nPunto cruce: {0}   Cantidad: {1}", crossPoint, cantToSelec + "\n");

            Console.WriteLine("\n--------------- Hijo 1 ---------------\n");
            FillOX(crossPoint, cantToSelec, hijo1, padre2, ref asig, ref comp);
            
            PrintList(hijo1, "Hijo 1");         
            
            asig = 0;
            comp = 0;

            Console.WriteLine("\n--------------- Hijo 2 ---------------\n");
            FillOX(crossPoint, cantToSelec, hijo2, padre1, ref asig, ref comp);                                    
            PrintList(hijo2, "Hijo 2");

            padre1 = hijo1;
            padre2 = hijo2;            
        }
        /// <summary>
        /// Mutation Function
        /// </summary>
        public void Mutations()
        {
            Random rnd = new Random();
            bool listo = false;
            Course crashCourse;
            for (int a = 0; a < 5; a++)//dias
            {
                for (int b = 0; b < 4; b++)//horas
                {
                    listo = false;
                    for (int c = 0; c < aulas; c++)//aulas
                    {
                        if (matrix[a, b, c] != null)
                        {
                            Professor profesor = matrix[a, b, c].idProfessor;
                            if (IsProfessorCrushes(profesor, a, b) | IsSemesterCrushes(matrix[a, b, c].semester, matrix[a, b, c].groupe, a, b)) // si hay choques de semestre o de profes
                            {
                                Console.WriteLine("Choque de profesor o semestre!");
                                crashCourse = matrix[a, b, c];

                                for (int d = 0; d < 5; d++) // busco null perfecto para meter aqui el curso y que no de choques
                                {
                                    for (int e = 0; e < 4; e++)
                                    {
                                        for (int f = 0; f < aulas; f++)
                                        {
                                            if (matrix[d, e, f] == null)
                                                if (!IsProfessorCrushes(crashCourse.idProfessor, d, e) & !IsSemesterCrushes(crashCourse.semester, crashCourse.groupe, d, e))
                                                { 
                                                    matrix[d, e, f] = crashCourse;
                                                    Console.WriteLine("Mutando curso#"+crashCourse.idCourse+" a posicion #["+d+", "+e+", "+f+"]\n");
                                                    matrix[a, b, c] = null;
                                                    listo = true;
                                                    break;
                                                }
                                        }
                                        if (listo)
                                            break;
                                    }
                                    if (listo)
                                        break;
                                }
                                if (listo)
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public static void FillOX(int crossPo, int cantSelect, List<Course> hijo1, List<Course> hijo2, ref int asig, ref int comp)
        {
            bool esta = false;
            int pos = crossPo + cantSelect, veces = 0;
            asig += 4;
            for (int i = crossPo + cantSelect; i < hijo2.Count; i++) // en hijo 2 para agregar a hijo 1 el elemento ubicado en i si ese elemento no esta dentro del segmento marcado
            {
                asig += 3;
                comp++;
                esta = false;
                for (int j = crossPo; j < crossPo + cantSelect; j++)
                {
                    asig += 3;
                    comp++;
                    veces = 0;
                    for (int h = crossPo; h < crossPo + cantSelect; h++)
                    {
                        asig++;
                        comp += 2;
                        if (hijo2[i] != null)
                        {
                            comp++;
                            if (hijo2[i].Equals(hijo1[h]))
                            {
                                asig++;
                                veces++;
                            }
                        }
                    }
                    comp += 2;
                    if (hijo2[i] != null)
                    {
                        comp += 3;
                        if (hijo2[i].Equals(hijo1[j]) & veces == hijo2[i].lections) // para descargar el elemento y no agregarlo...
                        {
                            asig+=2;
                            esta = true;
                            comp++;
                            if (i == hijo2.Count - 1)
                            {
                                asig++;
                                i = -1;
                            }
                            break;
                        }
                    }
                }
                comp += 2;
                if (esta)
                {
                    asig++;
                    continue;
                }
                else
                {
                    asig += 4;
                    hijo1[pos] = hijo2[i];
                    if (hijo2[i] != null)
                        Console.WriteLine("Colocando curso #" + hijo2[i].idCourse + " en la posicion #" + pos);
                    //else
                        //Console.WriteLine("Colocando un espacio (null) en la posicion #" + pos);
                    pos++;

                    veces = 0;
                    for (int m = 0; m < hijo1.Count; m++)
                    {
                        asig++;
                        comp += 2;
                        if (hijo2[i] != null)
                        {
                            comp++;
                            if (hijo2[i].Equals(hijo1[m]))
                            {
                                asig++;
                                veces++;
                            }
                        }
                    }
                    comp += 2;
                    if (hijo2[i] != null)
                    {
                        comp++;
                        if (veces > hijo2[i].lections)
                        {
                            asig++;
                            pos--;
                        }
                    }
                    comp++;
                    if (pos == crossPo)
                    {
                        asig++;
                        break;
                    }
                }
                comp++;
                if (i == hijo2.Count - 1)
                {
                    asig++;
                    i = -1;
                }
                comp++;
                if (pos == hijo2.Count)
                {
                    asig++;
                    pos = 0;
                }
            }
            comp++;
        }
        
        /// <summary>
        /// Returns true if a professor already has to give classes at determinated hour
        /// </summary>
        /// <param name="Profesor"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public bool IsProfessorCrushes(Professor Profesor, int day, int hour)
        {
            for (int i = 0; i < aulas; i++)
            {
                Course actual = matrix[day, hour, i];

                if(actual != null)
                {
                    if(actual.idProfessor.Equals(Profesor))
                    {
                        return true; 
                    }   
                }
            }

            return false;   
        }
        
		/// <summary>
		/// Function that evaluates if there is a clash of semesters
		/// </summary>
		/// <returns></returns>
        public Course[,,] Clone()
        {
            Course[,,] response = new Course[5, 4, aulas];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int a = 0; a < aulas; a++)
                    {
                        response[i, j, a] = matrix[i, j, a];
                    }
                }
            }
            return response;
        }

		public Course[,,] Clone(Course[,,] toCopy)
		{
			Course[,,] response = new Course[5, 4, aulas];
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					for (int a = 0; a < aulas; a++)
					{
                        response[i, j, a] = toCopy[i, j, a];
					}
				}
			}
			return response;
		}

        /// <summary>
        /// Function that evaluates if there is a crash of semesters
        /// </summary>
        /// <param name="semester"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public bool IsSemesterCrushes(int semester, int groupe, int day, int hour)
        {
			for (int i = 0; i < aulas; i++)
			{
				Course actual = matrix[day, hour, i];

				if (actual != null)
				{
                    if (actual.semester == semester && actual.groupe == groupe)
					{
						return true;
					}
				}
			}
			return false;
		}
        
        /// <summary>
        /// Prepare a list by adding same courses depending on the number of lessons
        /// </summary>
        /// <param name="initial"></param>
        /// <returns></returns>
        public List<Course> PrepareListForCreate(List<Course> initial)
        {
            List<Course> response = new List<Course>();
            for (int i = 0; i < initial.Count; i++)
            {
                for (int j = 0; j < initial[i].lections; j++)
                {
                    response.Add(initial[i]);
                }
            }
            return response;
        }
        
		public static void printSchedule(Course[,,] matrix)
		{
			String[] days = new string[] { "lunes", "martes", "miercoles", "jueves", "viernes" };
			String[] hours = new string[] { "\n7:00 a 9:15", "\n9:15 a 11:30", "\n12:30 a 2:45", "\n2:45 a 4:30" };

			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine(days[i]);
				for (int j = 0; j < 4; j++)
				{
					Console.WriteLine(hours[j]);
					for (int k = 0; k < aulas; k++)
					{
                        Course actual = matrix[i, j, k];
                        if (actual != null)
						{
                            Console.WriteLine(actual.name + " Aula: " + k + " Grupo: "+ actual.groupe);
						}
					}
				}
			}
        }   

        /// <summary>
        /// Creates a three-dimensional array which will be a parent schedule
        /// </summary>
        /// <param name="seed">List with all courses to assign</param>
        public void CreateParent(List<Course> seed)
        {
            Random rand = new Random();
            while( seed.Count > 0)
            {
                int cursor = rand.Next(seed.Count-1);
                Course actual = seed[cursor];
                while(true)
                {
					int day = rand.Next(4);
					int hour = rand.Next(3);
                    if (!IsSemesterCrushes(actual.semester,actual.groupe, day, hour) || !IsProfessorCrushes(actual.idProfessor, day, hour))
                    {
                        for (int i = 0; i < aulas; i++)
                        {
                            if(matrix[day,hour,i]==null)
                            {
                                matrix[day, hour, i] = actual;
                                seed.Remove(actual);
                                break;
                            }
                        }
                        break;
                    }  
                }
            }
        }

		/// <summary>
		/// Iterates a Matrix and returns the fitness.
		/// </summary>

		public float getFitness()
        {
            float fit = 1;
            float penalty = (float)0.05;
            for (int i = 0; i < 5; i++)
            {
                List<Course> FoundCourses = new List<Course>();
                for (int j = 0; j < 4; j++)
                {
                    for (int a = 0; a < aulas; a++)
                    {
                        for (int aux = 0; aux < FoundCourses.Count; aux++)
                        {
                            if (matrix[i,j,a]!=null)
                            {
                                if (FoundCourses[aux].Equals(matrix[i, j, a]))
                                {
                                    fit -= penalty;
                                    break;
                                }
                            }
                        }
                        if (matrix[i,j,a]!=null)
                            FoundCourses.Add(matrix[i, j, a]);
                    }
                }


            }
            return fit;
        }

		public float getFitness(Course[,,] toEvaluate)
		{
			float fit = 1;
			float penalty = (float)0.05;
			for (int i = 0; i < 5; i++)
			{
				List<Course> FoundCourses = new List<Course>();
				for (int j = 0; j < 4; j++)
				{
					for (int a = 0; a < aulas; a++)
					{
						for (int aux = 0; aux < FoundCourses.Count; aux++)
						{
							if (matrix[i, j, a] != null)
							{
                                if (FoundCourses[aux].Equals(toEvaluate[i, j, a]))
								{
									fit -= penalty;
									break;
								}
							}
						}
						if (matrix[i, j, a] != null)
							FoundCourses.Add(matrix[i, j, a]);
					}
				}


			}
			return fit;
		}
        
        public void CleanMatrix()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int a = 0; a < aulas; a++)
                    {
                        matrix[i, j, a] = null;
                    }

                }
            }
        }
        
		/// <summary>
		/// Brand and Bounds method that explores all the posibilities.
		/// </summary>
		/// <param name="seed">List with all courses to assign</param>
		public void BrandAndBoundAux(List<Course> seed, int day, int hour, int aula, ref long comp, ref long asig, ref int iterations, ref int bounds)
        {

            comp++;
            if(iterations >= 10000)
                return;
            
			if (seed.Count == 0)
			{
                asig++;
                float fit = getFitness();
                comp++;
				if (fit > bestFit)
				{
                    asig += 203;
					best = Clone();
                    bestFit = fit;
                    //Console.WriteLine("NUEVO MEJOR \n" + "FIT: " + fit + "\n" + "BESTFIT: " + bestFit+"\n");
                    //printSchedule(best);
                    Console.WriteLine();
                    iterations = 0;
					return;
				}
                    
					//Console.WriteLine("DESCARTADO \n" + "FIT: " + fit + "\n" + "BESTFIT: " + bestFit + "\n");
                    iterations++;
					//printSchedule(matrix);
                    return;

			}
            comp++;
			if (((day == 4) && (hour == 3)) && (aula == aulas-1))
			{
                comp++;
                if(seed.Count == 1)
                {
                    Course actual = seed[0];
                    comp++;
                    if (!IsSemesterCrushes(actual.semester,actual.groupe, day, hour) && (!IsProfessorCrushes(actual.idProfessor, day, hour)))
                    {
                        asig++;
                        matrix[day, hour, aula] = actual;
                        seed.RemoveAt(0);
                        BrandAndBoundAux(seed, day, hour, aula, ref comp, ref asig, ref iterations, ref bounds);
                        matrix[day, hour, aula] = null;
                        asig++;
                        seed.Add(actual);
                    }
                    return;

                }
                return;
			}
            comp++;
			if (aula == aulas)
			{
                asig++;
				aula = 0;
				hour++;
			}
            comp++;
			if (hour == 4)
			{
                asig++;
				hour = 0;
				day++;
			}
            comp++;
            for (int i = 0; i < seed.Count; i++)
            {
                comp++;
                Course actual = seed[0];
                seed.RemoveAt(0);
                comp+=2;
                if (!IsSemesterCrushes(actual.semester, actual.groupe, day, hour) && (!IsProfessorCrushes(actual.idProfessor, day, hour)))
                {
                    matrix[day, hour, aula] = actual;
                    BrandAndBoundAux(seed, day, hour, aula + 1, ref comp, ref asig, ref iterations, ref bounds);
                    if (iterations >= 10000)
                    {
                        break;
                    }
                    matrix[day, hour, aula] = null;
                    asig++;

                }
                else
                    bounds++;
                    
                seed.Add(actual);
                comp++;
                if (bestFit == 1)
                    return;
				if (iterations >= 10000)
				{
					break;
				}


            }

            BrandAndBoundAux(seed, day, hour, aula + 1, ref comp, ref asig, ref iterations, ref bounds);
       }


        public void BrandAndBound()
        {
            int bounds = 0;
            int iterations = 0;
            long asig = 0, comp = 0;
            
			List<Course> seed = PrepareListForCreate(DefaultData.courses);
            Shuffle(seed);
			CleanMatrix();
            BrandAndBoundAux(seed, 0, 0, 0, ref asig, ref comp, ref iterations, ref bounds);
            Console.WriteLine("PODAS: "+bounds+ " Comparaciones: "+comp +" Asig: "+asig+"\n");
            Console.WriteLine("FITNESS:"+bestFit+"\n");
			long totalBytesOfMemoryUsed = currentProcess.WorkingSet64;
            Console.WriteLine("MEMORIA UTILIZADA: " + totalBytesOfMemoryUsed / 1048576.0);
        }


		/// <summary>
		/// Receives a list and shuffles it.
		/// </summary>
		/// <param name="list">List to shuffle</param>
		public static void Shuffle<Course>(List<Course> list)
		{
            Random rng = new Random();
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				Course T = list[k];
				list[k] = list[n];
				list[n] = T;
			}
		}

        public Tuple<Course[,,], Course[,,]> CreateAlternativeMatrixes()
        {
            Course[,,] professorMatrix = new Course[5, 4, DefaultData.professors.Count];
            Course[,,] SemestersMatrix = new Course[5, 4, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int a = 0; a < aulas; a++)
                    {
                        Course actual = best[i, j, a];
                        if (actual != null)
                        {
                            actual.classroom = a;
                            professorMatrix[i, j, actual.idProfessor.idProfessor - 1] = actual;
                            SemestersMatrix[i, j, actual.semester - 1] = actual;
                        }
                    }
                }
            }
            Tuple<Course[,,], Course[,,]> response = new Tuple<Course[,,], Course[,,]>(professorMatrix,SemestersMatrix);
            return response;
        }
    }
}
