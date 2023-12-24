using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMentalHealth : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int maxLife;

    public int ZombieClose;
    
    private int noLight;
    private int zombieHere;

    [SerializeField] private Image _stressImage;
    [SerializeField] private RectTransform _stressBackground;
    [SerializeField] private Gradient _stressGradient;

    public static PlayerMentalHealth Instance;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    void Start()
    {
        life = maxLife;
        UpdateMentalHealth();
    }

    public void UpdateMentalHealth()
    {
        StartCoroutine(UpdateStress());
    }

    IEnumerator UpdateStress()
    {
        while (true)
        {

            // If no flashlight and no global light = 1 / else = 0
            int light = (!GameManager.Instance.isLightOn ? 1 : 0) * (!SwitchLights.Instance.isLightOn ? 1 : 0);

            // If more than one zombie = 1 / else = 0
            int zombie = ZombieClose > 0 ? 1 : 0;

            noLight = noLight * light + light;
            zombieHere = zombieHere * zombie + zombie;

            int amount = noLight + zombieHere;
            UpdateStressAmount(amount);
            yield return new WaitForSeconds(5);
        }
    }

    private void UpdateStressAmount(int amount)
    {
        // If less than 0 = 0 / else if > maxlife = maxlife / else life - amount
        life = life - amount <= 0 ? 0 : life - amount > maxLife ? maxLife : life - amount;

        Vector3 CurrentScale = _stressBackground.localScale;
        CurrentScale.x = (float)life / (float)maxLife;
        _stressBackground.localScale = CurrentScale;

        _stressImage.color = _stressGradient.Evaluate(CurrentScale.x);
    }

    public void takeMedicine()
    {
        life += life + 20 > maxLife ? maxLife : life + 20;
    }

    public void Death()
    {
        GameManager.Instance.Death();
    }
}
