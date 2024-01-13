using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerMentalHealth : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int maxLife;

    private int noLight;

    [SerializeField] private Volume volume;

    private ChromaticAberration aberration;
    private LensDistortion distortion;

    [SerializeField] private Image _stressImage;
    [SerializeField] private RectTransform _stressBackground;
    [SerializeField] private Gradient _stressGradient;

    private int timer;

    public static PlayerMentalHealth Instance;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    void Start()
    {
        life = maxLife;
        volume.profile.TryGet<ChromaticAberration>(out aberration);
        volume.profile.TryGet<LensDistortion>(out distortion);
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
            if (timer > 2)
            {
                // If no flashlight and no global light = 1 / else = 0
                int light = (!GameManager.Instance.isLightOn ? 1 : 0) * (!SwitchLights.Instance.isLightOn ? 1 : 0);

                noLight = noLight * light + light;

                int amount = noLight;
                UpdateStressAmount(amount);
            }
            else
            {
                timer += 1;
            }
            yield return new WaitForSeconds(3);
        }
    }

    public float getStress()
    {
        return (float)life / (float)maxLife;
    }

    private void UpdateStressAmount(int amount)
    {
        // If less than 0 = 0 / else if > maxlife = maxlife / else life - amount
        life = life - amount <= 0 ? 0 : life - amount > maxLife ? maxLife : life - amount;

        Vector3 CurrentScale = _stressBackground.localScale;
        CurrentScale.x = (float)life / (float)maxLife;
        _stressBackground.localScale = CurrentScale;

        _stressImage.color = _stressGradient.Evaluate(CurrentScale.x);
        aberration.intensity.value = (float)(maxLife - life) / (float)maxLife;
        distortion.intensity.value = -((float)(maxLife - life) / (float)maxLife) / 2;

        if (life <= 0) GameManager.Instance.Death();
    }

    public void takeMedicine()
    {
        life += life + 20 > maxLife ? maxLife : life + 20;
    }
}