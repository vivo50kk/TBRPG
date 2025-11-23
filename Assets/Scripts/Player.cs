using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerID;
    public string PlayerName;

    public int MaxHealthValue;
    public int CurrentHealthValue;
    public int BaseMemoryValue;
    public int MaxHunger;
    public int CurrentHunger;
    public int MaxMagicValue;
    public int CurrentMagicValue;
    public int AttackValue;
    public int DefenseValue;
    
    private BloodBarUI playerHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthBar = GameObject.Find("Canvas/BattleUI/PlayerHealthUI").GetComponent<BloodBarUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        int damageTaken = Mathf.Max(damage, 0);
        CurrentHealthValue -= damageTaken;
        Debug.Log($"{PlayerName} 受到 {damageTaken} 点伤害，当前生命值：{CurrentHealthValue}");
        if (CurrentHealthValue < 0)
        {
            CurrentHealthValue = 0;
        }
        // 更新血条UI
        playerHealthBar.SetHP(MaxHealthValue, CurrentHealthValue);

    }

    public bool IsHealthDefeated()
    {
        return CurrentHealthValue <= 0;
    }
}
