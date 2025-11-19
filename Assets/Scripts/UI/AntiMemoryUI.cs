using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AntiMemoryUI : MonoBehaviour
{
    public Slider AntiMemoryBarSlider;
    public TextMeshProUGUI AntiMemoryValueText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public int SetAntiMemoryBar(int AntiMemoryValue)
    {
        AntiMemoryBarSlider.value = AntiMemoryValue;
        AntiMemoryValueText.text = AntiMemoryBarSlider.value.ToString() + "/" + AntiMemoryBarSlider.maxValue.ToString();

        return (int)AntiMemoryBarSlider.value;

    }

    public void InitAntiMemoryBar(int MaxAntiMemory)
    {
        AntiMemoryBarSlider.maxValue = MaxAntiMemory;
    }
}
