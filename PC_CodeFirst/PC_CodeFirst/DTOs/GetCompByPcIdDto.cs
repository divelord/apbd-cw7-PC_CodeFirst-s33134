namespace PC_CodeFirst.DTOs;

public class GetCompByPcIdDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    public List<GetComponentListDetailsDto> Components { get; set; } = [];
}

public class GetComponentListDetailsDto
{
    public int Amount { get; set; }
    public GetComponentDetailsDto Component { get; set; } = null!;
}

public class GetComponentDetailsDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public GetManufacturerDetailsDto Manufacturer { get; set; } = null!;
    public GetTypeDetailsDto Type { get; set; } = null!;
}

public class GetManufacturerDetailsDto
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public DateTime FoundationDate { get; set; }
}

public class GetTypeDetailsDto
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}