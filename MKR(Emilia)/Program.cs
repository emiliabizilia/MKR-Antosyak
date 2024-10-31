using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class Student
{
    public string LastName { get; set; }
    public string Group { get; set; }
    public string Subject { get; set; }
    public int Score { get; set; }
}

public class Program
{
    public static void Main()
    {
        // Список студентів з даними
        List<Student> students = new List<Student>
        {
            new Student { LastName = "Маківчук", Group = "СО", Subject = "Математичний аналіз", Score = 85 },
            new Student { LastName = "Ковач", Group = "СА", Subject = "Програмування", Score = 90 },
            new Student { LastName = "Пекар", Group = "СО", Subject = "Математичний аналіз", Score = 75 },
            new Student { LastName = "Бізіля", Group = "СА", Subject = "Програмування", Score = 80 },
            new Student { LastName = "Сібулатова", Group = "СО", Subject = "Математичний аналіз", Score = 88 },
            new Student { LastName = "Дяченко", Group = "СА", Subject = "Програмування", Score = 92 }
        };

        // Групування ао студентах і розрахунок середнього балу
        var averageScores = students
            .GroupBy(s => s.LastName)
            .Select(g => new
            {
                LastName = g.Key,
                AverageScore = g.Average(s => s.Score)
            });

        // Вивід середнього балу для кожного студента
        foreach (var student in averageScores)
        {
            Console.WriteLine($"Студент: {student.LastName}, Середній бал: {student.AverageScore:F2}");
        }
        XElement xml = new XElement("Students",
            from student in students
            select new XElement("Student",
                new XElement("LastName", student.LastName),
                new XElement("Group", student.Group),
                new XElement("Subject", student.Subject),
                new XElement("Score", student.Score)
            )
        );

        xml.Save("students.xml");
        Console.WriteLine("Збережемо дані в students.xml");
    }
}

