using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SOFallOffData))]
public class ESOFallOffNoiseData : Editor
{
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        SOFallOffData window = (SOFallOffData)target;
        if (DrawDefaultInspector())
        {
            if (window.autoUpdate)
            {
                window.OnGenerateTexturePreview();
            }
        }

        if (GUILayout.Button("GenerateMap"))
        {
            window.OnGenerateTexturePreview();

        }


        GUILayout.Box(window.texurePreview);



    }
}
