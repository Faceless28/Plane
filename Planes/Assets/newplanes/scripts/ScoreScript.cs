using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    public Text ScoreUI;
    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set {
            this.score = value;
            UpdateScoreTextUI();
        }
    }

	// Use this for initialization
	void Start () {
        ScoreUI = GetComponent<Text>();
	}
    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:00000}", score);
        ScoreUI.text = scoreStr;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
