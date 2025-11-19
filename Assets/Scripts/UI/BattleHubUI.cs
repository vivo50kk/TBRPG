using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleHubUI : MonoBehaviour
{

    public TextMeshProUGUI playerNameText;
    //public TextMeshProUGUI enemyMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHub(Player player,Enemy enemy)
    {
        
        playerNameText.text = player.PlayerName + "Magic:" + player.CurrentMagicValue + "Hunger:" + player.CurrentHunger;
        //enemyMessage.text = enemy.EnemyName + " appeared!";
    }
}
