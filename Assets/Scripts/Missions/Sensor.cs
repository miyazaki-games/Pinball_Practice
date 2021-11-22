using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public bool isStarter;
    public bool isCounter;

    public bool showGizmos;
    [Space]
    public int triggerId;

    void OnTriggerEnter(Collider col)
    {
        bool startedAlready = MissionManager.instance.CheckIfMissionStarted(triggerId);
        if (isStarter)
        {
            MissionManager.instance.StartMission(triggerId);
        }

        if (isCounter)
        {
            MissionManager.instance.UpdateMission(triggerId);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        bool startedAlready = MissionManager.instance.CheckIfMissionStarted(triggerId);
        if (isStarter)
        {
            MissionManager.instance.StartMission(triggerId);
        }

        if (isCounter)
        {
            MissionManager.instance.UpdateMission(triggerId);
        }
    }

    void OnDrawGizmos()
    {
        if (showGizmos)
        {
            Gizmos.color = new Color32(125, 175, 255, 125);
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawCube(Vector3.zero, Vector3.one);
        }
    }
}
