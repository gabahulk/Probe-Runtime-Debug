using System.Globalization;
using Probe.Runtime.Core;
using Probe.Runtime.Core.Variables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Probe.Runtime.Unity
{
    /// <summary>
    /// Ultra-simple OnGUI variable tweaker.
    /// Intended for demo/proof-of-life, not production UI.
    /// </summary>
    public sealed class DebugVariableTweaker : MonoBehaviour
    {
        [SerializeField] private Key toggleKey = Key.Tab;

        [Header("UI")]
        [SerializeField] private bool visible = true;
        [SerializeField] private float floatStep = 0.5f;

        private Vector2 _scroll;
        public  ProbeContext ProbeContext { private get; set; }

        void Awake()
        {
            // Ensure consistent float formatting (e.g. dot as decimal separator).
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        }

        void Update()
        {
            if (Keyboard.current == null) return;
            if (Keyboard.current[toggleKey].wasPressedThisFrame) 
                visible = !visible;

        }

        void OnGUI()
        {
            if (!visible) return;
            if (ProbeContext == null || ProbeContext.Registry == null)
            {
                GUILayout.BeginArea(new Rect(10, 10, 520, 80), GUI.skin.box);
                GUILayout.Label("ProbeContext/Registry not assigned.");
                GUILayout.EndArea();
                return;
            }

            var registry = ProbeContext.Registry;

            GUILayout.BeginArea(new Rect(10, 10, 520, Screen.height - 20), GUI.skin.box);

            GUILayout.Label("Probe, Debug Variable Tweaker (OnGUI)");
            GUILayout.Label($"Toggle: {toggleKey}");

            _scroll = GUILayout.BeginScrollView(_scroll);

            DrawFloats(registry);
            GUILayout.Space(8);
            DrawBools(registry);

            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }

        private void DrawFloats(VariableRegistry registry)
        {
            // Assumes: registry.Floats.All returns IEnumerable<TypedRegistry<float>.Entry>
            GUILayout.Label("Floats");

            foreach (var entry in registry.Floats.All)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(entry.Name, GUILayout.Width(240));

                float current = entry.Get();
                GUILayout.Label(current.ToString("0.###", CultureInfo.InvariantCulture), GUILayout.Width(80));

                if (GUILayout.Button("-", GUILayout.Width(35)))
                    entry.Set(current - floatStep);

                if (GUILayout.Button("+", GUILayout.Width(35)))
                    entry.Set(current + floatStep);

                GUILayout.EndHorizontal();
            }

            if (IsEmpty(registry.Floats.All))
                GUILayout.Label("(none)");
        }

        private void DrawBools(VariableRegistry registry)
        {
            // Assumes: registry.Bools.All returns IEnumerable<TypedRegistry<bool>.Entry>
            GUILayout.Label("Bools");

            foreach (var entry in registry.Bools.All)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(entry.Name, GUILayout.Width(240));

                bool current = entry.Get();
                bool next = GUILayout.Toggle(current, current ? "ON" : "OFF", GUILayout.Width(80));
                if (next != current)
                    entry.Set(next);

                GUILayout.EndHorizontal();
            }

            if (IsEmpty(registry.Bools.All))
                GUILayout.Label("(none)");
        }

        private static bool IsEmpty<T>(System.Collections.Generic.IEnumerable<T> enumerable)
        {
            foreach (var _ in enumerable) return false;
            return true;
        }
    }
}
