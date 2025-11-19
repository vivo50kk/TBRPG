using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;



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
    //public AntiMemoryUI antiMemoryUI;
    public SkillSystemUI skillSystemUI;

    private int antiMemoryValue;
    private AntiMemorySystem antiMemorySystem;
    // Start is called before the first frame update
    public static BattleSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); return;
        }
        Instance = this;
    }
    void Start()
    {
        antiMemorySystem = GetComponent<AntiMemorySystem>();
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

        antiMemoryValue = antiMemorySystem.FirstSetAntiMemory(player, enemy);
        //antiMemoryUI.SetAntiMemoryBar(antiMemoryValue);
        Debug.Log("AntiMemoryValue:" + antiMemoryValue);
        //set

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

    private void PlayerTurn()
    {
        Debug.Log("playerTrun");
        
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

    



    public void OnSkillButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        skillSystemUI.Show();
    }

    public void SkillExecute(SkillSO skill)
    {
        Debug.Log("Find Skill:" + skill.skillName);
        if (skill.IsUsable(player))
        {
            Debug.Log("Execute Skill:" + skill.skillName);
            StartCoroutine(skill.Execute(player, enemy, this, antiMemorySystem));
        }
        enemyBloodBarUI.SetHP(enemy.MaxHealthValue, enemy.CurrentHealthValue);
        playerBloodBarUI.SetHP(player.MaxHealthValue, player.CurrentHealthValue);
        
        //判断血量胜负，更新UI，切换回合状态
        //记忆胜利判断没做
        if (enemy.IsHealthDefeated())
        {
            state = BattleState.WON;
        }
    }
}
