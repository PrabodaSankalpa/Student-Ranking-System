using System;
using System.Text;
using System.IO;

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
                Console.Write("\nEnter student name: ");
                names[i] = Console.ReadLine();
                subjects[i,0] = i;
                Console.Write("Enter Maths mark: ");
                subjects[i,1] = getMark();
                Console.Write("Enter English mark: ");
                subjects[i,2] = getMark();
                Console.Write("Enter Science mark: ");
                subjects[i,3] = getMark();
                Console.Write("Enter IT mark: ");
                subjects[i,4] = getMark();

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
                Logger.WriteLog($"Name: {names[i]} - Maths: {subjects[i,1]} | English: {subjects[i,2]} | Science: {subjects[i,3]} | IT: {subjects[i,4]} Best-Subject: {subjNames[subjects[i,5]]}");
            }
            for(int i = 0; i < count; i++)
            {
                int totalMarks = subjects[i,1] + subjects[i,2] + subjects[i,3] + subjects[i,4];
                preRank[i] = totalMarks;
                Logger.WriteLog($"{names[i]}'s total mark is: {totalMarks}");
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
            Logger.WriteLog($"{names[maxRank]}'s rank is 1");
            int rankNumber = 2;
            for(int i = preRank[maxRank] - 1; i >= 0; i--)
            {
                for(int j = 0; j < count; j++)
                {
                    if(preRank[j] == i)
                    {
                        subjects[j,6] = rankNumber;
                        Logger.WriteLog($"{names[j]}'s rank is {rankNumber}");
                        rankNumber++;
                        
                    }
                }
            }

                var csvFile = new FileInfo(@"./Data-Report.csv");
                if(csvFile.Length == 0)
                {
                    try
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./Data-Report.csv", true))
                        {
                            file.WriteLine("Name,Rank,Best-Subject");
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        
                        throw new ApplicationException("Fail to Write to CSV!", ex);
                    }
                }

            
            

            for(int i = 0; i < count; i++)
            {
                int subjIndex = subjects[i,5];
                Console.WriteLine("\n{0}\t{1}\t{2}", names[i], subjects[i,6], subjNames[subjIndex]);
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./Data-Report.csv", true))
                    {
                        file.WriteLine("{0},{1},{2}", names[i], subjects[i,6], subjNames[subjIndex]);
                        Logger.WriteLog("CSV file wrote successful!");
                    }
                    //Console.WriteLine("File is writing...");
                }
                catch (Exception ex)
                {
                    
                    throw new ApplicationException("Fail to Write to CSV!", ex);
                }
            }

        }
        static int isValidCount()
        {
            while (true)
            {
                Console.Write("Enter how many student do you enter: ");
                int count = Convert.ToInt32(Console.ReadLine());
                if (count > 0)
                {
                    Logger.WriteLog($"Student count is: {count}");
                    return count;
                }
            }
        }

        static int getMark()
        {
            while(true){
                int markValue = Convert.ToInt32(Console.ReadLine());
                if(markValue < 0 || markValue > 100){
                    Console.Write("Invalid mark! Enter again: ");
                }else{
                    return markValue;
                }

            }
        }
    }
}