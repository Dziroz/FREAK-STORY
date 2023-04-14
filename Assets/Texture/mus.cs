using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mus : MonoBehaviour
{
    public AudioClip boss;
    public AudioSource radio;
    public GameObject bos;
    void Start()
    {
        radio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(bos.activeSelf == true)
        {
            radio.PlayOneShot(boss);
        }
    }
    
}
