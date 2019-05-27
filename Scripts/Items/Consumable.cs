using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "RPG Toolkit/Items/Consumable", order = 0)]
public class Consumable : ItemData, IInvokeEvent
{ 
    // Effects
    // Invoke
    public virtual void Invoke () 
    {
        // Do Something
    }
}