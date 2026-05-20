# MiniEquipmentInventory

## 📋 Mô Tả Dự Án

**MiniEquipmentInventory** là một ứng dụng web ASP.NET Core MVC nhẹ nhàng, dùng để quản lý danh sách thiết bị. Ứng dụng cho phép người dùng xem, quản lý và thống kê thông tin về các thiết bị trong hệ thống.

## 🛠️ Công Nghệ Sử Dụng

- **Backend**: ASP.NET Core (net8.0)
- **Frontend**: Razor Views, HTML5, CSS3, JavaScript
- **Framework CSS**: Bootstrap 5
- **JavaScript Libraries**: jQuery, jQuery Validation, jQuery Validation Unobtrusive
- **Architecture**: MVC Pattern

## 📁 Cấu Trúc Thư Mục

```
MiniEquipmentInventory.sln          # Solution file
│
└── MiniEquipmentInventory.Mvc/     # Main project folder
    ├── Program.cs                  # Entry point & configuration
    ├── MiniEquipmentInventory.Mvc.csproj
    ├── appsettings.json           # Configuration file
    ├── appsettings.Development.json
    │
    ├── Controllers/               # Các controller xử lý request
    │   ├── EquipmentController.cs # Quản lý thiết bị
    │   └── HomeController.cs      # Trang chủ
    │
    ├── Models/                    # Data models
    │   ├── Equipment.cs           # Model cho thiết bị
    │   └── ErrorViewModel.cs      # Model cho error page
    │
    ├── Services/                  # Business logic
    │   └── EquipmentService.cs    # Service quản lý thiết bị
    │
    ├── ViewModels/                # Data cho Views
    │   ├── EquipmentDetailViewModel.cs    # Chi tiết 1 thiết bị
    │   ├── EquipmentListItemViewModel.cs  # Item trong danh sách
    │   └── EquipmentStatsViewModel.cs     # Thống kê thiết bị
    │
    ├── Views/                     # Razor Views
    │   ├── _ViewImports.cshtml    # Import global cho views
    │   ├── _ViewStart.cshtml      # Layout mặc định
    │   ├── Equipment/             # Views cho Equipment
    │   │   ├── Index.cshtml       # Danh sách thiết bị
    │   │   ├── Detail.cshtml      # Chi tiết thiết bị
    │   │   └── Stats.cshtml       # Thống kê thiết bị
    │   ├── Home/                  # Views cho Home
    │   │   ├── Index.cshtml       # Trang chủ
    │   │   └── Privacy.cshtml     # Trang chính sách
    │   └── Shared/                # Shared views
    │       ├── _Layout.cshtml     # Master layout
    │       ├── _Layout.cshtml.css # Layout styles
    │       ├── _ValidationScriptsPartial.cshtml
    │       └── Error.cshtml       # Error page
    │
    ├── wwwroot/                   # Static files
    │   ├── css/
    │   │   └── site.css          # Custom styles
    │   ├── js/
    │   │   └── site.js           # Custom scripts
    │   └── lib/                  # Thư viện JavaScript
    │       ├── bootstrap/         # Bootstrap CSS framework
    │       ├── jquery/            # jQuery library
    │       ├── jquery-validation/
    │       └── jquery-validation-unobtrusive/
    │
    ├── Properties/
    │   └── launchSettings.json    # Debug & launch settings
    │
    └── bin/ & obj/                # Build output (ignored in git)
```

## 🎯 Chức Năng Chính

### Equipment Management
- **Index**: Hiển thị danh sách tất cả thiết bị
- **Detail**: Xem chi tiết một thiết bị
- **Stats**: Xem thống kê về các thiết bị

### Home
- **Index**: Trang chủ ứng dụng
- **Privacy**: Trang chính sách bảo mật


## 📝 Các File Quan Trọng

| File | Mô Tả |
|------|-------|
| `Program.cs` | Cấu hình startup, dependency injection, middleware |
| `EquipmentService.cs` | Business logic cho quản lý thiết bị |
| `EquipmentController.cs` | Xử lý HTTP requests cho Equipment |
| `Models/Equipment.cs` | Data model chứa thông tin thiết bị |
| `Views/Equipment/Index.cshtml` | UI hiển thị danh sách thiết bị |

