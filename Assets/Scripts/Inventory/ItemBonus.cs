using UnityEngine;

public class ItemBonus : MonoBehaviour
{
    [Header("Hygiene")]
    [SerializeField] private int lifeHygiene;
    [SerializeField] private int thisLifeTimeHygiene;

    private void Start()
    {
        thisLifeTimeHygiene = lifeHygiene;
    }

    public void BonusNewDay(Inventory inventory, Indicator indicator)
    {
        // Есть ли у нас средство гигиены
        if(inventory.FindItemForType(2))
        {
            thisLifeTimeHygiene--;
            if(thisLifeTimeHygiene <= 0)
            {
                inventory.RemoveItemForType(2);
                thisLifeTimeHygiene = lifeHygiene;
            }
        }
        else
        {
            thisLifeTimeHygiene = lifeHygiene;
        }

        for (int i = 0; i < indicator.changes.Length; i++)
        {
            indicator.changes[i] = indicator.defaultChanges[i];
        }
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (inventory.items[i].GetComponent<ItemSlot>().GetItem().itemType == 3)
            {
                for(int j = 0; j < indicator.changes.Length; j++)
                {
                    indicator.changes[j] += inventory.items[i].GetComponent<ItemSlot>().GetItem().itemBonus[j];
                }
            }
        }
    }
}
