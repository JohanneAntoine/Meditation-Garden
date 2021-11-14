using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 90;
    public bool timeIsRunning = false; 
    public Text timeText;
    public int days;
    public bool meditated;

    void Start() 
    {
        timeIsRunning = true;
        meditated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsRunning) {
            if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
            } 
            else {
            Debug.Log("Time has run out!");
            timeRemaining = 0;
            timeIsRunning = false;
            meditated = true;
            SceneManager.LoadScene("FloweringPotScene");
            }
        }
        
        DisplayTime(timeRemaining);
        
    }

    public void Paused() { 
        if (timeIsRunning) {
            timeIsRunning = false;
        } else {
            timeIsRunning = true;
        }
    }

    public void Reset() {
        timeRemaining = 90;
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
