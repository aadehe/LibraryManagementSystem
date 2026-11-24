namespace LibraryManagementSystem;

public class Loan
{
    public Book Book { get; }
    public Member Member { get; }
    public DateTime BorrowDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }

    public bool IsReturned => ReturnDate.HasValue;

    public Loan(Book book, Member member, int borrowingDays)
    {
        if (borrowingDays <= 0)
            throw new ArgumentOutOfRangeException(nameof(borrowingDays));

        Book = book;
        Member = member;
        BorrowDate = DateTime.Today;
        DueDate = BorrowDate.AddDays(borrowingDays);
    }

    public void MarkAsReturned()
    {
        if (IsReturned)
            throw new InvalidOperationException("Loan has already been returned.");

        ReturnDate = DateTime.Today;
    }
}