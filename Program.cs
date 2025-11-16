namespace projet;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

public class QuizApp : Form
{
    private static QuizManager quizManager = new QuizManager();

    public QuizApp()
    {
        Text = "Quiz Generator";
        Size = new System.Drawing.Size(400, 220);

        TableLayoutPanel panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 4,
            Padding = new Padding(10),
            AutoSize = true
        };

        Button teacherButton = new Button
        {
            Text = "Teacher",
            Dock = DockStyle.Fill,
            Margin = new Padding(10),
            Font = new System.Drawing.Font("Arial", 15),
            BackColor = Color.LightBlue,
            Size = new Size(80, 40)
        };

        Button studentButton = new Button
        {
            Text = "Student",
            Dock = DockStyle.Fill,
            Margin = new Padding(10),
            Font = new System.Drawing.Font("Arial", 15),
            BackColor = Color.LightGreen,
            Size = new Size(80, 40)
        };

        Button exitButton = new Button
        {
            Text = "Exit",
            Dock = DockStyle.Top,
            Margin = new Padding(10),
            Font = new System.Drawing.Font("Arial", 12),
            BackColor = Color.LightCoral,
        };

        teacherButton.Click += (sender, e) => ShowTeacherMenu();
        studentButton.Click += (sender, e) => ShowStudentMenu();
        exitButton.Click += (sender, e) => Application.Exit();

        panel.Controls.Add(teacherButton);
        panel.Controls.Add(studentButton);
        panel.Controls.Add(exitButton);

        Controls.Add(panel);
    }

    private void ShowTeacherMenu()
    {
        Form teacherForm = new Form { Text = "Teacher Menu", Size = new System.Drawing.Size(338, 233) };
        TableLayoutPanel panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            Padding = new Padding(10),
            AutoSize = true
        };

        Button createQuizButton = new Button
        {
            Text = "Create a new quiz",
            Dock = DockStyle.Fill,
            Margin = new Padding(10),
            Font = new System.Drawing.Font("Arial", 15),
            BackColor = Color.LightBlue,
            Size = new Size(100, 45)
        };

        Button displayQuizzesButton = new Button
        {
            Text = "Display all quizzes",
            Dock = DockStyle.Fill,
            Margin = new Padding(10),
            Font = new System.Drawing.Font("Arial", 15),
            BackColor = Color.LightGreen,
            Size = new Size(100, 45)
        };

        Button backButton = new Button
        {
            Text = "Back",
            Dock = DockStyle.Fill,
            Margin = new Padding(10),
            Font = new System.Drawing.Font("Arial", 12),
            BackColor = Color.LightCoral,
            Size = new Size(60, 30)
        };

        createQuizButton.Click += (sender, e) => CreateQuiz();
        displayQuizzesButton.Click += (sender, e) => DisplayAllQuizzes();
        backButton.Click += (sender, e) => teacherForm.Close();

        panel.Controls.Add(createQuizButton);
        panel.Controls.Add(displayQuizzesButton);
        panel.Controls.Add(backButton);

        teacherForm.Controls.Add(panel);
        teacherForm.ShowDialog();
    }

    private void CreateQuiz()
    {
        Form createQuizForm = new Form { Text = "Create Quiz", Size = new System.Drawing.Size(300, 180) };
        TableLayoutPanel panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            Padding = new Padding(10),
            AutoSize = true
        };

        Label numQuestionsLabel = new Label { Text = "Enter the number of questions:", Dock = DockStyle.Fill, Font = new System.Drawing.Font("Arial", 12) };
        TextBox numQuestionsField = new TextBox { Dock = DockStyle.Fill, Font = new System.Drawing.Font("Arial", 12) };
        Button nextButton = new Button { Text = "Next", Dock = DockStyle.Fill, Margin = new Padding(10), Font = new System.Drawing.Font("Arial", 12), BackColor = Color.LightBlue };

        nextButton.Click += (sender, e) =>
        {
            if (int.TryParse(numQuestionsField.Text, out int numQuestions))
            {
                createQuizForm.Close();
                EnterQuestions(numQuestions);
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        };

        panel.Controls.Add(numQuestionsLabel);
        panel.Controls.Add(numQuestionsField);
        panel.Controls.Add(nextButton);

        createQuizForm.Controls.Add(panel);
        createQuizForm.ShowDialog();
    }

    private void EnterQuestions(int numQuestions)
    {
        List<Question> questions = new List<Question>();

        for (int i = 0; i < numQuestions; i++)
        {
            var question = GetQuestionFromUser(i + 1);
            if (question != null)
            {
                questions.Add(question);
            }
            else
            {
                MessageBox.Show("Question creation cancelled.");
                return;
            }
        }

        Quiz quiz = new Quiz();
        questions.ForEach(q => quiz.AddQuestion(q));
        quizManager.AddQuiz(quiz);
        MessageBox.Show("Quiz created successfully.");
    }

    private Question GetQuestionFromUser(int questionNumber)
    {
        Form questionForm = new Form { Text = $"Enter Question {questionNumber}", Size = new System.Drawing.Size(300, 210) };
        TableLayoutPanel panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 5,
            Padding = new Padding(10),
            AutoSize = true
        };

        Label questionLabel = new Label { Text = "Enter question text:", Dock = DockStyle.Fill, Font = new System.Drawing.Font("Arial", 12) };
        TextBox questionField = new TextBox { Dock = DockStyle.Fill, Font = new System.Drawing.Font("Arial", 12) };
        Label numOptionsLabel = new Label { Text = "Enter the number of options:", Dock = DockStyle.Fill, Font = new System.Drawing.Font("Arial", 12) };
        TextBox numOptionsField = new TextBox { Dock = DockStyle.Fill, Font = new System.Drawing.Font("Arial", 12) };
        Button nextButton = new Button { Text = "Next", Dock = DockStyle.Fill, Margin = new Padding(10), Font = new System.Drawing.Font("Arial", 12), BackColor = Color.LightBlue };

        List<string> options = new List<string>();
        string correctAnswer = "";

        nextButton.Click += (sender, e) =>
        {
            if (string.IsNullOrWhiteSpace(questionField.Text) || !int.TryParse(numOptionsField.Text, out int numOptions))
            {
                MessageBox.Show("Please enter valid question text and number of options.");
                return;
            }

            string questionText = questionField.Text;

            for (int j = 0; j < numOptions; j++)
            {
                string option = Microsoft.VisualBasic.Interaction.InputBox($"Enter option {j + 1}:", "Option Input", "");
                if (!string.IsNullOrWhiteSpace(option))
                {
                    options.Add(option);
                }
                else
                {
                    MessageBox.Show("Option cannot be empty.");
                    return;
                }
            }

            correctAnswer = Microsoft.VisualBasic.Interaction.InputBox("Enter the correct answer:", "Correct Answer Input", "");
            if (string.IsNullOrWhiteSpace(correctAnswer))
            {
                MessageBox.Show("Correct answer cannot be empty.");
                return;
            }

            Question question = new Question(questionText, options, correctAnswer);
            questionForm.DialogResult = DialogResult.OK;
            questionForm.Close();
        };

        panel.Controls.Add(questionLabel);
        panel.Controls.Add(questionField);
        panel.Controls.Add(numOptionsLabel);
        panel.Controls.Add(numOptionsField);
        panel.Controls.Add(nextButton);

        questionForm.Controls.Add(panel);
        var result = questionForm.ShowDialog();

        if (result == DialogResult.OK)
        {
            return new Question(questionField.Text, options, correctAnswer);
        }

        return null;
    }

    private void DisplayAllQuizzes()
    {
        List<Quiz> quizzes = quizManager.GetQuizzes();
        if (quizzes.Count == 0)
        {
            MessageBox.Show("No quizzes available.");
            return;
        }

        string allQuizzes = "";
        for (int i = 0; i < quizzes.Count; i++)
        {
            allQuizzes += "Quiz " + (i + 1) + ":\n";
            foreach (Question question in quizzes[i].Questions)
            {
                allQuizzes += question.QuestionText + "\n";
                foreach (string option in question.AnswerOptions)
                {
                    allQuizzes += " - " + option + "\n";
                }
                allQuizzes += "\n";
            }
            allQuizzes += "\n"; // Adding extra space between quizzes
        }

        TextBox textBox = new TextBox
        {
            Text = allQuizzes,
            Multiline = true,
            ReadOnly = true,
            Dock = DockStyle.Fill,
            ScrollBars = ScrollBars.Vertical,
            Font = new System.Drawing.Font("Arial", 12),
            Padding = new Padding(10)
        };

        Form displayForm = new Form { Text = "All Quizzes", Size = new System.Drawing.Size(600, 400) };
        displayForm.Controls.Add(textBox);
        displayForm.ShowDialog();
    }

    private void ShowStudentMenu()
    {
        Form studentForm = new Form { Text = "Student Menu", Size = new System.Drawing.Size(300, 180) };
        TableLayoutPanel panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2,
            Padding = new Padding(10),
            AutoSize = true
        };

        Button selectQuizButton = new Button
        {
            Text = "Select a quiz",
            Dock = DockStyle.Fill,
            Margin = new Padding(10),
            Font = new System.Drawing.Font("Arial", 15),
            BackColor = Color.LightBlue,
            Size = new Size(95, 45)
        };

        Button backButton = new Button
        {
            Text = "Back",
            Dock = DockStyle.Fill,
            Margin = new Padding(10),
            Font = new System.Drawing.Font("Arial", 12),
            BackColor = Color.LightCoral
        };

        selectQuizButton.Click += (sender, e) => SelectQuiz();
        backButton.Click += (sender, e) => studentForm.Close();

        panel.Controls.Add(selectQuizButton);
        panel.Controls.Add(backButton);

        studentForm.Controls.Add(panel);
        studentForm.ShowDialog();
    }

    private void SelectQuiz()
    {
        List<Quiz> quizzes = quizManager.GetQuizzes();
        if (quizzes.Count == 0)
        {
            MessageBox.Show("No quizzes available.");
            return;
        }

        string[] quizNames = new string[quizzes.Count];
        for (int i = 0; i < quizzes.Count; i++)
        {
            quizNames[i] = "Quiz " + (i + 1);
        }

        string selectedQuiz = Microsoft.VisualBasic.Interaction.InputBox("Select a quiz number:", "Quiz Selection", "");
        if (int.TryParse(selectedQuiz, out int quizNumber) && quizNumber > 0 && quizNumber <= quizzes.Count)
        {
            TakeQuiz(quizzes[quizNumber - 1]);
        }
        else
        {
            MessageBox.Show("Invalid quiz number. Try again.");
        }
    }

    private void TakeQuiz(Quiz quiz)
    {
        int score = 0;
        Form quizForm = new Form { Text = "Take Quiz", Size = new System.Drawing.Size(600, 400) };
        TableLayoutPanel panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = quiz.Questions.Count + 2,
            Padding = new Padding(10),
            AutoSize = true
        };

        List<ComboBox> answerBoxes = new List<ComboBox>();

        foreach (Question question in quiz.Questions)
        {
            Label questionLabel = new Label { Text = question.QuestionText, Dock = DockStyle.Fill, Font = new System.Drawing.Font("Arial", 12), Padding = new Padding(5) };
            panel.Controls.Add(questionLabel);

            ComboBox answerBox = new ComboBox { Dock = DockStyle.Fill, Font = new System.Drawing.Font("Arial", 12), DropDownStyle = ComboBoxStyle.DropDownList };
            answerBox.Items.AddRange(question.AnswerOptions.ToArray());
            panel.Controls.Add(answerBox);

            answerBoxes.Add(answerBox);
        }

        Button submitButton = new Button { Text = "Submit", Dock = DockStyle.Fill, Margin = new Padding(10), Font = new System.Drawing.Font("Arial", 12), BackColor = Color.LightBlue };
        submitButton.Click += (sender, e) =>
        {
            for (int i = 0; i < quiz.Questions.Count; i++)
            {
                if (answerBoxes[i].SelectedItem != null && answerBoxes[i].SelectedItem.ToString() == quiz.Questions[i].CorrectAnswer)
                {
                    score++;
                }
            }

            MessageBox.Show("Your score: " + score + "/" + quiz.Questions.Count);
            quizForm.Close();
        };

        panel.Controls.Add(submitButton);
        quizForm.Controls.Add(panel);
        quizForm.ShowDialog();
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new QuizApp());
    }
}

public class Question
{
    public string QuestionText { get; }
    public List<string> AnswerOptions { get; }
    public string CorrectAnswer { get; }

    public Question(string questionText, List<string> answerOptions, string correctAnswer)
    {
        QuestionText = questionText;
        AnswerOptions = answerOptions;
        CorrectAnswer = correctAnswer;
    }
}

public class Quiz
{
    public List<Question> Questions { get; } = new List<Question>();

    public void AddQuestion(Question question)
    {
        Questions.Add(question);
    }
}

public class QuizManager
{
    private List<Quiz> quizzes = new List<Quiz>();

    public void AddQuiz(Quiz quiz)
    {
        quizzes.Add(quiz);
    }

    public List<Quiz> GetQuizzes()
    {
        return quizzes;
    }
}