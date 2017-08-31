
using System;
[System.Serializable]
public class DnaItem
{
    public float max;
    public float def;
    public float min;

    public DnaItem(float _def = 0.5f, float _min = 0f, float _max = 1f)
    {
        this.max = _max;
        this.def = _def;
        this.min = _min;
    }
}

[System.Serializable]
public class UmaDnaItem
{
    public int dnaKey { get; set; }
    public double dnaValue { get; set; }

    public static UmaDnaItem transfer(EnumUmaParamters _key, float _value = 0.5f)
    {
        UmaDnaItem udi = new UmaDnaItem();
        udi.dnaKey = (int)_key;

        DnaItem di = UmaDnaConst.dnaItemDic[_key];
        if (_value > di.max)
        {
            _value = di.max;
        }

        if (_value < di.min)
        {
            _value = di.min;
        }
        udi.dnaValue = Math.Round(_value, 2);
        return udi;
    }
}