using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OreManager))]
[CanEditMultipleObjects]
public class OreManagerEditor : Editor
{
    OreManager oreManager;
    void OnEnable()
    {
        oreManager = (OreManager)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        #region Reload Materials
        if (GUILayout.Button("Reload Material IDs"))
        {
            foreach (OreResourceObject oreResource in oreManager.ores)
            {
                if (oreResource != null)
                {
                    foreach (MaterialResourceObject materialResource in oreResource.materialResourceObjects)
                    {
                        if (materialResource != null)
                        {
                            materialResource.Init();
                        }
                    }
                }
            }
        }
        #endregion

        foreach (OreResourceObject oreResource in oreManager.ores)
        {
            if (oreResource != null)
            {
                if (oreResource.tile == null) {
                    EditorGUILayout.LabelField($"{oreResource.name} with the ore name of {oreResource.oreName} doesn't have a defined tile");
                }
            }
        }
   

    }
}