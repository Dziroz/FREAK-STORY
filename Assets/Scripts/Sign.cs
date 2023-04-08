using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sign : MonoBehaviour
{
    TextMeshProUGUI dialogText;
    public GameObject dialogBox;
    public string dialog;
    public bool dialogActive;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player")
        {

        } 
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

        }
    }
}
