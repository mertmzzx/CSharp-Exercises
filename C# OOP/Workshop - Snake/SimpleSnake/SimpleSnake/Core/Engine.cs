namespace SimpleSnake.Core
{
    using GameObjects;
    using Enums;
    using System;
    using System.Threading;

    public class Engine : IEngine
    {
        private readonly Point[] pointsOfDirection;
        private readonly Snake snake;
        private readonly Field field;

        private Direction direction;
        private double sleepTime;

        private Engine()
        {
            this.sleepTime = 100;
            this.pointsOfDirection = new Point[4];
        }

        public Engine(Field field, Snake snake)
            : this()
        {
            this.field = field;
            this.snake = snake;
        }

        public void Run()
        {
            this.InitializeDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                bool canMove = this.snake.CanMove(this.pointsOfDirection[(int)this.direction]);
                if (!canMove)
                {
                    this.AskUserForRestart();
                }

                this.sleepTime -= 0.01;
                Thread.Sleep((int)this.sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int leftX = this.field.LeftX + 1; //Right to the field
            int topY = 3; //3 from the top

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");

            string input = Console.ReadLine();
            if (input == "yes")
            {
                Console.Clear();
                StartUp.Main(); //Restart the program
            }
            else
            {
                this.StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game Over!");
            Environment.Exit(0);
        }

        private void InitializeDirections()
        {
            //The indexing is not random!
            //The indexing is following the Direction Enum
            this.pointsOfDirection[0] = new Point(1, 0);
            this.pointsOfDirection[1] = new Point(-1, 0);
            this.pointsOfDirection[2] = new Point(0, 1);
            this.pointsOfDirection[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }
    }
}
