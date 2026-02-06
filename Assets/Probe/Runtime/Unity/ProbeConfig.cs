using UnityEngine;

namespace Probe.Runtime.Unity
{
    [CreateAssetMenu(fileName = "ProbeConfig", menuName = "Probe/Config", order = 1)]
    public class ProbeConfig : ScriptableObject
    {
        public bool isEnabled = true;
        public bool showOverlay = true;
        public bool enableConsole = true;
        public KeyCode toggleKey = KeyCode.F1;
        public bool developmentBuildOnly = true;
    }
}
