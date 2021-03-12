using Spectre.Console;
using System;

namespace StockIt.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.Render(
    new FigletText("StockIt")
        .LeftAligned()
        .Color(Color.Red));

            var rule = new Rule("[red]Hello[/]");
            rule.Alignment = Justify.Left;
            rule.RuleStyle("red dim");

            AnsiConsole.Render(rule);

            AnsiConsole.Markup("[underline yellow]Hello[/] World!");
            Console.ReadLine();
        }
    }
}
