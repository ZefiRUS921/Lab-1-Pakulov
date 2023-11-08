using System;

/// <summary>
/// Базовый класс для хранения информации о студентах
/// </summary>
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}

/// <summary>
/// Класс для хранения информации о старосте группы
/// </summary>
class HeadStudent : Student
{
    public string Responsibilities { get; set; }
}

/// <summary>
/// Класс для хранения информации о группе студентов
/// </summary>
class Group
{
    public string Name { get; set; }
    public HeadStudent Head { get; set; }
    public Student[] Students { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Группа: {Name}");
        Console.WriteLine($"Староста группы: {Head.Name}, Обязанности: {Head.Responsibilities}");
        Console.WriteLine("Студенты:");
        foreach (var student in Students)
        {
            Console.WriteLine($"{student.Name}, Возраст: {student.Age}");
        }
    }
}

/// <summary>
/// Класс для режима отображения информации
/// </summary>
class ReadOnlyMode
{
    public void Display(Group group)
    {
        group.DisplayInfo();
    }
}

/// <summary>
/// Класс для режима редактирования информации
/// </summary>
class EditMode : ReadOnlyMode
{
    public void EditHeadResponsibilities(Group group, string responsibilities)
    {
        group.Head.Responsibilities = responsibilities;
    }
}

class Program
{
    static void Main()
    {
        Student[] students = new Student[]
        {
            new Student { Name = "Алекс", Age = 20 },
            new Student { Name = "Лена", Age = 21 },
            new Student { Name = "Иван", Age = 19 }
        };

        Group group = new Group
        {
            Name = "Группа А",
            Head = new HeadStudent { Name = "Виктор", Age = 22, Responsibilities = "Координатор группы" },
            Students = students
        };

        ReadOnlyMode readOnlyMode = new ReadOnlyMode();
        readOnlyMode.Display(group);

        EditMode editMode = new EditMode();
        editMode.EditHeadResponsibilities(group, "Староста группы");

        Console.WriteLine("После редактирования:");
        readOnlyMode.Display(group);
    }
}