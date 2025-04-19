using UnityEngine;

namespace DefaultNamespace.Utils
{
    public class ColourUtils
    {
        public static void SetTransparency(GameObject gameObject, float transparency)
        {
            var hoverColour = gameObject.GetComponent<Renderer>().material.color;
            hoverColour.a = transparency;
            gameObject.GetComponent<Renderer>().material.color = hoverColour;
        }    
    }
}