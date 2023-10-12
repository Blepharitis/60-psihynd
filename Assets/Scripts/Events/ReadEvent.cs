using UnityEngine;

[CreateAssetMenu(menuName = "Events/Read Event")]
public class ReadEvent : ScriptableObject
{
    public string text;
    public float[] changes;
}
