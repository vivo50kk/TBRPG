using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum BattleState
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}
public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    private Player player;
    private Enemy enemy;

    public BattleHubUI battleHubUI;

    public BloodBarUI playerBloodBarUI;
    public BloodBarUI enemyBloodBarUI;
    public AntiMemoryUI antiMemoryUI;
    public SkillSystemUI skillSystemUI;

    private float antiMemoryValue;
    // Start is called before the first frame update

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SetUpBattle()
    {

        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        player = playerGO.GetComponent<Player>();
        enemy = enemyGO.GetComponent<Enemy>();

        battleHubUI.SetHub(player, enemy);
        playerBloodBarUI.SetHP(player.MaxHealthValue, player.CurrentHealthValue);
        enemyBloodBarUI.SetHP(enemy.MaxHealthValue, enemy.CurrentHealthValue);

        antiMemoryValue = antiMemoryUI.FirstSetAntiMemoryBar(player, enemy);

        yield return new WaitForSeconds(3f);

        if (CalculateTurnOrder(antiMemoryValue))
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else
        {
            state= BattleState.ENEMYTURN;
            Debug.Log("EnemyTurn");

        }
    }


    private bool CalculateTurnOrder(float AntiMemoryValue)
    {
        
        if (AntiMemoryValue >= 50)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void PlayerTurn()
    {
        Debug.Log("playerTrun");
    }

    public void OnSkillButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        skillSystemUI.Show();
    }
}
