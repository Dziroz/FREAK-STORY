using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FISHINGTRIGGER : MonoBehaviour
{
    public GameObject FISH;
    public bool isFishing = false;
    static public bool RIBA;
    public TextMeshProUGUI RibText;
    public GameObject box;
    public string text;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if ((FISH.activeSelf == true))
            {
                FISH.SetActive(false);
                RIBA = false;
                //RibText.gameObject.SetActive(false);
            }
            else
            {
                if (isFishing)
                {
                    //RibText.gameObject.SetActive(true);
                    FISH.SetActive(true);
                    RIBA = true;
                }

            }


        }
        if(FISH.activeSelf == false)
        {
            RIBA = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isFishing = true;
            box.SetActive(true);
            RibText.text = text;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            isFishing = false;
            box.SetActive(false);
            RibText.text = text;

        }
    }


}

