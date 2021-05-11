using UnityEngine;

[CreateAssetMenu(fileName = "Vector2Variable", menuName = "Variable/Vector2")]
public class Vector2Variable : VariableBase<Vector2>
{
    public float X => Value.x;
    public float Y => Value.y;

    public void SetValue(float x, float y)
    {
        variableValue.x = x;
        variableValue.y = y;
    }
}