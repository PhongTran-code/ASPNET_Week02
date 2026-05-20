using MiniEquipmentInventory.Mvc.Models;
using MiniEquipmentInventory.Mvc.Services;
using MiniEquipmentInventory.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MiniEquipmentInventory.Mvc.Controllers;

public class EquipmentController : Controller
{
    private readonly EquipmentService _equipmentService;

    public EquipmentController(EquipmentService equipmentService)
    {
        _equipmentService = equipmentService;
    }

    public IActionResult Index()
    {
        var equipment = _equipmentService.GetAll()
            .Select(ToListItemViewModel)
            .ToList();
        return View(equipment);
    }

    public IActionResult Detail(int id)
    {
        var equipment = _equipmentService.GetById(id);
        if (equipment == null)
        {
            return NotFound($"Không tìm thấy thiết bị có id = {id}");
        }
        var viewModel = ToDetailViewModel(equipment);
        return View(viewModel);
    }

    public IActionResult Stats()
    {
        var stats = _equipmentService.GetStats();
        return View(stats);
    }

    public IActionResult Welcome()
    {
        return Content("Welcome to ASP.NET Core MVC Lab02");
    }

    public IActionResult EquipmentJson()
    {
        var equipment = _equipmentService.GetAll()
            .Select(item => new
            {
                item.EquipId,
                item.EquipName,
                item.EquipCategory,
                item.EquipSupplier,
                item.EquipUnitPrice,
                item.EquipQuantity
            });
        return Json(equipment);
    }

    public IActionResult GoToList()
    {
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Force404()
    {
        return NotFound("Đây là response 404 demo từ action Force404.");
    }

    public IActionResult CategoryInfo()
    {
        return Content("Danh mục hiện có: Projection Equipment, Board Equipment, Audio Equipment, Furniture");
    }

    private static EquipmentListItemViewModel ToListItemViewModel(Equipment equipment)
    {
        return new EquipmentListItemViewModel
        {
            EquipId = equipment.EquipId,
            EquipName = equipment.EquipName,
            EquipCategory = equipment.EquipCategory,
            EquipSupplier = equipment.EquipSupplier,
            EquipUnitPrice = equipment.EquipUnitPrice,
            EquipQuantity = equipment.EquipQuantity,
            EquipMinStock = equipment.EquipMinStock
        };
    }

    private static EquipmentDetailViewModel ToDetailViewModel(Equipment equipment)
    {
        return new EquipmentDetailViewModel
        {
            EquipId = equipment.EquipId,
            EquipName = equipment.EquipName,
            EquipCategory = equipment.EquipCategory,
            EquipSupplier = equipment.EquipSupplier,
            EquipUnitPrice = equipment.EquipUnitPrice,
            EquipQuantity = equipment.EquipQuantity,
            EquipMinStock = equipment.EquipMinStock,
            EquipLastUpdatedAt = equipment.EquipLastUpdatedAt
        };
    }
}
