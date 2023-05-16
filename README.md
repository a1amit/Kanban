# Kanban Board Project

This is a Kanban board project implemented in C# using a 3-tier architecture. The project allows users to manage their tasks using a visual Kanban board interface. The GUI is designed using Material Design, and the presentation layer is implemented with the MVVM (Model-View-ViewModel) architectural pattern. The project also includes a local database using SQLite for storing and retrieving task data.

## Project Structure

The project follows a 3-tier architecture, which separates the application into three distinct layers:

1. Presentation Layer:
   - The presentation layer handles the user interface and user interactions.
   - It is implemented using the MVVM architectural pattern.
   - The GUI is designed using Material Design components and styling.
   - User actions and events trigger corresponding commands and methods in the ViewModel layer.

2. Business Layer:
   - The business layer contains the core logic and operations of the Kanban board.
   - It handles tasks such as task creation, editing, deletion, and task movement between different stages of the Kanban board.
   - The business layer interacts with the data access layer to read from and write to the local database.

3. Data Access Layer:
   - The data access layer is responsible for interacting with the local database.
   - It provides methods for storing and retrieving task data from the SQLite database.
   - The data access layer abstracts the underlying database operations, allowing the business layer to work with task objects without worrying about the database details.

## GUI and User Interaction

The project utilizes a visually appealing GUI designed with Material Design components and styling. The GUI provides an intuitive Kanban board interface, allowing users to manage their tasks efficiently. Users can perform the following actions:

- Create new tasks by specifying task details and adding them to the appropriate board stage.
- Edit existing tasks by modifying their properties such as title, description, due date, etc.
- Delete tasks that are no longer needed.
- Move tasks between different stages of the Kanban board by dragging and dropping them.
- Mark tasks as completed or update their status.

The GUI communicates with the underlying ViewModel layer, which in turn interacts with the business layer to perform the necessary operations.

## Local Database (SQLite)

The project includes a local database implemented using SQLite. SQLite is a lightweight and self-contained database engine, making it suitable for small to medium-sized applications. The local database stores task data, including task details, status, due dates, etc.

The data access layer handles the interactions with the SQLite database, providing methods for creating, updating, and retrieving task data. This allows the application to persist task information locally and retrieve it when needed.

## Getting Started

To get started with the Kanban board project:

1. Clone the repository to your local machine.
2. Open the project in your preferred C# development environment (e.g., Visual Studio).
3. Build the solution to restore dependencies.
4. Run the application to launch the Kanban board GUI.
5. Start managing your tasks using the Kanban board interface.
