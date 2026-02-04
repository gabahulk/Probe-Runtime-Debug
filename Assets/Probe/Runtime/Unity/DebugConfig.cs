using UnityEngine;

namespace Runtime
{
    public class DebugConfig : ScriptableObject
    {
        public bool enabledByDefault = true;
        public bool showOverlay = true;
        public bool enableConsole = true;
        public KeyCode toggleKey = KeyCode.F1;
        public bool developmentBuildOnly = true;
    }
}
