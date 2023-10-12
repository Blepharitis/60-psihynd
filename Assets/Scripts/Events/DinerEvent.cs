using UnityEngine;

[CreateAssetMenu(menuName = "Events/Diner Event")]
public class DinerEvent : ScriptableObject
{
    public string text;
    public float[] changes;
    public int dayPlayable;
}
