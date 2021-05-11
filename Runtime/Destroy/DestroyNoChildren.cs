using UnityEngine;

public class DestroyNoChildren : MonoBehaviour
{
    private void Update()
    {
        if (transform.childCount < 1)
            Destroy(gameObject);
    }
}
