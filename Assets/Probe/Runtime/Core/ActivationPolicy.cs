namespace Probe.Runtime.Core
{
    public class ActivationPolicy
    {
        private bool _isEnabled;
        private BuildTypes _buildType;
        private bool _isDevBuildOnly;
        public ActivationPolicy(bool isEnabled, BuildTypes buildType, bool isDevBuildOnly = true)
        {
            _isEnabled = isEnabled;
            _buildType = buildType;
            _isDevBuildOnly = isDevBuildOnly;
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
