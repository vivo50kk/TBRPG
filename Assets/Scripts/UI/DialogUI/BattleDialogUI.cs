using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleDialogUI : MonoBehaviour
{
    private TextMeshProUGUI DialogText;
    private TextMeshProUGUI NameText;
    private Sprite CharacterPortrait;
    // Start is called before the first frame update
    void Start()
    {
        DialogText = GameObject.Find("DialogBg/BattleDialogContentText").GetComponent<TextMeshProUGUI>();
        NameText = GameObject.Find("NameBg/NameText").GetComponent <TextMeshProUGUI>();
        CharacterPortrait = GameObject.Find("BattleCharacterIcon").GetComponent<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
