# DotNetLibrary


## Description
WebAPI8 is a .NET web application that provides RESTful APIs for managing authors and books. It allows users to perform CRUD operations on authors and books, as well as retrieve a list of authors and books.

![WhatsApp Image 2024-05-15 at 07 17 47](https://github.com/LucasFonseca0/DotNetLibrary-RestfulAPI-SQL-server/assets/151788899/ee65f457-78ca-4b19-991e-87e2fc43ecfa)

## Features
- List authors
- Search for an author by ID
- Search for an author by book ID
- Create an author
- Edit an author
- Delete an author
- List books
- Search for a book by ID
- Search for books by author ID
- Create a book
- Edit a book
- Delete a book

## Technologies Used
- .NET Core
- Entity Framework Core
- ASP.NET Core Web API
- Swagger UI (for API documentation)
- Microsoft SQL Server (as the database)

## Getting Started
To run this project locally, follow these steps:
1. Clone this repository to your local machine.
2. Open the solution file (WebAPI8.sln) in Visual Studio or your preferred IDE.
3. Ensure you have the necessary dependencies installed (such as .NET Core SDK).
4. Update the database connection string in the appsettings.json file to point to your local SQL Server instance.
5. Run the database migrations to create the database schema: 
```dotnet ef database update```
6. Build and run the project.
7. Use a tool like Postman or Swagger UI to interact with the API endpoints.

## Contributing
Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.

## Authors
- Lucas Fonseca

