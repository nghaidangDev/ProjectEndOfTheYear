using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public int totalCoin = 0;
    public TMP_Text coinText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateCoin();
    }

    public void AddCoin(int amount)
    {
        totalCoin += amount;

        UpdateCoin();
    }

    public void UpdateCoin()
    {
        if (coinText != null)
        {
            coinText.text = totalCoin.ToString();
        }
    }
}
