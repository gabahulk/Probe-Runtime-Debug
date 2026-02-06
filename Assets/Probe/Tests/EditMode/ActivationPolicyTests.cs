using System.Collections;
using NUnit.Framework;
using Probe.Runtime.Core;
using Probe.Runtime.Unity;
using UnityEngine;
using UnityEngine.TestTools;

namespace Probe.Tests.EditMode
{
    public class ActivationPolicyTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CheckPolicyReturnsTrueWhenOnDebugBuildAndIsEnabled()
        {
            var config = ScriptableObject.CreateInstance<ProbeConfig>();
            config.isEnabled = true;
            config.developmentBuildOnly = true;
            var policy = new ActivationPolicy(config, BuildTypes.Debug);

            var result = policy.Evaluate();
            
            Assert.IsTrue(result);
        }
        
        [Test]
        public void CheckPolicyReturnsFalseWhenOnReleaseBuildAndIsEnabledAndIsDevBuildOnlyIsTrue()
        {
            var config = ScriptableObject.CreateInstance<ProbeConfig>();
            config.isEnabled = true;
            config.developmentBuildOnly = true;
            var policy = new ActivationPolicy(config, BuildTypes.Release);

            var result = policy.Evaluate();
            
            Assert.IsFalse(result);
        }
        
        [Test]
        public void CheckPolicyReturnsFalseWhenIsEnabledIsFalseAndBuildIsDebug()
        {
            var config = ScriptableObject.CreateInstance<ProbeConfig>();
            config.isEnabled = false;
            config.developmentBuildOnly = true;
            
            var policy = new ActivationPolicy(config, BuildTypes.Debug);

            var result = policy.Evaluate();
            
            Assert.IsFalse(result);
        }
        
        [Test]
        public void CheckPolicyReturnsFalseWhenIsEnabledIsFalseAndBuildIsRelease()
        {
            var config = ScriptableObject.CreateInstance<ProbeConfig>();
            config.isEnabled = false;
            config.developmentBuildOnly = true;
            var policy = new ActivationPolicy(config, BuildTypes.Release);

            var result = policy.Evaluate();
            
            Assert.IsFalse(result);
        }
        
        [Test]
        public void CheckPolicyReturnsTrueWhenOnReleaseBuildAndIsEnabledAndIsDevBuildOnlyIsFalse()
        {
            var config = ScriptableObject.CreateInstance<ProbeConfig>();
            config.isEnabled = true;
            config.developmentBuildOnly = false;
            var policy = new ActivationPolicy(config, BuildTypes.Release);

            var result = policy.Evaluate();
            
            Assert.IsTrue(result);
        }
    }
}
