using UnityEngine;

public class Crafting : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Inventory inventoryScript;
    [SerializeField] private Animator animator;

    public void ChangeAnimation(int id)
    {
        switch (id)
        {
            case 1:
                animator.SetTrigger("open");
                break;
            case 2:
                animator.SetTrigger("close");
                break;
        }
    }

    public void CloseCraft()
    {
        gameObject.SetActive(false);
    }

    public void Craft(Craft craft)
    {
        if(craft.item1 != null && inventoryScript.FindItem(craft.item1))
        {
            if (craft.item2 != null && inventoryScript.FindItem(craft.item2))
            {
                if (Random.Range(1, 100) < craft.chance)
                {
                    inventoryScript.RemoveItem(craft.item1);
                    inventoryScript.RemoveItem(craft.item2);
                    inventoryScript.AddItem(craft.itemResult);
                }
                else
                {
                    if(Random.Range(1, 100) < 50) inventoryScript.RemoveItem(craft.item1);
                    if(Random.Range(1, 100) < 50) inventoryScript.RemoveItem(craft.item2);
                    Debug.Log("no chance");
                }
            }
            else
            {
                if(Random.Range(1, 100) < craft.chance)
                {
                    inventoryScript.RemoveItem(craft.item1);
                    inventoryScript.AddItem(craft.itemResult);
                }
                else
                {
                    if(Random.Range(1, 100) < 50) inventoryScript.RemoveItem(craft.item1);
                    Debug.Log("no chance");
                }
            }
        }
        else
        {
            Debug.Log("no item");
        }
    }
}
