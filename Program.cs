
using LibraryManagementSystem;

var library = new Library();

while (true)
{
    Console.WriteLine("\n===== LIBRARY MANAGEMENT SYSTEM =====");
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. Register Member");
    Console.WriteLine("3. View Books");
    Console.WriteLine("4. Borrow Book");
    Console.WriteLine("5. Return Book");
    Console.WriteLine("6. View Loans");
    Console.WriteLine("7. View Overdue Loans");
    Console.WriteLine("0. Exit");
    Console.Write("Select an option: ");

    var choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Book ID: ");
                var bookId = Console.ReadLine() ?? "";

                Console.Write("Title: ");
                var title = Console.ReadLine() ?? "";

                Console.Write("Author: ");
                var author = Console.ReadLine() ?? "";

                library.AddBook(new Book(bookId, title, author));
                Console.WriteLine("Book added successfully.");
                break;

            case "2":
                Console.Write("Member ID: ");
                var memberId = Console.ReadLine() ?? "";

                Console.Write("Member name: ");
                var name = Console.ReadLine() ?? "";

                Console.WriteLine("1. Student");
                Console.WriteLine("2. Staff");
                Console.Write("Select membership type: ");

                var typeInput = Console.ReadLine();

                if (!Enum.TryParse<MemberType>(
                    typeInput == "1" ? "Student" :
                    typeInput == "2" ? "Staff" : "",
                    out var memberType))
                {
                    Console.WriteLine("Invalid membership type.");
                    break;
                }

                library.RegisterMember(
                    new Member(memberId, name, memberType));

                Console.WriteLine("Member registered successfully.");
                break;

            case "3":
                Console.WriteLine("\n--- BOOKS ---");

                foreach (var book in library.Books)
                {
                    Console.WriteLine(
                        $"{book.Id} | {book.Title} | {book.Author} | " +
                        $"{(book.IsAvailable ? "Available" : "Borrowed")}");
                }
                break;

            case "4":
                Console.Write("Book ID: ");
                var borrowBookId = Console.ReadLine() ?? "";

                Console.Write("Member ID: ");
                var borrowMemberId = Console.ReadLine() ?? "";

                var loan = library.BorrowBook(
                    borrowBookId, borrowMemberId);

                Console.WriteLine("Book borrowed successfully.");
                Console.WriteLine($"Borrow date: {loan.BorrowDate:d}");
                Console.WriteLine($"Due date: {loan.DueDate:d}");
                break;

            case "5":
                Console.Write("Book ID: ");
                var returnBookId = Console.ReadLine() ?? "";

                library.ReturnBook(returnBookId);

                Console.WriteLine("Book returned successfully.");
                break;

            case "6":
                Console.WriteLine("\n--- LOAN HISTORY ---");

                foreach (var item in library.Loans)
                {
                    Console.WriteLine(
                        $"{item.Book.Title} | {item.Member.Name} | " +
                        $"Borrowed: {item.BorrowDate:d} | " +
                        $"Due: {item.DueDate:d} | " +
                        $"Returned: {(item.ReturnDate?.ToString("d") ?? "No")}");
                }
                break;

            case "7":
                Console.WriteLine("\n--- OVERDUE LOANS ---");

                var overdueLoans = library.GetOverdueLoans();

                if (overdueLoans.Count == 0)
                {
                    Console.WriteLine("No overdue loans.");
                    break;
                }

                foreach (var item in overdueLoans)
                {
                    Console.WriteLine(
                        $"{item.Book.Title} | {item.Member.Name} | " +
                        $"Due: {item.DueDate:d}");
                }
                break;

            case "0":
                Console.WriteLine("Goodbye!");
                return;

            default:
                Console.WriteLine("Invalid option. Try again.");
                break;
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Validation error: {ex.Message}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Operation failed: {ex.Message}");
    }
}
