using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticCheduleGenerator
{
    class DefaultData
    {
        /// <summary>
        /// This list will contain objects of type Professor
        /// </summary>
        public static List<Professor> professors;

        /// <summary>
        /// This list will contain objects of type Course
        /// </summary>
        public static List<Course> courses;
        public static void InsertDefaultData()
        {
            // nombre idP horAsig
            Professor p1 = new Professor("Diego Rojas", 1, 38);
            Professor p2 = new Professor("Vera Gamboa", 2, 40);
            Professor p3 = new Professor("Karina Gonzales", 3, 38);

            Professor p4 = new Professor("Rocio Quiros", 4, 40);
            Professor p5 = new Professor("Danilo Alpizar", 5, 38);
            Professor p6 = new Professor("Anabelle Castro", 6, 40);

            Professor p7 = new Professor("Lorena Valerio", 7, 40);
            Professor p8 = new Professor("Leonardo Viquez", 8, 38);
            Professor p9 = new Professor("Carlos Guillen", 9, 40);
            Professor p10 = new Professor("Dere Elizondo", 10, 40);
            Professor p11 = new Professor("Erick Salas", 11, 40);
            Professor p12 = new Professor("Oscar Viquez", 12, 40);
            Professor p13 = new Professor("Jorge Velasco", 13, 40);
            professors = new List<Professor> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12 ,p13};


            //semestre 1
            Course c1 = new Course("Fundamentos de computacion", 1, p1,1,2);
            Course c2 = new Course("Fundamentos de computacion", 2, p4, 1,2);
            Course c3 = new Course("Matematica General", 3, p3,1,2);
            Course c4 = new Course("Matematica General", 4, p9, 1,2);
            Course c5 = new Course("Introduccion a la programacion", 5, p2,1,2);
            Course c6 = new Course("Comunicacion tecnica", 6, p11, 1,2);
            Course c7 = new Course("Matematica discreta", 7, p3, 1,1);
            Course c8 = new Course("Matematica discreta", 8, p10, 1,1);
            Course c9 = new Course("Ingles I para computacion", 9, p5, 1,1);
            Course c10 = new Course("Ingles I para computacion", 10, p5, 1,1);
            Course c11 = new Course("Ingles I para computacion", 11, p5, 1,1);
            Course c12 = new Course("Taller de programacion", 12, p2, 1,2);

            //semestre 2
            Course c13 = new Course("Ambiente humano", 13, p11, 2,1);
            Course c14 = new Course("Programacion Orientada a Objetos", 14, p7, 2,2);
            Course c15 = new Course("Estructura de datos", 15, p12, 2,2);
            Course c16 = new Course("Calculo para computacion", 16, p6, 2,2);
            Course c17 = new Course("Calculo para computacion", 17, p9, 2,2);
            Course c18 = new Course("Ingles II para computacion", 18, p5, 2,1);
            Course c19 = new Course("Ingles II para computacion", 19, p5, 2,1);
            Course c20 = new Course("Arquitectura de computadores", 20, p4, 2,2);
            Course c21 = new Course("Arquitectura de computadores", 21, p1, 2,2);
            //semestre 3
            Course c22 = new Course("Analisis de algoritmos", 22, p7,3,2);
            Course c23 = new Course("Analisis de algoritmos", 23, p7, 3,2);
            Course c24 = new Course("Bases de datos I", 24, p8,3,2);
            Course c25 = new Course("Algebra lineal para computacion", 25, p9,3,2);
            Course c26 = new Course("Algebra lineal para computacion", 26, p9, 3,2);
            //semestre 4
            Course c27 = new Course("Lenguajes de programacion", 27, p13, 3,2);
            Course c28 = new Course("Bases de datos II", 28, p8, 50,2);
            Course c29 = new Course("Requerimientos de Software", 29, p8, 3,2);
            Course c30 = new Course("Probabilidades", 30, p9, 3,2);

            //semestre 5
            Course c31 = new Course("Filosoficos", 31, p11, 5,1);
            Course c32 = new Course("Administracion de proyectos", 32, p13, 5,2);
            Course c33 = new Course("Compiladores e interpretes", 33, p12, 5,2);
            Course c34 = new Course("Diseñode software", 34, p8, 5,2);
            courses = new List<Course> { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34 };
        }            
    }
}
