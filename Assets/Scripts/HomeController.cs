using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    public Text textCoins;

    private SaveLoadSystem ss;

    // Start is called before the first frame update
    void Start()
    {
        ss = new SaveLoadSystem();
        var coins = ss.LoadCoins();

        if (coins != null)
            textCoins.text = coins.ToString();
        else
            textCoins.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
