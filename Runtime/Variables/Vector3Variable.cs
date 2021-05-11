using UnityEngine;

[CreateAssetMenu(fileName = "Vector3Variable", menuName = "Variable/Vector3")]
public class Vector3Variable : VariableBase<Vector3>
{
    public float X => Value.x;
    public float Y => Value.y;
    public float Z => Value.z;

    public void SetValue(float x, float y, float z)
    {
        variableValue.x = x;
        variableValue.y = y;
        variableValue.z = z;
    }

    public void SetValue(float x, float y)
    {
        SetValue(x, y, Z);
    }
}