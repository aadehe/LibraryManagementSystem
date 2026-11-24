namespace LibraryManagementSystem;

public class StaffBorrowingPolicy : IBorrowingPolicy
{
    public int MaximumBooks => 5;
    public int BorrowingPeriodDays => 28;
}