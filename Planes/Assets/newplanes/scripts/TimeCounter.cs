using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeCounter : MonoBehaviour {
    Text timeUI;
    float StartTime;
    float TimeEllapsed;
    bool StartCounter;
    int minutes;
    int seconds;

	// Use this for initialization
	void Start () {
        StartCounter = false;
        timeUI = GetComponent<Text>();
	
	}

    public void StartTimer()
    {
        StartTime = Time.time;
        StartCounter = true;
    }
    public void StopTimer()
    {
        StartCounter = false;
    }
    // Update is called once per frame
    void Update () {
        if (StartCounter)
        {
            TimeEllapsed = Time.time - StartTime;
            minutes = (int)TimeEllapsed / 60;
            seconds = (int)TimeEllapsed % 60;
            timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
	
	}
}
