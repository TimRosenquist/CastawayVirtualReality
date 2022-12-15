using UnityEngine;

public class Item : MonoBehaviour
{
    public Vector3 slotPosition, slotRotation, slotScale, originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }
}
