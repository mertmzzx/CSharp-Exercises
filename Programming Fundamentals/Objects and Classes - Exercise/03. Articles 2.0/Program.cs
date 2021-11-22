using System;

namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initialArticle = Console.ReadLine().Split(", ");
            Article article = new Article(initialArticle[0], initialArticle[1], initialArticle[2]);
            int n = int.Parse(Console.ReadLine());
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
