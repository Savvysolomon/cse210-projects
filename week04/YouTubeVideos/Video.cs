using System.Collections.Generic;

public class Video
{
    // properties
    public string Title {get; set;}
    public string Author {get; set;}
    public int Length {get; set;}


    // list for storing comments
    public List<Comment> Comments {get; set;}

    
    // constructor
    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;

        Comments = new List<Comment>();
    }


    // method to add a comment
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    // method to return the number of comments
    public int GetNumberOfComments ()
    {
        return Comments.Count;
    }
}