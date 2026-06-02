namespace MiniEquipmentInventory.Mvc.ViewModels;

public class EquipmentSearchViewModel
{
    public string Keyword { get; set; } = string.Empty;
    public decimal? MinPrice { get; set; }
    public List<EquipmentListItemViewModel> Equipment { get; set; } = new();
}
