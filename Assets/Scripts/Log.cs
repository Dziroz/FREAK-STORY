using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    public Transform target;
    public float chaseRaidus;
    public float attackRadius;
    public  Transform homePosition;
    public Animator anim;
    public GameObject yUP;
    public GameObject yDOWN;
    public Rigidbody2D rb;
    public bool isBoss;
    private float tm;
    private float temp;
    public GameObject bolt;
    void Start()
    {
        anim = GetComponent<Animator>();
        currentState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //C//heckDistance();
        rb.velocity = Vector2.zero;
    }
    private void FixedUpdate()
    {
        Debug.Log(tm);
        if (isBoss)
        {
            tm += Time.deltaTime;
            if (tm >= 5)
            {
                temp += Time.deltaTime;
                if (temp >= 1)
                {
                    anim.SetBool("mag", true);
                    Instantiate(bolt, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                    
                    tm = 0;
                    temp = 0;
                    return;
                }
            }
            CheckDistance();
            changeAnim(transform.position);
            return;
        }
        //Debug.Log("1");
        CheckDistance();
        changeAnim(transform.position);
    }
    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRaidus && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
                
            }

        }
    }
    private void changeAnim(Vector2 direction)
    {
        if(yUP.activeSelf == true)
        {
            anim.SetFloat("moveY", 1);
        }
        else
        {
            //anim.SetFloat("moveY", 0);
        }
        if(yDOWN.activeSelf == true)
        {
            anim.SetFloat("moveY", -1);
        }
        else
        {
            //anim.SetFloat("moveY", 0);
        }
    }
    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
