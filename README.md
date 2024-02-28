# SocialDating

## Description

This project is a comprehensive dating app designed to facilitate user interactions through features like user profiles, photo management, messaging, likes, and live chat functionalities. It emphasizes secure user authentication, real-time communication, and an engaging user experience. The project showcases a modern tech stack and adheres to best practices in software development.

## Features

- **User Authentication and Profile Management** - Implements JWT authentication, allowing users to register, log in, and manage their profiles. User passwords are securely hashed, and JWT tokens are configured with user role claims. Users can update profiles, including personal details and photos, ensuring a dynamic and personalized experience.

- **Real-time Messaging and Likes** - Utilizes SignalR for live chat functionality, enabling users to communicate in real-time. The messaging feature supports sending, retrieving, and deleting messages. A likes feature allows users to express interest in other users, enhancing user interaction and engagement.

- **Photo Management** - Integrates Cloudinary for efficient photo storage and management. Users can upload photos, set a main photo, and delete photos, enriching their profile presentation and visibility.

- **Database and ORM** - Migrates the database from SQLite to PostgreSQL for improved performance and scalability. Implements the UnitOfWork pattern for database operations, ensuring a clean and maintainable codebase. Utilizes Entity Framework Core for object-relational mapping, facilitating data management and manipulation.

#### Technology Stack

- .NET 8.0
- Entity Framework Core
- AutoMapper
- JWT Authentication
- SignalR
- CloudinaryDotNet
- PostgreSQL

## Installation

### Prerequisites

- .NET 8.0 SDK
- PostgreSQL
- Cloudinary account

### Environment Setup

- Configure `appsettings.json` with your PostgreSQL and Cloudinary credentials.
- Ensure .NET CLI is installed.

### Installation Commands

```bash
# Clone the repository
git clone https://github.com/elvan/social-dating-app-backend-dotnet.git

# Navigate to the project directory
cd social-dating-app-backend-dotnet

# Install dependencies
dotnet restore

# Apply migrations
dotnet ef database update

# Run the project
dotnet run
```

## Usage

After installation, the project can be accessed at `http://localhost:5000` for the API endpoints and `http://localhost:5000/swagger` for Swagger UI documentation. Use the Swagger UI to test various endpoints:

- **Authentication**: Register a new user or log in to receive a JWT token.
- **Profiles**: View and update user profiles, including photo management.
- **Messaging**: Use the live chat feature for real-time communication with other users.
- **Likes**: Like other users and view who liked you or whom you liked.

This README provides a general overview and setup instructions. Explore the Swagger documentation for detailed usage of each endpoint.
