# GreenFields - .NET Core Web App

## Table of Contents
1. [Environment Setup](#environment-setup)
2. [Running the Prototype](#running-the-prototype)
3. [Functions and User Roles](#functions-and-user-roles)

## Environment Setup

### Prerequisites
- Visual Studio 2022 or later
- .NET 8.0 SDK or later
- SQL Server Management Studio (SSMS)

### Step-by-Step Instructions

1. **Clone the Repository or Download the Zip**
   - Clone the repository: `git clone <repository-url>`
   - Or download and extract the zip file.

2. **Open the Solution in Visual Studio**
   - Navigate to the extracted folder and open the `.sln` file.

3. **Configure the Database Connection**
   - Open SQL Server Management Studio (SSMS).
   - Copy the server name from SSMS.
   - Open `appsettings.json` in Visual Studio.
   - Replace the server name in the connection string with your SSMS server name:

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=GreenFieldsDB;Trusted_Connection=True;TrustServerCertificate=Yes"
   }

## Running the Prototype

### Update the Database

1. **Open Package Manager Console**
   - In Visual Studio, go to Tools > NuGet Package Manager > Package Manager Console.

2. **Run Update Command**
   - Run the following command to update the database schema:
   ```powershell
   Update-Database


### Populate the Database
- Open SSMS and Run Script
- Open SQL Server Management Studio (SSMS).
- Open the script file included with the project.
- Ensure the database is set to GreenFieldsDB.
- Run the script.
- Note: Some errors might occur during script execution, but they won't affect the app's functionality.

### Running the Prototype
- Start the Application

- Click the Run button in Visual Studio (F5 or Ctrl+F5).

## Functions and User Roles

### User Roles

- **Farmer**
  - Can add products.
  - Can view their products.

- **Employee**
  - Can add farmers and other employees.
  - Can view a specific farmer's products.
  - Can filter products based on category and date range.

### Functions

1. **Adding Products (Farmer)**
   - Navigate to the "Add Product" section.
   - Enter the product name, category, production date, and stock available.
   - Click "Save".

2. **Viewing Products (Farmer)**
   - Navigate to "My Products" to see a list of all products added by the farmer.

3. **Adding Farmers and Employees (Employee)**
   - Navigate to "Register User".
   - Enter the details of the farmer or employee and assign the appropriate role.
   - Click "Save".

4. **Viewing Farmer's Products (Employee)**
   - Navigate to "View Farmers".
   - Select a farmer to view their products.

5. **Filtering Products (Employee)**
   - Select the desired category and/or date range.
   - Click "Apply Filter" to see the results.

