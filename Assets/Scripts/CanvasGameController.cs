using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameController : MonoBehaviour
{
    public Canvas CanvasGame;
    public Canvas CanvasWelcome;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void B_OnHandleButtonExit()
    {
        CanvasGame.gameObject.SetActive(false);
        CanvasWelcome.gameObject.SetActive(true);
    }
}
