using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int startBallAmount = 3;
    int currentBallAmount;
    int activeBallsOnPlayfield;

    public GameObject ballPrefab;
    public Transform spawnPoint;
    public Transform multiSpawnPoint;

    public TargetSet targetSet1;

    bool gameStarted;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ResetGame();
    }

    void ResetGame()
    {
        currentBallAmount = startBallAmount;
        UIManager.instance.UpdateBallText(currentBallAmount);

        CreateNewBall();
    }

    public void CreateNewBall()
    {
        if (activeBallsOnPlayfield == 0)
        {
            Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
            targetSet1.ResetAllTargets();
            UpdateBallsOnPlayfield(+1);
            currentBallAmount--;
            UIManager.instance.UpdateBallText(currentBallAmount);
        }
    }

    public void StartMultiBall()
    {
        StartCoroutine(Multiball());
    }

    public void UpdateBallsOnPlayfield(int amount)
    {
        activeBallsOnPlayfield += amount;
    }

    IEnumerator Multiball()
    {
        int amount = 3;
        while(amount > 0)
        {
            Instantiate(ballPrefab, multiSpawnPoint.position, Quaternion.identity);
            UpdateBallsOnPlayfield(+1);
            amount--;
            yield return new WaitForSeconds(1f);
        }
    }
}
