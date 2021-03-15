using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIPlayer : MonoBehaviour
{
    [SerializeField] private Text coinCounter;
    void Start()
    {
        if(coinCounter == null)
        {
            Debug.LogError("Component Text Coin Counter Belum di tambahkan");
        }
    }

    void Update()
    {
        coinCounter.text = "Score : " + Data.coin;
    }
}
