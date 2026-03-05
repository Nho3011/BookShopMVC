# 📚 BookShopMVC

Web application bán sách trực tuyến được xây dựng bằng **ASP.NET MVC**
nhằm mục đích học tập và thực hành xây dựng hệ thống thương mại điện tử
cơ bản.

Hệ thống cho phép người dùng xem sách, thêm vào giỏ hàng, thanh toán qua
**VNPay**, đồng thời quản trị viên có thể quản lý danh mục và sản
phẩm trong khu vực **Admin Area**.

------------------------------------------------------------------------

# ✨ Features

  | Feature | Description |
|-------|-------------|
| 📚 **Product Management** | Manage books and categories |
| 🛒 **Shopping Cart** | Add, remove, and update products in the shopping cart |
| 💳 **MoMo Payment** | Online payment integration using MoMo payment gateway |
| 👤 **User Authentication** | User registration, login, and account management using ASP.NET Identity |
| ⚙️ **Admin Dashboard** | Admin area for managing products and categories |
| 🔗 **RESTful API** | API endpoints for product, cart, and other operations |
| 🧩 **Component-based UI** | Reusable UI components implemented with ViewComponents |

------------------------------------------------------------------------

# 📂 Directory Structure

```cmd
    ├── BookShopMVC
    │   ├── Areas
    │   │   ├── Admin                   # Admin controllers for product and category management
    │   │   │   ├── Controllers         
    │   │   │   └── Views
    │   │   │       ├── Category        # Category management views
    │   │   │       └── Product         # Product management views
    |   |   |
    │   │   └── Identity                # User account management pages
    │   │       
    │   |
    │   ├── Controllers                 # RESTful API controllers
    │   │   └── Api
    │   |
    │   ├── Middleware                  # Custom middleware components
    │   |
    │   ├── Pages                       # Razor Pages
    │   |
    │   ├── Properties                  # Application configuration
    │   |
    │   ├── Services                    # Business logic and service layer
    │   |
    │   ├── ViewComponents              # Reusable UI components (Menu, Footer)
    │   |
    │   ├── Views                       # Views
    │   │   ├── Home
    │   │   ├── Shared
    │   │   │   └── Components
    │   │   │  
    │   │   └── ShoppingCart
    |   |
    │   └── wwwroot                     # Static assets (CSS, JS, images, libraries)
    │      
    │
    ├── BookShopMVC.DataAccess
    │   ├── Data                        # Database context
    │   ├── Migrations                  # Entity Framework migrations
    │   └── Repository
    │       └── IRepository             # Repository pattern interfaces
    │
    ├── BookShopMVC.Model
    │   ├── DTO                         # Data transfer objects
    │   ├── Mappers                     # Object mapping logic
    │   ├── Validation                  # Model validation rules
    │   └── ViewModels                  # View models for UI
    │
    └── BookShopMVC.Utility             # Helper classes and constants
```
------------------------------------------------------------------------

# 🏗️ System Overview

Hệ thống được thiết kế theo kiến trúc **ASP.NET MVC nhiều layer**:

Frontend hiển thị giao diện bằng **Bootstrap và Razor Views**
Backend **C# ASP.NET MVC** xử lý business logic và API
Dữ liệu lưu trong **MySQL database** thông qua **Entity Framework
Core**
Thanh toán được tích hợp với **VNPay**

Kiến trúc này giúp tách rõ:

-   Presentation Layer (Views / Controllers)
-   Business Logic Layer (Services)
-   Data Access Layer (Repository + DbContext)

------------------------------------------------------------------------

# 🛠️ Tech Stack

 | Layer | Technologies |
|------|-------------|
| **Frontend** | Bootstrap, Razor Views |
| **Backend** | C# ASP.NET MVC |
| **Database** | MySQL |
| **Authentication** | ASP.NET Identity |
| **Payment** | VNPay |
| **Architecture** | RESTful API + Repository Pattern |

------------------------------------------------------------------------

# 🎯 Purpose of the Project

Dự án được xây dựng nhằm:

-   Thực hành xây dựng hệ thống **E-commerce bằng ASP.NET MVC**
-   Làm quen **ASP.NET Identity Authentication**
-   Tìm hiểu **tích hợp cổng thanh toán VNPay**
-   Áp dụng **Repository Pattern và RESTful API**
-   Hiểu cách tổ chức **multi-layer architecture trong ASP.NET**

Project này phục vụ mục đích **học tập và nghiên cứu công nghệ**, không
hướng tới triển khai thương mại.
