using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] private Item item;

    public void OnClick()
    {
        Destroy(gameObject);
        item.Quantity++;
        GameManager.Instance.UpdateBattery();
    }
    
    public void looseBattery()
    {
        item.Quantity--;
        GameManager.Instance.isLightOn = false;
        GameManager.Instance.UpdateBattery();
    }
}
