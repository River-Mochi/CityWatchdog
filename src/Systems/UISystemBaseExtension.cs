// File: src/Systems/UISystemBaseExtension.cs
// Purpose: Local UI binding helpers used by the React bridge.

namespace CityWatchdog.Systems
{
    using Colossal.UI.Binding;
    using Game.UI;
    using System;

    public abstract partial class UISystemBaseExtension : UISystemBase
    {
        public virtual string ModId { get; set; } = Mod.ModId;

        public BoolBinding AddBoolBindingAndTriggerBinding(string name, bool initialValue, Action<bool> callback)
        {
            BoolBinding boolBinding = AddBoolBinding(name, initialValue);
            AddBoolTriggerBinding(name, callback);
            return boolBinding;
        }

        public BoolBinding AddBoolBinding(string name, bool initialValue)
        {
            BoolBinding boolBinding = new BoolBinding(ModId, name, initialValue);
            AddBinding(boolBinding.ValueBinding);
            return boolBinding;
        }

        public void AddBoolTriggerBinding(string name, Action<bool> callback)
        {
            AddTriggerBinding(name, callback);
        }

        public TriggerBinding<T> AddTriggerBinding<T>(string name, Action<T> callback)
        {
            TriggerBinding<T> triggerBinding = new TriggerBinding<T>(ModId, name, callback);
            AddBinding(triggerBinding);
            return triggerBinding;
        }

        public ValueBinding<T> AddValueBinding<T>(string name, T initialValue)
        {
            ValueBinding<T> valueBinding = new ValueBinding<T>(ModId, name, initialValue);
            AddBinding(valueBinding);
            return valueBinding;
        }
    }

    public sealed class BoolBinding
    {
        public ValueBinding<bool> ValueBinding { get; }

        public Action<bool>? OnValueChanged;

        public bool Value
        {
            get => ValueBinding.value;
            set
            {
                if (value == ValueBinding.value)
                {
                    return;
                }

                Update(value);
                OnValueChanged?.Invoke(value);
            }
        }

        public BoolBinding(string group, string name, bool initialValue)
        {
            ValueBinding = new ValueBinding<bool>(group, name, initialValue);
        }

        public void Update()
        {
            Update(!ValueBinding.value);
        }

        public void Update(bool value)
        {
            ValueBinding.Update(value);
        }
    }
}
