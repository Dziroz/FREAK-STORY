using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KRISA : MonoBehaviour
{
    public float timer;
    static public bool harch;
    static public bool harchPlus;
    static public bool harch2;
    static public bool harchPlus2;
    public Animator anim;
    public GameObject harcPoint;
    public GameObject harcPoint2;
    public int hp;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<= 0)
        {
            Destroy(this.gameObject);
        }
        if(harcPoint.activeSelf == false)
        {
            harchPlus = true;
        }
        timer += Time.deltaTime;
        if(timer >= 3)
        {
            anim.SetBool("harch", true);
            harch = true;
        }
        if(timer >= 4)
        {
            harch = false;
            anim.SetBool("harch", false);
            timer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "blast")
        {
            Destroy(collision.gameObject);
            hp--;
        }
    }
}
