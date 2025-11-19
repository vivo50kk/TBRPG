using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BloodBarUI : MonoBehaviour
{
    public Slider bloodBarSlider;
    public TextMeshProUGUI HealthValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHP(int MaxHealth,int CurrentHealth)
    {
        bloodBarSlider.maxValue = MaxHealth;
        bloodBarSlider.value = CurrentHealth;
        HealthValue.text = CurrentHealth.ToString() + "/" + MaxHealth.ToString();
    }
}
