namespace PC_CodeFirst.Entities;

public class PcComponent
{
    public int PCId { get; set; }
    public string ComponentCode { get; set; } = string.Empty;
    public int Amount { get; set; }

    public Pc Pc { get; set; } = null!;
    public Component Component { get; set; } = null!;
}