using System;
using System.Collections.Generic;

namespace GeneticCheduleGenerator
{
    public class Schedule
    {
        public static int aulas = 10;
        public Course[,,] matrix = new Course[5,4,aulas];// days, hours (1 space in the matrix is equal to 2 hours and 15 minutes)

        public Schedule()
        {
            List<Course> seed = prepareListForCreate(DefaultData.courses);
            createParent(seed);
        }
        /// <summary>
        /// Generates a list respect to a matrix
        /// </summary>
        /// <returns>List with all elements of the matrix</returns>
        public List<Course>  matrixToList()
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
        /// Converts a received matrix into a list
        /// </summary>
        /// <param name="list">List to convert</param>
        public void listToMatrix(List<Course>list)
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

        public static void printParent(List<Course> list,int n)
        {
            Console.Write("\nPadre "+n+": ");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                    Console.Write(" " + list[i].idCourse);
            }
        }

        public static void printSon(List<Course> list, int n)
        {
            Console.Write("\nHijo " + n + ": ");
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
            // save element obtained in a position x
            Random rnd = new Random();

            int crossPoint = rnd.Next(hijo.Count) + 1;  // point to start to select elements of the mutation

            asig += 2;
            comp++;
            while (crossPoint >= hijo.Count) // el punto de cruce no puede quedar al final porque sino no puede seleccionar una subcadena y por ende no habria nada para intercambiar
                crossPoint = rnd.Next(hijo.Count) + 1;

            int cantToSelec = rnd.Next(1, hijo.Count - crossPoint); // number of items to select


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
            choques(crossPoint, cantToSelec, hijo, hija, ref asig, ref comp);

        }
        /// <summary>
        /// Fixed clashes produced by crossing chromosome segments
        /// </summary>
        /// <param name="croPo">Cross point</param>
        /// <param name="cant">Number of elements interchanged</param>
        /// <param name="hijo"></param>
        /// <param name="hija"></param>
        public static void choques(int croPo, int cant, List<Course> hijo, List<Course> hija, ref int asig, ref int comp)
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
                    if ((j >= croPo | j <= croPo + cant) & hijo[i].idCourse == hijo[j].idCourse)
                    {
                        vecesHijo++;
                        asig++;
                    }
                }
                asig++;
                for (int j = 0; j < hijo.Count; j++) // ciclo para comprar el elemento del segmento intercambiado que esta en la pos i con los que estan fuera del segmento
                {
                    asig++;
                    comp += 2;
                    if (hijo[j] != null) // en caso de ser un espacio vacio
                    {
                        comp += 4; ;
                        if ((j < croPo | j > croPo + cant - 1) & hijo[i].idCourse == hijo[j].idCourse)   // si el elemento esta repetido pero es diferente al que se encuentra en la posicion i quiere decir que hay 
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
                                    for (int n = croPo; n < croPo + cant; n++) // cuento cuantas veces aparece el hijo de la posicion i en el segmento de cromosomas seleccionado
                                    {
                                        asig++;
                                        comp+=5;
                                        if ((n >= croPo | n <= croPo + cant) & hija[o].idCourse == hija[n].idCourse)
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
                                            if ((n < croPo | n > croPo + cant - 1) & hija[o].idCourse == hija[n].idCourse)
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
        /// <param name="semester"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
		public bool IsSemesterCrushes(int semester, int day, int hour)
		{
			for (int i = 0; i < aulas; i++)
			{
				Course actual = matrix[day, hour, i];

				if (actual != null)
				{
                    if (actual.semester == semester)
					{
						return true;
					}
				}
			}
			return false;
		}
        /*
        public bool IsCourseCrushes(int semester, int day, int hour)
        {
            for (int i = 0; i < aulas; i++)
            {
                Course actual = matrix[day, hour, i];

                if (actual != null)
                {
                    if (actual.semester == semester)
                    {
                        return true;
                    }
                }
            }
            return false;
        }*/
        /// <summary>
        /// Prepare a list by adding same courses depending on the number of lessons
        /// </summary>
        /// <param name="initial"></param>
        /// <returns></returns>
        public List<Course> prepareListForCreate(List<Course> initial)
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
        /// <summary>
        /// Creates a three-dimensional array which will be a parent schedule
        /// </summary>
        /// <param name="seed">List with all courses to assign</param>
        public void createParent(List<Course> seed)
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
                    if (!IsSemesterCrushes(actual.semester, day, hour) || !IsProfessorCrushes(actual.idProfessor, day, hour))
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
    }
}
