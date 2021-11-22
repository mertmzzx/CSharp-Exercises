using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initialArticle = Console.ReadLine().Split(", ");
            Article article = new Article(initialArticle[0], initialArticle[1], initialArticle[2]);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(": ");
                string mainCmd = cmd[0];
                string argument = cmd[1];
                switch (mainCmd)
                {
                    case "Edit":
                        article.Edit(argument);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(argument);
                        break;
                    case "Rename":
                        article.Rename(argument);
                        break;
                }
            }

            Console.WriteLine(article);
        }
    }

    class Article
    {
        private string title_;
        private string content_;
        private string author_;

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Rename(string title) => Title = title;
        public void Edit(string content) => Content = content;
        public void ChangeAuthor(string author) => Author = author;
        
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
