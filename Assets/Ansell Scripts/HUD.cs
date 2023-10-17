using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    public Coin coinpurse;
    
    private static HUD hud;
    
    public int coins;
    public int health;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Awake()
    {
        if (hud != null && hud != this) 
        {
            Destroy(gameObject);
        }
        else
        {
            hud = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coins.ToString();
        healthText.text = health.ToString();
    }
}
