using System;
using System.Collections.Generic;

namespace Probe.Runtime.Core.Variables
{
    public sealed class TypedRegistry<T>
    {
        public sealed class Entry
        {
            public string Name { get; }
            private readonly Func<T> _get;
            private readonly Action<T> _set;

            public Entry(string name, Func<T> get, Action<T> set)
            {
                Name = name;
                _get = get;
                _set = set;
            }

            public T Get() => _get();
            public void Set(T value) => _set(value);
        }
        
        private readonly Dictionary<string, Entry> _entries = new();
        
        public bool Register(string name, Func<T> get, Action<T> set)
        {
            if (_entries.ContainsKey(name)) return false;
            _entries[name] = new Entry(name, get, set);
            return true;
        }

        public bool TryGet(string name, out Entry entry) => _entries.TryGetValue(name, out entry);

        public IEnumerable<Entry> All => _entries.Values;
    }
}