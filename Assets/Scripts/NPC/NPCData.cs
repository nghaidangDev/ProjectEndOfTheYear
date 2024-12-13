using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC/ Create new NPC")]
public class NPCData : ScriptableObject
{
    public Sprite spriteNPC;
    public string nameNPC;
    public string infoNPC;
}
