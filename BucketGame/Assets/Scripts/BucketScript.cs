using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour
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
            return;

        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.Score++;
            Debug.Log("Score: " + GameManager.Instance.Score);
            Destroy(collision.gameObject);
        }
    }
}
