# Library Management System

A console-based Library Management System built with C# and .NET. The application manages books, library members, borrowing transactions, returns and due dates.

## Features

- Add and manage books.
- Register library members.
- Borrow available books.
- Return borrowed books.
- Track borrowing dates and due dates.
- Identify overdue loans.
- Apply different borrowing rules based on membership type.
- Validate user input and prevent invalid operations.

## Class Design

The application uses object-oriented programming to separate responsibilities.

| Class | Responsibility |
|---|---|
| `Book` | Represents a book and manages its availability. |
| `Member` | Represents a registered library member. |
| `MemberType` | Defines the supported membership categories. |
| `Loan` | Records borrowing transactions, due dates and return dates. |
| `Library` | Coordinates book management, member registration, borrowing and returns. |
| `IBorrowingPolicy` | Defines the contract for borrowing rules. |
| `StudentBorrowingPolicy` | Defines borrowing rules for students. |
| `StaffBorrowingPolicy` | Defines borrowing rules for staff. |

### Object-Oriented Programming

The application demonstrates:

- **Encapsulation:** Objects control access to their internal state.
- **Abstraction:** `IBorrowingPolicy` defines the borrowing policy contract.
- **Polymorphism:** Different borrowing policy implementations provide different borrowing rules.
- **Composition:** The library coordinates books, members, loans and borrowing policies.

## Borrowing Rules

| Membership type | Maximum books | Borrowing period |
|---|---:|---:|
| Student | 3 | 14 days |
| Staff | 5 | 28 days |

## Prerequisites

- .NET 10 SDK or a compatible SDK for the project's target framework.
- A terminal or command-line interface.

## Setup and Execution

Clone the repository:

```bash
git clone <YOUR-GITHUB-REPOSITORY-URL>
```

Navigate into the repository:

```bash
cd LibraryManagementSystem
```

Build the application:

```bash
dotnet build
```

Run the application:

```bash
dotnet run --project LibraryManagementSystem/LibraryManagementSystem.csproj
```

## Assumptions

- The library supports student and staff membership categories.
- Students may borrow up to three books for 14 days.
- Staff may borrow up to five books for 28 days.
- A book can only have one active borrowing transaction at a time.
- A member cannot borrow the same book more than once simultaneously.

## Known Limitations

- Application data is stored in memory and is not retained after the application closes.
- The application does not use a database.
- The application is operated through a console interface.

## Testing

Build verification is performed using:

```bash
dotnet build
```

Automated test coverage should be added and executed against the application functionality before submission.

## Technology

- C#
- .NET
- Object-Oriented Programming
