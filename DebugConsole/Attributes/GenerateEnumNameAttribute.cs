// File: DebugConsole/Attributes/GenerateEnumNameAttribute.cs
// Purpose: Contains debug-console support code for City Watchdog development.

namespace DebugConsole.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class GenerateEnumNameAttribute(string value) : Attribute {
        public string EnumName { get; } = value;
    }

}
