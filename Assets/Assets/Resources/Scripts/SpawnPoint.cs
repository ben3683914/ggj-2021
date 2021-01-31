using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{
    public float width = 0.5f;

    public Color GizmoColor;

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Gizmos.color = GizmoColor;

        //draw force application point
        Gizmos.DrawWireSphere(transform.position, width);

        Gizmos.color = Color.white;
#endif
    }
}
