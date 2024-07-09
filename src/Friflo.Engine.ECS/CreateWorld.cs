﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Friflo.Engine.ECS;

[ShortRunJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
public class CreateWorld
{
    [GlobalSetup]
    public void Setup() { }
    
    [GlobalCleanup]
    public void Shutdown() {
    }
    
    [Benchmark]
    public void Run()
    {
        _ = new EntityStore();
        // nothing to Dispose() - has no unmanaged resources
    }
}