using System;
using RapierPhysics;
using TMPro;
using UnityEngine;

public class TestManagerSimple : TestManagerBase
{
    public TextMeshProUGUI startHashcode;
    public TextMeshProUGUI endHashcode;
    
    public int ticksToTest = 120;
    public Vector3 spawnPosition = new Vector3(0, 10, 0);

    public ulong startHash;
    public ulong endHash;
    
    public void Awake()
    {
        Physics.simulationMode = SimulationMode.Script;
    }
    
    public void StartTest()
    {
        Debug.Log("Starting Test.");
        _ = RunTest();
    }

    private int cnt = 0;
    public async Awaitable RunTest()
    {
        try
        {
            startHash = RapierDebug.GetPhysicsWorldHash();
            startHashcode.text = startHash.ToString();
            Debug.Log($"Start: {startHash.ToString()} ({cnt})");
            
            while (cnt < ticksToTest)
            {
                await Awaitable.FixedUpdateAsync();
                RapierLoop.Tick();
                cnt++;
            }

            endHash = RapierDebug.GetPhysicsWorldHash();
            endHashcode.text = endHash.ToString();
            Debug.Log($"Final: {endHash.ToString()} ({cnt})");
            cnt = 0;
            
        }
        catch (Exception e)
        {
            Debug.LogError("Exception during test.");
            Debug.LogException(e);
        }
    }
}
