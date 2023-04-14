using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HARJOK : MonoBehaviour
{
    public GameObject harch;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(harch, new Vector2(transform.position.x,transform.position.y), Quaternion.identity);
        
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (KRISA.harch == true && KRISA.harchPlus == true)
        {
            Instantiate(harch, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            KRISA.harchPlus =false;
        }
        
    }
}
