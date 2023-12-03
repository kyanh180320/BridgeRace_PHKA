using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorData", menuName = "ScriptableObjects/ColorData")]
public class ColorData : ScriptableObject
{
    public Material[] colorMaterials;
    public Material GetColorMaterial(ColorType colorType)
    {
        return colorMaterials[(int)colorType];
    }

}
