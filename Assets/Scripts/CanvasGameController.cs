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

    public void OnHandleButtonExit()
    {
        Debug.Log("Exit");
        // canvasGame.gameObject.SetActive(false);
        // canvasWelcome.gameObject.SetActive(true);
    }
}
