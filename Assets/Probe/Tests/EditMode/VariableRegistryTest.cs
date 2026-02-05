using System;
using System.Collections;
using NUnit.Framework;
using Probe.Runtime.Core;
using Probe.Runtime.Core.Variables;
using UnityEngine;
using UnityEngine.TestTools;

public class VariableRegistryTest
{
    //TODO: 
    // * Test registering a variable with wrong type (float in an int)
    // * Test Accessing a variable that doesn't exist
    [Test]
    public void RegisterFloatRegistersFloatVariableWithCorrectName()
    {
      var variable = 1.5f;
      Func<float> variable_getter = () => variable;
      Action<float> variable_setter = (float f) => { variable = f; };
      var registry = new VariableRegistry();
      
      registry.RegisterFloat("test_variable", variable_getter, variable_setter);
      registry.Floats.TryGet("test_variable", out var result);
      
      Assert.AreEqual(variable,result.Get());
    }
    
    [Test]
    public void RegisterFloatRegisteredVariableCanBeChangedBySetter()
    {
        var variable = 1.5f;
        Func<float> variable_getter = () => variable;
        Action<float> variable_setter = (float f) => { variable = f; };
        var registry = new VariableRegistry();
        registry.RegisterFloat("test_variable", variable_getter, variable_setter);
        registry.Floats.TryGet("test_variable", out var result);
        
        result.Set(2);
        
        Assert.AreEqual(variable,result.Get());
    }
    
    [Test]
    public void RegisterIntRegistersFloatVariableWithCorrectName()
    {
        var variable = 1;
        Func<int> variable_getter = () => variable;
        Action<int> variable_setter = (int i) => { variable = i; };
        var registry = new VariableRegistry();
      
        registry.RegisterInt("test_variable", variable_getter, variable_setter);
        registry.Ints.TryGet("test_variable", out var result);
      
        Assert.AreEqual(variable,result.Get());
    }
    
    [Test]
    public void RegisterIntRegisteredVariableCanBeChangedBySetter()
    {
        var variable = 1;
        Func<int> variable_getter = () => variable;
        Action<int> variable_setter = (int i) => { variable = i; };
        var registry = new VariableRegistry();
        registry.RegisterInt("test_variable", variable_getter, variable_setter);
        registry.Ints.TryGet("test_variable", out var result);
        
        result.Set(2);
        
        Assert.AreEqual(variable,result.Get());
    }
    
    [Test]
    public void RegisterBoolRegistersFloatVariableWithCorrectName()
    {
        var variable = true;
        Func<bool> variable_getter = () => variable;
        Action<bool> variable_setter = (bool b) => { variable = b; };
        var registry = new VariableRegistry();
      
        registry.RegisterBool("test_variable", variable_getter, variable_setter);
        registry.Bools.TryGet("test_variable", out var result);
      
        Assert.AreEqual(variable,result.Get());
    }
    
    [Test]
    public void RegisterBoolRegisteredVariableCanBeChangedBySetter()
    {
        var variable = true;
        Func<bool> variable_getter = () => variable;
        Action<bool> variable_setter = (bool b) => { variable = b; };
        var registry = new VariableRegistry();
        registry.RegisterBool("test_variable", variable_getter, variable_setter);
        registry.Bools.TryGet("test_variable", out var result);
        
        result.Set(false);
        
        Assert.AreEqual(variable,result.Get());
    }
    
    [Test]
    public void RegisterWrongType()
    {
        Assert.Ignore("TBD");
    }
    
    
    [Test]
    public void AccessVariableWithWrongName()
    {
        Assert.Ignore("TBD");
    }
}
