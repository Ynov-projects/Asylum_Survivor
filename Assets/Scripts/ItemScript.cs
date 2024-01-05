using UnityEngine;
using UnityEngine.Events;

public class ItemScript : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private GameObject keyPanel;
    [SerializeField] private UnityEvent functionOnClick;

    public void OnClick()
    {
        functionOnClick.Invoke();
    }
    
    public void looseBattery()
    {
        item.Quantity--;
        GameManager.Instance.isLightOn = false;
        GameManager.Instance.UpdateBattery();
    }

    public void collectBattery()
    {
        Destroy(gameObject);
        item.Quantity++;
        GameManager.Instance.UpdateBattery();
    }

    public void collectKey()
    {
        Destroy(gameObject);
        keyPanel.SetActive(true); // A remplacer par un appel à la fonction du canvas permettant d'activer la clef
        item.Quantity++;
    }

    public void collectMedicine()
    {
        Destroy(gameObject);
        PlayerMentalHealth.Instance.takeMedicine();
        PlayerMentalHealth.Instance.UpdateMentalHealth();
    }
}
