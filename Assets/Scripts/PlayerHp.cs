using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public ScriptableVariable playerHp;
    public TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        playerHp.hp = 5;
        textMeshProUGUI.text = playerHp.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayerLife(int value)
    {
        playerHp.hp += value;
        textMeshProUGUI.text = playerHp.hp.ToString();
    }

}
