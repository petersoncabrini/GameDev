using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float Cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get GameManager
        var gameManager = GameManager.Instance;

        // Ignore if game is over
        if (!gameManager.IsGameActive())
            return;

        //Update Cooldown
        Cooldown -= Time.deltaTime;
        if (Cooldown <= 0f)
        {
            Cooldown = gameManager.ObstacleInterval;

            //Spawn Obstacle
            var prefabIndex = Random.Range(0, gameManager.Prefabs.Count);
            var prefab = gameManager.Prefabs[prefabIndex];

            var offsetY = Random.Range(gameManager.ObstacleOffsetY.x, gameManager.ObstacleOffsetY.y);
            var position = new Vector3(gameManager.ObstacleOffsetX, offsetY);
            var rotation = prefab.transform.rotation;
            Instantiate(prefab, position, rotation);
        }
    }
}
