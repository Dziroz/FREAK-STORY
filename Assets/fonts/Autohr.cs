using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Autohr : MonoBehaviour
{
    public GameObject dada;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void Author()
    {
        dada.SetActive(!dada.activeSelf);
    }
    public void GOPLAY()
    {
        SceneManager.LoadScene(2);
    }
}
