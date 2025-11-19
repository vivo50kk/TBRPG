using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class SkillSO : ScriptableObject
{
    [Header("所有者")]
    public int PlayerID;
    [Header("基础信息")]
    public string skillName;
    public string description;
    public SkillType skillType;
    [Header("消耗与条件")]
    public int MagicCost;
    public int healthCost;
    //public int cooldown;
    //public int currentCooldown = 0;
    public bool requiresTarget = true;
    [Header("目标")]
    public SkillTargetType targetType;
    [Header("效果数值")]
    public int AntiMemoryEffect;
    public float HitRateFix;
    //public int hitTimes = 1;

    public virtual bool IsUsable(Player player)
    {
        if (player.CurrentMagicValue < MagicCost)
        {
            Debug.Log($"{player.PlayerName} 魔法值不足");
            return false;
        }
        if (player.CurrentHealthValue <= healthCost)
        {
            Debug.Log($"{player.PlayerName} 生命值不足");
            return false;
        }

        return true;
    }

    public virtual IEnumerator Execute(Player player, Enemy enemy, BattleSystem battleSystem,AntiMemorySystem antiMemorySystem)
    {
        Debug.Log($"{player.PlayerName} 使用了 {skillName}");

        // 消耗资源
        player.CurrentMagicValue -= MagicCost;
        player.CurrentHealthValue -= healthCost;
        // 播放动画和音效
        yield return new WaitForSeconds(1f);
        Debug.Log("技能动画放映");

        // 显示技能名称
        
        // 根据技能类型执行不同效果
        switch (skillType)
        {
            case SkillType.Physics:
                enemy.TakeDamage(CalculatePhysicDamage(player.AttackValue, enemy.DefenseValue));
                break;
            case SkillType.Memory:
                antiMemorySystem.SetAntiMemory(AntiMemoryEffect);
                break;
            case SkillType.Item:
                break;
        }

        // 设置冷却时间
        
    }

    public int CalculatePhysicDamage(int atk,int def)
    {
        int PhysicDamage = atk - def;
        return PhysicDamage;
    }

}
