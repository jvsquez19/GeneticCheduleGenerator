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
        public static Course[][][] horario1;
        public static Course[][][] horario2;
        public static List<Course> padre = new List<Course>();
        public static List<Course> madre = new List<Course>();

        public static List<Course> hijo = new List<Course>();
        public static List<Course> hija = new List<Course>();

        /// <summary>
        /// Function that cross two parents and be obtained two son
        /// </summary>
        public static void CrossWithPMX()
        {
            int numAulas = 0;
            numAulas = horario1[5][5].Length;

            Course course; // save element obtained in a position x
            List<Course> backUp = new List<Course>(); 
            Random rnd = new Random();
            
            int crossPoint = rnd.Next(padre.Count) + 1;  // point to start to select elements of the mutation

            while (crossPoint == padre.Count) // el punto de cruce no puede quedar al final porque sino no puede seleccionar una subcadena y por ende no habria nada para intercambiar
                crossPoint = rnd.Next(padre.Count);

            int cantToSelec = rnd.Next(1,padre.Count - crossPoint); // number of items to select

            hijo = padre;
            hija = madre;

            for (int i = crossPoint; i < cantToSelec + crossPoint; i++) // realiza el cruce genetico
            {
                course = hijo[i];
                hijo[i] = hija[i];
                hija[i] = course;
            }
            choques(crossPoint,cantToSelec);
            
        }
        /// <summary>
        /// Repara los choques existentes
        /// </summary>
        /// <param name="croPo">Cross Point</param>
        public static void choques(int croPo, int cant)
        {
            int vecesHijo = 0, vecesHija = 0; // cantidad de veces que aparece el obj

            for (int i = croPo; i < hijo.Count; i++) // comparo los elementos seleccionados (cruzados) para ver si hay algun error y corregirlo
            {
                for (int j = 0; j < hijo.Count; j++)
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
                                    if ((j < croPo | j > croPo + cant) & hija[n].Equals(hija[o]))
                                    {
                                        vecesHija++;
                                        if (vecesHija > hija[o].lections)
                                        {
                                            hijo[j] = hija[n];
                                            hija[n] = hijo[i];
                                        }
                                    }
                                }// end for
                            }// end for                           
                        }
                    }
                }// end for
            }// end for            
        }

        public static void Main(string[] args)
        {
            // horario1 = creaarhorario();
            // padre = toList(horario1);
            // madre = toList(horario2);

            Console.ReadKey();
        }
    }
}
