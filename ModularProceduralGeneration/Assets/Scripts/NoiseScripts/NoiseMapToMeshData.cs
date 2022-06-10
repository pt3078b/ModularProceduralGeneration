using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMapToMeshData : MonoBehaviour
{
    public static MeshData OnGenerateTerrainMesh(float[,] heightMap, float scale)
    {
        int widthX = heightMap.GetLength(0);
        int heightY = heightMap.GetLength(1);
        int vertIndex = 0; // Current index of verticies

        MeshData _meshData = new MeshData(widthX, heightY);

        float topLeftX = (widthX - 1) / -2f;
        float topLeftZ = (heightY - 1) / 2f;

        for (int y = 0; y < heightY; y++)
        {
            for (int x = 0; x < widthX; x++)
            {
                // v Calculates the heigth of terrain - Turn this into a function that is a set of rules to manipulate the terrain
                _meshData.verts[vertIndex] = new Vector3(topLeftX + x, (heightMap[x, y]) * scale, topLeftZ - y); // Calculate current vertex vector
                _meshData.uvs[vertIndex] = new Vector2(x / (float)widthX, y / (float)heightY);


                if (x < (widthX - 1) && y < (heightY - 1)) // Not left edge and not bottom edge create triangle
                {
                    _meshData.OnAddNewTriangle(vertIndex, vertIndex + widthX + 1, vertIndex + widthX);
                    _meshData.OnAddNewTriangle(vertIndex + widthX + 1, vertIndex, vertIndex + 1);
                }

                // i --------- (i+1)
                // |  \          |
                // |   \         |
                // |    \        |
                // |     \       |
                // |      \      |
                // |       \     |
                // |        \    |
                // |         \   |                  i == vertex index
                // (i+W) ----- (i + W + 1)          W == width(int) number of verticies across


                vertIndex++;
            }
        }


        return _meshData;

    }


}

/// <summary>
/// Helper class to construct meshes
/// </summary>
public class MeshData
{
    public Vector3[] verts;
    public int[] tris;

    public Vector2[] uvs;

    private int triangleIndex;

    public MeshData(int meshWidthX, int meshHeightY)
    {
        verts = new Vector3[meshWidthX * meshHeightY];
        tris = new int[(meshWidthX - 1) * (meshHeightY - 1) * 6];
        uvs = new Vector2[meshWidthX * meshHeightY];
    }

    public void OnAddNewTriangle(int vertA, int vertB, int vertC)
    {
        tris[triangleIndex] = vertA;
        tris[triangleIndex + 1] = vertB;
        tris[triangleIndex + 2] = vertC;
        triangleIndex += 3;

    }

    public Mesh OnGenerateMeshObject()
    {
        Mesh newMesh = new Mesh();
        newMesh.vertices = verts;
        newMesh.triangles = tris;
        newMesh.uv = uvs;
        newMesh.RecalculateNormals();

        return newMesh;
    }




}
