using System;
using UnityEngine;

public class JunkCollector : MonoBehaviour
{
    public float size;
    public event Action<float> OnSizeChange;
    private SphereCollider _sphereCollider;

    public static JunkCollector Instance { get; private set; }
    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Junk"))
        {
            var newJunk = other.GetComponent<Junk>();
            newJunk.isPickedUp = true;
            
            size += other.transform.localScale.magnitude;
            //_sphereCollider.radius += 0.05f;

            OnSizeChange?.Invoke(size);
        }
    }
}