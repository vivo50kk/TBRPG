using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }
    public List<SkillSO> skillList;
    public List<EnemySkillSO> enemySkillList;
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); return;
        }
        Instance = this;
        
    }

    public int SkillCount()
    {
        return skillList.Count;
    }
    public SkillSO SkillShow(int index)
    {
        return skillList[index];
    }

    public EnemySkillSO RandomEnemySkill()
    {
        System.Random random = new System.Random();
        int randomNum = random.Next(0, enemySkillList.Count);
        return enemySkillList[randomNum];
    }

}
