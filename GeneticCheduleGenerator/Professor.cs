using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticCheduleGenerator
{
    public class Professor
    {
        public string name;
        public int idProfessor;
        public int assignedHours;
        
        public Professor(string name, int id, int assig)
        {
            this.name = name;
            this.idProfessor = id;
            this.assignedHours = assig;
        }
    }
}
