using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {

    public GameObject EnemyBullet;

    // Use this for initialization
    private void Start()
    {

        Invoke("FireGun", 2f);
    }

    // Update is called once per frame
    private void Update()
    {
        //Invoke("FireGun", 1);
    }

    void FireGun()
    {

        GameObject playerPlane = GameObject.Find("PlayerPlane");
        
        if(playerPlane != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);
            bullet.transform.position = transform.position;
            Vector2 direction = playerPlane.transform.position - bullet.transform.position;
            bullet.GetComponent<EnemyBulletScript>().SetDirection(direction);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("collision name = " + col.gameObject.tag);
        //Debug.Log("collision name = " + col.gameObject.name);


        if ((col.tag == "Player") || (col.tag == "Bullet"))
        {
            Destroy(col.gameObject);
        }
    }
}
