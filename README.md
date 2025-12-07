# 🚌 SRC Travel Agency – Online Bus Reservation System

![.NET](https://img.shields.io/badge/Framework-ASP.NET-blue?style=flat\&logo=dotnet\&logoColor=white) ![C#](https://img.shields.io/badge/Language-C%23-green?style=flat\&logo=c-sharp\&logoColor=white) ![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-orange?style=flat\&logo=microsoft-sql-server\&logoColor=white) ![License](https://img.shields.io/badge/License-MIT-lightgrey?style=flat)

**SRC Travel Agency** is a complete **online bus ticket reservation system** built with **ASP.NET MVC and C#**. Users can browse bus routes, book tickets, select seats, and manage reservations, while admins can manage buses and monitor bookings efficiently.

---

## 🌟 Features

* **User Features:**

  * Browse bus routes and schedules
  * Select seats and book tickets
  * Enter passenger details
  * View booking history and cancel reservations

* **Admin Features:**

  * Add, update, or delete buses and routes
  * Monitor bookings and user activities
  * Manage seat availability

* **Technical Features:**

  * ASP.NET MVC with **C#**
  * SQL Server database for storing users, buses, and bookings
  * Input validation using **Data Annotations**
  * Responsive and intuitive UI

---

## 🖥 Screens

| Screen         | Description                                  |
| -------------- | -------------------------------------------- |
| Homepage       | View available buses and routes              |
| Booking Page   | Select seats and book tickets                |
| Admin Panel    | Manage buses, routes, and bookings           |
| User Dashboard | View booking history and cancel reservations |

---

## 🛠 Tech Stack

* **ASP.NET MVC** – Web framework
* **C#** – Programming language
* **SQL Server** – Database
* **HTML/CSS/Bootstrap** – Frontend
* **Data Annotations** – Input validation

---

## ⚡ Installation

1. Clone the repository:

```bash
git clone <repo-url>
```

2. Open the solution in **Visual Studio**

3. Configure the **SQL Server connection string** in `Web.config`

4. Run the project using **IIS Express** or your preferred server

## 📖 Usage

* Register as a user to book tickets
* Login to access your dashboard
* Browse buses, select a route, pick seats, and confirm booking
* Admins login to manage buses, routes, and monitor reservations

---

## 📂 Project Structure

```
SRCTravelAgency/
├── Controllers/
│   ├── BookingController.cs
│   ├── BusController.cs
│   └── UserController.cs
├── Models/
│   ├── Booking.cs
│   └── Bus.cs
├── Views/
│   ├── Home/
│   ├── Booking/
│   └── Admin/
├── Scripts/
├── Content/
├── Web.config
└── SRCTravelAgency.sln
```

---

## 📄 License

This project is **open-source** and licensed under the **MIT License**.

