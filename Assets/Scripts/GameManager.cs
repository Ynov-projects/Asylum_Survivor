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
    [SerializeField] private TextMeshProUGUI[] buttonsUI;

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
        if (Input.GetKeyDown(KeyCode.P) && items[2].Quantity > 0)
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
        RenderSettings.ambientLight = difficulty > 3 ? new Color(0.4f, 0.4f, 0.4f) : new Color(0.032f, 0.016f, 0.016f);
        Cursor.visible = false;
        foreach (Item item in items) item.Quantity = 0;

        activateElements(4 - difficulty, batteries);
        activateElements(3 - difficulty, batteriesUp);
        activateElements(2 - difficulty, batteriesDown);
        activateElements(4 - difficulty, pills);
        activateElements(4, keys);
        
        foreach (TextMeshProUGUI info in infos) info.text = Traductions.getTraduction(info.name);
        foreach (TextMeshProUGUI info in buttonsUI) info.text = Traductions.getTraduction(info.transform.parent.name);
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

    private void displayPanel()
    {
        changeState(false);
        endGamePanel.SetActive(true);
    }

    public void changeState(bool active)
    {
        if (active) { ingame.TransitionTo(1); }
        else { menu.TransitionTo(1); }
        Cursor.visible = !active;
        GetCollectible.Instance.enabled = active;
        CameraFollow.Instance.enabled = active;
        PlayerMentalHealth.Instance.isPlaying = active;
        PlayerMovement.Instance.enabled = active;
    }

    public void replay()
    {
        changeState(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Death()
    {
        endTitle.text = Traductions.getTraduction("losing");
        displayPanel();
    }

    public void Win()
    {
        endTitle.text = Traductions.getTraduction("winning");
        displayPanel();
    }
}
