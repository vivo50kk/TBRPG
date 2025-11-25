using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class BattleHubUI : MonoBehaviour
{

    public TextMeshProUGUI playerNameText;
    
    public SkillSystemUI skillSystemUI;
    public DialogSystemUI dialogSystemUI;
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

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this .gameObject.SetActive(false);
    }

    public void OnSkillButton()
    {
        if (BattleSystem.Instance.state != BattleState.PLAYERTURN)
        {
            return;
        }
        skillSystemUI.Show();
    }

    public void OnDialogButtonClick()
    {
        if (BattleSystem.Instance.state != BattleState.PLAYERTURN)
        {
            return;
        }
        dialogSystemUI.Show();
    }
}
