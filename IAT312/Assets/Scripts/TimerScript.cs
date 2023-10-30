using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public float timeLeft;
    public bool timerOn = false;
    public TextMeshProUGUI text;
    public UnityEvent keypadEvent;
    public FirstPersonCamera player;
    // Start is called before the first frame update
    void Start()
    {
        timerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if(!text.enabled)
                text.enabled = true;
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                timerOn = false;
                keypadEvent.Invoke();
            }
        }
        else if (text.enabled)
        {
            text.enabled = false;
        }
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes= Mathf.FloorToInt(currentTime/60);
        float seconds= Mathf.FloorToInt(currentTime%60);
        text.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
    public void updateScene()
    {
        player.MoveCam = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("BadEnding");
    }
}
