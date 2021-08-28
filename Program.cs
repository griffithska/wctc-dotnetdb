using System;
using System.IO;

namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.csv";
            string choice;
            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    //read data from file
                    if (File.Exists(file))
                    {
                        Console.Clear();
                        StreamReader sr = new StreamReader(file);
                        //skip first line (comment out the below line if you want headers in the output)
                        sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] data = line.Split(',');
                            Console.WriteLine("{0,-10} {1,-30} {2,-10} {3,-10} {4,-20} {5,-20} {6,-60}", data[0], data[1], data[2], data[3], data[4], data[5], data[6]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    // create file from data
                    StreamWriter sw = new StreamWriter(file);
                    sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                    for (int i = 0; i < 7; i++)
                    {
                        // ask a question
                        Console.WriteLine("Enter a ticket (Y/N)?");
                        // input the response
                        string resp = Console.ReadLine().ToUpper();
                        // if the response is anything other than "Y", stop asking
                        if (resp != "Y") { break; }
                        // prompt for summary
                        Console.WriteLine("Enter the ticket summary.");
                        // save the summary
                        string summary = Console.ReadLine();
                        // prompt for ticket status
                        Console.WriteLine("Enter the ticket status code.");
                        Console.WriteLine("1 - Open");
                        Console.WriteLine("2 - In Progress");
                        Console.WriteLine("3 - On Hold");
                        Console.WriteLine("4 - Closed");
                        Console.WriteLine("5 - Resolved");
                        // save the status
                        string statuscd = Console.ReadLine().ToUpper();
                        string status = statuscd == "1" ? "Open" : statuscd == "2" ? "In Progress" : statuscd == "3" ? "On Hold" : statuscd == "4" ? "Closed" : statuscd == "5" ? "Resolved" : "Unkown";
                        // prompt for ticket priority
                        Console.WriteLine("Enter the ticket priority code.");
                        Console.WriteLine("1 - Low");
                        Console.WriteLine("2 - Medium");
                        Console.WriteLine("3 - High");
                        Console.WriteLine("4 - URGENT");
                        // save the priority
                        string priorityCd = Console.ReadLine().ToUpper();
                        string priority = priorityCd == "1" ? "Low" : priorityCd == "2" ? "Medium" : priorityCd == "3" ? "High" : priorityCd == "4" ? "URGENT" : "Unkown";
                        // prompt for submitter
                        Console.WriteLine("Enter the name of the ticket submitter.");
                        // save the submitter
                        string submitter = Console.ReadLine();
                        // prompt for assigned
                        Console.WriteLine("Enter the name of who the ticket is assigned to.");
                        // save the assigned
                        string assigned = Console.ReadLine();
                        // prompt for watching
                        Console.WriteLine("Is anyone watching this ticket (Y/N)?");
                        string watching = Console.ReadLine().ToUpper();
                        string watchers = "";
                        if (watching == "Y")
                            {
                                System.Console.WriteLine("Enter the name of who is watching this ticket");
                                watchers = Console.ReadLine();
                                System.Console.WriteLine("Is anyone else watching this ticket (Y/N)?");
                                string additional = Console.ReadLine();
                                do
                                {
                                    System.Console.WriteLine("Who else is watching this ticket?");
                                    watchers = watchers + "|" + Console.ReadLine();
                                    System.Console.WriteLine("Is anyone else watching this ticket (Y/N)?");
                                    additional = Console.ReadLine().ToUpper();
                                }
                                while (additional == "Y");
                                System.Console.WriteLine("Is anyone else watching this ticket?");
                            }

                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", i + 1, summary, status, priority, submitter, assigned, watchers);
                    }
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}