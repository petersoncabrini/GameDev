using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidbody;
    public float jumpPower = 7f;
    public float jumpInterval = 0.2f;
    private float jumpCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update Cooldown
        jumpCooldown -= Time.deltaTime;
        var canJump = jumpCooldown <= 0;

        //Jump
        if (canJump)
        {
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if (jumpInput)
            {
                Jump();
            }

        }
    }

    private void Jump()
    {   
        //Reset Cooldown
        jumpCooldown = jumpInterval;

        //Apply Force
        thisRigidbody.velocity = Vector3.zero;
        thisRigidbody.AddForce(new Vector3(0f, jumpPower, 0f), ForceMode.Impulse);
    }
}
