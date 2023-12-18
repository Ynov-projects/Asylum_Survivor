using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/items")]
public class Item : ScriptableObject
{
    public int Id;
    public string Name;
    public GameObject Prefab;
    public Sprite icon;

    public int Quantity = 0;
    public int usedQuantity = 0;
}
