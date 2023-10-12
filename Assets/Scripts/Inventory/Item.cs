using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public Sprite icon;
    public int id;
    public int itemType;
    public float[] itemBonus;

    public bool usable;
    public float[] useChanges;

    public string name;
    public string description;
}
