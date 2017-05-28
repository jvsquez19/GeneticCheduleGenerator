using System;
using System.Collections.Generic;

namespace GeneticCheduleGenerator
{
    public class Schedule
    {
        static int aulas = 10;

        private Course[,,] matrix = new Course[5,4,aulas];


        // Generates a one dimension list from the matrix 

        public List<Course>  matrixToList()
        {
            List<Course> response = new List<Course>();

            for (int i = 0; i < 5; i++)
            {
				for (int j = 0; j < 4; j++)
				{
					for (int k = 0; k < aulas; k++)
					{
                        response.Add(matrix[i,j,k]);

					}
				}
			}
            return response;
        }


        // converts a received matrix into a list
        public void listToMatrix(List<Course>list)
        {
            int count = 0;
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					for (int k = 0; k < aulas; k++)
					{
                        matrix[i, j, k] = list[count];
                        count++;

					}
				}
			}
        }

        // Returns true if a professor already has to give classes at determinated hour

        public bool IsProfessorCrushes(int idProfesor, int day, int hour)
        {
            for (int i = 0; i < aulas; i++)
            {
                Course actual = matrix[day, hour, i];

                if(actual != null)
                {
                    if(actual.idProfessor == idProfesor)
                    {
                        return true; 
                    }   
                }
            }
            return false;   

        }

		public bool IsSemesterCrushes(int semester, int day, int hour)
		{
			for (int i = 0; i < aulas; i++)
			{
				Course actual = matrix[day, hour, i];

				if (actual != null)
				{
                    if (actual.semester == semester)
					{
						return true;
					}
				}
			}
			return false;
		}
    }
}
