
## JWTAuth API

A simple, secure RESTful Web API built with **ASP.NET Core 9**, implementing **JWT (JSON Web Token) Authentication** for user login and registration.  
User data is stored using **Entity Framework Core** with **SQL Server**.  
The project is structured with **clean architecture principles**, making it scalable, testable, and easy to maintain.

---

## Technologies Used

- **.NET 9**
- **ASP.NET Core Web API**
- **Entity Framework Core** (with SQL Server)
- **JWT Authentication**
- `System.IdentityModel.Tokens.Jwt`
- `Microsoft.AspNetCore.Authentication.JwtBearer`
- `Microsoft.EntityFrameworkCore.Tools`
- `Scalar.AspNetCore` (for strong typing and value objects)
- Clean, modular architecture (CQRS-ready)

---

## Endpoints

### 1. **POST /api/auth/register**
   - **Description**: Registers a new user.
   
---

### 2. **POST /api/auth/login**
   - **Description**: Logs in an existing user and returns a JWT access token and refresh token.

---

### 3. **GET /api/auth**
   - **Description**: A test endpoint that requires authentication.
  
---

### 4. **GET /api/auth/admin-only**
   - **Description**: A test endpoint that requires an "Admin" role.

---

### 5. **POST /api/auth/refresh-token**
   - **Description**: Refreshes the JWT access and refresh tokens.
---

## How to Use

1. **Clone the repository**:
   ```bash
   git clone https://github.com/misiak-wojciech/JWTAuth.git
   cd JWTAuth
   ```

2. **Set up your database connection** in `appsettings.json`:

3. **Run the migrations** to set up the database:
   ```bash
   dotnet ef database update
   ```

4. **Run the application**:
   ```bash
   dotnet run
   ```

---
