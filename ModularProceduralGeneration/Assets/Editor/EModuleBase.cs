using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof(ModuleBase), true)]
public class EModuleBase : Editor
{
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        ModuleBase window = (ModuleBase)target;
        
        if (DrawDefaultInspector())
        {
            MasterModuleTerrain masterModule = window.GetComponent<MasterModuleTerrain>();
            
            if (masterModule.autoGenerate)
            {
                masterModule.OnMasterGenerate();

            }

        }

        

    }
}
