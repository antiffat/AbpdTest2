## Getting Started

These instructions will help you set up the project on your local machine for development and testing purposes.

### Prerequisites

Before you begin, ensure you have the following installed:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or any other database supported by EF Core)
- [Git](https://git-scm.com/downloads)

### Installation

1. **Clone the Repository**:
   ```sh
   git clone https://github.com/antiffat/AbpdTest2.git
   cd AbpdTest2
   ```
   2. **Navigate to the Project Directory**:
   ```sh
   cd src/AbpdTest2
   ```

3. **Restore Dependencies**:
   ```sh
   dotnet restore
   ```

### Running the Project

1. **Update Database**:
   - Ensure your SQL Server is running.
   - Update the database with migrations.
     ```sh
     dotnet ef database update
     ```

3. **Access the Application**:
   - Open your browser and navigate to `https://localhost:5237` (or the port specified in the launch settings).
