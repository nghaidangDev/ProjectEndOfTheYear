using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy/Create new Enemy")]
public class EnemyData : ScriptableObject
{
    public string nameEnemy;
    public float hp;
    public float damaged;
    public float speed;
    public Sprite spriteEnemy;
}
