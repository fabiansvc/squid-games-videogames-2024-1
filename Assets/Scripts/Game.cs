using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    private static Game instance;
    private bool isStarted = false;
    public GameObject TextTime;
    public TMP_Text TmpText;
    private IEnumerator enumerator;
    private int time;

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isStarted)
        {
            TextTime.SetActive(true);
            TmpText.text = time.ToString();

            if (time == 0)
            {
                TextTime.SetActive(false);
            }
        }
    }

    IEnumerator CountDown()
    {
        time = 3;
        do
        {
            yield return new WaitForSeconds(1f);
            time--;
        }while(time>0);
    }

    public void SetIsStarted(bool isStarted)
    {
        this.isStarted = isStarted;
    }

    public void StartGame()
    {
        enumerator = CountDown();
        StartCoroutine(enumerator);
    }

    public static Game GetInstance()
    {
        return instance == null ? instance = new Game() : instance;
    }
}

