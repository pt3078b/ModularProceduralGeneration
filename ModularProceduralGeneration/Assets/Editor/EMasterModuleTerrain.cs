using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(MasterModuleTerrain))]
public class EMasterModuleTerrain : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        MasterModuleTerrain window = (MasterModuleTerrain)target;
        if (DrawDefaultInspector())
        {
            if (window.autoGenerate)
            {
                window.OnMasterGenerate();
            }
        }

        if (GUILayout.Button("Generate Manually"))
        {
            window.OnMasterGenerate();
        }

        if(GUILayout.Button("Export To Terrain"))
        {
            window.OnExportToTerrainMesh();
        }

    }
}
