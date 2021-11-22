using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mission
{
    public int missionId;
    public string description;

    [Space]
    public bool active;
    public bool permanentActive;
    public bool missionComplete;
    [Space]
    public bool restartOnNextBall;
    public bool stopOnBallEnd;
    public bool resetOnComplete;
    public bool canTriggerMultiball;
    [Space]
    public float timeToComplete;
    [Space]
    public int score;
    public int amountToComplete;
    public int currentAmount;
    [Space]
    public Lightshow lightShow;

    public void ResetMission()
    {
        if (resetOnComplete)
        {
            active = false;
            missionComplete = false;
            currentAmount = 0;

            if (lightShow != null)
            {
                lightShow.StopLightShow();
            }
        }
    }

    public void DeactivateMission()
    {
        if (permanentActive)
        {
            active = true;

            if (lightShow != null)
            {
                lightShow.StartLightShow();
            }
        }
        else
        {
            active = false;

            if (lightShow != null)
            {
                lightShow.StopLightShow();
            }
        }

        currentAmount = 0;
    }

    public void UpdateMission()
    {
        if (active && !missionComplete)
        {
            currentAmount++;

            CheckMissionComplete();
        }
    }

    void CheckMissionComplete()
    {
        if (currentAmount >= amountToComplete)
        {
            missionComplete = true;
            active = false;

            if (timeToComplete > 0)
            {
                // STOP TIMER
                MissionManager.instance.StopTimer();
            }

            if (canTriggerMultiball)
            {
                GameManager.instance.StartMultiBall();
            }

            ScoreManager.instance.AddScore(score);

            ResetMission();
        }
    }

    public bool GetMissionActive()
    {
        return active;
    }

}
