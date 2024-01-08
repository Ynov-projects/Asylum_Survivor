using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI keyText;
    [SerializeField] private TextMeshProUGUI batteryText;

    [SerializeField] private Animator batteryAnimator;
    [SerializeField] private Item key;
    [SerializeField] private Item battery;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    public void UpdateBattery()
    {
        batteryAnimator.SetBool("hasBattery", battery.Quantity > 0);
        batteryText.text = battery.Quantity + "x";
    }

    public void UpdateKeys()
    {
        keyText.text = key.Quantity + "x";
    }
}
