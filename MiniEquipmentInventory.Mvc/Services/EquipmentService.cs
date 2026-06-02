using MiniEquipmentInventory.Mvc.Models;
using MiniEquipmentInventory.Mvc.ViewModels;

namespace MiniEquipmentInventory.Mvc.Services;

public class EquipmentService
{
    private readonly List<Equipment> _equipments = new()
    {
        new Equipment
        {
            EquipId = 1,
            EquipName = "Smart Projector",
            EquipCategory = "Projection Equipment",
            EquipSupplier = "Epson Vietnam",
            EquipUnitPrice = 8500000,
            EquipQuantity = 18,
            EquipMinStock = 5,
            EquipLastUpdatedAt = new DateTime(2025, 5, 9, 9, 12, 0)
        },
        new Equipment
        {
            EquipId = 2,
            EquipName = "Interactive Whiteboard",
            EquipCategory = "Board Equipment",
            EquipSupplier = "SMART Technologies",
            EquipUnitPrice = 15000000,
            EquipQuantity = 4,
            EquipMinStock = 5,
            EquipLastUpdatedAt = new DateTime(2025, 5, 9, 9, 12, 0)
        },
        new Equipment
        {
            EquipId = 3,
            EquipName = "Magnetic Whiteboard",
            EquipCategory = "Board Equipment",
            EquipSupplier = "Local Board Supplier",
            EquipUnitPrice = 2500000,
            EquipQuantity = 0,
            EquipMinStock = 3,
            EquipLastUpdatedAt = new DateTime(2025, 5, 9, 9, 12, 0)
        },
        new Equipment
        {
            EquipId = 4,
            EquipName = "Classroom Audio System",
            EquipCategory = "Audio Equipment",
            EquipSupplier = "Bose Vietnam",
            EquipUnitPrice = 5000000,
            EquipQuantity = 9,
            EquipMinStock = 4,
            EquipLastUpdatedAt = new DateTime(2025, 5, 9, 9, 12, 0)
        },
        new Equipment
        {
            EquipId = 5,
            EquipName = "Student Desk",
            EquipCategory = "Furniture",
            EquipSupplier = "Local Furniture Supplier",
            EquipUnitPrice = 1200000,
            EquipQuantity = 2,
            EquipMinStock = 6,
            EquipLastUpdatedAt = new DateTime(2025, 5, 9, 9, 12, 0)
        },
        new Equipment
        {
            EquipId = 6,
            EquipName = "Student Chair",
            EquipCategory = "Furniture",
            EquipSupplier = "Local Furniture Supplier",
            EquipUnitPrice = 800000,
            EquipQuantity = 7,
            EquipMinStock = 3,
            EquipLastUpdatedAt = new DateTime(2025, 5, 9, 9, 12, 0)
        }
    };

    public List<Equipment> GetAll()
    {
        return _equipments;
    }

    public Equipment? GetById(int id)
    {
        return _equipments.FirstOrDefault(equipment => equipment.EquipId == id);
    }

    public EquipmentStatsViewModel GetStats()
    {
        var totalProducts = _equipments.Count;
        var totalQuantity = _equipments.Sum(equipment => equipment.EquipQuantity);
        var totalInventoryValue = _equipments.Sum(equipment =>
            equipment.EquipUnitPrice * equipment.EquipQuantity);

        var outOfStockCount = _equipments.Count(equipment =>
            equipment.EquipQuantity <= 0);
        var needReorderCount = _equipments.Count(equipment =>
            equipment.EquipQuantity > 0 && equipment.EquipQuantity <= equipment.EquipMinStock);

        return new EquipmentStatsViewModel
        {
            TotalEquipment = totalProducts,
            TotalQuantity = totalQuantity,
            TotalInventoryValue = totalInventoryValue,
            OutOfStockCount = outOfStockCount,
            NeedReorderCount = needReorderCount
        };
    }

    public List<Equipment> Search(string? keyword, decimal? minPrice)
    {
        var query = _equipments.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            query = query.Where(equipment =>
                equipment.EquipName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                equipment.EquipCategory.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                equipment.EquipSupplier.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        if (minPrice.HasValue)
        {
            query = query.Where(equipment => equipment.EquipUnitPrice >= minPrice.Value);
        }

        return query.ToList();
    }

    public Equipment Create(EquipmentCreateViewModel model)
    {
        var newId = _equipments.Count == 0
            ? 1
            : _equipments.Max(equipment => equipment.EquipId) + 1;

        var equipment = new Equipment
        {
            EquipId = newId,
            EquipName = model.EquipName,
            EquipCategory = model.EquipCategory,
            EquipSupplier = model.EquipSupplier,
            EquipUnitPrice = model.EquipUnitPrice,
            EquipQuantity = model.EquipQuantity,
            EquipMinStock = model.EquipMinStock,
            EquipLastUpdatedAt = DateTime.Now
        };

        _equipments.Add(equipment);
        return equipment;
    }
}
