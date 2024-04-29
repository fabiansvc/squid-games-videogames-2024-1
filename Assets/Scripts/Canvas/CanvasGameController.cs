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
