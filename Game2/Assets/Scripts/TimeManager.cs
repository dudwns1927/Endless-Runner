
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
public class TimeManager : MonoBehaviour {
    [SerializeField] private Text timeText;          
    [SerializeField] private float startTimeInSeconds = 30f;

    private float timeRemaining;
    private bool timerRunning = true;

    void Start() {
        timeRemaining = startTimeInSeconds;
    }

    void Update() {
        if (!timerRunning) return;

        timeRemaining -= Time.deltaTime;
        timeRemaining = Mathf.Max(0, timeRemaining); 

        int totalMilliseconds = (int)(timeRemaining * 1000);
        int minutes = (totalMilliseconds / 60000) % 60;
        int seconds = (totalMilliseconds / 1000) % 60;
        int milliseconds = totalMilliseconds % 1000 / 10;

        timeText.text = string.Format("{0 : 00}:{1 : 00}:{2 : 00}", minutes, seconds, milliseconds);

        Color targetColor = Color.green;

        if (timeRemaining <= 10f) {
            targetColor = Color.red;
        } else if (timeRemaining <= 20f) {
            targetColor = Color.yellow;
        }
        if (timeRemaining <= 5f) {
            float alpha = Mathf.PingPong(Time.time * 5f, 1f); 
            targetColor.a = alpha;
        }

        timeText.color = targetColor;

        if (timeRemaining <= 0f) {
            timerRunning = false;
        }


    }
}
*/



public class TimeManager : MonoBehaviour
{
    [SerializeField] Text timetext;
    [SerializeField] float time;

    [SerializeField] int minute;
    [SerializeField] int second;
    [SerializeField] int millisecond;

    private void Awake() {
        StartCoroutine(Measure());
    }

    public IEnumerator Measure() {

        while (true) { 
        time += Time.deltaTime;


        minute = (int)time / 60;
        second = (int)time % 60;
        millisecond = (int)(time * 100) % 100;

        timetext.text = string.Format("{0:00}:{1:00}:{2:00}", minute, second, millisecond);

        yield return null;
        }
    }
}
