using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public TextMeshProUGUI skillNameText;
    public TextMeshProUGUI skillDescriptionText;
    
    private SkillSO skill;

    public void InitSkill(SkillSO _skill)
    {
        skill = _skill;
        skillNameText.text = skill.skillName;
        skillDescriptionText.text = skill.MagicCost.ToString()+"/"+skill.healthCost.ToString();
        
    }

    public void OnButtonClick()
    {
        Debug.Log("Skill Button Clicked: " + skill.skillName);
        BattleSystem.Instance.SkillExecute(skill);

    }
}
