using SnakeFinal;

Utils.SetupConsole();

int screenWidth = Console.WindowWidth;
int screenHeight = Console.WindowHeight;

Random random = new Random();
int score = 5;
bool gameOver = false;

Snake snake = new Snake(screenWidth, screenHeight);

Pixel berry = Utils.GetRandomPixel(screenWidth, screenHeight, random);

DateTime startTime = DateTime.Now;
DateTime endTime = DateTime.Now;

GUI gui = new GUI(screenWidth, screenHeight);

while (true)
{
    Console.Clear();

    gameOver = gui.CheckCollision(snake);

    gui.DrawBoundaries();

    Console.ForegroundColor = ConsoleColor.Green;

    if (berry.X == snake.Head.X && berry.Y == snake.Head.Y)
    {
        score++;
        berry = Utils.GetRandomPixel(screenWidth, screenHeight, random);
    }

    gui.DrawBody(snake.Body);

    if (gameOver)
    {
        break;
    }

    gui.PrintPixel(snake.Head.X, snake.Head.Y, snake.Head.Color, "■");
    gui.PrintPixel(berry.X, berry.Y, ConsoleColor.Cyan, "■");

    startTime = DateTime.Now;
    string buttonPressed = "no";

    while (true)
    {
        endTime = DateTime.Now;

        if (endTime.Subtract(startTime).TotalMilliseconds > 500)
        {
            break;
        }

        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            gui.HandleKeyPress(snake.Movement, keyInfo, ref buttonPressed);
        }
    }

    snake.Move();

    if (snake.Body.Count() > score)
    {
        snake.Body.RemoveAt(0);
    }
}

gui.DisplayGameOverMessage(score);