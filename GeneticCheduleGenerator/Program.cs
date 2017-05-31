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
        public static List<Course> hija = new List<Course>();

        /// <summary>
        /// Function that cross two parents and be obtained two son
        /// </summary>
        public static void CrossWithPMX(ref List<Course> hijo, ref List<Course> hija)
        {
            Course course; // save element obtained in a position x
            List<Course> backUp = new List<Course>(); 
            Random rnd = new Random();
            
            int crossPoint = rnd.Next(padre.Count) + 1;  // point to start to select elements of the mutation

            while (crossPoint == padre.Count) // el punto de cruce no puede quedar al final porque sino no puede seleccionar una subcadena y por ende no habria nada para intercambiar
                crossPoint = rnd.Next(padre.Count);

            int cantToSelec = rnd.Next(1,padre.Count - crossPoint); // number of items to select
            
            for (int i = crossPoint; i < cantToSelec + crossPoint; i++) // realiza el cruce genetico
            {
                course = hijo[i];
                hijo[i] = hija[i];
                hija[i] = course;
            }
            choques(crossPoint,cantToSelec, ref hijo, ref hija);            
        }
        /// <summary>
        /// Repara los choques existentes
        /// </summary>
        /// <param name="croPo">Cross Point</param>
        public static void choques(int croPo, int cant, ref List<Course> hijo, ref List<Course> hija)
        {
            int vecesHijo = 0, vecesHija = 0; // cantidad de veces que aparece el obj

            for (int i = croPo; i < hijo.Count; i++) // comparo los elementos seleccionados (cruzados) para ver si hay algun error y corregirlo
            {
                for (int j = 0; j < hijo.Count; j++)
                {
                    if (hijo[j] != null)
                    {
                        if ((j < croPo | j > croPo + cant) & hijo[j].Equals(hijo[i])) // si el elemento esta repetido pero es diferente al que se encuentra en la posicion i quiere decir que hay 
                        {                                   // mas de 1 y si hay mas de 1 de ese tipo de curso quiere decir que esta ahi por el cruce realizado
                            vecesHijo++;
                            if (vecesHijo > hijo[i].lections)
                            {
                                for (int o = croPo; o < hija.Count; o++)
                                {
                                    for (int n = 0; n < hija.Count; n++)
                                    {
                                        if (hija[n] != null)
                                        {
                                            if ((n < croPo | n > croPo + cant) & hija[n].Equals(hija[o]))
                                            {
                                                vecesHija++;
                                                if (vecesHija > hija[o].lections)
                                                {
                                                    hijo[j] = hija[n];
                                                    hija[n] = hijo[i];
                                                }
                                            }
                                        }
                                    }// end for
                                }// end for                           
                            }
                        }
                    }
                }// end for
            }// end for   
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(124%40.0+"\n\n");
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
            DefaultData.InsertDefaultData();
            Schedule parent1 = new Schedule();
            Schedule parent2 = new Schedule();
            padre = parent1.matrixToList();
            madre = parent2.matrixToList();
            
            hijo = padre;
            //hijo = padre;

            hija = parent2.matrixToList();

            for (int i = 0; i < padre.Count; i++)
            {
                if(padre[i] != null)
                    Console.Write(" "+padre[i].idCourse);
            }

            CrossWithPMX(ref hijo, ref hija);
            
            /*Console.WriteLine("\n");
            for (int i = 0; i < madre.Count; i++)
            {
                if (madre[i] != null)
                    Console.Write(" " + madre[i].idCourse);
            }
            Console.WriteLine("\n");
            for (int i = 0; i < hija.Count; i++)
            {
                if (hija[i] != null)
                    Console.Write(" " + hija[i].idCourse);
            }*/
            //Console.WriteLine(hijo.Count + ", " + hija.Count);
            parent1.listToMatrix(padre);
            parent2.listToMatrix(madre);

            Console.ReadKey();
        }
    }
}
