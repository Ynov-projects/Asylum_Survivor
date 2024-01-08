using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Item[] items;

    public bool isLightOn;

    [SerializeField] private Light flashLight;
    [SerializeField] private Animator batteryAnimator;

    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject keyPanel;
    [SerializeField] private TextMeshProUGUI endTitle;

    [SerializeField] private GameObject[] batteries;
    [SerializeField] private GameObject[] pills;
    [SerializeField] private GameObject[] keys;

    [SerializeField] private AudioMixerSnapshot ingame;
    [SerializeField] private AudioMixerSnapshot menu;

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
        Cursor.visible = false;
        foreach (Item item in items) item.Quantity = 0;
        activateElements(6, batteries);
        activateElements(2, pills);
        activateElements(1, keys);
    }

    private void activateElements(int numberOfElements, GameObject[] items)
    {
        for (int i = 0; i < numberOfElements; i++)
        {
            int rand = Random.Range(0, items.Length);
            while (items[rand].activeSelf == true)
            {
                rand = Random.Range(0, items.Length);
            }
            items[rand].SetActive(true);
        }
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
        menu.TransitionTo(0);
        Time.timeScale = 0;
        Cursor.visible = true;
        GetCollectible.Instance.enabled = false;
        CameraFollow.Instance.enabled = false;
        endGamePanel.SetActive(true);
    }

    public void replay()
    {
        ingame.TransitionTo(0);
        Time.timeScale = 1;
        Cursor.visible = false;
        GetCollectible.Instance.enabled = true;
        CameraFollow.Instance.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Win()
    {
        endTitle.text = "YOU WIN!";
        displayPanel();
    }

    public void getKey()
    {
        keyPanel.SetActive(true);
    }
}
