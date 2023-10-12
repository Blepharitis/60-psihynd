using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Craft")]
public class Craft : ScriptableObject
{
    public Item item1;
    public Item item2;
    public int chance;

    public Item itemResult;
}
