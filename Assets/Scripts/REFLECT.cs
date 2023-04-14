using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REFLECT : MonoBehaviour
{
    public GameObject blast;
    public GameObject player;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "fire")
        {
            Destroy(collision.gameObject);
            Instantiate(blast, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);
        }
        //Instantiate(blast, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);

    }
}
