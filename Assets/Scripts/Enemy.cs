using UnityEditor.Overlays;
using UnityEngine;

public abstract class Enemy : Character
{
    public int DamageHit { get; protected set; }
    public abstract void Behavior();
    
}
