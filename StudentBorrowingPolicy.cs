namespace LibraryManagementSystem;

public class StudentBorrowingPolicy : IBorrowingPolicy
{
    public int MaximumBooks => 3;
    public int BorrowingPeriodDays => 14;
}