# Unity-Helper-Tools
This is a repo full of small utility scripts I use for my client &amp; personal projects. Improvements and additions are welcome. Use at your own discretion. 



NearestPointOnMesh.cs :

Get Nearest Point on a Mesh by iterating through all vertices (Not the same as Nearest point on Collider). Although a little expensive on paper, in practice, I haven't noticed a search time longer than 20 ms or so, Even on medium end mobile devices I tested on with meshes having 3000+ faces.

Use static method "NearestVertexTo()", with first parameter being the Vector3 Input point & the second parameter being the GameObject to check vertices in. Ofcourse, A MeshFilter component with a valid Mesh must be attached to the supplied GameObject.



SubMeshCombine.cs :

Optimize/Combine Sub-Meshes with same materials (Within one MeshFilter) for performance gains. Useful if you're somehow instantiating large number of surfaces/submeshes on a mesh with all having instances of visually identical materials (Which in my case happened while using the "Mesh Slicer" asset from the Asset Store).

Use "CombineAllToOne()" static method, which, for the input mesh, combines ALL it's submeshes into one submesh, then returns this new combined Mesh, which can be assigned back to the MeshFilter in question. The first parameter is the supplied Mesh & the second is the supplied Mesh's Renderer component.
