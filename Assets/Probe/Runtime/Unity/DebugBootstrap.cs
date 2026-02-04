using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime
{
    public class DebugBootstrap : MonoBehaviour
    {
        public GameObject probeParentObject;

        private void Awake()
        {
            if (ShouldShowOverlay())
            {
                return;
            }
            
            Destroy(probeParentObject);
        }

        private bool ShouldShowOverlay()
        {
            return false;
        }
    }
}
