using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

[CreateAssetMenu(fileName = "New Enemy Skill", menuName = "EnemySkill")]
public class EnemySkillSO : ScriptableObject
{
    [Header("所有者")]
    public int EnemyID;
    [Header("基础信息")]
    public string skillName;
    public string description;
    public EnemySkillType skillType;
    [Header("消耗与条件")]
    public int healthCost;
    //public int cooldown;
    //public int currentCooldown = 0;
    public bool requiresTarget = true;
    [Header("目标")]
    public SkillTargetType targetType;
    [Header("效果数值")]
    public int AntiMemoryEffect;
    public int PlayerBaseMemoryEffect;
    public float HitRateFix;

    public virtual bool FirstCheck(Enemy enemy,Player player)
    {
        //第一次随机数判定
        //基础技能过第一次判定即可发动，物理和记忆技能过第一判定发动，过第二判定生效
        System.Random random = new System.Random();
        double randomNum = random.NextDouble();
        double Hitrate = enemy.HitRateCalculate(player)+HitRateFix/100.0;
        if (Hitrate < randomNum)
        {
            Debug.Log("enemy命中率：" + Hitrate.ToString()+"/随机命中率："+randomNum.ToString());
            return false;
        }
        else
        {
            Debug.Log("enemy命中率：" + Hitrate.ToString() + "/随机命中率：" + randomNum.ToString());
            return true;

        }
    }
    public virtual bool SecondCheck(Enemy enemy, Player player)
    {
        //第二次判定，判断player攻击类技能闪避率与敌人命中率
        //用于敌人物理攻击和回忆攻击
        double playerDodgeChance = player.CalculateDodgeChance();
        double enemyHitRate = enemy.HitRateCalculate(player)+HitRateFix/100.0;
        if (playerDodgeChance < enemyHitRate)
        {
            Debug.Log("enemy命中率：" + enemyHitRate.ToString()+"/player闪避率："+ playerDodgeChance.ToString());
            return true;
        }
        else
        {
            Debug.Log("enemy命中率：" + enemyHitRate.ToString() + "/player闪避率：" + playerDodgeChance.ToString());
            return false;
        }
    }

    //命中判定
    public bool BaseSkillIsHit(Enemy enemy,Player player)
    {
        return FirstCheck(enemy, player);
    }

    public bool OtherSkillIsHit(Enemy enemy, Player player)
    {
        if (FirstCheck(enemy, player))
        {
            return SecondCheck(enemy, player);
        }
        else
        {
            return false ;
        }
    }

    public virtual IEnumerator Execute(Player player, Enemy enemy, BattleSystem battleSystem, AntiMemorySystem antiMemorySystem)
    {
        Debug.Log($"{enemy.EnemyName} 使用了 {skillName}");

        // 消耗资源
        //敌人的扣血技能等？
        
        

        
        // 播放动画和音效
        yield return new WaitForSeconds(1f);
        Debug.Log("敌方技能动画放映");

        // 显示技能名称

        // 根据技能类型执行不同效果
        switch (skillType)
        {
            case EnemySkillType.BaseSkills:
                antiMemorySystem.SetAntiMemory(AntiMemoryEffect);
                player.BaseMemoryLoss(PlayerBaseMemoryEffect);
                break;
            case EnemySkillType.Physics:
                player.TakeDamage(CalculatePhysicDamage(enemy.AttackValue,player.DefenseValue));
                break;
            case EnemySkillType.Memory:
                antiMemorySystem.SetAntiMemory(AntiMemoryEffect);
                player.BaseMemoryLoss(PlayerBaseMemoryEffect);
                player.TakeDamage(CalculatePhysicDamage(enemy.AttackValue, player.DefenseValue));
                break;
        }

        // 设置冷却时间

    }

    public int CalculatePhysicDamage(int atk, int def)
    {
        int PhysicDamage = atk - def;
        return PhysicDamage;
    }
}
