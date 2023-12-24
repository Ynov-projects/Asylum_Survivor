using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Item[] items;

    public bool isLightOn;

    [SerializeField] private Light flashLight;
    [SerializeField] private Animator batteryAnimator;

    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private TextMeshProUGUI endTitle;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isLightOn = !isLightOn && items[1].Quantity > 0;
        }
        if (isLightOn)
        {
            batteryAnimator.speed = 1;
            batteryAnimator.SetTrigger("switchOn");
            flashLight.intensity = 5;
        }
        else
        {
            batteryAnimator.speed = 0;
            flashLight.intensity = 0;
        }
    }

    private void Start()
    {
        foreach (Item item in items) item.Quantity = 0;
    }

    public void UpdateBattery()
    {
        batteryAnimator.SetBool("hasBattery", items[1].Quantity > 0);
    }

    public void Death()
    {
        endTitle.text = "YOU LOSE!";
        displayPanel();
    }

    private void displayPanel()
    {
        Time.timeScale = 0;
        MouseInteraction.Instance.enabled = false;
        endGamePanel.SetActive(true);
    }

    public void Win()
    {
        endTitle.text = "YOU WIN!";
        displayPanel();
    }
}
