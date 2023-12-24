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
        item.Quantity++;
    }

    public void collectMedicine()
    {
        Destroy(gameObject);
        PlayerMentalHealth.Instance.takeMedicine();
        PlayerMentalHealth.Instance.UpdateMentalHealth();
    }
}
