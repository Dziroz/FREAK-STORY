using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FISHINGTRIGGER : MonoBehaviour
{
    public GameObject FISH;
    public bool isFishing;
    static public bool RIBA;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (FISH.activeSelf == true)
            {
                FISH.SetActive(false);
                RIBA = false;
            }
            else
            {
                FISH.SetActive(true);
                RIBA = true;
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isFishing = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            isFishing = false;
            
        }
    }


}

