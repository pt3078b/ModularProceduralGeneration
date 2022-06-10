using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterModuleTerrain : MonoBehaviour
{
    [Tooltip("True: Changes in inpector automatically generate terrain")]
    public bool autoGenerate = false;


    [Header("Module Generation")]
    // Noise data for original generation
    [Tooltip("Noise data Scriptable Object from which perlin noise is generated from")]
    [SerializeField] public VINoise noiseData;

    

    [Header("Modules")]
    [Tooltip("List of modules to apply to heightmap data, Order relates to what oporations are applied in whuich order. Item 1 is applied first, then Item 2 ...")]
    public List<Behaviour> listOfModules = new List<Behaviour>();

    private float[,] noiseMap;

    [Header("Target Plane")]
    [Tooltip("Target Object to perform mesh generation on")]
    public GameObject terrainTarget;
    [Tooltip("Determines the difference in height bettween noise values 0 - 1. A high value will make a higher mesh")]
    public float localNoiseScale = 30f;

    [Header("Terrain Tool Export")]
    public Terrain terrain;
    public int offsetX = 0;
    public int offsetY = 0;

    public void OnMasterGenerate()
    {
        Debug.Log("Begin Generation");
        /*
                   
                     *Step by step process-
            
            1. Noise generation
            2. Heightmap
            3. Loop through MODULES in order
            MODULES
            4. Set Colours
            5. Draw to terrain
            6. Set Terrain material
            
            
            MODULES:
            
            1. Set Ocean height value == If below x set to x
            2. Add to another height map of same size == height = a+b/2
            3. Add reveins
            4. Concave mountains?
            5. More modules
            
        */

        // 1. Noise Generation + 2. heightMap
        OnGenerateNoiseMap();
        // 3. Loop through modules and process module data
        OnProcessModules();
        // 5. Draw to Terrain mesh
        OnGenerateMeshFromHeightMap();
        // 6. Set Terrain Material
        OnGenerateTextureMaterial();
        Debug.Log("Generation Succesful");
    }

    private void OnGenerateNoiseMap()
    {
        noiseMap = noiseData.OnGetNoiseMap();

    }

    private void OnGenerateNoiseMapWithOffset(Vector2 offsetFill, bool dontNormalize)
    {
        noiseMap = noiseData.OnGetNoiseMApWithOffset(offsetFill, dontNormalize);

    }

    private void OnProcessModules()
    {
        if (listOfModules.Count != 0)
        {
            foreach (IModule item in listOfModules)
            {
                if (item.OnIReturnInclude())
                {
                    noiseMap = item.OnIProcessMap(noiseMap);

                }

            }
        }
        else
        {
            Debug.LogWarning("No Modules applied! Add Modules to the Module list of MasterModuleTerrain");
        }

        
    }

    private void OnGenerateMeshFromHeightMap()
    {
        // Check for MeshDataToTerrain Component, if null add component

        if (terrainTarget.GetComponent<MeshDataToTerrain>() == null)
        {
            MeshDataToTerrain newMeshDataToTerrain =  terrainTarget.AddComponent<MeshDataToTerrain>();
            Debug.Log(newMeshDataToTerrain);

            newMeshDataToTerrain.OnInitComponents();
        }


        MeshData mesh = NoiseMapToMeshData.OnGenerateTerrainMesh(noiseMap, localNoiseScale);

        terrainTarget.GetComponent<MeshDataToTerrain>().OnDrawTerrainFromMeshData(mesh);

    }

    private void OnGenerateTextureMaterial()
    {
        // get ColourMap send to NoiseMapToTexture2D for a coloured map

        Texture2D texture2d = NoiseMapToTexture2D.OnNoiseMapToTexture(noiseMap);

        terrainTarget.GetComponent<MeshDataToTerrain>().OnSetRendererMaterial(texture2d);
    }

    public void OnExportToTerrainMeshXXX() // For Precise Placement of items
    {
        OnMasterGenerate();

        TerrainData tData = terrain.terrainData;

        tData.SetHeights(offsetX, offsetY, NormalizeNoiseMap.OnNormalizeNoiseMap(noiseMap));


    }

    public void OnExportToTerrainMesh()
    {

        OnMasterGenerate();


        float[,] map = noiseData.OnGetNoiseMap();

        int width = map.GetLength(1);
        int height = map.GetLength(0);

        float tempX = 1000 / width;
        float tempX1 = tempX % 1;
        tempX = tempX - tempX1;

        int numHorizontal = (int)tempX;

        float tempY = 1000 / height;
        float tempY1 = tempX % 1;
        tempY = tempY - tempY1;

        int numVertical = (int)tempY;

        offsetX = 0;
        offsetY = 0;

        TerrainData tData = terrain.terrainData;

        

        Vector2 noiseOffset = Vector2.zero;


        for (int i = 0; i < numHorizontal; i++)
        {
            for (int j = 0; j < numVertical; j++)
            {

                OnMasterGenerateFill(noiseOffset);

             //   tData.SetHeights(offsetX, offsetY, NormalizeNoiseMap.OnNormalizeNoiseMap(noiseMap));
                tData.SetHeights(offsetX, offsetY, noiseMap);

                offsetY += height;
                noiseOffset.x += 4;


            }

            offsetY = 0;
            noiseOffset.x = 0;


            offsetX += width;

            noiseOffset.y += 4;


        }

    }

    public void OnMasterGenerateFill( Vector2 offset)
    {
        Debug.Log("Begin Generation");
                   
        OnGenerateNoiseMapWithOffset(offset, true);
        // 3. Loop through modules and process module data
        OnProcessModules();
        // 5. Draw to Terrain mesh
        OnGenerateMeshFromHeightMap();
        // 6. Set Terrain Material
        OnGenerateTextureMaterial();
        Debug.Log("Generation Succesful");
    }




    public void OnAutomaticAddToList(Behaviour behav)
    {
        if (behav.GetComponent<IModule>() != null)
        {
            listOfModules.Add(behav);
        }
    }


}
