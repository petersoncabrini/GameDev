using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public Vector3 OriginPoint = Vector3.zero;
    public List<GameObject> Prefabs = new List<GameObject>();
    public float Interval = 2f;
    private float Cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Lifes <= 0)
            return;

        Cooldown -= Time.deltaTime;
        if (Cooldown <= 0)
        {
            Cooldown = Interval;
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        // Get prefab
        var prefabIndex = Random.Range(0, Prefabs.Count);
        var prefab = Prefabs[prefabIndex];

        // Get rotation
        var rotation = prefab.transform.rotation;

        // Get position
        var gameWidth = GameManager.Instance.GameWidth;
        var xOffSet = Random.Range(-gameWidth / 2f, gameWidth / 2f);
        var position = OriginPoint + new Vector3(xOffSet, 0, 0);

        Instantiate(prefab, position, rotation);
    }
}
