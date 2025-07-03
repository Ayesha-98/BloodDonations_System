# Management System - Blazor Server App

A full-featured **Blazor Server** web application with integrated **Google OAuth 2.0 login**, **SQL Server** database, **3-tier architecture**, and a working **Web API module**. The project demonstrates modular design using reusable components, role-based UI navigation, and clean separation of concerns.

---

## 🔍 Project Overview

This system allows authenticated users to manage donors and other entities through a clean UI built with Blazor Server. It includes:

- Google Sign-In (OAuth 2.0)
- Full CRUD for Donors using Web API (GET, POST, PUT, DELETE)
- Local CRUD for Staff/Other modules using ADO.NET and Repository pattern
- 3-Tier Architecture (Presentation → BLL → DAL)
- Responsive UI with Bootstrap/CSS
- Data persistence in Microsoft SQL Server

---

## 🛠️ Technologies Used

- **Frontend:** Blazor Server (ASP.NET Core)
- **Backend:** ASP.NET Core Web API, C#
- **Database:** Microsoft SQL Server
- **Authentication:** Google OAuth 2.0 with ASP.NET Core Identity
- **Architecture:** 3-Tier (Presentation, Business Logic Layer, Data Access Layer)
- **HTTP Client:** `HttpClient` for API calls
- **UI Styling:** Bootstrap 5, CSS Flexbox/Grid

---

## 🧩 Key Features

- 🔐 Google Sign-In with secure session management  
- 📋 CRUD Operations:
  - Donors: via Web API
  - Staff and Donations: via ADO.NET and repository pattern  
- 💾 SQL Server integration with normalized schema (foreign keys, constraints)
- ♻️ Reusable Razor components  
- 🌐 Route-based navigation  
- ⚙️ Clean codebase with separation of concerns

---

## ⚙️ Setup Instructions

### Prerequisites

- [.NET SDK 7+](https://dotnet.microsoft.com/)
- [SQL Server 2019 or 2022](https://www.microsoft.com/en-us/sql-server/)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/)
- A Google Developer Account (for OAuth Client ID/Secret)

---

### 🛠 Database Configuration

1. Create a SQL Server database named: `management_system`
2. Execute the table creation script (`Users`, `Donors`, `Staff`, etc.)
3. Update your connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=YOUR_SERVER_NAME;Initial Catalog=management_system;Integrated Security=True;TrustServerCertificate=True"
}
