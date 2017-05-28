﻿using System;
namespace GeneticCheduleGenerator
{
    public class Course
    {
        public int lections;
        public string name{ get; set; }
        public int semester; //{ get; set; }
        public int idCourse; //{ get; set; }
        public Professor idProfessor; //{ get; set; }

        public Course(string n, int idC, Professor idP, int gr,int lections)
        {
            this.lections = lections;
            this.name = n;
            this.idCourse = idC;
            this.idProfessor = idP;
            this.semester = gr;
        }
    }
}
