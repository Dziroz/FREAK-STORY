using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishController : MonoBehaviour
{

    public GameObject fish1;
    public GameObject fish2;
    public GameObject fish3;
    public AudioSource audio;
    public AudioClip clip;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            HpController.hp++;
            Fishing.fishCount--;
            audio.PlayOneShot(clip);
        }
        switch (Fishing.fishCount)
        {
            case 0:
                {
                    fish1.SetActive(false);
                    fish2.SetActive(false);
                    fish3.SetActive(false);
                    break;
                }
            case 1:
                {
                    fish1.SetActive(true);
                    fish2.SetActive(false);
                    fish3.SetActive(false);
                    break;
                }
            case 2:
                {
                    fish1.SetActive(true);
                    fish2.SetActive(true);
                    fish3.SetActive(false);
                    break;
                }
            case 3:
                {
                    fish1.SetActive(true);
                    fish2.SetActive(true);
                    fish3.SetActive(true);
                    break;
                }
        }
    }
}
