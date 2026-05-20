namespace MiniEquipmentInventory.Mvc.Models;

public class Equipment
{
    public int EquipId { get; set; }
    public string EquipName { get; set; } = "";
    public string EquipCategory { get; set; } = "";
    public string EquipSupplier { get; set; } = "";
    public decimal EquipUnitPrice { get; set; }
    public int EquipQuantity { get; set; }
    public int EquipMinStock { get; set; }
    public DateTime EquipLastUpdatedAt { get; set; }
}
