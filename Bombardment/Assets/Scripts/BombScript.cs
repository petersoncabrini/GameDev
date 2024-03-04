using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float ExplosionDelay = 5f;
    public GameObject ExplosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(explosionCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator explosionCoroutine()
    {
        //Wait
        yield return new WaitForSeconds(ExplosionDelay);

        //Explode
        Explode();
    }

    private void Explode()
    {
        //Create explosion
        Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation);

        //Destroy
        Destroy(gameObject);
    }
}
