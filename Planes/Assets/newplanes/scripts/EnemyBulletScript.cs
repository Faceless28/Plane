using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour {

    GameObject Scoretext;
    float speed;
    Vector2 _direction;
    bool isReady;


    void Awake()
    {
        speed = 5f;
        isReady = false;


    }

    // Use this for initialization
    private void Start() {
        Scoretext = GameObject.FindGameObjectWithTag("score");

    }

   
    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            // Debug.Log("x==" + transform.position.x);
            //Debug.Log("y==" + transform.position.y);
            // Debug.Log("max x= " + max.x);

            if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //if ((col.tag == "Enemy") || (col.tag == "Bomb"))
        {
            // Destroy(col.gameObject);
            //PlayExplosion();
        }
        //уничтожение только EnemyPlane
        if (col.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Scoretext.GetComponent<ScoreScript>().Score += 5;
        }
    }

}

