using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector3 maxPosition;
    public Vector3 minPosition;
    public Vector3 playerChange;
    private CameraMovement cam;
    public Camera cameraMouse;
    public bool MouseRoom;
    public bool MouseDied;
    public GameObject kris;
    static public bool key;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if((other.tag == "Player") && (MouseRoom == false)) 
        {
            if(key == true)
            {
                cam.minPosition = minPosition;
                cam.maxPosition = maxPosition;
                other.transform.position += playerChange;
            }

        }
        if ((other.tag == "Player") && (MouseRoom == true))
        {
            cam.enabled = false;
            other.transform.position += playerChange;
            cameraMouse.transform.position = new Vector3(-18.45f, 44.5f, -10);
            cameraMouse.orthographicSize = 10;
            kris.SetActive(true);
            
        }
        if ((other.tag == "Player") && (MouseDied == true))
        {
            cam.enabled = true;
            cam.minPosition = minPosition;
            cam.maxPosition = maxPosition;
            cameraMouse.orthographicSize = 5;
            other.transform.position += playerChange;
        }


    }
}
