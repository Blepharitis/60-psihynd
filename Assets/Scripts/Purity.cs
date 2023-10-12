using UnityEngine;
using UnityEngine.UI;

public class Purity : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text text;
    [SerializeField] private float amount;
    [SerializeField] private float[] changes;

    public void ChangePurity(Inventory inventory, Indicator indicator)
    {
        if (inventory.FindItemForType(2) && amount + 2 <= 100) amount += 2;
        else if(!inventory.FindItemForType(2) && amount - 2 >= 0) amount -= 2; 
        image.fillAmount = amount / 100;
        text.text = amount.ToString();

        if(amount <= 0)
        {
            for (int i = 0; i < indicator.changes.Length; i++)
            {
                indicator.changes[i] += changes[i];
            }
        }
    }
}
