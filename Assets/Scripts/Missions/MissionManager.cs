using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;

    bool timeBasedMissionActive;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        foreach (var mission in missionList)
        {
            if (mission.active)
            {
                if (mission.lightShow != null)
                {
                    mission.lightShow.StartLightShow();
                }
            }
        }
    }

    public List<Mission> missionList = new List<Mission>();

    public void StartMission(int ID)
    {
        foreach (Mission mission in missionList)
        {
            if (mission.missionId == ID)
            {
                if (!mission.missionComplete && !mission.active && mission.timeToComplete > 0 && !timeBasedMissionActive)
                {
                    mission.active = true;
                    timeBasedMissionActive = true;

                    StartCoroutine(Timer(mission.timeToComplete, ID));

                    if (mission.lightShow != null)
                    {
                        mission.lightShow.StartLightShow();
                    }
                }

                else if (!mission.missionComplete && !mission.active && mission.timeToComplete <= 0)
                {
                    mission.active = true;

                    if (mission.lightShow != null)
                    {
                        mission.lightShow.StartLightShow();
                    }
                }
            }
        }
    }

    IEnumerator Timer(float t, int ID)
    {
        float tempTime = t;
        while (timeBasedMissionActive && tempTime > 0)
        {
            yield return new WaitForSeconds(1f);
            tempTime -= 1;
        }

        timeBasedMissionActive = false;
        DeactivateMission(ID);
    }

    void DeactivateMission(int ID)
    {
        missionList.Find(m => m.missionId == ID).DeactivateMission();
        if (timeBasedMissionActive)
        {
            timeBasedMissionActive = false;
        }
    }

    public void UpdateMission(int ID)
    {
        missionList.Find(m => m.missionId == ID).UpdateMission();
    }

    public void StopTimer()
    {
        timeBasedMissionActive = false;
    }

    public bool CheckIfMissionStarted(int ID)
    {
        return missionList.Find(m => m.missionId == ID).GetMissionActive();
    }

    public void ResetAllMissions()
    {
        foreach(var mission in missionList)
        {
            if (mission.active)
            {
                mission.DeactivateMission();
            }
        }

        timeBasedMissionActive = false;
    }
}
