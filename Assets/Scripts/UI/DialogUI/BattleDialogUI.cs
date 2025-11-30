using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BattleDialogUI : MonoBehaviour
{
    private TextMeshProUGUI DialogText;
    private TextMeshProUGUI NameText;
    private UnityEngine.UI.Image CharacterPortrait;
    // Start is called before the first frame update
    void Start()
    {
        DialogText = GameObject.Find("DialogBg/BattleDialogContentText").GetComponent<TextMeshProUGUI>();
        NameText = GameObject.Find("NameBg/NameText").GetComponent <TextMeshProUGUI>();
        CharacterPortrait = GameObject.Find("BattleCharacterIcon").GetComponent< UnityEngine.UI.Image> ();

        SetDialogLine(DialogManager.Instance.ChangeDialogLine());
    }

    public void SetDialogLine(DialogLine dialogLine)
    {
        DialogText.text = dialogLine.DialogContentText;
        NameText.text = dialogLine.CharacterName;
        CharacterPortrait.sprite = dialogLine.CharacterPortrait;
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void OnButtonClicked()
    {
        DialogLine newDialogLine = DialogManager.Instance.ChangeDialogLine();
        if (newDialogLine == null)
        {
            Hide();
            return;
        }
        SetDialogLine(newDialogLine);
    }
}
