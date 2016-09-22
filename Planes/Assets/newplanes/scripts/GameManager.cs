using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject PlayButton;
    public GameObject PlayerPlane;
    public GameObject EnemyPlaneSpawner;
    public GameObject gameOver;
    public GameObject Scoretext;
    public GameObject Timer;


    public enum GameManagerState
    {
        Opening,
        GamePlay,
        GameOver,
    }

    GameManagerState GMState;

    // Use this for initialization
    void Start () {
        GMState = GameManagerState.Opening;
	
	}
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                PlayButton.SetActive(true);
                gameOver.SetActive(false);
                break;
            case GameManagerState.GamePlay:
                Scoretext.GetComponent<ScoreScript>().Score = 0;
                PlayButton.SetActive(false);
                PlayerPlane.GetComponent<planecontroll>().Init();
                EnemyPlaneSpawner.GetComponent<EnemySpawnerScript>().ScheduleEnemySpawner();
                Timer.GetComponent<TimeCounter>().StartTimer();
                 break;
            case GameManagerState.GameOver:
                EnemyPlaneSpawner.GetComponent<EnemySpawnerScript>().UnScheduleEnemySpawner();
                Invoke("ChangeToOpeningState", 3f);
                gameOver.SetActive(true);
                Timer.GetComponent<TimeCounter>().StopTimer();
                break;
        }
    }
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }
    public void StartGame()
    {
        GMState = GameManagerState.GamePlay;
        UpdateGameManagerState();
    }
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
