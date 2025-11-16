# 🚀 Générateur de Quiz (C# Quiz Generator)

### 🛡️ Project Status & Context

| Status | Tech Stack | Type | Context |
| :--- | :--- | :--- | :--- |
| **Complete** | C#, .NET, WinForms | Desktop Application | **ISGA Academic Project** |

[![GitHub last commit](https://img.shields.io/github/last-commit/nveyounes/Quiz-generator?style=for-the-badge&color=2ecc71)](https://github.com/nveyounes/Quiz-generator)
[![License](https://img.shields.io/github/license/nveyounes/Quiz-generator?style=for-the-badge&color=3498db)](LICENSE)
[![Repo Size](https://img.shields.io/github/repo-size/nveyounes/Quiz-generator?style=for-the-badge&color=9b59b6)](https://github.com/nveyounes/Quiz-generator)

---

## ⭐ Project Goal: Desktop Quiz Application

This repository contains a C# Windows Forms (WinForms) application designed as an academic mini-project for ISGA.

The primary objective is to demonstrate object-oriented programming (OOP) principles and GUI development in .NET by creating a simple, two-sided quiz system for teachers and students.

### 📌 Key Features
* **Role-Based Access:** A main menu that separates the application into two distinct user flows: **Teacher** and **Student**.
* **Dynamic UI Generation:** The application dynamically creates UI elements (like question labels and answer dropdowns) based on the quiz content.
* **In-Memory Data Handling:** Utilizes C# `List<T>` collections to manage quizzes and questions during a single application session.

---

## 🛠️ Technology Stack

This application was built using a classic .NET stack for desktop development.

| Category | Technology | Purpose | Icon |
| :--- | :--- | :--- | :--- |
| **Language** | C# | Primary programming language for all logic. | ![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white) |
| **Framework** | .NET | Core runtime for the application. | ![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat-square&logo=dotnet&logoColor=white) |
| **UI** | Windows Forms | Used for building the graphical user interface. | ![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D6?style=flat-square&logo=windows&logoColor=white) |
| **IDE** | Visual Studio | Development environment for building and debugging. | ![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=flat-square&logo=visualstudio&logoColor=white) |

---

## 📂 Application Workflow & Data

### 1. Data Model (In-Memory)
The application does **not** use a database. All quizzes are stored in-memory and are **lost when the app is closed**.

* **`QuizManager`:** A static class holding a `List<Quiz>` that acts as the temporary, session-only "database".
* **`Quiz`:** A class that contains a `List<Question>`.
* **`Question`:** A class holding the `QuestionText` (string), `AnswerOptions` (List), and `CorrectAnswer` (string).

### 2. 🧑‍🏫 Teacher Workflow
1.  From the main menu, the user selects **"Teacher"**.
2.  Clicks **"Create a new quiz"**.
3.  The app asks for the *number* of questions.
4.  For each question, the app uses `Microsoft.VisualBasic.Interaction.InputBox` pop-ups to ask for:
    * The question text.
    * The number of answer options.
    * Each answer option's text.
    * The correct answer's text.
5.  The new `Quiz` object is added to the `QuizManager`'s list.
6.  The **"Display all quizzes"** option shows all questions and answers in a read-only text box.

### 3. 🧑‍🎓 Student Workflow
1.  From the main menu, the user selects **"Student"**.
2.  Clicks **"Select a quiz"**.
3.  The app asks the user to enter the *quiz number* (e.g., "1" for the first quiz).
4.  A new form is dynamically generated, displaying each question `Label` and an answer `ComboBox` for all questions in the selected quiz.
5.  The student makes their selections and clicks **"Submit"**.
6.  The app calculates the score and displays it in a `MessageBox` (e.g., "Your score: 2/3").

## 🚀 Getting Started

### Prerequisites
* [.NET 5.0 (or newer) SDK](https://dotnet.microsoft.com/en-us/download)
* [Visual Studio 2019 or 2022](https://visualstudio.microsoft.com/vs/) with the ".NET desktop development" workload installed.

### Installation & Usage

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/nveyounes/Quiz-generator.git](https://github.com/nveyounes/Quiz-generator.git)
    ```
2.  **Navigate to the source code:**
    ```bash
    cd Quiz-generator/"source code"
    ```
3.  **Run the project in Visual Studio:**
    * Open **Visual Studio**.
    * Select **"Open a project or solution"**.
    * Navigate to the `"source code"` folder and open the `projet.csproj` file.
    * Press **`F5`** or click the "Start" button to build and run the application.

---

## 👥 Authors & Acknowledgements

This was an academic project for **ISGA (EDVANTIS Higher Education Group)**.

* **Younes**
* **Amine**

### Supervised By:
* **Mr. LAANAOUI**
