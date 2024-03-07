using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Read Input
        var isUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        var isDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        var isLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        var isRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        //Create movement vector
        var movementZ = isUp ? 1 : isDown ? -1 : 0;
        var movementX = isRight ? 1 : isLeft ? -1 : 0;
        var movementVector = new Vector3(movementX, 0, movementZ);

        //Apply input to character
        transform.Translate(movementVector * movementSpeed * Time.deltaTime);
    }
}
