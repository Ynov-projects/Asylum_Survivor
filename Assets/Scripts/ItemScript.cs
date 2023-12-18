using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] private Item item;

    public void OnClick()
    {
        Destroy(gameObject);
        item.Quantity++;
        GameManager.Instance.UpdateBattery(item.Quantity);
    }
    
    public void looseBattery()
    {
        item.Quantity--;
        Debug.Log(item.Quantity);
        GameManager.Instance.isLightOn = false;
        GameManager.Instance.UpdateBattery(item.Quantity);
    }
}
