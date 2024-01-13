using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private int code;
    [SerializeField] private TextMeshProUGUI[] numberPanels;

    [SerializeField] private TextMeshProUGUI keyText;
    [SerializeField] private TextMeshProUGUI batteryText;
    [SerializeField] private TextMeshProUGUI pillsText;

    [SerializeField] private Animator batteryAnimator;
    [SerializeField] private Item key;
    [SerializeField] private Item battery;
    [SerializeField] private Item pills;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        code = Random.Range(0, 999);
        int emplacement = Random.Range(0, 3);
        int hundreds = code / 100;
        numberPanels[3 * emplacement].text = hundreds.ToString();
        numberPanels[3 * emplacement + 1].text = ((code - hundreds * 100) / 10).ToString();
        numberPanels[3 * emplacement + 2].text = (code % 10).ToString();
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

    public void UpdatePills()
    {
        pillsText.text = pills.Quantity + "x";
    }

    public int GetCode()
    {
        return code;
    }
}
