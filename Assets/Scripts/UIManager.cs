using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private Text coinScore;

    // Start is called before the first frame update
    void Start()
    {
        coinScore = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoinScore(int coins)
    {
        coinScore.text = "Coins: " + coins;
    }
}
