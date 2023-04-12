using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIZDEXC : MonoBehaviour
{
    public GameObject y;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            y.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            y.SetActive(false);
        }
    }
}
