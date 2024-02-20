using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallScript : MonoBehaviour
{
    private static readonly float DestroyThreshold = -10;
    private Rigidbody MyRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        //apply force to ball
        var forceAmountY = Random.Range(10f, 10f);
        var forceAmountX = forceAmountY * Random.Range(-0.07f, 0.07f);
        var forceAmountZ = forceAmountY * Random.Range(-0.07f, 0.07f);
        var forceVector = new Vector3(forceAmountX, forceAmountY, forceAmountZ);

        MyRigidBody = gameObject.GetComponent<Rigidbody>();
        MyRigidBody.AddForce(forceVector, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        var y = transform.position.y;
        if(y <= DestroyThreshold)
        {
            Destroy(gameObject);
        }
    }
}
