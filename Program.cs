using System;

namespace Console_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = isValidCount();
            String[] names = new String[count];
            int[,] subjects = new int[count, 7];
            int[] preRank = new int[count];
            String[] subjNames = {"Maths", "English", "Science", "IT"};
            int bestSubject = 0;
            int maxRank = 0;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter student name: ");
                names[i] = Console.ReadLine();
                subjects[i,0] = i;
                Console.WriteLine("Enter Maths mark: ");
                subjects[i,1] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter English mark: ");
                subjects[i,2] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Science mark: ");
                subjects[i,3] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter IT mark: ");
                subjects[i,4] = Convert.ToInt32(Console.ReadLine());

                int bestSubjectMarks = subjects[i,1];
                for(int j = 1; j < 3; j++)
                {
                    if(bestSubjectMarks < subjects[i, j + 1])
                    {
                        bestSubjectMarks = subjects[i, j + 1];
                        bestSubject = j;
                    }
                }
                subjects[i,5] = bestSubject;
            }
            for(int i = 0; i < count; i++)
            {
                int totalMarks = subjects[i,1] + subjects[i,2] + subjects[i,3] + subjects[i,4];
                preRank[i] = totalMarks;
            }
            int maxPreRank = preRank[0];
            for(int i = 0; i < count - 1; i++)
            {
                if(maxPreRank < preRank[i+1])
                {
                    maxPreRank = preRank[i+1];
                    maxRank = i + 1;
                } else
                {
                    //maxRank = i;
                }
            }
            subjects[maxRank,6] = 1;
            int rankNumber = 2;
            for(int i = preRank[maxRank] - 1; i >= 0; i--)
            {
                for(int j = 0; j < count; j++)
                {
                    if(preRank[j] == i)
                    {
                        subjects[j,6] = rankNumber;
                        rankNumber++;
                        
                    }
                }
            }

            //Console.WriteLine("Student Name\tRank\tBest Subject");
            for(int i = 0; i < count; i++)
            {
                int subjIndex = subjects[i,5];
                Console.WriteLine("{0}\t{1}\t{2}", names[i], subjects[i,6], subjNames[subjIndex]);
            }

        }
        static int isValidCount()
        {
            while (true)
            {
                Console.WriteLine("Enter how many student do you enter: ");
                int count = Convert.ToInt32(Console.ReadLine());
                if (count > 0)
                {
                    return count;
                }
            }
        }
    }
}
