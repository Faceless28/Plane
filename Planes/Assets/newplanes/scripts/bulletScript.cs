using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

    private GameObject[] objects = null; //массив пуль
    public GameObject objectToInstantiate;

    public int poolSize = 0; //количество пуль максимальное чтобы рендерить


	// Use this for initialization
	private void Start()
    {
        objects  = new GameObject [poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            objects[i] = Instantiate(objectToInstantiate) as GameObject;
            objects[i].transform.parent = gameObject.transform;
            objects[i].SetActive(false);

        }
	}

    private void ActiveObject()
    {
        for (int i = 0; i < poolSize; i++) //активация пуль по требованию
        {
            if (objects[i].activeInHierarchy==false)
            {
                objects[i].SetActive(true);
                return;
            }
        }
    }
}
