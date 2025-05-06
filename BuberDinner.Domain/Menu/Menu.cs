using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = [];
    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
}   