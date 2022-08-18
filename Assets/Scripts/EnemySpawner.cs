using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float timer = 2;
    public GameObject asteriodPrefab;

    private bool TimerFinished()
    {
        timer-=Time.deltaTime;
        if(timer<= 0)
        {
            timer = 2;
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerFinished() && GameManager.instance.gameOver == GameStates.Ingame) 
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-14,14), 15, 0);
            Instantiate(asteriodPrefab, spawnPosition, asteriodPrefab.transform.rotation);
        }
    }
}
