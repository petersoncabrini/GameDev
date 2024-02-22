using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Lifes <= 0)
            return;

        // Get input values
        var isPressingLeft = Input.GetKey(KeyCode.LeftArrow);
        var isPressingRight = Input.GetKey(KeyCode.RightArrow);

        // Abort if no keys are pressed or both are pressed at the same time
        if (isPressingLeft == isPressingRight)
            return;

        // Move player
        var movement = (speed * Time.deltaTime);
        if (isPressingLeft)
            movement *= -1f;
        transform.position += new Vector3(movement, 0, 0);

        var movementLimit = GameManager.Instance.GameWidth / 2;

        if(transform.position.x < -movementLimit)
            transform.position = new Vector3(-movementLimit, transform.position.y, transform.position.z);
        else if (transform.position.x > movementLimit)
            transform.position = new Vector3(movementLimit, transform.position.y, transform.position.z);
    }
}
