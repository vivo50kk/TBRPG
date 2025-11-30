using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance { get; private set; }


    public DialogCharacterDBSO dialogCharacterDB;

    public TextAsset DialogText;

    private string[] rows;
    private string[] cells;
    private int DialogLineIndex = 1;

    private DialogLine newDialogLine;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); return;
        }
        Instance = this;
        ReadText();
    }

    public DialogLine ChangeDialogLine()
    {

        int CharacterID = -1;
        newDialogLine = new DialogLine();
        if (DialogLineIndex >= (rows.Length-2))
        {
            return null;
        }

        cells = rows[DialogLineIndex].Split(',');

        //分支选项待做

        CharacterID = int.Parse(cells[2]);

        newDialogLine.CharacterPortrait = dialogCharacterDB.dialogCharacterList[CharacterID].CharacterPortrait;
        newDialogLine.CharacterName = cells[3];
        newDialogLine.DialogContentText = cells[4];

        DialogLineIndex = int.Parse(cells[5]);

        return newDialogLine;
    }

    public void ReadText()
    {
        rows = DialogText.text.Split("\n");

    }
}
