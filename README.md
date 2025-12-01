 Products API (Technical Assignment by Denis Aliti)

This project is a .NET 8 Web API developed for the InterAdria technical assignment. It implements a product management system with CRUD operations, filtering, pagination, and JWT authentication.

The architecture follows a clean separation of concerns using a Service layer and DTOs.

 Technologies

   Framework: .NET 8 (ASP.NET Core Web API)
   Language: C
   Database: SQL Server LocalDB
   ORM: Entity Framework Core
   Authentication: JWT (JSON Web Tokens)

 Project Structure

The solution is organized to separate business logic, data access, and API controllers:

ProductsApi/
│
├── Controllers/       (API Endpoints)
├── Data/               (DbContext configuration)
├── DTOs/               (Data Transfer Objects (CQRS pattern))
├── Entities/           (Database Models)
├── Migrations/         (EF Core Migrations)
├── Services/           (Business Logic Layer)
│
├── Program.cs          (Dependency Injection and Config)
└── appsettings.json    (Database connection string and JWT settings)


 Database & Entity

The main entity is Product, which contains the following fields: `Id`, `Name`, `Category`, `Price`, `StockQuantity`, and `CreatedAt`.

Business Logic:
When fetching products, the API includes a computed field:
   `InStock`: Returns `true` if `StockQuantity > 0`, otherwise `false`.

 Authentication

The API is secured using JWT. To access protected endpoints (POST, PUT, DELETE), you must provide a valid token in the request header.

Header format:
`Authorization: Bearer <your-token>`

 How to run the project

 Prerequisites
   .NET 8 SDK
   Visual Studio 2022 (or newer)
   SQL Server LocalDB

 Installation Steps
1.  Clone or Open the project in Visual Studio.
2.  Configure the Database:
    Since the database is not included in the source control, you need to generate it using migrations.
       Open the Package Manager Console (Tools > NuGet Package Manager > Package Manager Console).
       Run the following command:
        (Update-Database)
        
       This will create the local database and apply the necessary tables.
3.  Run the Application:
       Press `F5` in Visual Studio or run `dotnet run` in the terminal.

 API Endpoints

 Products

GET `/api/products`
Returns a list of all products.
   Filtering: You can filter by `category`, `minPrice`, and `maxPrice`.
   Pagination: Supports `pageNumber` and `pageSize`.
   Logic: Includes the `InStock` status field.

GET `/api/products/{id}`
Returns a single product based on the provided ID.

POST `/api/products`
Creates a new product.
   Required fields: Name, Category, Price.
   Requires Authentication.

  Test Credentials
To test the protected endpoints (POST, PUT, DELETE), use the following default user to generate a JWT token via the login endpoint:

*   Username: `admin`
*   Password: `password123`

PUT `/api/products/{id}`
Updates an existing product record.
   Requires Authentication.

DELETE `/api/products/{id}`
Deletes a product by ID.
   Requires Authentication.
