using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverWheat : GoapAction
{
    bool completed = false;
    float startTime = 0;
    public float workDuration = 2; // secs
    public Inventory windmill;

    public DeliverWheat()
    {
        // It dsnt have an A Precondition , we can have actions and effects without precondition.
        addPrecondition("hasWheat", true);
        addEffect("doJob", true);
        name = "DeliverWheat";
    }

    public override void reset()
    {
        completed = false;
        startTime = 0;
    }

    public override bool isDone()
    {
        return completed;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
        return true;
    }

    public override bool perform(GameObject agent)
    {
        if (startTime == 0)
        {
            Debug.Log("Starting: " + name);
            startTime = Time.time;
        }

        if (Time.time - startTime > workDuration)
        {
            windmill.flourLevel += 10;
            Debug.Log("Finished: " + name);
            completed = true;
        }
        return true;
    }
}
