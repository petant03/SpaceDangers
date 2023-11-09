using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBar : MonoBehaviour
{
    public Text textCoins;

    private SaveLoadSystem ss;
    private int coins;

    // Start is called before the first frame update
    void Start()
    {
        ss = new SaveLoadSystem();
    }

    // Update is called once per frame
    void Update()
    {
        coins = ss.LoadCoins() != null ? int.Parse(ss.LoadCoins()) : 0;
        textCoins.text = coins.ToString();
    }
}
