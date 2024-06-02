using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        List<int> grades = new List<int>();
        TextBox inputGrade;
        Button btnEnter;
        Label lblResult;

        public Form1()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            inputGrade = new TextBox { Location = new System.Drawing.Point(10, 10), Width = 100 };
            Controls.Add(inputGrade);

            btnEnter = new Button { Text = "Enter Grade", Location = new System.Drawing.Point(120, 10), Size = new System.Drawing.Size(100, 20) };
            btnEnter.Click += BtnEnter_Click;
            Controls.Add(btnEnter);

            lblResult = new Label { Location = new System.Drawing.Point(10, 40), Size = new System.Drawing.Size(200, 25) };
            Controls.Add(lblResult);
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (int.TryParse(inputGrade.Text, out int grade))
            {
                if (grade == -1)
                {
                    if (grades.Count == 0)
                    {
                        lblResult.Text = "No grades entered.";
                        return;
                    }

                    double average = grades.Average();
                    lblResult.Text = "Average Grade: " + average.ToString("N2");
                }
                else if (grade >= 0 && grade <= 10)
                {
                    grades.Add(grade);
                }
            }
            inputGrade.Clear();
        }
    }
}
