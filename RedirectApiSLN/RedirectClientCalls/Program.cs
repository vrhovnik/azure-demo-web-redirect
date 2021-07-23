using Spectre.Console;

namespace RedirectClientCalls
{
    class Program
    {
        static void Main(string[] args)
        {
            var rule = new Rule("Executing rest calls to different API endpoints!");
            AnsiConsole.Render(rule);
            //TODO: execute different calls to REST api to demonstrate routing and works with Web API in Linux docker container and Azure FrontDoor
        }
    }
}