using System;
using System.Collections.Generic;

namespace Probe.Runtime.Core.Variables
{
    public class VariableRegistry
    {
        public TypedRegistry<float> Floats { get; } = new();
        public TypedRegistry<bool> Bools { get; } = new();
        public TypedRegistry<int> Ints { get; } = new();
        public void RegisterFloat(string name, Func<float> getter, Action<float> setter)
        {
            Floats.Register(name, getter, setter);
        }
        
        public void RegisterInt(string name, Func<int> getter, Action<int> setter)
        {
            Ints.Register(name, getter, setter);
        }
        
        public void RegisterBool(string name, Func<bool> getter, Action<bool> setter)
        {
            Bools.Register(name, getter, setter);
        }
    }
}
