using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public GameStates gameOver=GameStates.Start;

    void Awake()
    {
        instance = this;
    }
}
