using UnityEngine;

public class Gizmo : MonoBehaviour
{
    [SerializeField] [Range(10,200)] private float m_rad;
    void OnDrawGizmosSelected()
    {
#if UNITY_EDITOR
        Gizmos.color = Color.red;
 
        //draw force application point
        Gizmos.DrawWireSphere(transform.position, m_rad);
 
        Gizmos.color = Color.white;
#endif
    }
}
