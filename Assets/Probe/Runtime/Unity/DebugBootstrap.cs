using Probe.Runtime.Core;
using Probe.Runtime.Core.Variables;
using UnityEngine;

namespace Probe.Runtime.Unity
{
    public class DebugBootstrap : MonoBehaviour
    {
        public GameObject probeParentObject;
        public ProbeConfig probeConfig;
        private ProbeContext _context;
        private void Awake()
        {
            if (ShouldShowOverlay())
            {
                SetupProbe();
                return;
            }
            
            Destroy(probeParentObject);
        }


        private void SetupProbe()
        {
            _context = new ProbeContext(new ActivationPolicy(probeConfig, GetBuildType()),new VariableRegistry());
        }

        private BuildTypes GetBuildType()
        {
            return Debug.isDebugBuild ? BuildTypes.Debug : BuildTypes.Release;
        }

        private bool ShouldShowOverlay()
        {
            return _context.ActivationPolicy.Evaluate();
        }
    }
}
