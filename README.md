# Social Dating App API

## Description

This project is an API built using .NET 8.0, designed to handle user authentication, messaging, photo management, and real-time features like online presence tracking. The API is highly scalable, using SQL Server for data storage, and supports role-based authorization and real-time communication via SignalR. The project focuses on providing a secure, efficient backend for user-centric web applications, integrating key features such as user roles, photo moderation, messaging, and user activity tracking.

## Features

- **User Authentication and Authorization**

  - Implemented user authentication with JWT tokens for secure access.
  - Added role-based authorization, allowing admins and moderators to manage user roles and perform tasks like photo moderation.
  - Integrated ASP.NET Core Identity for handling users, roles, and permissions.

- **Messaging Functionality**

  - Real-time messaging system via SignalR, enabling users to send, receive, and delete messages.
  - Presence tracking, which shows online status for users in real-time.
  - Pagination and filters for managing message history and threads efficiently.

- **Photo Upload and Moderation**

  - Integrated photo upload feature with Cloudinary for storage.
  - Admins can approve or reject user-uploaded photos.
  - Users can set their main profile photo and delete unwanted ones.

- **Likes and User Interaction**

  - Implemented a "like" system allowing users to like or unlike other users.
  - Managed many-to-many relationships between users with efficient data handling.
  - Pagination and filters for browsing user interactions.

- **Activity Logging and Pagination**

  - Logs user activity automatically, tracking when a user is active.
  - Implemented pagination in user listing and messaging to handle large datasets efficiently.

- **Migration from SQLite to SQL Server**

  - Migrated database from SQLite to SQL Server for better scalability and performance.
  - Adjusted data relationships to prevent cascading deletes in certain cases.

#### Technology Stack

- **Languages**: C#, .NET 8.0
- **Frameworks**: ASP.NET Core, SignalR
- **Database**: SQL Server, Entity Framework Core
- **Authentication**: ASP.NET Core Identity, JWT
- **Cloud Storage**: Cloudinary (for photo uploads)
- **Real-time Communication**: SignalR
- **Others**: AutoMapper, CORS, Pagination

## Installation

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Server Express
- [Cloudinary Account](https://cloudinary.com/) (for photo uploads)

### Environment Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/elvan/social-dating-app-backend-dotnet.git
   cd social-dating-app-backend-dotnet
   ```

2. Set up environment variables:

   - Create a new file `appsettings.Development.json` based on `appsettings.Development.json.example`.
   - Add your Cloudinary API keys and connection string for SQL Server.

3. Run database migrations:

   ```bash
   dotnet ef database update
   ```

4. Seed the database (optional, for testing):
   ```bash
   dotnet run --seed
   ```

### Installation Commands

1. Install required dependencies:

   ```bash
   dotnet restore
   ```

2. Run the project:
   ```bash
   dotnet run
   ```

## Usage

1. **Authentication**: Register a new user via the `/api/account/register` endpoint. Upon successful registration, you will receive a JWT token.

2. **Photo Upload**: Once authenticated, upload photos using `/api/users/add-photo`. You can set your main photo and delete any unwanted photos.

3. **Messaging**: Use the `/api/messages` endpoints to send, receive, and delete messages in real-time. SignalR hubs will track your online presence and display it to other users.

4. **Admin Features**: Users with admin roles can moderate photos and manage user roles through the admin interface. Admin controllers are secured with role-based policies.

Feel free to modify or enhance the project by exploring various controllers and repositories to suit your application's needs.
