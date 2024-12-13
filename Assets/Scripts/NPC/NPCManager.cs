using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    public GameObject panelDiague;
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public NPCData npcData;

    private void Start()
    {
        nameText.text = npcData.nameNPC;
        dialogueText.text = npcData.infoNPC;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            panelDiague.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            panelDiague.SetActive(false);
        }
    }
}
