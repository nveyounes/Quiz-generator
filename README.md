# 🚀 Générateur de Quiz (C# Quiz Generator)

![Language](https://img.shields.io/badge/language-C%23-blue.svg)
![Framework](https://img.shields.io/badge/framework-.NET%20WinForms-purple.svg)
![Platform](https://img.shields.io/badge/platform-Windows-brightgreen.svg)

This is a **Quiz Generator** application built in C# with Windows Forms. [cite_start]It was created as a mini-project for ISGA[cite: 6]. [cite_start]The application provides a simple interface for two types of users: **Teachers** and **Students**[cite: 41, 44].

[cite_start]Teachers can create custom multiple-choice quizzes [cite: 42][cite_start], and students can select and take these quizzes to receive an immediate score[cite: 45, 47].

## 📸 Screenshots

*(This is a great place to add screenshots of your application!)*

| Main Menu | Teacher's View | Student's Quiz |
| :---: | :---: | :---: |
|  |  |  |

## ✨ Features

The application is split into two main roles:

### 🧑‍🏫 Teacher Portal
* **Create Quizzes:** Easily create a new quiz by specifying the number of questions.
* **Add Questions:** For each question, add the question text, a variable number of answer options, and designate the correct answer.
* **View All Quizzes:** Display a list of all quizzes created during the current session.

### 🧑‍🎓 Student Portal
* **Select Quiz:** Choose from the list of available quizzes (by number).
* **Take Quiz:** Answer each multiple-choice question using a simple dropdown menu.
* **Instant Score:** Receive your score immediately in a pop-up message after submitting the quiz.

## 🛠️ Tech Stack
* **Language:** C#
* **Framework:** .NET 5.0
* **UI:** Windows Forms (WinForms)
* **Data Handling:** In-memory `List<T>` (Quizzes are not persisted after the app closes).

## ⚡ Getting Started

### Prerequisites
* [.NET SDK (v5.0 or later)](https://dotnet.microsoft.com/download)
* [Visual Studio 2019/2022](https://visualstudio.microsoft.com/vs/) (Recommended for WinForms)

### Running the Application
1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/nveyounes/Quiz-generator.git](https://github.com/nveyounes/Quiz-generator.git)
    ```
2.  **Navigate to the source code directory:**
    ```bash
    cd Quiz-generator/"source code"
    ```
3.  **Open the project in Visual Studio:**
    * Open Visual Studio.
    * Select "Open a project or solution".
    * Navigate to the `"source code"` folder and open `projet.csproj`.
4.  **Run the project:**
    * Press `F5` or click the "Start" button to build and run the application.

## 📁 Project Structure

Here is a simplified overview of the project's file structure:

```
.
├── C# projet.pdf         # The academic report (in French)
├── Quiz_Generator.pptx   # Project presentation
└── source code           # Directory for all C# source files
    ├── Form1.cs          # Main form logic (Teacher/Student menus, quiz flow)
    ├── Form1.Designer.cs   # UI layout code (auto-generated)
    ├── Program.cs        # Main application entry point (launches Form1)
    ├── projet.csproj       # The C# project file
    ├── bin/                # Compiled output (binaries)
    └── obj/                # Build artifacts
```

## 👥 Authors & Acknowledgements

This project was created as part of the engineering curriculum at ISGA.

* [cite_start]**Younes Farhat** [cite: 4]
* [cite_start]**Amine Jamal Eddine** [cite: 5]

### Supervised by:
* **Mr. [cite_start]LAANAOUI** [cite: 2]

---
[cite_start]*This project was created at ISGA (EDVANTIS Higher Education Group)[cite: 6, 10, 11].*
