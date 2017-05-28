using System;
namespace GeneticCheduleGenerator
{
    public class Course
    {
        public string name;
        public int group;
        public int idCourse;
        public int idProfessor;

        public Course(string n, int idC, int idP, int gr)
        {
            this.name = n;
            this.idCourse = idC;
            this.idProfessor = idP;
            this.group = gr;
        }
    }
}
