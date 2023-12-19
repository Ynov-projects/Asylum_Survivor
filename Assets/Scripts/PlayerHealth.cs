using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int life;
    private int maxLife = 1000;

    public bool ZombieClose;

    private int noFlashLight;
    private int noBigLights;
    private int zombieHere;

    [SerializeField] private Image _stressImage;
    [SerializeField] private RectTransform _stressBackground;
    [SerializeField] private Gradient _stressGradient;

    public static PlayerHealth Instance;

    private void Awake()
    {
        if(Instance != null) Destroy(gameObject); 
        Instance = this;
    }

    void Start()
    {
        life = maxLife;
    }

    void Update()
    {
        StartCoroutine(UpdateStress());
    }

    IEnumerator UpdateStress()
    {
        int flashLight = GameManager.Instance.isLightOn == true ? 1 : 0;
        int bigLights = SwitchLights.Instance.isLightOn == true ? 1 : 0;
        int zombie = ZombieClose == true ? 1 : 0;

        noFlashLight = noFlashLight * flashLight + flashLight;
        noBigLights = noBigLights * bigLights + bigLights;
        zombieHere = zombieHere * zombie + zombie;

        int amount = noFlashLight + noBigLights + zombieHere;

        yield return new WaitForSeconds(1f);
        life = life - amount <= 0 ? 0 : life - amount > maxLife ? maxLife : life - amount;

        Vector3 CurrentScale = _stressBackground.localScale;
        CurrentScale.x = (float)life / (float)maxLife;
        _stressBackground.localScale = CurrentScale;

        _stressImage.color = _stressGradient.Evaluate(CurrentScale.x);
    }

    public void Death()
    {
        GameManager.Instance.Death();
    }
}
