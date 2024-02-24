using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshPro startText;
    public TextMeshPro endText;
    public TextMeshPro scoreText;

    public List<GameObject> Prefabs = new List<GameObject>();

    public float ObstacleInterval = 2f;

    public float ObstaceSpeed = 5;

    public Vector2 ObstacleOffsetY = new Vector2(1, 6);

    public float ObstacleOffsetX = 15;

    [HideInInspector]
    public int Score;

    private bool isGameOver = false;

    [HideInInspector]
    public bool isGameActive = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;    
    }

    public bool IsGameOver() => this.isGameOver;
    public bool IsGameActive() => this.isGameActive && !this.isGameOver;
    

    public void EndGame()
    {
        // Set flag
        this.isGameOver = true;
        this.isGameActive = false;

        endText.gameObject.SetActive(true);

        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay)
    {
        // Wait 2 seconds (delay)
        yield return new WaitForSeconds(delay);

        // Reload Scene
        var sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
