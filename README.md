

```markdown
# Student Management System (CRUD Application)

This is a simple MVC CRUD application built using ASP.NET Core 8.0. It allows users to perform basic operations for managing student data, including adding, updating, retrieving, and deleting records from a database.

## Features

- **Add Student**: Add a new student to the database.
- **Retrieve Student**: View student details by ID.
- **Update Student**: Edit student information using their ID.
- **Delete Student**: Remove a student record by ID.

## Technologies Used

- **Framework**: ASP.NET Core 8.0
- **Language**: C#
- **Database**: My SQL
- **Frontend**: Razor Pages 
- **IDE**: Visual Studio

## Setup and Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/your-repository.git
   cd your-repository
   ```

2. Open the project in your preferred IDE.

3. Restore the dependencies:
   ```bash
   dotnet restore
   ```

4. Update the database connection string in `appsettings.json` to match your database configuration:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=your_server;Database=your_database;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

5. Apply migrations and seed the database (if applicable):
   ```bash
   dotnet ef database update
   ```

6. Run the application:
   ```bash
   dotnet run
   ```

7. Navigate to `http://localhost:5000` (or the port specified in your configuration).

## How to Use

### Add a Student
1. Navigate to the "Add Student" page.
2. Fill in the student details and click "Submit."

### Retrieve Student Details
1. Go to the "View Students" page.
2. Search for a student by their ID.

### Update a Student
1. Navigate to the "Update Student" page.
2. Enter the student ID and update the details.

### Delete a Student
1. Go to the "Delete Student" page.
2. Enter the student ID and confirm deletion.

## Project Structure

- **Controllers**: Contains the logic for handling user requests.
- **Models**: Defines the `Student` class and database schema.
- **Views**: Razor views for displaying and interacting with student data.
- **Migrations**: Folder for Entity Framework Core migrations.

