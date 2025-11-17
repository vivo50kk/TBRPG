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


    // Start is called before the first frame update

    void Start()
    {
        state = BattleState.START;
        SetUpBattle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetUpBattle()
    {

        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        player = playerGO.GetComponent<Player>();
        enemy = enemyGO.GetComponent<Enemy>();

        battleHubUI.SetHub(player, enemy);

        playerBloodBarUI.SetHP(player.MaxHealthValue, player.CurrentHealthValue);
        enemyBloodBarUI.SetHP(enemy.MaxHealthValue, enemy.CurrentHealthValue);
    }

}
