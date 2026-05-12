// File: DebugConsole/Program.cs
// Purpose: Contains debug-console support code for City Watchdog development.

namespace DebugConsole
{
    using DebugConsole.Notification;
    using System.Reflection;
    using CityWatchdog;
    using Game.Settings;

    internal class Program {
        public static event Func<string>? OnPrinted;

        public static void Main() {
            Console.WriteLine($"CityWatchdog.DebugConsole");
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttribute<NotificationAttribute>() != null)) {
                var instance = Activator.CreateInstance(type);
                Console.WriteLine($"Instance of {type.Name} created.");
            }

            Console.WriteLine($"Invocation count: {OnPrinted?.GetInvocationList().Length ?? 0}");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(OnPrinted?.Invoke());
            Core.GetNotificationInfo();

            CityWatchdog.Settings.Setting setting = new(new Mod());
            Console.WriteLine(setting is null);
        }
    }
}
