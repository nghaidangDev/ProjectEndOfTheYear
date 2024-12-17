using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    Play,
    Pause,
    Victory,
    Lose
}

public class GameController : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Transform[] spawnTransforms; 

    private void Start()
    {
        for (int i = 0; i < spawnTransforms.Length; i++)
        {
            Instantiate(prefabEnemy, spawnTransforms[i].position, spawnTransforms[i].rotation);
        }
    }
}
