using UnityEngine;
using System.Collections;

public class EnemyMoveScript : MonoBehaviour {

    GameObject Scoretext;
    float speed;
    
	// Use this for initialization
	private void Start ()
    {
        speed = 2f;
        Scoretext = GameObject.FindGameObjectWithTag("score");
	
	}
	
	// Update is called once per frame
	private void Update ()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x - speed * Time.deltaTime, position.y);
        transform.position = position;
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));
        if (position.x < min.x)
        {
            Destroy(gameObject);
        }
       
     }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("collision name = " + col.gameObject.tag);
        //Debug.Log("collision name = " + col.gameObject.name);
        if (col.tag == "Bullet")
        {
           Scoretext.GetComponent<ScoreScript>().Score+=10;
           Destroy(col.gameObject);
        }
    }
    
}
