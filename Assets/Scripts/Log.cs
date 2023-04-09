using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    public Transform target;
    public float chaseRaidus;
    public float attackRadius;
    public  Transform homePosition;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //C//heckDistance();
    }
    private void FixedUpdate()
    {
        CheckDistance();
    }
    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRaidus && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}
