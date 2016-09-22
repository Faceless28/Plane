using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {

    public GameObject Enemy1;

    float spawnspeed = 2f;

	// Use this for initialization
	private void Start ()
    {
       
	}
	
	// Update is called once per frame
	private void Update () {
	
	}
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject anEnemy = (GameObject)Instantiate(Enemy1);
        anEnemy.transform.position = new Vector2 (max.x,Random.Range(min.y, max.y));
        NextEnemySpawn();
    }
    void NextEnemySpawn()
    {

        if (spawnspeed > 1f)
        {
            //spawnspeed = Random.Range(1f, spawnspeed);
        }
        else
        {
            //spawnspeed = 1f;
        }
        Invoke("SpawnEnemy", spawnspeed);
    }
        public void ScheduleEnemySpawner()
    {
        Invoke("SpawnEnemy", spawnspeed);
    }
    public void UnScheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
    }
}
