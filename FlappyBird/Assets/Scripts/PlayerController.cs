using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidbody;
    public float jumpPower = 5f;
    public float jumpInterval = 0.1f;
    private float jumpCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();

        //Hide score text
        GameManager.Instance.scoreText.gameObject.SetActive(false);

        //Remove gravity from character while game is not active
        thisRigidbody.useGravity = false;

        //Hide gameover text
        GameManager.Instance.endText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        var gameManager = GameManager.Instance;
        var playerPressesSpaceBar = Input.GetKey(KeyCode.Space);
        
        // Start game only when player press spacebar
        if (playerPressesSpaceBar)
        {
            //Start game
            gameManager.isGameActive = true;

            //Active character gravity
            thisRigidbody.useGravity = true;

            //Hide start text
            gameManager.startText.gameObject.SetActive(false);

            //Show score text
            GameManager.Instance.scoreText.gameObject.SetActive(true);

        }

        //Update Cooldown
        jumpCooldown -= Time.deltaTime;
        var canJump = jumpCooldown <= 0 && gameManager.IsGameActive();

        //Jump
        if (canJump)
        {
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if (jumpInput)
            {
                Jump();
            }
        }

        // Stop Character Animation
        GetComponent<Animator>().enabled = gameManager.IsGameActive();
    }


    private void OnCollisionEnter(Collision collision) => OnCustomCollisionEnter(collision.gameObject);

    private void OnTriggerEnter(Collider other) => OnCustomCollisionEnter(other.gameObject);


    private void OnCustomCollisionEnter(GameObject obj)
    {
        var isSensor = obj.CompareTag("Sensor");
        if (isSensor)
        {
            // Score
            GameManager.Instance.Score++;
            GameManager.Instance.scoreText.text = GameManager.Instance.Score.ToString();
        }
        else
        {
            // Game Over
            GameManager.Instance.EndGame();
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
