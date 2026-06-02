using System.ComponentModel.DataAnnotations;

namespace MiniEquipmentInventory.Mvc.ViewModels;

public class EquipmentCreateViewModel
{
    [Required(ErrorMessage = "Tên thiết bị không được để trống")]
    [StringLength(100, ErrorMessage = "Tên thiết bị không được vượt quá 100 ký tự")]
    public string EquipName { get; set; } = "";

    [Required(ErrorMessage = "Nhóm thiết bị không được để trống")]
    public string EquipCategory { get; set; } = "";

    [Required(ErrorMessage = "Nhà cung cấp không được để trống")]
    public string EquipSupplier { get; set; } = "";

    [Range(1000, 100000000, ErrorMessage = "Giá bán phải từ 1.000 đến 100.000.000")]
    public decimal EquipUnitPrice { get; set; }

    [Range(0, 10000, ErrorMessage = "Số lượng phải từ 0 đến 10.000")]
    public int EquipQuantity { get; set; }

    [Range(0, 10000, ErrorMessage = "Mức tồn tối thiểu phải từ 0 đến 10.000")]
    public int EquipMinStock { get; set; }
}
