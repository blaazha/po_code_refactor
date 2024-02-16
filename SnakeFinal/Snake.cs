namespace SnakeFinal;

class Snake
{
    public Pixel Head { get; private set; }
    public List<Pixel> Body { get; private set; }
    public DirectionWrapper Movement { get; set; }

    private int screenWidth;
    private int screenHeight;

    public Snake(int screenWidth, int screenHeight)
    {
        this.screenWidth = screenWidth;
        this.screenHeight = screenHeight;

        Head = new Pixel
        {
            X = screenWidth / 2,
            Y = screenHeight / 2,
            Color = ConsoleColor.Red
        };

        Body = new List<Pixel>();
        Movement = Direction.RIGHT;
    }

    public void Move()
    {
        Body.Add(new Pixel { X = Head.X, Y = Head.Y, Color = Head.Color });
        switch (Movement.Value)
        {
            case Direction.UP:
                Head.Y--;
                break;
            case Direction.DOWN:
                Head.Y++;
                break;
            case Direction.LEFT:
                Head.X--;
                break;
            case Direction.RIGHT:
                Head.X++;
                break;
        }
    }
}