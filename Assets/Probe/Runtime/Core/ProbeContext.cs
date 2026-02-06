using Probe.Runtime.Core.Variables;

namespace Probe.Runtime.Core
{
    public class ProbeContext
    {
        public VariableRegistry Registry { get; set; }
        public ActivationPolicy ActivationPolicy { get; set; }
        public ProbeContext(ActivationPolicy activationPolicy, VariableRegistry registry)
        {
            ActivationPolicy = activationPolicy;
            Registry = registry;
        }
    }
}
