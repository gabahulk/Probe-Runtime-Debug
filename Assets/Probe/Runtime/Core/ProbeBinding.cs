using UnityEngine;

namespace Probe.Runtime.Core
{
    public class ProbeBinding : MonoBehaviour, IProbeBindable
    {
        public virtual void Bind(ProbeContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}