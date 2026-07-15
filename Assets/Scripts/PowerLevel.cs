using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects / Power Levels")]
public class PowerLevel : ScriptableObject
{
    public int amount;

    public void Apply(Collision collision)
    {
        collision.gameObject.GetComponent<PowerCore>().powerLevel += amount;
    }
}
