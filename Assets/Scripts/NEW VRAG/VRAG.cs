using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAG : MonoBehaviour
{
    public float speed;
    private Transform target;
    public GameObject player;
    public int distance;
    public float vidnoGeroya;
    public float duration;
    public float power;
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    
    void Update()
    {
        //PushAway(target, pushPower);
    }
    private void FixedUpdate()
    {
        if(Vector2.Distance(transform.position,target.position) > distance)
        {
            if(Vector2.Distance(transform.position, target.position) <= vidnoGeroya)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }
    public IEnumerator KnockBack(float knockBackDuraction, float knockbackPower, Transform obj)
    {
        float timer = 0;
        while(knockBackDuraction > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            
            rb.AddForce(-direction * knockbackPower);

        }
        yield return 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "mech")
        {
            rb.velocity = Vector2.zero;
            StartCoroutine(KnockBack(duration,power,target));
        }
    }


}
