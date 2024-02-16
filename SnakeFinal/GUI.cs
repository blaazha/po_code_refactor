namespace SnakeFinal;

        class GUI
        {
            private int screenWidth;
            private int screenHeight;

            public GUI(int screenWidth, int screenHeight)
            {
                this.screenWidth = screenWidth;
                this.screenHeight = screenHeight;
            }

            public void DrawBoundaries()
            {
                for (int i = 0; i < screenWidth; i++)
                {
                    PrintPixel(i, 0, ConsoleColor.White, "■");
                    PrintPixel(i, screenHeight - 1, ConsoleColor.White, "■");
                }

                for (int i = 0; i < screenHeight; i++)
                {
                    PrintPixel(0, i, ConsoleColor.White, "■");
                    PrintPixel(screenWidth - 1, i, ConsoleColor.White, "■");
                }
            }

            public void DrawBody(List<Pixel> body)
            {
                foreach (var pixel in body)
                {
                    PrintPixel(pixel.X, pixel.Y, ConsoleColor.White, "■");
                }
            }

            public bool CheckCollision(Snake snake)
            {
                if (snake.Head.X == screenWidth - 1 || snake.Head.X == 0 || snake.Head.Y == screenHeight - 1 || snake.Head.Y == 0)
                    return true;

                foreach (Pixel body in snake.Body)
                {
                    if (snake.Head.X == body.X && snake.Head.Y == body.Y)
                        return true;
                }

                return false;
            }

            public void PrintPixel(int x, int y, ConsoleColor color, string symbol)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = color;
                Console.Write(symbol);
            }

            public void HandleKeyPress(DirectionWrapper movement, ConsoleKeyInfo keyInfo, ref string buttonPressed)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (movement != Direction.DOWN && buttonPressed == "no")
                        {
                            movement.Value = Direction.UP;
                            buttonPressed = "yes";
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (movement != Direction.UP && buttonPressed == "no")
                        {
                            movement.Value = Direction.DOWN;
                            buttonPressed = "yes";
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (movement != Direction.RIGHT && buttonPressed == "no")
                        {
                            movement.Value = Direction.LEFT;
                            buttonPressed = "yes";
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (movement != Direction.LEFT && buttonPressed == "no")
                        {
                            movement.Value = Direction.RIGHT;
                            buttonPressed = "yes";
                        }
                        break;
                }
            }

            public void DisplayGameOverMessage(int score)
            {
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
                Console.WriteLine($"Game over, Score: {score}");
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
            }
        }