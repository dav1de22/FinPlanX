# FinPlanX - Financial Planning Application

FinPlanX is a financial planning application designed to help financial advisors manage clients and create financial plans. The application consists of a **back-end API** built with **ASP.NET Core** and a **front-end** built with **Angular**.

---

## Table of Contents
1. [Features](#features)
2. [Technologies](#technologies)
3. [Setup](#setup)
   - [Back-End](#back-end)
   - [Front-End](#front-end)
4. [API Documentation](#api-documentation)
5. [Postman Collection](#postman-collection)
6. [Contributing](#contributing)
7. [License](#license)

---

## Features
- **User Authentication**: Register and log in with JWT-based authentication.
- **Client Management**: Add, update, delete, and view client details.
- **Financial Plans**: Create and manage financial plans for clients.
- **Responsive UI**: Built with Angular and Angular Material for a modern, responsive design.

---

## Technologies
### Back-End
- **ASP.NET Core**: RESTful API with C#.
- **Entity Framework Core**: Database management with SQL Server.
- **JWT Authentication**: Secure user authentication.
- **Swagger**: API documentation and testing.

### Front-End
- **Angular**: Front-end framework for building the user interface.
- **Angular Material**: UI component library for a polished design.
- **RxJS**: Reactive programming for handling API requests.
- **TypeScript**: Strongly-typed JavaScript for better code quality.

---

## Setup

### Back-End
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/FinPlanX.git
   cd FinPlanX/Backend
   ```

2. **Set Up the Database**:
   - Update the connection string in `appsettings.json`.
   - Run migrations to create the database:
     ```bash
     dotnet ef database update
     ```

3. **Run the API**:
   ```bash
   dotnet run
   ```
   The API will be available at `http://localhost:5251`.

---

### Front-End
1. **Navigate to the Front-End Folder**:
   ```bash
   cd FinPlanX/Frontend
   ```

2. **Install Dependencies**:
   ```bash
   npm install
   ```

3. **Run the Angular Application**:
   ```bash
   ng serve
   ```
   The front-end will be available at `http://localhost:4200`.

---

## API Documentation
The API is documented using **Swagger**. After running the back-end, you can access the Swagger UI at:
```
http://localhost:5251/swagger
```

---

## Postman Collection
A Postman collection is available for testing the API. You can find it in the `postman` folder:
- **Collection**: [`postman/FinPlanX_API.postman_collection.json`](postman/FinPlanX_API.postman_collection.json)
- **Environment**: [`postman/FinPlanX_Local.postman_environment.json`](postman/FinPlanX_Local.postman_environment.json)

To use the collection:
1. Import the collection and environment files into Postman.
2. Set the `base_url` variable in the environment to your API's base URL (e.g., `http://localhost:5251`).
3. Use the collection to test the API endpoints.

---

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Acknowledgments
- **Angular**: For providing a powerful front-end framework.
- **ASP.NET Core**: For building a robust back-end API.
- **Postman**: For simplifying API testing.
