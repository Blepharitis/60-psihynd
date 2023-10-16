using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Flower : MonoBehaviour
{
    public GameObject FlowerMain;
    public GameObject Manager;
    public Sprite FlowerStage1;
    public Sprite FlowerStage2;
    public Sprite FlowerStage3;
    void Update()
    {
        if (Manager.GetComponent<Manager>().day < 3)
            FlowerMain.GetComponent<Image>().sprite = FlowerStage1;
        else if (Manager.GetComponent<Manager>().day < 5)
            FlowerMain.GetComponent<Image>().sprite = FlowerStage2;
        else if (Manager.GetComponent<Manager>().day >=5)
            FlowerMain.GetComponent<Image>().sprite = FlowerStage3;
    }
}
