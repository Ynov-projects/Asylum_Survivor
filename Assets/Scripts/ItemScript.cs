using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] private Items item;

    public void Start()
    {
        item.Quantity = 0;
    }

    public void OnClick()
    {
        Destroy(gameObject);
        item.Quantity++;
    }
}
