using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blast : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 1,0) * speed * Time.deltaTime;
    }
}
