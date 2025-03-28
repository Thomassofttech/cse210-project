using System;

// Main program to demonstrate the Video and Comment classes
class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold videos
        List<Video> videos = new List<Video>();

        // Create and add first video
        Video video1 = new Video("C# Tutorial for Beginners", "Programming Master", 600);
        video1.AddComment(new Comment("Thomas Moses", "Great tutorial! Very helpful."));
        video1.AddComment(new Comment("Samson Lucas", "I learned so much from this."));
        video1.AddComment(new Comment("Jeremiah Johnson", "Could you make one about OOP?"));
        videos.Add(video1);

        // Create and add second video
        Video video2 = new Video("Cooking Pasta Like a Chef", "Cooking Pro", 450);
        video2.AddComment(new Comment("FoodLover22", "This changed my pasta game!"));
        video2.AddComment(new Comment("ChefMike", "Nice technique with the sauce."));
        video2.AddComment(new Comment("HomeCook", "Tried it and my family loved it!"));
        video2.AddComment(new Comment("RecipeHunter", "What other pasta types would you recommend?"));
        videos.Add(video2);

        // Create and add third video
        Video video3 = new Video("Morning Yoga Routine", "Yoga with Sarah", 1200);
        video3.AddComment(new Comment("YogaBeginner", "Perfect way to start my day."));
        video3.AddComment(new Comment("FitnessFan", "Love the energy in this video!"));
        video3.AddComment(new Comment("MeditationGuru", "The breathing exercises are excellent."));
        videos.Add(video3);

        // Create and add fourth video
        Video video4 = new Video("Travel Guide: Tokyo", "World Explorer", 900);
        video4.AddComment(new Comment("TravelBug", "Tokyo is my dream destination!"));
        video4.AddComment(new Comment("JapanLover", "Great recommendations for food places."));
        video4.AddComment(new Comment("Wanderer", "When is the best time to visit?"));
        video4.AddComment(new Comment("PhotographyFan", "Amazing shots of the city!"));
        videos.Add(video4);

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetAllComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine(); // Add a blank line between videos
        }
    }
}