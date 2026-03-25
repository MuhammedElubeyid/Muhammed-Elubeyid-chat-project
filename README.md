# Muhammed-Elubeyid-chat-project
💬 ChatApp
A structured, desktop-based chat application built with C# and Windows Forms. This project demonstrates a clean implementation of the Model-View-Presenter (MVP) design pattern in a modern .NET 10.0 environment.

🚀 Overview
ChatApp is designed to be a scalable and maintainable messaging platform. By separating the user interface from the business logic, the application ensures that each component can be developed, tested, and updated independently.

🏗️ Project Structure
The project is organized into four main layers to ensure a clean Separation of Concerns:

📂 Models: Contains the data structures and core business logic. This layer defines "what" the data is (e.g., Users, Messages) without any knowledge of the UI.

📂 Views: The UI layer containing Windows Forms and Interfaces. Components here are "passive"—they only display information and capture user input.

📂 Presenters: The bridge between the Model and the View. The Presenter handles user events, retrieves data from the Model, and updates the View accordingly.

📂 Services: Dedicated to external logic such as network communication, API handling, or database management.

🛠️ Tech Stack
Language: C#

Framework: .NET 10.0 (Windows)

Architecture: Model-View-Presenter (MVP)

UI: Windows Forms (WinForms)

📥 Getting Started
