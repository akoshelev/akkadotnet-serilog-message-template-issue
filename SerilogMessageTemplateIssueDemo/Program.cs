using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Configuration;
using Serilog;

namespace SerilogMessageTemplateIssueDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .WriteTo.ColoredConsole(outputTemplate: "[{Level}][{LogSource}][Thread {Thread}] {Message}{NewLine}{Exception}")
              .CreateLogger();

            using (
                var actorSystem = ActorSystem.Create("test",
                    ConfigurationFactory.ParseString("akka {  loggers = [\"Akka.Logger.Serilog.SerilogLogger, Akka.Logger.Serilog\"] } "))) 
            {
                actorSystem.ActorOf(Props.Create(() => new SimpleActor()), "simple");
                actorSystem.Shutdown();
            }

            Console.ReadLine();
        }
    }


}
