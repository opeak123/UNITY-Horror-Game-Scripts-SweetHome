using UnityEngine;
public class InteractUIPos : MonoBehaviour
{
    public Vector3 value;
    const float radius = 0.1f;
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + value, radius);
    }
}
