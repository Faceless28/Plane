using UnityEngine;
using System.Collections;

public class Bulletfirew : MonoBehaviour {

    float speed;
    public GameObject Explosion;

	// Use this for initialization
	private void Start()
    {
        speed = 5f;
	}
	
	// Update is called once per frame
	private void Update()
    {
        Vector2 position = transform.position; // вычесляем текущую позицию пули

        position = new Vector2(position.x + speed * Time.deltaTime, position.y);

        transform.position = position; //обновляем позицию пули

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //верхний правый угол экрана

        //если пуля улетит за экран уничтожаем пулю
        if (transform.position.x > max.x)
        {
            Destroy(gameObject);
        }
	}
    void PlayExplosion()
    {
       GameObject explosions = (GameObject)Instantiate(Explosion);
       explosions.transform.position = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //if ((col.tag == "Enemy") || (col.tag == "Bomb"))
        {
          // Destroy(col.gameObject);
           //PlayExplosion();
        }
        //уничтожение только EnemyPlane
        if (col.tag == "Enemy")
        {
           Destroy(col.gameObject);
           PlayExplosion();
        }
        if (col.tag == "Bomb")
        {
           Destroy(col.gameObject);
       }
    }
}
