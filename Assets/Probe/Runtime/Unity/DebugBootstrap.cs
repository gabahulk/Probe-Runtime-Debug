using Probe.Runtime.Core;
using Probe.Runtime.Core.Variables;
using UnityEngine;
using UnityEngine.Serialization;

namespace Probe.Runtime.Unity
{
    public class DebugBootstrap : MonoBehaviour
    {
        public GameObject probeParentObject;
        public ProbeConfig probeConfig;
        public ProbeBinding probeBind;
        public DebugVariableTweaker debugVariableTweaker;
        
        private ProbeContext _context;

        private void Awake()
        {
            SetupProbe();

            if (ShouldShowOverlay())
            {
                return;
            }
            
            Destroy(probeParentObject);
        }


        private void SetupProbe()
        {
            _context = new ProbeContext(new ActivationPolicy(probeConfig, GetBuildType()),new VariableRegistry());
            probeBind.Bind(_context);
            debugVariableTweaker.ProbeContext = _context;
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
