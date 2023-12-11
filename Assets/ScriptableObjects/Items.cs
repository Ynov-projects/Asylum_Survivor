using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/items")]
public class Items : ScriptableObject
{
    public int Id;
    public string Name;
    public GameObject Prefab;
    public Sprite icon;

    public int Quantity = 0;
}
