using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDataToTerrain : MonoBehaviour
{
    public MeshFilter _meshFilter;
    public MeshRenderer _meshRender;

    // Constructor
    public MeshDataToTerrain()
    {

    }

    public void OnInitComponents()
    {
        // Renderer
        MeshFilter filt = gameObject.AddComponent<MeshFilter>();
        _meshFilter = filt;

        // Renderer
        MeshRenderer meshRend = gameObject.AddComponent<MeshRenderer>();
        _meshRender = meshRend;
    }

    public void OnDrawTerrainFromMeshData(MeshData meshData)
    {
        _meshFilter.sharedMesh = meshData.OnGenerateMeshObject();
    }

    public void OnSetRendererMaterial(Texture2D colourMap)
    {
        _meshRender.sharedMaterial.mainTexture = colourMap;

        //Material mat = _meshRender.sharedMaterial;
        //mat.EnableKeyword("_NORMALMAP");
        //mat.SetTexture("_BumpMap", colourMap);     // Heightmap2Normalmap... for another day
    }
}
