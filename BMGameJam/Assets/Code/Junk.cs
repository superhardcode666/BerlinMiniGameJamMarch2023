using UnityEngine;

public class Junk : MonoBehaviour
{
    public bool isPickedUp;
    [SerializeField] private float homingSpeed;
    
    private void MoveToPlayer()
    {
        // if (Vector3.Distance(transform.position, PlayerController.playerPos) > 0.001f)
        // {
        //     Vector3.MoveTowards(transform.position, PlayerController.playerPos, homingSpeed);
        // }
        // else
        // {
        //     transform.parent = transform;
        //     // switch off collider?
        // }
    }

    private void Update()
    {
        if (isPickedUp)
        {
            MoveToPlayer();
        }
    }
}
