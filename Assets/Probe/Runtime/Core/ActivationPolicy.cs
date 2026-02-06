using Probe.Runtime.Unity;

namespace Probe.Runtime.Core
{
    public class ActivationPolicy
    {
        private readonly bool _isEnabled;
        private readonly BuildTypes _buildType;
        private readonly bool _isDevBuildOnly;
        public ActivationPolicy(ProbeConfig config, BuildTypes buildType)
        {
            _isEnabled = config.isEnabled;
            _buildType = buildType;
            _isDevBuildOnly = config.developmentBuildOnly;
        }

        public bool Evaluate()
        {
            if (!_isEnabled)
            {
                return false;
            }

            if (_isDevBuildOnly && _buildType == BuildTypes.Release)
            {
                return false;
            }
            
            return true;
        }
    }
}
