using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public List<GameObject> Prefabs;
    public float Interval = 1f;
    private float Cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown -= Time.deltaTime;
        if(Cooldown <= 0f)
        {
            ShootBall();
            Cooldown = Interval;
        }
    }

    private void ShootBall()
    {
        var prefab = Prefabs[Random.Range(0, Prefabs.Count)];
        Instantiate(prefab, transform);
    }
}
