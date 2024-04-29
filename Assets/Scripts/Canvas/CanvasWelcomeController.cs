using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasWelcomeController : MonoBehaviour
{
    private static CanvasWelcomeController instance;
    public Canvas CanvasWelcome;
    public Canvas CanvasGame;

    void Awake()
    {
        instance = this;
    }

    public void B_OnHandleButtonStart()
    {
        CanvasWelcome.gameObject.SetActive(false);
        CanvasGame.gameObject.SetActive(true);
        Game.GetInstance().SetIsStarted(true);
        Game.GetInstance().StartGame();
    }

    public static CanvasWelcomeController GetInstance()
    {
        return instance == null ? instance = new CanvasWelcomeController() : instance;
    }
}

