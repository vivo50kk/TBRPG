using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int EnemyID;
    public string EnemyName;
    public int MaxHealthValue;
    public int CurrentHealthValue;
    public int AttackValue;
    public int DefenseValue;
    public int BaseMemoryValue;
    
    public void TakeDamage(int damage)
    {
        int damageTaken = Mathf.Max(damage, 0);
        CurrentHealthValue -= damageTaken;
        Debug.Log($"{EnemyName} 受到 {damageTaken} 点伤害，当前生命值：{CurrentHealthValue}");
        if (CurrentHealthValue < 0)
        {
            CurrentHealthValue = 0;
        }
    }
    public bool IsHealthDefeated()
    {
        return CurrentHealthValue <= 0;
    }
}
