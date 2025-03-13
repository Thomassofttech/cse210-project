using System;

public class Resume

{
    public string _name;

    //Initializing to a new list
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("jobs:");
    

    // Use of the custom data type "job" in this loop
    foreach (Job job in _jobs)
        {
        //calling the display method on each job
        job.Display();
        }    
    } 
 }
