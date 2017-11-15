using System;
using System.Linq;

namespace EasyConsole
{
    public abstract class Page
    {
        public string Title { get; set; }

        public Program Program { get; set; }

        public Page(string title, Program program)
        {
            Title = title;
            Program = program;
        }

        public virtual void Display()
        {
            var length = 3;
            if (Program.History.Count > 1 && Program.BreadcrumbHeader)
            {
                string breadcrumb = null;
                foreach (var title in Program.History.Select((page) => page.Title).Reverse())
                    breadcrumb += title + " > ";
                breadcrumb = breadcrumb.Remove(breadcrumb.Length - 3);
                length = breadcrumb.Length;
                Console.WriteLine(breadcrumb);
            }
            else
            {
                length = Title.Length;
                Console.WriteLine(Title);
            }
            Console.WriteLine(new string('-', length));
        }
    }
}
