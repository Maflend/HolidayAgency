namespace HA.Domain.ValueObjects;

public record FullName(FullNamePart FirstName, FullNamePart LastName, FullNamePart? Patronymic);

public class FullNamePart
{
    private string _part = string.Empty;

    public FullNamePart()
    {

    }

    public FullNamePart(string value)
    {
        Part = value;
    }

    public string Part
    {
        get { return _part; }
        set { _part = SetPart(value); }
    }

    private string SetPart(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException();
        }

        if (value.Any(char.IsDigit))
        {
            throw new ArgumentException();
        }

        return value;
    }

    public static implicit operator string(FullNamePart part)
    {
        return part.Part;
    }

    public static implicit operator FullNamePart(string value)
    {
        return new FullNamePart(value);
    }

    public static bool operator ==(FullNamePart part1, FullNamePart part2)
    {
        return part1.Part == part2.Part;
    }

    public static bool operator !=(FullNamePart part1, FullNamePart part2)
    {
        return part1.Part != part2.Part;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (ReferenceEquals(obj, null))
        {
            return false;
        }

        throw new NotImplementedException();
    }
}