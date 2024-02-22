using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.Instance.Lifes <= 0)
        {
            Debug.Log("GAME OVER");
            return;
        }

        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.Lifes--;
            Debug.Log("Lifes: " + GameManager.Instance.Lifes);
            Destroy(collision.gameObject);
        }
    }
}
