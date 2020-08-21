using UnityEngine;

public static class SubMeshCombine
{
    public static Mesh CombineAllToOne(Mesh mesh, Renderer rend)
    {
        Mesh m = mesh;
        m.SetTriangles(mesh.triangles, 0);
        m.subMeshCount = 1;
        m.Optimize();

        Material mat = rend.sharedMaterials[0];
        rend.sharedMaterials = new Material[1];
        rend.sharedMaterial = mat;
        return m;
    }
}