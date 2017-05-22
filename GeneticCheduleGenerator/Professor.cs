using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticCheduleGenerator
{
    public class Professor
    {
        private string name;
        private int idProfessor;
        private int assignedHours;
        
        public Professor(string n, int id, int assig)
        {
            this.name = n;
            this.idProfessor = id;
            this.assignedHours = assig;
        }
    }
}
