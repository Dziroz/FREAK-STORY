using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpController : MonoBehaviour
{
    public int hp= 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (hp)
        {
            case 1:
                {
                    heart1.SetActive(true);
                    heart2.SetActive(false);
                    heart3.SetActive(false);
                    break;
                }
            case 2:
                {
                    heart1.SetActive(true);
                    heart2.SetActive(true);
                    heart3.SetActive(false);
                    break;
                }
            case 3:
                {
                    heart1.SetActive(true);
                    heart2.SetActive(true);
                    heart3.SetActive(true);
                    break;
                }

        }
    }
}
