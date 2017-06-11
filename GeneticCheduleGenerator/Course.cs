﻿using System;
namespace GeneticCheduleGenerator
{
    public class Course
    {
        public string name{ get; set; }
        public int semester; //{ get; set; }
        public int idCourse; //{ get; set; }
        public Professor idProfessor; //{ get; set; }
        public int lections; //{ get; set; }
        public int groupe;
        public int classroom = 0;

        public Course(string name, int idCourse, Professor profe, int groupe, int semester,int lections)
        {
            this.name = name;
            this.idCourse = idCourse;
            this.idProfessor = profe;
            this.semester = semester;
            this.lections = lections;
            this.groupe = groupe;
        }
    }
}
