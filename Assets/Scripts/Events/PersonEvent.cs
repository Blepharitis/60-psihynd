using UnityEngine;

[CreateAssetMenu(menuName = "Events/Person Event")]
public class PersonEvent : ScriptableObject
{
    public int eventType;
    public string text;
    public float[] lykaStats;
    public float[] pepperStats;
    public float[] demianStats;
    public float[] victorStats;

    public string resultNone;
    public string resultLyka;
    public string resultPepper;
    public string resultDemian;
    public string resultVictor;

    public string resultNo;
    public string resultYes;

    public Item[] items;
}
