using UnityEngine;

public class BaseInteractable : Interactable
{
    protected override void OnInteract()
    {
        Debug.Log($"Interacted with BaseInteractable: {name}");
    }
}
