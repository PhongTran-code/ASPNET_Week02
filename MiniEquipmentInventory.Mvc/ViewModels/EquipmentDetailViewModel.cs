namespace MiniEquipmentInventory.Mvc.ViewModels;

public class EquipmentDetailViewModel
{
    public int EquipId { get; set; }
    public string EquipName { get; set; } = "";
    public string EquipCategory { get; set; } = "";
    public string EquipSupplier { get; set; } = "";
    public decimal EquipUnitPrice { get; set; }
    public int EquipQuantity { get; set; }
    public int EquipMinStock { get; set; }
    public DateTime EquipLastUpdatedAt { get; set; }

    public string PriceText => $"{EquipUnitPrice:N0} VND";
    public decimal InventoryValue => EquipUnitPrice * EquipQuantity;
    public string InventoryValueText => $"{InventoryValue:N0} VND";
    public string LastUpdatedText => EquipLastUpdatedAt.ToString("dd/MM/yyyy HH:mm");

    public string StockStatus
    {
        get
        {
            if (EquipQuantity <= 0)
            {
                return "Hết hàng";
            }
            if (EquipQuantity <= EquipMinStock)
            {
                return "Cần nhập thêm";
            }
            return "Còn hàng";
        }
    }

    public string ReorderSuggestion
    {
        get
        {
            if (EquipQuantity <= 0)
            {
                return "Cần nhập hàng ngay vì sản phẩm đã hết.";
            }
            if (EquipQuantity <= EquipMinStock)
            {
                return $"Nên nhập thêm. Tồn kho hiện tại chỉ còn {EquipQuantity}, mức tối thiểu là {EquipMinStock}.";
            }
            return "Tồn kho đang ổn định, chưa cần nhập thêm.";
        }
    }
}
