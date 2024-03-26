using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasWelcomeController : MonoBehaviour
{
    public Canvas CanvasWelcome;
    public Canvas CanvasGame;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void B_OnHandleButtonStart(){
        CanvasWelcome.gameObject.SetActive(false);
        CanvasGame.gameObject.SetActive(true);
    }
}
