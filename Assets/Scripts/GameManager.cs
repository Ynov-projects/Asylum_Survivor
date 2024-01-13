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
    [SerializeField] private TextMeshProUGUI endTitle;

    [SerializeField] private GameObject[] batteries;
    [SerializeField] private GameObject[] batteriesUp;
    [SerializeField] private GameObject[] batteriesDown;

    [SerializeField] private GameObject[] pills;
    [SerializeField] private GameObject[] keys;

    [SerializeField] private AudioMixerSnapshot ingame;
    [SerializeField] private AudioMixerSnapshot menu;

    [SerializeField] private TextMeshProUGUI[] infos;

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
        if(Input.GetKeyDown(KeyCode.P) && items[2].Quantity > 0) 
        {
            items[2].Quantity--;
            PlayerMentalHealth.Instance.takeMedicine();
            PlayerMentalHealth.Instance.UpdateMentalHealth();
            UIManager.Instance.UpdatePills();
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
        int difficulty = PlayerPrefs.GetInt("difficulty");
        RenderSettings.ambientLight = difficulty > 3 ? new Color(0.4f, 0.4f, 0.4f) : new Color(0.08f, 0.04f, 0.04f);
        Cursor.visible = false;
        foreach (Item item in items) item.Quantity = 0;
        activateElements(4 - difficulty, batteries);
        activateElements(3 - difficulty, batteriesUp);
        activateElements(2 - difficulty, batteriesDown);
        activateElements(4 - difficulty, pills);
        activateElements(4, keys);
        foreach (TextMeshProUGUI info in infos) info.text = Traductions.getTraduction(info.name);
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
}
