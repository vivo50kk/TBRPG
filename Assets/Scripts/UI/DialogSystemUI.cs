using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystemUI : MonoBehaviour
{
    public static DialogSystemUI Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this .gameObject.SetActive(false);
    }
}
