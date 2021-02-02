using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    [SerializeField]
    private Material[] skyboxMaterials;

    [SerializeField]
    private int skyboxMaterialsIndex;


    public void ChangeSkybox()
    {
        if(skyboxMaterialsIndex == 999)
        {
            RenderSettings.skybox = skyboxMaterials[RandomSelectIndexOfSkyboxMaterials()];
        }
        else 
        {
            RenderSettings.skybox = skyboxMaterials[skyboxMaterialsIndex];
        }
    }

    public int RandomSelectIndexOfSkyboxMaterials()
    {
        return Random.Range(0, skyboxMaterials.Length);
    }
}
