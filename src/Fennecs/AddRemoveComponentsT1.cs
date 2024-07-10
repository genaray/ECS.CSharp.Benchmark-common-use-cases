﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using fennecs;
using Fennecs.Types;

namespace Fennecs;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class AddRemoveComponentsT1
{
    private World       world;
    private Entity[]    entities;
    
    [GlobalSetup]
    public void Setup() {
        world       = new World();
        entities    = world.CreateEntities(Constant.EntityCount);
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Dispose();
    }
    
    [Benchmark]
    public void Run()
    {
        foreach (var entity in entities) {
            entity.Add(new Component1());
            entity.Remove<Component1>();
        }
    }
}