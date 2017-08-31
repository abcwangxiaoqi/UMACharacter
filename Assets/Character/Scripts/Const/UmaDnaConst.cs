using System.Collections.Generic;

public static class UmaDnaConst
{
    static Dictionary<EnumUmaParamters, DnaItem> _dnaItemDic;
    public static Dictionary<EnumUmaParamters, DnaItem> dnaItemDic//dna value range
    {
        get
        {
            if (_dnaItemDic == null)
            {
                _dnaItemDic = new Dictionary<EnumUmaParamters, DnaItem>();
                _dnaItemDic[EnumUmaParamters.height] = new DnaItem(0.5f,0.5f,0.6f);
                _dnaItemDic[EnumUmaParamters.headSize] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.headWidth] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.neckThickness] = new DnaItem(0.5f,0.45f,0.6f);
                _dnaItemDic[EnumUmaParamters.armLength] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.forearmLength] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.armWidth] = new DnaItem(0.5f,0.2f,0.7f);
                _dnaItemDic[EnumUmaParamters.forearmWidth] = new DnaItem(0.5f,0.2f,0.7f);
                _dnaItemDic[EnumUmaParamters.handsSize] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.feetSize] = new DnaItem(0.5f,0.4f,0.65f);
                _dnaItemDic[EnumUmaParamters.legSeparation] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.upperMuscle] = new DnaItem(0.5f,0.45f,0.55f);
                _dnaItemDic[EnumUmaParamters.lowerMuscle] = new DnaItem(0.5f,0.4f,0.6f);
                _dnaItemDic[EnumUmaParamters.upperWeight] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.lowerWeight] = new DnaItem(0.5f,0.5f,0.55f);
                _dnaItemDic[EnumUmaParamters.legsSize] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.belly] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.waist] = new DnaItem(0.5f,0.4f,0.7f);
                _dnaItemDic[EnumUmaParamters.gluteusSize] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.earsSize] = new DnaItem(0.5f,0,0.6f);
                _dnaItemDic[EnumUmaParamters.earsPosition] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.earsRotation] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.noseSize] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.noseCurve] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.noseWidth] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.noseInclination] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.nosePosition] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.nosePronounced] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.noseFlatten] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.chinSize] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.chinPronounced] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.chinPosition] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.mandibleSize] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.jawsSize] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.jawsPosition] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.cheekSize] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.cheekPosition] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.lowCheekPronounced] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.lowCheekPosition] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.foreheadSize] = new DnaItem(0.5f,0,0.6f);
                _dnaItemDic[EnumUmaParamters.foreheadPosition] = new DnaItem(0.5f,0,0.8f);
                _dnaItemDic[EnumUmaParamters.lipsSize] = new DnaItem(0.5f,0.3f,0.7f);
                _dnaItemDic[EnumUmaParamters.mouthSize] = new DnaItem(0.5f,0.2f,0.8f);
                _dnaItemDic[EnumUmaParamters.eyeRotation] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.eyeSize] = new DnaItem();
                _dnaItemDic[EnumUmaParamters.breastSize] = new DnaItem();
            }
            return _dnaItemDic;
        }
    }
}