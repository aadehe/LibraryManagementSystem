namespace LibraryManagementSystem;

public class Member
{
    public string Id { get; }
    public string Name { get; }
    public MemberType Type { get; }

    public Member(string id, string name, MemberType type)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Member ID is required.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Member name is required.");

        if (!Enum.IsDefined(type))
            throw new ArgumentException("Invalid member type.");

        Id = id;
        Name = name;
        Type = type;
    }
}