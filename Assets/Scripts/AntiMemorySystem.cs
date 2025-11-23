using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiMemorySystem : MonoBehaviour
{
    public int MaxAntiMemoryValue = 100;
    public int CurrentAntiMemoryValue = 101;
    public AntiMemoryUI antiMemoryUI;

    void Awake()
    {
        antiMemoryUI.InitAntiMemoryBar(MaxAntiMemoryValue);
    }
    public int FirstSetAntiMemory(Player player,Enemy enemy)
    {
        CurrentAntiMemoryValue = (player.BaseMemoryValue + enemy.BaseMemoryValue) / 2;
        Debug.Log("First AntiMemoryValue:" + CurrentAntiMemoryValue);
        antiMemoryUI.SetAntiMemoryBar(CurrentAntiMemoryValue);
        return CurrentAntiMemoryValue;
    }
    public void SetAntiMemory(int SkillChangeAntiMemory)
    {
        CurrentAntiMemoryValue = CurrentAntiMemoryValue + SkillChangeAntiMemory;
        antiMemoryUI.SetAntiMemoryBar(CurrentAntiMemoryValue);

    }
}
