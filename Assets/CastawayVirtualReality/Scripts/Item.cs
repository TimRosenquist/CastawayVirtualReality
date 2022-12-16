using UnityEngine;

public class Item : MonoBehaviour
{
    public Vector3 slotPosition, slotRotation, slotScale, originalScale;

    //[SerializeField]
    public bool isLog;
    //[SerializeField]
    public bool isRope;

    private void Start()
    {
        originalScale = transform.localScale;
    }
}
