using UnityEngine;
using UnityEngine.Events;

public class ItemScript : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private UnityEvent functionOnClick;

    public void OnClick()
    {
        functionOnClick.Invoke();
    }
    
    public void looseBattery()
    {
        item.Quantity--;
        GameManager.Instance.isLightOn = false;
        UIManager.Instance.UpdateBattery();
    }

    public void collectBattery()
    {
        Destroy(gameObject);
        item.Quantity++;
        UIManager.Instance.UpdateBattery();
    }

    public void collectKey()
    {
        Destroy(gameObject);
        item.Quantity++;
        UIManager.Instance.UpdateKeys();
    }

    public void collectMedicine()
    {
        Destroy(gameObject);
        PlayerMentalHealth.Instance.takeMedicine();
        PlayerMentalHealth.Instance.UpdateMentalHealth();
    }
}
