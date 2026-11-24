
namespace LibraryManagementSystem;

public class Library
{
    private readonly List<Book> _books = [];
    private readonly List<Member> _members = [];
    private readonly List<Loan> _loans = [];

    private readonly Dictionary<MemberType, IBorrowingPolicy> _policies;

    public Library()
    {
        _policies = new Dictionary<MemberType, IBorrowingPolicy>
        {
            [MemberType.Student] = new StudentBorrowingPolicy(),
            [MemberType.Staff] = new StaffBorrowingPolicy()
        };
    }

    public IReadOnlyList<Book> Books => _books.AsReadOnly();
    public IReadOnlyList<Member> Members => _members.AsReadOnly();
    public IReadOnlyList<Loan> Loans => _loans.AsReadOnly();

    public void AddBook(Book book)
    {
        if (_books.Any(b => b.Id == book.Id))
            throw new InvalidOperationException("Book ID already exists.");

        _books.Add(book);
    }

    public void RegisterMember(Member member)
    {
        if (_members.Any(m => m.Id == member.Id))
            throw new InvalidOperationException("Member ID already exists.");

        _members.Add(member);
    }

    public Loan BorrowBook(string bookId, string memberId)
    {
        var book = _books.FirstOrDefault(b => b.Id == bookId)
            ?? throw new InvalidOperationException("Book not found.");

        var member = _members.FirstOrDefault(m => m.Id == memberId)
            ?? throw new InvalidOperationException("Member not found.");

        if (!book.IsAvailable)
            throw new InvalidOperationException("Book is not available.");

        var activeLoans = _loans
            .Where(l => l.Member.Id == memberId && !l.IsReturned)
            .ToList();

        if (activeLoans.Any(l => l.Book.Id == bookId))
            throw new InvalidOperationException("Member already has this book.");

        var policy = _policies[member.Type];

        if (activeLoans.Count >= policy.MaximumBooks)
            throw new InvalidOperationException("Borrowing limit reached.");

        book.Borrow();

        var loan = new Loan(
            book,
            member,
            policy.BorrowingPeriodDays
        );

        _loans.Add(loan);

        return loan;
    }

    public void ReturnBook(string bookId)
    {
        var loan = _loans.LastOrDefault(l =>
            l.Book.Id == bookId && !l.IsReturned)
            ?? throw new InvalidOperationException("No active loan found for this book.");

        loan.MarkAsReturned();
        loan.Book.Return();
    }

    public IReadOnlyList<Loan> GetOverdueLoans()
    {
        return _loans
            .Where(l => !l.IsReturned && l.DueDate < DateTime.Today)
            .ToList()
            .AsReadOnly();
    }
}
