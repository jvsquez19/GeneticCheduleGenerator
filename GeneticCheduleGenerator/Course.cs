using System;
namespace GeneticCheduleGenerator
{
    public class Course
    {
        private string name;
        private int idCourse;
        private int idProfessor;
        private int duration;

        public Course(string n, int idC, int idP, int dur)
        {
            this.name = n;
            this.idCourse = idC;
            this.idProfessor = idP;
            this.duration = dur;
        }
    }
}
