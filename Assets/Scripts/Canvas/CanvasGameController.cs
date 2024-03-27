using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameController : MonoBehaviour
{
    private static CanvasGameController instance;
    public Canvas CanvasGame;
    public Canvas CanvasWelcome;

    void Awake()
    {
        instance = this;
    }

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
        Game.GetInstance().SetIsStarted(false);
    }

    public static CanvasGameController GetInstance()
    {
        return instance == null ? instance = new CanvasGameController() : instance;
    }
}
