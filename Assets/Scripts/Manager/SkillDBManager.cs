using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDBManager : MonoBehaviour
{
    public static SkillDBManager Instance { get; private set; }

    public SkillDBSO skillDB;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject); return;
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
