using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum PlayerState
    {
        walk,
        attack,
        interact
    }
    public float speed;
    private Rigidbody2D rb;
    private Vector3 change;
    private Animator animator;
    public PlayerState currentState;
    public AudioSource CORS;
    public AudioClip UDAR;
    void Start()
    {
        CORS = GetComponent<AudioSource>();
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(KeyCode.Space) && currentState != PlayerState.attack)
        {
            CORS.PlayOneShot(UDAR);
            StartCoroutine(AttackCo());
            
        }
    }
    private void FixedUpdate()
    {
        if(currentState == PlayerState.walk)
        {
            if(FISHINGTRIGGER.RIBA== false)
            {
                UpdateAnimationAndMove();
            }
            //UpdateAnimationAndMove();
        }
       // UpdateAnimationAndMove();
    }
    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }
    void UpdateAnimationAndMove() 
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("MoveX", change.x);
            animator.SetFloat("MoveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    void MoveCharacter()
    {
        change.Normalize();
        rb.MovePosition(transform.position + change * speed * Time.deltaTime);        
    }
}
