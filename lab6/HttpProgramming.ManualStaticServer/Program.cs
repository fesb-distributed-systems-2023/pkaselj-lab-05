namespace HttpProgramming.ManualStaticServer;

public class Program
{
    public static async Task Main(string[] args)
    {
        var server = new ManualStaticServer(32000, @"a:\PRIBACIT\SWEDES\WWW");
        await server.Listen();
    }
}