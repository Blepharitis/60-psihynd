using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Indicator indicator;
    [SerializeField] private Notebook notebook;
    [SerializeField] private Manager manager;
    [SerializeField] private Animator animator;

    [Header("Info")]
    [SerializeField] private Text itemName;
    [SerializeField] private Text itemDescription;

    [Header("Use")]
    [SerializeField] private Toggle[] togglesUse;
    [SerializeField] private Button buttonUse;
    [SerializeField] private Item item;
    int person;

    [Header("Slots")]
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform itemParent;
    public List<GameObject> items = new List<GameObject>();

    public void ChangeAnimation(int id)
    {
        switch (id)
        {
            case 1:
                animator.SetTrigger("open");
                FMODUnity.RuntimeManager.PlayOneShot("event:/BagOpen"); //Озвучка анимаций
                break;
            case 2:
                animator.SetTrigger("close");
                FMODUnity.RuntimeManager.PlayOneShot("event:/BagClosed");
                break;
        }
    }

    public void CloseInventory()
    {
        gameObject.SetActive(false);
    }

    public void AddItem(Item _item)
    {
        if(items.Count >= 24) return;
        GameObject newItem = Instantiate(slotPrefab, itemParent);
        newItem.GetComponent<ItemSlot>().SetInventoryScript(this);
        newItem.GetComponent<ItemSlot>().SetItem(_item);
        items.Add(newItem);
    }

    public void RemoveItem(Item _item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].GetComponent<ItemSlot>().GetItem() == _item)
            {
                Destroy(items[i]);
                items.Remove(items[i].gameObject);
                return;
            }
        }
        return;
    }

    public bool FindItem(Item _item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].GetComponent<ItemSlot>().GetItem() == _item)
            {
                return true;
            }
        }
        return false;
    }

    public bool RemoveItemForType(int _itemType)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetComponent<ItemSlot>().GetItem().itemType == _itemType)
            {
                Destroy(items[i]);
                items.Remove(items[i].gameObject);
                return true;
            }
        }
        return false;
    }

    public bool FindItemForType(int _itemType)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetComponent<ItemSlot>().GetItem().itemType == _itemType)
            {
                return true;
            }
        }
        return false;
    }

    public bool FindItemForID(int id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetComponent<ItemSlot>().GetItem().id == id)
            {
                return true;
            }
        }
        return false;
    }

    public bool RemoveItemForID(int id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetComponent<ItemSlot>().GetItem().id == id)
            {
                Destroy(items[i]);
                items.Remove(items[i].gameObject);
                return true;
            }
        }
        return false;
    }

    public void SetItemInfo(Item _item)
    {
        itemName.text = _item.name;
        itemDescription.text = _item.description;
        item = _item;
    }

    public void ClearItemInfo()
    {
        itemName.text = "";
        itemDescription.text = "";
        item = null;
    }

    public void ButtonUse()
    {
        if (item == null) return;
        if (!item.usable) return;
        for (int i = 0; i < togglesUse.Length; i++)
        {
            if (togglesUse[i].isOn)
            {
                person = i + 1;
            }
        }
        Debug.Log(person);

        switch(person)
        {
            case 1:
                indicator.ChangeLyka(item.useChanges);
                notebook.AddText("Лука использовал " + item.name + ". ");
                RemoveItem(item);
                ClearItemInfo();
                person = 0;
                for (int i = 0; i < togglesUse.Length; i++)
                {
                    togglesUse[i].isOn = false;
                }
                break;
            case 2:
                indicator.ChangePepper(item.useChanges);
                notebook.AddText("Перец использовал " + item.name + ". ");
                RemoveItem(item);
                ClearItemInfo();
                person = 0;
                for (int i = 0; i < togglesUse.Length; i++)
                {
                    togglesUse[i].isOn = false;
                }
                break;
            case 3:
                indicator.ChangeDemian(item.useChanges);
                notebook.AddText("Демиан использовал " + item.name + ". ");
                RemoveItem(item);
                ClearItemInfo();
                person = 0;
                for (int i = 0; i < togglesUse.Length; i++)
                {
                    togglesUse[i].isOn = false;
                }
                break;
            case 4:
                indicator.ChangeVictor(item.useChanges);
                notebook.AddText("Виктор использовал " + item.name + ". ");
                RemoveItem(item);
                ClearItemInfo();
                person = 0;
                for (int i = 0; i < togglesUse.Length; i++)
                {
                    togglesUse[i].isOn = false;
                }
                break;
        }
    }
}
