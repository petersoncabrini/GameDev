using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    public GameObject Reference;
    public float ReferenceSpeed;
    public Vector2 Frequency;
    public Vector2 Distance;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var sin = Mathf.Sin(Time.time * Frequency.x) * Distance.x;
        var cos = Mathf.Cos(Time.time * Frequency.y) * Distance.y;
        transform.position = Reference.transform.position + new Vector3(sin, cos, 0);
        Reference.transform.position += new Vector3(0, 0, ReferenceSpeed/100);
    }
}
