﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Spectre.Console;

namespace RedirectClientCalls
{
    class Program
    {
        static async Task Main(string[] args)
        {
            OutputRule("Executing rest calls to different API endpoints!");

            var baseUrl = Environment.GetEnvironmentVariable("BaseURL") ?? "https://localhost:5005";

            AnsiConsole.Render(new Markup($"Url is set to [bold blue]{baseUrl}[/]"));
            AnsiConsole.WriteLine();

            await CallHttpApi("Calling [bold red]system[/] health to see, if API is up and running", baseUrl, "health");
            await CallHttpApi("Calling [bold red]api[/] health to see, if API is up and running", baseUrl,
                "demo/amialive");
            await CallHttpApi("Calling [bold red]json api[/] to see, if API return json", baseUrl, "demo/givemejson");

            await CallHttpApi("Calling [bold red]api with parameter[/] to check, if it works", baseUrl,
                "demo/withparam/john");
            //call parameter and add ASCI characters in
            await CallHttpApi("Calling [bold red]api with HTML encoded parameter[/] to check, if it works", baseUrl,
                "demo/withparam/john%2Fd");

            var productionBaseUrl = Environment.GetEnvironmentVariable("ProdURL");

            if (!string.IsNullOrEmpty(productionBaseUrl))
            {
                AnsiConsole.Render(new Markup($"Prodution URL is set to [bold blue]{productionBaseUrl}[/]"));
                AnsiConsole.WriteLine();

                await CallHttpApi("Calling production [bold red]api[/] health to see, if API is up and running",
                    productionBaseUrl, "live/amialive"); 
                
                await CallHttpApi("Calling [bold red]api with HTML encoded parameter[/] to check, if it works", baseUrl,
                    "live/withparam/john%2Fd");
            }

            OutputRule("Finished with calls");
        }

        private static async Task CallHttpApi(string message, string baseUrl, string endpoint)
        {
            AnsiConsole.Render(new Markup(message));
            AnsiConsole.WriteLine();

            using var client = new HttpClient {BaseAddress = new Uri(baseUrl, UriKind.Absolute)};
            try
            {
                var result = await client.GetAsync(endpoint);
                AnsiConsole.WriteLine($"Calling {baseUrl + endpoint} address");
                result.EnsureSuccessStatusCode();

                var data = await result.Content.ReadAsStringAsync();
                AnsiConsole.WriteLine(data);
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }

            AnsiConsole.WriteLine();
        }

        private static void OutputRule(string message)
        {
            AnsiConsole.WriteLine();
            var rule = new Rule(message);
            AnsiConsole.Render(rule);
            AnsiConsole.WriteLine();
        }
    }
}