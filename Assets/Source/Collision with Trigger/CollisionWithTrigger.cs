using UnityEngine;

public class CollisionWithTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
}
