using System;
using System.Collections.Generic;

namespace GeneticCheduleGenerator
{
    public class Schedule
    {
        public static int aulas = 10;

        public Course[,,] matrix = new Course[5,4,aulas];


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

        public bool IsProfessorCrushes(Professor Profesor, int day, int hour)
        {
            for (int i = 0; i < aulas; i++)
            {
                Course actual = matrix[day, hour, i];

                if(actual != null)
                {
                    if(actual.idProfessor.Equals(Profesor))
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

        public List<Course> prepareListForCreate(List<Course> initial)
        {
            List<Course> response = new List<Course>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < initial[i].lections; j++)
                {
                    response.Add(initial[i]);
                }

            }
            return response;

        }

        public void createParent(List<Course> seed)
        {
            Random rand = new Random();
            while( seed.Count > 0)
            {
                int cursor = rand.Next(seed.Count-1);
                Course actual = seed[cursor];
                while(true)
                {
					int day = rand.Next(4);
					int hour = rand.Next(3);
                    if (!IsSemesterCrushes(actual.semester, day, hour) || !IsProfessorCrushes(actual.idProfessor, day, hour))
                    {
                        for (int i = 0; i < aulas; i++)
                        {
                            if(matrix[day,hour,i]==null)
                            {
                                matrix[day, hour, i] = actual;
                                seed.Remove(actual);
                                break;
                            }
                        }
                        break;
                    }  
                }

            }
        }



    }
}
