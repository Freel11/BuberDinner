using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Location : ValueObject
{
    private Location(
        string name,
        string address,
        double latitude,
        double longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Name { get; }
    public string Address { get; }
    public double Latitude { get; }
    public double Longitude { get; }

    public static Location CreateNew(
        string name,
        string address,
        double latitude,
        double longitude)
    {
        return new(
            name,
            address,
            latitude,
            longitude);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Latitude;
        yield return Longitude;
    }
}