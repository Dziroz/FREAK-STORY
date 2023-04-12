using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;

    [SerializeField] Transform fish;

    float fishPosition;
    float fishDestination;

    float fishTimer;
    [SerializeField] float timerMultiplicator = 3f;
    float fishSpeed;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform hook;
    float hookPosition;
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPower = 5f;
    float hookProgress;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookProgressDefradationPower = 0.1f;
    [SerializeField] SpriteRenderer hookSpriteRenderer;

    [SerializeField] Transform progressBarContainer;
    public GameObject EBALO;

    bool pause = false;
    void Start()
    {
        Resize();
    }
    private void Resize()
    {
        Bounds b = hookSpriteRenderer.bounds;
        float ySize = b.size.y;
        Vector3 Is = hook.localScale;
        float distancer = Vector3.Distance(topPivot.position, bottomPivot.position);
        Is.y = (distancer / ySize * hookSize);
        hook.localScale = Is;


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hookPosition);
        if (pause)
        {
            return;
        }
        Fish();
        Hook();
        ProgressCheck();
    }
    private void ProgressCheck()
    {
        Vector3 Is = progressBarContainer.localScale;
        Is.y = hookProgress;
        progressBarContainer.localScale = Is;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;
        
        if (min < fishPosition && fishPosition < max)
        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookProgressDefradationPower * Time.deltaTime;
        }
        if(hookProgress >= 1f)
        {
            Win();
            hookProgress = 0;
        }
        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
    }
    private void Win()
    {
        EBALO.SetActive(false);
    }
    void Fish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer <= 0f)
        {
            fishTimer = UnityEngine.Random.value * timerMultiplicator;

            fishDestination = UnityEngine.Random.value;
        }
        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPosition);
    }
    void Hook()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            hookPullVelocity = 0;
        }
        if (Input.GetKey(KeyCode.F))
        {

            hookPullVelocity += hookPullPower * Time.deltaTime;
            //Debug.Log("333");
        }
        hookPullVelocity -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVelocity;
        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize/2);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);
    }
}
