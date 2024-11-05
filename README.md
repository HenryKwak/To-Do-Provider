# ToDo Provider Application
This project is a full-stack web application for managing to-do tasks. It allows users to add, edit, delete, and search tasks using different data providers. The application is built using modern web technologies for both the frontend and backend.
# Features
Add, edit, and delete tasks
Search tasks with debounce functionality
Switch between different data providers (Database and InMemory)
# Technologies Used
- Frontend
1. Vue.js: A progressive JavaScript framework used for building the user interface. The application uses Vue components to manage tasks dynamically.
2. BootstrapVue: Provides Bootstrap components for Vue.js, used for styling and layout.
3. Axios: A promise-based HTTP client for making requests to the backend API.
- Backend
1. ASP.NET Core: A cross-platform framework for building web applications. It serves as the backend for handling API requests.
2. Entity Framework Core: An ORM (Object-Relational Mapper) used for database operations with the Database provider.
3. SQLite: A lightweight, file-based database used for storing tasks when using the Database provider.
# Project Structure
- Frontend: The frontend code is located in the wwwroot/js directory, with the main application logic in app.js.
- Backend: The backend code is organized in the Controllers and Repository directories. The ToDoController handles API requests, and the Repository contains implementations for different data providers.
