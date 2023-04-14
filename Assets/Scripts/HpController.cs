using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpController : MonoBehaviour
{
    static public int hp= 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public float timer;
    public Collider2D col;
    public AudioSource audioSou;
    public AudioClip hit;
    void Start()
    {
        col = GetComponent<Collider2D>();
        audioSou = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(hp <= 0)
        {
            hp = 3;
            Fishing.fishCount = 0;
            SceneManager.LoadScene(0);
        }
        switch (hp)
        {
            case 0:
                {
                    heart1.SetActive(false);
                    heart2.SetActive(false);
                    heart3.SetActive(false);
                    break;
                }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
           if(timer >= 1)
           {
               hp--;
               timer = 0;
               col.enabled = false;
               col.enabled = true;
               audioSou.PlayOneShot(hit);
           
           }
        }
        Debug.Log("FFFF");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Enemy")
       {
           if (timer >= 1)
           {
                hp--;
                timer = 0;
                col.enabled = false;
                col.enabled = true;
                audioSou.PlayOneShot(hit);
            }
       }
    }  
}
