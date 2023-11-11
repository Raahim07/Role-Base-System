# FICompliance System

## Overview

FICompliance is a Role-Based System built using C# ASP.NET MVC and SQL Server. The system follows the N-tier architecture, organized into different layers including FICompliance.DAL, FICompliance.BOL, FICompliance.BLL, and FICompliance.WebPortal.

## Features

The key features of the system include:

- **Role-Based Access Control:** The system implements a role-based access control mechanism with the roles of Maker and Checker.

- **User Management:** The Maker role has the rights to create, delete, and update users. 

- **Approval Workflow:** The Checker role is responsible for approving actions initiated by the Maker, providing a secure and controlled environment.

## N-tier Architecture

The application is structured into the following layers:

- **FICompliance.DAL:** Data Access Layer responsible for interacting with the database.
  
- **FICompliance.BOL:** Business Object Layer containing business entities and validations.

- **FICompliance.BLL:** Business Logic Layer implementing the application's business rules.

- **FICompliance.WebPortal:** Presentation Layer built using C# ASP.NET MVC, handling user interface and interactions.

## Getting Started

To set up and run the FICompliance System locally, follow these steps:

1. **Clone the Repository:**
    ```bash
    git clone https://github.com/your-username/FICompliance.git
    ```

2. **Database Setup:**
    - Execute SQL scripts in the `DatabaseScripts` folder to create the required database and tables.

3. **Configure Connection String:**
    - Update the connection string in the `web.config` file of the `FICompliance.WebPortal` project with your database details.

4. **Build and Run:**
    - Open the solution in Visual Studio and build the solution.
    - Run the application.

## Contribution Guidelines

If you would like to contribute to the development of the FICompliance System, please follow our [Contribution Guidelines](CONTRIBUTING.md).

## License

This project is licensed under the [MIT License](LICENSE).
