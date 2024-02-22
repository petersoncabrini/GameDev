using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float GameWidth = 16f;

    [HideInInspector]
    public int Score = 0;

    [HideInInspector]
    public int Lifes = 5;

    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

}
