namespace SnakeFinal;

public static class Utils
{
    public static Pixel GetRandomPixel(int screenWidth, int screenHeight, Random random)
    {
        return new Pixel
        {
            X = random.Next(0, screenWidth),
            Y = random.Next(0, screenHeight)
        };
    }
    
    public static void SetupConsole()
    {
        if (IsRunningOnWindows())
        {
            Console.WindowHeight = 16;
            Console.WindowWidth = 32;   
        }
    }
    
    private static bool IsRunningOnWindows()
    {
        return Environment.OSVersion.Platform == PlatformID.Win32NT ||
               Environment.OSVersion.Platform == PlatformID.Win32S ||
               Environment.OSVersion.Platform == PlatformID.Win32Windows ||
               Environment.OSVersion.Platform == PlatformID.WinCE;
    }
}