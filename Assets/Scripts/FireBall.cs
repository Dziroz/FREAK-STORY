using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject player;
    public GameObject point;
    public Vector2 lastPosition;
    public float speed;
    public bool isPoint =true;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //lastPosition = player.transform;

    }



    private void FixedUpdate()
    {
        if (isPoint)
        {
            lastPosition = player.transform.position;
            isPoint = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, lastPosition, 0.1f);
        if(transform.position.x == lastPosition.x && transform.position.y == lastPosition.y) 
        {
            Destroy(this.gameObject);
        }
    }
}
