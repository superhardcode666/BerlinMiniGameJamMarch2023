using System;
using UnityEngine;

public class JunkCollector : MonoBehaviour
{
    [SerializeField] private float size;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Junk") && other.transform.localScale.magnitude <= size)

        other.transform.parent = transform;
        size += other.transform.localScale.magnitude;

        OnSizeChange?.Invoke(size);
    }

    public event Action<float> OnSizeChange;
}