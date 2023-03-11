using System;
using UnityEngine;

public class JunkCollector : MonoBehaviour
{
    [SerializeField] private float size;
    public event Action<float> OnSizeChange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Junk"))
        {
            var newJunk = other.GetComponent<Junk>();
            newJunk.isPickedUp = true;

            other.transform.parent = transform;
            size += other.transform.localScale.magnitude;

            OnSizeChange?.Invoke(size);
        }
    }
}