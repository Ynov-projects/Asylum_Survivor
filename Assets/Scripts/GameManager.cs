using System.Collections;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Item[] items;

    public bool isLightOn;

    [SerializeField] private Light flashLight;

    public Animator batteryAnimator;

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

    }
}
