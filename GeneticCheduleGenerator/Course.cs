﻿using System;
namespace GeneticCheduleGenerator
{
    public class Course
    {
        public string name{ get; set; }
        public int semester; //{ get; set; }
        public int idCourse; //{ get; set; }
        public int idProfessor; //{ get; set; }

        public Course(string n, int idC, int idP, int gr)
        {
            this.name = n;
            this.idCourse = idC;
            this.idProfessor = idP;
            this.semester = gr;
        }
    }
}
