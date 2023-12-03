using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : MonoBehaviour
{
    public ColorData colorData;
    public ColorType colorType;
    public Renderer renderer;
   
    public void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        renderer.material = colorData.GetColorMaterial(colorType);
    }
    //public void RandomColor()
    //{
    //    ColorType colorTypeRandom = (ColorType)Random.Range(1, System.Enum.GetValues(typeof(ColorType)).Length - 1);

    //    Material randomMaterial = colorData.GetColorMaterial(colorTypeRandom);
    //    this.colorType = colorTypeRandom;
    //    renderer.material = randomMaterial;
    //}
 



}
