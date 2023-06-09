using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sign : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public GameObject dialogBox;
    public string dialog;
    public bool playerInRange;
    public GameObject E;
    public bool mechIs;
    static public bool IsMech = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                
                dialogText.text = dialog;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player")
        {
            playerInRange = true;
            E.SetActive(true);
            if (mechIs)
            {
                if (IsMech == false)
                {
                    IsMech = true;
                }
            }

        } 
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
            dialogBox.SetActive(false);
            E.SetActive(false);
        }
    }
}
