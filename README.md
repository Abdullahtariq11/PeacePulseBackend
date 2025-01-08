Sure, here's a draft for your README file.

# Peace Pulse (Backend)

[![GitHub stars](about:sanitized)](https://www.google.com/url?sa=E&source=gmail&q=https://github.com/AbdullahTariq096/PeacePulse-Backend/stargazers)
[![GitHub license](about:sanitized)](https://www.google.com/url?sa=E&source=gmail&q=https://github.com/AbdullahTariq096/PeacePulse-Backend/blob/main/LICENSE)

## Table of Contents

1.  [Introduction](https://www.google.com/url?sa=E&source=gmail&q=#introduction)
2.  [Features](https://www.google.com/url?sa=E&source=gmail&q=#features)
3.  [API Endpoints](https://www.google.com/url?sa=E&source=gmail&q=#api-endpoints)
      * [User Authentication](https://www.google.com/url?sa=E&source=gmail&q=#user-authentication)
      * [Prayer Tracking](https://www.google.com/url?sa=E&source=gmail&q=#prayer-tracking)
      * [Dashboard](https://www.google.com/url?sa=E&source=gmail&q=#dashboard)
4.  [Database Schema](https://www.google.com/url?sa=E&source=gmail&q=#database-schema)
      * [User](https://www.google.com/url?sa=E&source=gmail&q=#user)
      * [Prayer](https://www.google.com/url?sa=E&source=gmail&q=#prayer)
      * [Dashboard](https://www.google.com/url?sa=E&source=gmail&q=#dashboard)
5.  [Project Structure](https://www.google.com/url?sa=E&source=gmail&q=#project-structure)
6.  [Getting Started](https://www.google.com/url?sa=E&source=gmail&q=#getting-started)
      * [Prerequisites](https://www.google.com/url?sa=E&source=gmail&q=#prerequisites)
      * [Installation](https://www.google.com/url?sa=E&source=gmail&q=#installation)
7.  [Contributing](https://www.google.com/url?sa=E&source=gmail&q=#contributing)
8.  [License](https://www.google.com/url?sa=E&source=gmail&q=#license)
9.  [Contact](https://www.google.com/url?sa=E&source=gmail&q=#contact)

## Introduction

Peace Pulse is a prayer tracking application designed to help users maintain their daily prayer routine and connect with their spirituality. This repository contains the backend code for the Peace Pulse application, built using ASP.NET Core Web API and a PostgreSQL database.

## Features

  * **User Authentication:** Secure user registration and login with password hashing.
  * **Prayer Tracking:** Track daily prayers, mark them as completed or missed, and view prayer history.
  * **Dashboard:** Visualize prayer progress and statistics to stay motivated.
  * **Cross-Platform Support:** Accessible from any device with internet connectivity.

## API Endpoints

### User Authentication

| Endpoint                                      | Method | Description                   |
| :-------------------------------------------- | :----- | :---------------------------- |
| `/user/signup`                                | POST   | Register a new user           |
| `/user/login`                                 | POST   | Login an existing user        |
| `/user/GetUsers`                              | GET    | Retrieve all users            |
| `/user/userById/{id:int}`                    | GET    | Retrieve user by ID           |
| `/user/confirm-email/{userId:int}/{token}` | GET    | Confirm user's email address |

### Prayer Tracking

| Endpoint                        | Method | Description                                  |
| :------------------------------ | :----- | :------------------------------------------- |
| `/prayer/PrayerSetStatus`       | POST   | Set the status of a prayer (Completed/Missed) |
| `/prayer/Getprayers`            | GET    | Retrieve all prayers                         |
| `/prayer/GetBydate/{date}`     | GET    | Retrieve prayers by date                     |
| `/prayer/GetByUser/{userId:int}` | GET    | Retrieve prayers by user ID                  |

### Dashboard

| Endpoint                             | Method | Description                               |
| :----------------------------------- | :----- | :---------------------------------------- |
| `/dashboard/GetDashboardData`       | GET    | Retrieve dashboard data for all users     |
| `/dashboard/GetById/{userId:int}`   | GET    | Retrieve dashboard data by user ID        |
| `/dashboard/resetData/{id:int}` | POST   | Reset dashboard data for user by ID       |

## Database Schema

The database schema consists of three main tables:

### User

| Column          | Data Type | Description                     |
| :--------------- | :-------- | :------------------------------ |
| UserId           | int       | Primary key, user identifier    |
| FirstName        | string    | User's first name              |
| LastName         | string    | User's last name               |
| Email            | string    | User's email address            |
| Password         | string    | Hashed user password           |
| EmailConfirmed  | boolean    | Indicates if email is confirmed |
| Createdt         | datetime  | User registration timestamp     |
| Prayers         | list      | List of prayers for the user   |
| Dashboard       | Dashboard | Dashboard for the user         |

### Prayer

| Column      | Data Type | Description                         |
| :----------- | :-------- | :---------------------------------- |
| PrayerID    | int       | Primary key, prayer identifier      |
| DashboardId | int       | Foreign key, dashboard identifier   |
| UserId      | int       | Foreign key, user identifier        |
| PrayerName  | string    | Name of the prayer                 |
| Date        | dateonly  | Date of the prayer                  |
| DateTime    | datetime  | Time of the prayer                  |
| Status      | string    | Prayer status (Completed/Missed) |
| CreatedAt   | datetime  | Prayer creation timestamp           |
| User        | User      | User associated with the prayer    |
| Dashboard   | Dashboard | Dashboard associated with the prayer |

### Dashboard

| Column         | Data Type | Description                                     |
| :-------------- | :-------- | :---------------------------------------------- |
| DashboardId    | int       | Primary key, dashboard identifier              |
| UserId         | int       | Foreign key, user identifier                   |
| Date           | datetime  | Timestamp for dashboard data                    |
| MissedPrayer   | int       | Count of missed prayers                        |
| CompletedPrayer | int       | Count of completed prayers                      |
| TotalPrayers   | int       | Total count of completed and missed prayers     |
| UnfilledPrayer | int       | Count of prayers not marked as completed/missed |
| User           | User      | User associated with the dashboard             |
| Prayers        | list      | List of prayers associated with the dashboard  |

## Project Structure

  * **Controllers:** Contains API controllers for handling user authentication, prayer tracking, and dashboard requests.
  * **Data:** Contains data transfer objects (DTOs) for API requests and responses.
  * **Migrations:** Contains database migration files for managing database schema changes.
  * **Models:** Contains database entity models representing the application's data.

## Getting Started

### Prerequisites

  * .NET 7 SDK
  * PostgreSQL Database

### Installation

1.  Clone the repository: `git clone https://github.com/AbdullahTariq096/PeacePulse-Backend.git`
2.  Configure the database connection string in `appsettings.json`.
3.  Run database migrations: `dotnet ef database update`
4.  Build and run the application: `dotnet run`

## Contributing

Contributions are welcome\! Please feel free to submit issues and pull requests.

## License

This project is licensed under the MIT License - see the [LICENSE](https://www.google.com/url?sa=E&source=gmail&q=LICENSE) file for details.

## Contact

Abdullah Tariq - [abdullahtariq096@gmail.com](https://www.google.com/url?sa=E&source=gmail&q=mailto:abdullahtariq096@gmail.com)

**Project Link:** [https://github.com/AbdullahTariq096/PeacePulse-Backend](https://www.google.com/url?sa=E&source=gmail&q=https://github.com/AbdullahTariq096/PeacePulse-Backend)
