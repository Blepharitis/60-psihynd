using UnityEngine;

[CreateAssetMenu(menuName = "LootEvent/Loot Event")]
public class LootType : ScriptableObject
{
    public string text;
    public float[] changes;
    public Item item;
    public int dayPlayable;
}
