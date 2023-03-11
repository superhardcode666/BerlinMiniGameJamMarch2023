using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Junk : MonoBehaviour
{
    public bool isPickedUp;
    [SerializeField] private float homingSpeed = 50f;
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        transform.localScale = new Vector3(1, 1, 1) * Random.Range(1f, 2f);
    }

    private void MoveToPlayer()
    {
        Vector3 playerPos = PlayerController.Instance.transform.position;
        float size = JunkCollector.Instance.size * 0.025f;
        
        if (Vector3.Distance(transform.position, playerPos) > size)
        {
            var step =  homingSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, playerPos, step);
        }
        else
        {
            transform.parent = PlayerController.Instance.transform;
            _trailRenderer.emitting = false;
        }
    }

    private void Update()
    {
        if (isPickedUp)
        {
            MoveToPlayer();
        }
    }
}
