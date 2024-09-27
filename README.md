# 🔐 **FICompliance System**

## 🚀 **Overview**

FICompliance is a **Role-Based System** built with **C# ASP.NET MVC** and **SQL Server**. It follows an **N-tier architecture**, separating the project into various layers like **FICompliance.DAL**, **FICompliance.BOL**, **FICompliance.BLL**, and **FICompliance.WebPortal**. The database design follows the **Code First** approach, ensuring flexibility and ease of migration.

## ✨ **Key Features**

- 🛡️ **Role-Based Access Control:** Securely manages user roles like **Maker** and **Checker** to ensure authorized access.
- 👤 **User Management:** The **Maker** role can create, delete, and update users within the system.
- ✅ **Approval Workflow:** Actions initiated by the **Maker** must be approved by the **Checker**, creating a controlled and compliant environment.

## 🏗️ **N-Tier Architecture**

The system's layers include:

- **🗄️ FICompliance.DAL:** Handles all database interactions.
- **📦 FICompliance.BOL:** Contains business entities and validation logic.
- **🧠 FICompliance.BLL:** Implements business rules for the application.
- **💻 FICompliance.WebPortal:** The **ASP.NET MVC** front-end that handles user interactions and displays data.

## 🛠️ **Getting Started**

Follow these steps to get the system up and running:

### 1. **📥 Clone the Repository**
```bash
git clone https://github.com/Raahim07/Role-Base-System
```

### 2. **🗄️ Database Setup**
- Run the SQL scripts located in the `DatabaseScripts` folder to set up the necessary database and tables.

### 3. **🔗 Configure Connection String**
- Open the `web.config` file in the **FICompliance.WebPortal** project and update the connection string with your database credentials.

### 4. **🏃 Build and Run**
- Open the project in **Visual Studio**, build the solution, and hit **Run** to launch the app!
- 

💡 *Pro tip: Customize roles and add more features by expanding the logic in the BLL layer!*
