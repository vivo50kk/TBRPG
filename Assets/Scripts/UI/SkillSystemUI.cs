using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class SkillSystemUI : MonoBehaviour
{
    public static SkillSystemUI Instance { get; private set; }

    public GameObject SkillPerfab;

    public SkillManager skillManager;

    private GameObject content;
    // Start is called before the first frame update
    //µ¥ÀýÄ£Ê½
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    void Start()
    {

        Hide();
        content = transform.Find("SkillSystemBg/Scroll View/Viewport/Content").gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        ShowSkillList();
        this.gameObject.SetActive(true);

    }

    public void ShowSkillList()
    {
        Debug.Log("Show Skill List"+ skillManager.SkillCount().ToString());
        for (int i = 0; i < skillManager.SkillCount(); i++)
        {
            SkillSO skill = skillManager.SkillShow(i);
            GameObject skillUIObj = Instantiate(SkillPerfab, content.transform);
            SkillUI skillUI = skillUIObj.GetComponent<SkillUI>();
            skillUI.InitSkill(skill);
        }
    }
}
