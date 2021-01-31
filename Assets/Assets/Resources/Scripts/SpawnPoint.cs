using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{
    MeshRenderer mesh;
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

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }
}
