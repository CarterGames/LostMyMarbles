using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Custom Marble Data", menuName = "LostMyMarbles/Custom Marble Data")]
public class MarbleData : ScriptableObject
{
    public float R;
    public float G;
    public float B;
    public float A;
    public int Number;

    // Return the current colour
    public Color GetColour()
    {
        return new Color(R, G, B, A);
    }

    // Allow the Colour to be set elsewhere in code
    public void SetColour(Image Input)
    {
        R = Input.color.r;
        G = Input.color.g;
        B = Input.color.b;
        A = Input.color.a;
    }

    // Retun the current number
    public int GetTexture()
    {
        return Number;
    }

    // All the Texture to be set elsewhere in code
    public void SetTexture(int Input)
    {
        Number = Input;
    }
}
