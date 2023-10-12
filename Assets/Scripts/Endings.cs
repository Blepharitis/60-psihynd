using UnityEngine;

public class Endings : MonoBehaviour
{
    [SerializeField] private GameObject deadEnd;
    [SerializeField] private GameObject dayEnd;

    public void CheckEnds(Manager manager)
    {
        if(!manager.lykaPlayable && !manager.pepperPlayable
            && !manager.demianPlayable && !manager.victorPlayable)
        {
            deadEnd.SetActive(true);
            manager.enabled = false;
        }
        else if(manager.lykaPlayable || manager.pepperPlayable
            || manager.demianPlayable || manager.victorPlayable)
        {
            if (manager.day < 180) return;
            dayEnd.SetActive(true);
            manager.enabled = false;
        }
    }
}
