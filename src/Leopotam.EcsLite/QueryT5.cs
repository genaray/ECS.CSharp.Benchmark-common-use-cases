﻿using BenchmarkDotNet.Attributes;

namespace Leopotam.EcsLite;

[ShortRunJob]
public class QueryT5
{
    private EcsWorld    world;
    private EcsFilter   filter;
    EcsPool<Component1> c1;
    EcsPool<Component2> c2;
    EcsPool<Component3> c3;
    EcsPool<Component4> c4;
    EcsPool<Component5> c5;
    
    [GlobalSetup]
    public void Setup() {
        world = new EcsWorld();
        world.CreateEntities(Constant.EntityCount).AddComponents(world);
        c1      = world.GetPool<Component1>();
        c2      = world.GetPool<Component2>();
        c3      = world.GetPool<Component3>();
        c4      = world.GetPool<Component4>();
        c5      = world.GetPool<Component5>();
        filter  = world.Filter<Component1>().Inc<Component2>().Inc<Component3>().Inc<Component4>().Inc<Component5>().End();
        Assert.AreEqual(Constant.EntityCount, filter.GetEntitiesCount());
    }
    
    [GlobalCleanup]
    public void Shutdown() {
        world.Destroy();
    }
    
    [Benchmark]
    public void Run()
    {
        int[] entities = filter.GetRawEntities();
        for (int i = 0, iMax = filter.GetEntitiesCount(); i < iMax; i++) {
            c1.Get(entities[i]).value = c2.Get(entities[i]).value +
                                        c3.Get(entities[i]).value +
                                        c4.Get(entities[i]).value +
                                        c5.Get(entities[i]).value;
        }
    }
}