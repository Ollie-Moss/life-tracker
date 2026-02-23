using BusinessLayer;
using Models;
using System.Reflection;

namespace TestProgram
{

    public class ConsoleApplication : IConsoleApplication
    {
        private readonly IService<Note> _noteService;

        public ConsoleApplication(IService<Note> noteService)
        {
            _noteService = noteService;
        }

        public void Run()
        {
            _noteService.Add(new Note() { Title = "was goody in the hoody", Content = "Hello World" });

            foreach (var note in _noteService.List())
            {
                Console.WriteLine($"------- {note.Title} -------");
                foreach (var property in note.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (property.Name == "Name") continue;
                    var value = property.GetValue(note);
                    Console.WriteLine($"{property.Name}: {value}");
                }
            }

            Console.ReadKey();
        }
    }
}
