using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Blinck : MonoBehaviour
{
    public GameObject MainLamp;
    public Sprite Lamp1;
    public Sprite Lamp2;
    public void OnClick()
    {
        StartCoroutine(Blick());
    }
    IEnumerator Blick()
    {
        MainLamp.GetComponent<Image>().sprite = Lamp1;
        yield return new WaitForSeconds(0.1f);
        MainLamp.GetComponent<Image>().sprite = Lamp2;
        yield return new WaitForSeconds(0.1f);
        MainLamp.GetComponent<Image>().sprite = Lamp1;
    }
}
