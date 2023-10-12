using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Image image;
    [SerializeField] private Item item;

    private void Start()
    {
        if (item != null)
            SetItem(item);
    }

    public void SetItem(Item _item)
    {
        item = _item;
        image.sprite = item.icon;
    }

    public void SetInventoryScript(Inventory _inventory)
    {
        inventory = _inventory;
    }

    public Item GetItem()
    {
        if (item != null)
            return item;
        else
            return null;
    }

    private void OnMouseDown()
    {
        inventory.SetItemInfo(item);
    }
}
