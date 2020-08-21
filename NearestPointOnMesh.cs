using UnityEngine;

/// <summary>
/// Returns world position of the vertex on a Gameobject's mesh nearest to Input point
/// </summary>
public static class NearestPointOnMesh
{
    public static Vector3 NearestVertexTo(Vector3 point, GameObject Object)
    {
        Transform t = Object.transform;

        // convert point to local space
        point = t.InverseTransformPoint(point);
        Mesh mesh = Object.GetComponent<MeshFilter>().sharedMesh;

        float minDistanceSqr = Mathf.Infinity;
        Vector3 nearestVertex = Vector3.zero;
        // scan all vertices to find nearest
        foreach (Vector3 vertex in mesh.vertices)
        {
            Vector3 diff = point - vertex;
            float distSqr = diff.sqrMagnitude;
            if (distSqr < minDistanceSqr)
            {
                minDistanceSqr = distSqr;
                nearestVertex = vertex;
            }
        }
        // convert nearest vertex back to world space
        return t.TransformPoint(nearestVertex);
    }
}
