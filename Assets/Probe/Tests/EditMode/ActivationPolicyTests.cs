using System.Collections;
using NUnit.Framework;
using Probe.Runtime.Core;
using UnityEngine.TestTools;

namespace Probe.Tests.EditMode
{
    public class ActivationPolicyTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CheckPolicyReturnsTrueWhenOnDebugBuildAndIsEnabled()
        {
            var policy = new ActivationPolicy(true, BuildTypes.Debug);

            var result = policy.Evaluate();
            
            Assert.IsTrue(result);
        }
        
        [Test]
        public void CheckPolicyReturnsFalseWhenOnReleaseBuildAndIsEnabledAndIsDevBuildOnlyIsTrue()
        {
            var policy = new ActivationPolicy(true, BuildTypes.Release);

            var result = policy.Evaluate();
            
            Assert.IsFalse(result);
        }
        
        [Test]
        public void CheckPolicyReturnsFalseWhenIsEnabledIsFalseAndBuildIsDebug()
        {
            var policy = new ActivationPolicy(false, BuildTypes.Debug);

            var result = policy.Evaluate();
            
            Assert.IsFalse(result);
        }
        
        [Test]
        public void CheckPolicyReturnsFalseWhenIsEnabledIsFalseAndBuildIsRelease()
        {
            var policy = new ActivationPolicy(false, BuildTypes.Release);

            var result = policy.Evaluate();
            
            Assert.IsFalse(result);
        }
        
        [Test]
        public void CheckPolicyReturnsTrueWhenOnReleaseBuildAndIsEnabledAndIsDevBuildOnlyIsFalse()
        {
            var policy = new ActivationPolicy(true, BuildTypes.Release,false);

            var result = policy.Evaluate();
            
            Assert.IsTrue(result);
        }
    }
}
