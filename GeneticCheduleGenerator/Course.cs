using System;
namespace GeneticCheduleGenerator
{
    public class Course
    {
        private string name;
        private int group;
        private int idCourse;
        private int idProfessor;

        public Course(string n, int idC, int idP, int gr)
        {
            this.name = n;
            this.idCourse = idC;
            this.idProfessor = idP;
            this.group = gr;
        }
    }
}
