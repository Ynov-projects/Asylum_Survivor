using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/items")]
public class Item : ScriptableObject
{
    public int Id;
    public string Name;
    public GameObject Prefab;

    public int Quantity = 0;
}
