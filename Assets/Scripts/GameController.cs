using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject prefabEnemy; // Prefab của Enemy
    public Transform[] spawnTransforms; // Vị trí spawn của Enemy

    private void Start()
    {
        for (int i = 0; i < spawnTransforms.Length; i++)
        {
            Instantiate(prefabEnemy, spawnTransforms[i].position, spawnTransforms[i].rotation);
        }
    }
}
