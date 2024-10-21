# 🌱 Agri-Energy Connect Platform 🌍

## Introduction
Welcome to the **Agri-Energy Connect Platform**, an innovative web application designed to bridge the gap between agriculture and green energy solutions. This platform enables farmers, green energy experts, and other stakeholders to collaborate and explore sustainable solutions for the agricultural sector. This repository contains the code and documentation for the prototype developed as part of my **Programming 3A** Portfolio of Evidence assignment.

## Features
- **Sustainable Farming Hub**: A resource center offering sustainable farming practices like organic farming, water conservation, and more.
- **Green Energy Marketplace**: A marketplace for green energy solutions tailored for agricultural needs such as solar-powered irrigation systems.
- **Educational Resources**: Access online courses, webinars, and workshops for adopting renewable energy technologies.
- **User Roles**: Two roles, Farmers and Employees, each with distinct functionalities.
- **Secure Authentication**: Login functionality with role-based access to secure user data.

## Setup Instructions
### Prerequisites
Before running the project, ensure you have the following installed:
- Visual Studio 2022 or later
- SQL Server or an alternative database system
- .NET Core 6.0 or later

### Steps to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/ST10067544-Thato/Agri-Energy-Connect.git
   ```
2. Open the solution in Visual Studio.
3. Restore the required packages by running:
   ```bash
   dotnet restore
   ```
4. Set up the database using the provided SQL scripts in `/Miscellaneous/AgriEnergyConnectDB.sql`.
5. Update the database connection string in `appsettings.json` to point to your local database.
6. Run the application by pressing `F5` in Visual Studio.

### Usage
Once the application is running:
- Login as either a **Farmer** or an **Employee**.
- Farmers can add products and view/manage their product listings.
- Employees can add new farmers and view/filter products by date or product type.

## Project Structure
- **/Controllers**: Handles the core logic of the application.
- **/Models**: Contains the data models used by the system.
- **/Views**: Razor views for the user interface.
- **/wwwroot**: Static content like CSS and JavaScript.

## Technologies Used
- C# with ASP.NET Core
- Entity Framework Core for database management
- Razor Pages for frontend development
- SQL Server for the database

## Future Enhancements
- Real-time collaboration features for users.
- Integration with third-party APIs for expanded functionality.

## Acknowledgements
This project was developed as part of my **PROG7311 Programming 3A** POE.

---
Developed by Thato - [GitHub Profile](https://github.com/ST10067544-Thato)
