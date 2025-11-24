using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float HitRateFix;

    public virtual bool FirstCheck(Enemy enemy)
    {
        //第一次随机数判定
        //基础技能过第一次判定即可发动，物理和记忆技能过第一判定发动，过第二判定生效
        //Random random = new Random();

        return true;
    }
}
