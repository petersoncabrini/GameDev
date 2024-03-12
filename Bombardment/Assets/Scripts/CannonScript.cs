using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public List<GameObject> bombPrefabs;
    public Vector2 timeInterval = new Vector2(1,1);
    public GameObject spawnPoint;
    public GameObject target;
    public float rangeInDegrees;
    public Vector2 force;
    private float cooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        cooldown = Random.Range(timeInterval.x, timeInterval.y);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown < 0){
            cooldown = Random.Range(timeInterval.x, timeInterval.y);
            Fire();
        }
    }

    private void Fire(){
        var bombPrefab = bombPrefabs[Random.Range(0, bombPrefabs.Count)];
        var bomb = Instantiate(bombPrefab, spawnPoint.transform.position, bombPrefab.transform.rotation);
        var bombRigidBody = bomb.GetComponent<Rigidbody>();
        var impulseVector = target.transform.position - spawnPoint.transform.position;
        impulseVector.Scale(new Vector3(1, 0, 1));
        impulseVector.Normalize();
        impulseVector = Quaternion.AngleAxis(45, Vector3.right) * impulseVector;
        impulseVector = Quaternion.AngleAxis(rangeInDegrees * Random.Range(-1f, 1f), Vector3.up) * impulseVector;

        impulseVector *= Random.Range(force.x, force.y);
        bombRigidBody.AddForce(impulseVector, ForceMode.Impulse);
    }
}
