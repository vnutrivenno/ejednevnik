using System;
using System.Collections.Generic;

public class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime Deadline { get; set; }

    public Note(string title, string description, DateTime date, DateTime deadline)
    {
        Title = title;
        Description = description;
        Date = date;
        Deadline = deadline;
    }
}

public class DailyPlanner
{
    private List<Note> notes;
    private int currentNoteIndex;
    private DateTime currentDate;

    public DailyPlanner()
    {
        notes = new List<Note>
        {
            new Note("Заметка 1", "Надо сделать торты", new DateTime(2023, 10, 6), new DateTime(2023, 10, 8)),
            new Note("Заметка 2", "купить подписку в доте", new DateTime(2023, 10, 8), new DateTime(2023, 10, 10)),
            new Note("Заметка 3", "сходить на пары, new DateTime(2023, 10, 13), new DateTime(2023, 10, 15))
        };

        currentNoteIndex = 0;
        currentDate = DateTime.Now;
    }

    public void Run()
    {
        Console.WriteLine("Добро пожаловать в ежедневник!");

        while (true)
        {
            Console.Clear();
            ShowNoteTitle();

            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    ShowPreviousDate();
                    break;
                case ConsoleKey.RightArrow:
                    ShowNextDate();
                    break;
                case ConsoleKey.Enter:
                    ShowNoteDetails();
                    break;
                case ConsoleKey.Escape:
                    return;
            }
        }
    }

    private void ShowNoteTitle()
    {
        Console.WriteLine("Ежедневник");
        Console.WriteLine("Нажмите Enter для полной информации, стрелки влево/вправо для переключения дат, Escape для выхода.");
        Console.WriteLine($"Дата: {currentDate:yyyy-MM-dd}");
        Console.WriteLine($"Заметка {currentNoteIndex + 1}: {notes[currentNoteIndex].Title}");
    }

    private void ShowNoteDetails()
    {
        Console.Clear();
        Console.WriteLine("Подробная информация о заметке:");
        Console.WriteLine($"Название: {notes[currentNoteIndex].Title}");
        Console.WriteLine($"Описание: {notes[currentNoteIndex].Description}");
        Console.WriteLine($"Дата: {notes[currentNoteIndex].Date:yyyy-MM-dd}");
        Console.WriteLine($"Дедлайн: {notes[currentNoteIndex].Deadline:yyyy-MM-dd}");
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey(true);
    }

    private void ShowNextDate()
    {
        currentDate = currentDate.AddDays(1);
        currentNoteIndex = 0;
    }

    private void ShowPreviousDate()
    {
        currentDate = currentDate.AddDays(-1);
        currentNoteIndex = 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        DailyPlanner planner = new DailyPlanner();
        planner.Run();
    }
}
