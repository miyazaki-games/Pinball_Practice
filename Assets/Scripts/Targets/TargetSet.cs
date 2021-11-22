using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSet : MonoBehaviour
{
    public Target[] targets;
    bool resetCheck;

    void Start()
    {
        targets = GetComponentsInChildren<Target>();
    }

    bool CheckAllTargets()
    {
        foreach(Target t in targets)
        {
            if (t.isOut)
            {
                return false;
            }
        }

        return true;
    }

    public void ResetAllTargets()
    {
        foreach(Target t in targets)
        {
            t.Activate(true);
        }
    }

    IEnumerator ResetTargets()
    {
        if (resetCheck)
        {
            yield break;
        }

        resetCheck = true;

        yield return new WaitForSeconds(.3f);

        if (CheckAllTargets())
        {
            ResetAllTargets();
        }

        resetCheck = false;
    }

    public void CheckForReset()
    {
        StartCoroutine(ResetTargets());
    }
}
