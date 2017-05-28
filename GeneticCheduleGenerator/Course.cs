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
        public int group;

        public Course(string name, int idCourse, Professor profe, int group, int semester,int lections)
        {
            this.name = name;
            this.idCourse = idCourse;
            this.idProfessor = profe;
            this.semester = semester;
            this.lections = lections;
            this.group = group;
        }
    }
}
