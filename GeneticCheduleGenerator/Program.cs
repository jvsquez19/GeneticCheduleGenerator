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
        public static Course[][][] horario; 

        /// <summary>
        /// Funcion encargada de insertar datos predeterminados
        /// </summary>
        public void InsertData()
        {
            // insert data
            Professor p1 = new Professor("Lorena Valerio",1,40);
            Professor p2 = new Professor("Leonardo Viquez",2,38);
            Professor p3 = new Professor("Diego Rojas",3,38);
            Professor p4 = new Professor("Carlos Guillen",4,40);
            Professor p5 = new Professor("Karina Gonzales",5,38);
            Professor p6 = new Professor("Patricia Lopez",6,40);

            Course c1 = new Course("Analisis de algoritmos",1,1,5);
            Course c2 = new Course("Bases de datos",2,2,5);
            Course c3 = new Course("Fundamentos de computacion", 3, 3, 4);
            Course c4 = new Course("Algebra lineal para computacion", 4, 4, 6);
            Course c5 = new Course("Matematica General", 4, 5, 6);
            Course c6 = new Course("Calculo para computacion", 5, 4, 6);
            Course c7 = new Course("Ingles II para computacion", 6, 6, 3);

            horario[0][0][0] = c1; // lunes a las 7am analisis
            horario[1][5][3] = c2;


        }


        public static void Main(string[] args)
        {
            Console.WriteLine("Hola, how are usted? ");
        }
    }
}
