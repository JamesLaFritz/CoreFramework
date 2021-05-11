using UnityEngine;

[CreateAssetMenu(fileName = "BoundsVariable", menuName = "Variable/Bounds")]
public class BoundsVariable : VariableBase<Bounds>
{
    public Vector3 Max => Value.max;

    public Vector3 Min => Value.min;
}