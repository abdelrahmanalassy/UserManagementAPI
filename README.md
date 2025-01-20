# User Manegement API

This Project is a .NET 8 WebAPI for managing users, where user data is fetched from the Random User API and stored in a database.

### **Setup instructions:**
1. NET SDK 8.0.
2. Set up SQL Server as the database.
3. Added the connection string to `appsettings.json` to enable communication with the database.
4. Start the application using `dotnet run`.
5. Using Postman for API testing.



### **API details**
**Base URL**
`http://localhost:5103/api`

**Endpoints**:
| HTTP Method | Endpoint                   | Description                                                              |
|-------------|----------------------------|--------------------------------------------------------------------------|
| **GET**     | `/users`                  | Retrieves a list of users.                                               |
| **GET**     | `/users?country=...`      | Retrieves users filtered by country and ordered by last name.            |
| **GET**     | `/users/populate`         | Fetches 10 random users from the Random User API and stores them.        |
| **GET**     | `/users/populate?count=...` | Fetches a specified number of random users and stores them.              |
| **GET**     | `/users/metrics`          | Calculates and retrieves user metrics (Total Users, Unique Countries, Average Age). |

### **Headers**
- `Content-Type: application/json`

### **Example Responses & Requests.:**
- Get All Users Order By Last Name: `/api/users`

  ```json
  [
    {
        "user_id": "b3d4fb74-8d8d-449d-b046-df6acdc181f8",
        "first_name": "Elif",
        "last_name": "Abadan",
        "email": "elif.abadan@example.com",
        "dob": "1980-02-09T00:00:00",
        "country": "Turkey"
    },
    {
        "user_id": "ce295fe0-dffe-4bb4-8c61-f04e63196109",
        "first_name": "Nurdan",
        "last_name": "Akbulut",
        "email": "nurdan.akbulut@example.com",
        "dob": "1947-03-24T00:00:00",
        "country": "Turkey"
    },
    {
        "user_id": "8125f858-3999-4753-bae5-4c99ecfded5c",
        "first_name": "Antoine",
        "last_name": "Andersen",
        "email": "antoine.andersen@example.com",
        "dob": "1987-04-24T00:00:00",
        "country": "Canada"
    },
    {
        "user_id": "80e8bbe4-6cdc-4555-8a24-0188948e9b7d",
        "first_name": "Karolina",
        "last_name": "Anfinsen",
        "email": "karolina.anfinsen@example.com",
        "dob": "1988-02-01T00:00:00",
        "country": "Norway"
    },
    {
        "user_id": "6ab90362-4333-432e-95fb-e3942d6d17ce",
        "first_name": "Otto",
        "last_name": "Arnaud",
        "email": "otto.arnaud@example.com",
        "dob": "1950-02-09T00:00:00",
        "country": "Switzerland"
    },
    {
        "user_id": "fbdcd0c1-7ec5-42a3-bab4-6333920acb12",
        "first_name": "Sofija",
        "last_name": "Auestad",
        "email": "sofija.auestad@example.com",
        "dob": "1992-04-13T00:00:00",
        "country": "Norway"
    },
    {
        "user_id": "699ee9dd-9844-4650-a83b-9b73c6e69273",
        "first_name": "Dwayne",
        "last_name": "Austin",
        "email": "dwayne.austin@example.com",
        "dob": "1989-12-16T00:00:00",
        "country": "United Kingdom"
    },
    {
        "user_id": "ed283cce-652c-4f8b-a833-57e6b2a523f4",
        "first_name": "Tude",
        "last_name": "Barros",
        "email": "tude.barros@example.com",
        "dob": "1946-04-01T00:00:00",
        "country": "Brazil"
    },
    {
        "user_id": "11eb62d0-b9fa-4cbe-bc67-68ee544facff",
        "first_name": "Hans-Ulrich",
        "last_name": "Bayer",
        "email": "hans-ulrich.bayer@example.com",
        "dob": "1981-09-09T00:00:00",
        "country": "Germany"
    }
  ]
  ```
  
- Populate Users: `/api/users/populate`

  ```json
  {
    "message": "10 Users Saved Successfully!"
  }
  ```
  
- Populate Random Users: `GET /api/users/populate?count=50`

  ```json
  {
    "message": "50 Users Saved Successfully!"
  }
  ```
  
- Filter by country: `GET /api/users?country=USA`

  ```json
  [
    {
        "user_id": "8724e19d-ba0f-428d-a032-086d942e99e0",
        "first_name": "Travis",
        "last_name": "Burke",
        "email": "travis.burke@example.com",
        "dob": "1976-09-17T00:00:00",
        "country": "United States"
    },
    {
        "user_id": "9b2df6d1-edd6-40fc-8596-1c80021e6729",
        "first_name": "Leonard",
        "last_name": "Curtis",
        "email": "leonard.curtis@example.com",
        "dob": "1955-07-29T00:00:00",
        "country": "United States"
    },
    {
        "user_id": "4dc99968-88fb-40bc-9446-cf664a357703",
        "first_name": "Chloe",
        "last_name": "Fields",
        "email": "chloe.fields@example.com",
        "dob": "1953-01-27T00:00:00",
        "country": "United States"
    },
    {
        "user_id": "72b85672-2d6a-4a47-81c4-071886c07141",
        "first_name": "Jennifer",
        "last_name": "Frazier",
        "email": "jennifer.frazier@example.com",
        "dob": "1952-06-25T00:00:00",
        "country": "United States"
    },
    {
        "user_id": "a86d277b-4a86-4342-93e0-d9f5cc30fc15",
        "first_name": "Katie",
        "last_name": "Gilbert",
        "email": "katie.gilbert@example.com",
        "dob": "1999-12-11T00:00:00",
        "country": "United States"
    }
  ]
  ```
  
- Get metrics: `GET /api/users/metrics`

  ```json
  {
    "total_users": 164,
    "countries_count": 21,
    "average_age": 52
  }
  ```
