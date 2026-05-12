// File: DebugConsole/Attributes/GenerateMethodNameAttribute.cs
// Purpose: Contains debug-console support code for City Watchdog development.

namespace DebugConsole.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class GenerateMethodNameAttribute(string value) : Attribute {
        public string Value { get; } = value;
    }

}
