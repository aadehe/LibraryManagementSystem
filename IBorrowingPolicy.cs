namespace LibraryManagementSystem;

public interface IBorrowingPolicy
{
    int MaximumBooks { get; }
    int BorrowingPeriodDays { get; }
}