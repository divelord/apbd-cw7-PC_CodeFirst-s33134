namespace PC_CodeFirst.Entities;

public class Component
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ComponentManufacturersId { get; set; }
    public int ComponentTypesId { get; set; }

    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;
    public ComponentType ComponentType { get; set; } = null!;

    public ICollection<PcComponent> PcComponents { get; set; } = [];
}