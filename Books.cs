namespace LibraryManagementSystem;

public class Book
{
    public string Id { get; }
    public string Title { get; }
    public string Author { get; }
    public bool IsAvailable { get; private set; }

    public Book(string id, string title, string author)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Book ID is required.");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Book title is required.");

        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Author is required.");

        Id = id;
        Title = title;
        Author = author;
        IsAvailable = true;
    }

    public void Borrow()
    {
        if (!IsAvailable)
            throw new InvalidOperationException("Book is already borrowed.");

        IsAvailable = false;
    }

    public void Return()
    {
        if (IsAvailable)
            throw new InvalidOperationException("Book is not currently borrowed.");

        IsAvailable = true;
    }
}