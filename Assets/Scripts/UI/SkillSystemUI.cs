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

    private bool isSkillExecuting = false;
    // Start is called before the first frame update
    //单例模式
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
        isSkillExecuting = false;
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        ShowSkillList();
        this.gameObject.SetActive(true);

    }

    public void ShowSkillList()
    {
        ClearSkillList();
        for (int i = 0; i < skillManager.SkillCount(); i++)
        {
            SkillSO skill = skillManager.SkillShow(i);
            GameObject skillUIObj = Instantiate(SkillPerfab, content.transform);
            SkillUI skillUI = skillUIObj.GetComponent<SkillUI>();
            skillUI.InitSkill(skill);
        }
    }
    private void ClearSkillList()
    {
        // 方法1: 反向遍历销毁（推荐，避免修改集合问题）
        for (int i = content.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }

        // 或者使用方法2: 使用临时列表
        // List<GameObject> children = new List<GameObject>();
        // foreach (Transform child in content.transform)
        // {
        //     children.Add(child.gameObject);
        // }
        // foreach (GameObject child in children)
        // {
        //     Destroy(child);
        // }
    }

    public bool IsExecuting()
    {
        return isSkillExecuting;
    }

    public void ExecutingSkill()
    {
        isSkillExecuting = true;
    }

}
