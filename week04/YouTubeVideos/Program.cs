using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // create the first video
        Video video1 = new Video(
            "Introduction to C# Programming", 
            "John Smith",
            600
        );


        video1.AddComment(new Comment("Mary", "Great introduction!"));
        video1.AddComment(new Comment("David", "Very helpful lesson."));
        video1.AddComment(new Comment("Peter", "Please make more tutorials."));


        // create second video 
        Video video2 = new Video(
            "Learning Object-Oriented Programming",
            "Jane Williams",
            900
        );


        video2.AddComment(new Comment("Paul", "Very informative."));
        video2.AddComment(new Comment("Sarah", "I love this explanation."));
        video2.AddComment(new Comment("James", "Thank you for sharing."));


        Video video3 = new Video(
            "C# Classes Explained", 
            "Michael Brown", 
            750
        ); 


        video3.AddComment(new Comment("Grace", "Excellent lesson!"));
        video3.AddComment(new Comment("Daniel", "Now I understand classes.")); 
        video3.AddComment(new Comment("Ruth", "Very helpful content."));


        // create a list of videos
        List<Video> videos = new List<Video>();

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);


        // display video information
        foreach(Video video in videos)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");

            foreach(Comment comment in video.Comments)
            {
                Console.WriteLine(
                    $"{comment.CommenterName}: {comment.CommentText}"
                );
            }

            Console.WriteLine();
            
        }

    }
}