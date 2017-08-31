
using UnityEngine;
[System.Serializable]
public class SkinColor
{
    public double R { get; set; }// skin color r channel
    public double G { get; set; }// skin color g channel
    public double B { get; set; }// skin color b channel

    public static SkinColor transfer(Color color)
    {
        SkinColor sc = new SkinColor();
        sc.R = color.r;
        sc.G = color.g;
        sc.B = color.b;
        return sc;
    }

    public Color color()
    {
        return new Color((float)this.R, (float)this.G, (float)this.B);
    }
}