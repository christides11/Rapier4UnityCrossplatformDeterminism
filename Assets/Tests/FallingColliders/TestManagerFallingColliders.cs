using System;
using System.Collections.Generic;
using RapierPhysics;
using TMPro;
using UnityEngine;

public class TestManagerFallingColliders : TestManagerBase
{
    public TextMeshProUGUI startHashcode;
    public TextMeshProUGUI endHashcode;

    public RapierBody bodyPrefab;

    List<RapierBody> spawnedBodies = new List<RapierBody>();
    public List<RapierBody> sceneColliders = new List<RapierBody>();

    public int ticksToTest = 120;
    public Vector3 spawnPosition = new Vector3(0, 10, 0);

    public ulong startHash;
    public ulong endHash;
    
    public void Awake()
    {
        Physics.simulationMode = SimulationMode.Script;
    }

    public void TestDebug()
    {
        Debug.Log("?");
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
            Debug.Log($"Start: {startHash.ToString()}");
            startHashcode.text = startHash.ToString();
            
            while (cnt < ticksToTest)
            {
                await Awaitable.FixedUpdateAsync();
                RapierLoop.Tick();
                //GenerateHashCode();
                cnt++;
                var go = GameObject.Instantiate(bodyPrefab, spawnPosition, Quaternion.identity);
                go.RegisterBody();
                spawnedBodies.Add(go);
            }

            endHash = RapierDebug.GetPhysicsWorldHash();
            Debug.Log($"Final: {endHash.ToString()}");
            endHashcode.text = endHash.ToString();
            cnt = 0;
            
        }
        catch (Exception e)
        {
            Debug.LogError("Exception during test.");
            Debug.LogException(e);
        }
    }

    /*
    void GenerateHashCode()
    {
        int hc = 0;
        for (var index = 0; index < sceneColliders.Count; index++)
        {
            var body = sceneColliders[index];
            var gotHashcode = GetRigidbodyHashCode(body.body);
            hc = GetNonRandomHashcode(hc, gotHashcode);
        }

        for (var index = 0; index < spawnedBodies.Count; index++)
        {
            var spawnedBody = spawnedBodies[index];
            var gotHashcode = GetRigidbodyHashCode(spawnedBody.body);
            hc = GetNonRandomHashcode(hc, gotHashcode);
        }
        
        //hashCodes.Add(hc);
    }

    int GetRigidbodyHashCode(Rigidbody rb)
    {
        return GetNonRandomHashcode(rb.position.GetHashCode(), rb.rotation.GetHashCode());
    }

    int GetNonRandomHashcode(int a, int b)
    {
        int hc = 23;
        hc = (hc * 37) + a;
        hc = (hc * 37) + b;
        return hc;
    }*/
}
