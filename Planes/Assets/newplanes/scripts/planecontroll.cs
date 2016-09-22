using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class planecontroll : MonoBehaviour {

    public float speed;
    public Text LivesUI;

    public GameObject Bulletgo;
    public GameObject GameManagerGO;
    public GameObject Bulletposition;

    const int MaxLives = 10;
    int Lives;
    public void Init()
    {
        Lives = MaxLives;
        LivesUI.text = Lives.ToString();
        gameObject.SetActive(true);
    }
    // Use this for initialization
    private  void Start()
    {
        

    }
	
	// Update is called once per frame
	private void Update() {
       // Debug.Log("Hello");

        //стреляет когда нажимаешь пробел
        if (Input.GetKeyDown("space"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            //рендер пули
            GameObject Bullet = (GameObject)Instantiate(Bulletgo);
            Bullet.transform.position = Bulletposition.transform.position;
        }

        float x = Input.GetAxisRaw("Horizontal"); //числа движения по горизонту от -1 до 1
        float y = Input.GetAxisRaw("Vertical"); //числа движения по вертикали от -1 до 1\

        Vector2 direction = new Vector2(x, y).normalized; //направление вектора и нормализация 
        Fly(direction); //функция полёта
    }

    private void Fly(Vector2 direction)
    {
        //находим граници экрана
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0, 0));//нижний левый угол экрана
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1, 1));//верхний правый гол экрана

        max.x = max.x - 1.225f;  //отнимаем половину ширины модели игрока
        min.x = min.x + 1.225f;  //добавляем половину ширины модели игрока

        max.y = max.y - 0.855f;  //отнимаем половину высоты модели игрока
        min.y = min.y + 0.855f;  //добавляем половину высоты модели игрока

        //Получаем данные о позиции модели игрока
        Vector2 pos = transform.position;

        //Расчитываем новую позицию модели
        pos += direction * speed * Time.deltaTime;

        //Проверяем чтобы модель не была за границей экрана
        pos.x = Mathf.Clamp (pos.x, min.x, max.x);
        pos.y = Mathf.Clamp (pos.y, min.y, max.y);

        //Полёт
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("collision name = " + col.gameObject.tag);
        //Debug.Log("collision name = " + col.gameObject.name);


        if ((col.tag == "Enemy") || (col.tag == "Bomb"))
        {
            Destroy(col.gameObject);
            Lives--;
            LivesUI.text = Lives.ToString();
            if (Lives==0)
            {
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                gameObject.SetActive(false);
            }
        }
    }
     
}
