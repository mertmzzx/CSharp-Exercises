namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private readonly Random random;

        private readonly Field field;
        private readonly ConsoleColor foodColor;

        protected Food(Field field, int foodPoints, char foodSymbol, ConsoleColor foodColor) 
            : base(field.LeftX, field.TopY)
        {
            this.random = new Random();

            this.field = field;
            this.FoodFoodPoints = foodPoints;
            this.FoodSymbol = foodSymbol;
            this.foodColor = foodColor;
        }

        public int FoodFoodPoints { get; }
        public char FoodSymbol { get;}

        public void SetRandomPosition(Queue<Point> snake)
        {
            do
            {
                this.LeftX = random.Next(2, field.LeftX - 2);
                this.TopY = random.Next(2, field.TopY - 2);

            } while (snake.Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY));

            Console.BackgroundColor = this.foodColor;
            this.Draw(this.FoodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snakeHead)
        {
            return this.LeftX == snakeHead.LeftX && this.TopY == snakeHead.TopY;
        }
    }
}
