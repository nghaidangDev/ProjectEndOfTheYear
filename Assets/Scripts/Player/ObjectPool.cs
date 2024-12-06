using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    //Must initialize value
    private List<GameObject> objectBullets = new List<GameObject>();

    private float amountOfObjects = 20;

    [SerializeField] GameObject prefabBullets;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountOfObjects; i++)
        {
            GameObject obj = Instantiate(prefabBullets);
            obj.SetActive(false);
            //Add to list
            objectBullets.Add(obj);
        }
    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i < objectBullets.Count; i++)
        {
            if (!objectBullets[i].activeInHierarchy)
            {
                return objectBullets[i];
            }
        }

        return null;
    }
}
