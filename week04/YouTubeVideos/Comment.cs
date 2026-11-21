public class Comment
{
    // properties 
    public string CommenterName {get; set;}
    public string CommentText {get; set;}

    // constructor
    public Comment (string commenterName, string commentText)
    {
        CommenterName = commenterName; 
        CommentText = commentText;
    }
}