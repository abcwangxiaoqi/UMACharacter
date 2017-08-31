
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UMA;
//public class CharacterDna : ICharacterDna
//{
//    UMADnaHumanoid umaDna;
//    UMAData umaData;
//    ICharacterAnim characterAnim;
//    CharacterData characterData;
//    public CharacterDna(UMADnaHumanoid _umaDna, UMAData _umaData,ICharacterAnim _characterAnim, CharacterData _characterData)
//    {
//        characterData = _characterData;
//        umaDna = _umaDna;
//        umaData = _umaData;
//        characterAnim = _characterAnim;
//        Update();
//    }

//    public void changeDna(EnumUmaParamters dna, float dnaValue)
//    {

//        bool isUpdate = false;

//        DnaItem udd = UmaDnaConst.dnaItemDic[dna];
//        if (dnaValue < udd.min)
//        {
//            dnaValue = udd.min;
//        }
//        if (dnaValue > udd.max)
//        {
//            dnaValue = udd.max;
//        }

//        switch (dna)
//        {
//            case EnumUmaParamters.armLength:
//                isUpdate = IsUpdate(ref umaDna.armLength, dnaValue);
//                break;
//            case EnumUmaParamters.armWidth:
//                isUpdate = IsUpdate(ref umaDna.armWidth, dnaValue);
//                break;
//            case EnumUmaParamters.belly:
//                isUpdate = IsUpdate(ref umaDna.belly, dnaValue);
//                break;
//            case EnumUmaParamters.breastSize:
//                isUpdate = IsUpdate(ref umaDna.breastSize, dnaValue);
//                break;
//            case EnumUmaParamters.cheekPosition:
//                isUpdate = IsUpdate(ref umaDna.cheekPosition, dnaValue);
//                break;
//            case EnumUmaParamters.cheekSize:
//                isUpdate = IsUpdate(ref umaDna.cheekSize, dnaValue);
//                break;
//            case EnumUmaParamters.chinPosition:
//                isUpdate = IsUpdate(ref umaDna.chinPosition, dnaValue);
//                break;
//            case EnumUmaParamters.chinPronounced:
//                isUpdate = IsUpdate(ref umaDna.chinPronounced, dnaValue);
//                break;
//            case EnumUmaParamters.chinSize:
//                isUpdate = IsUpdate(ref umaDna.chinSize, dnaValue);
//                break;
//            case EnumUmaParamters.earsPosition:
//                isUpdate = IsUpdate(ref umaDna.earsPosition, dnaValue);
//                break;
//            case EnumUmaParamters.earsRotation:
//                isUpdate = IsUpdate(ref umaDna.earsRotation, dnaValue);
//                break;
//            case EnumUmaParamters.earsSize:
//                isUpdate = IsUpdate(ref umaDna.earsSize, dnaValue);
//                break;
//            case EnumUmaParamters.eyeRotation:
//                isUpdate = IsUpdate(ref umaDna.eyeRotation, dnaValue);
//                break;
//            case EnumUmaParamters.eyeSize:
//                isUpdate = IsUpdate(ref umaDna.eyeSize, dnaValue);
//                break;
//            case EnumUmaParamters.feetSize:
//                isUpdate = IsUpdate(ref umaDna.feetSize, dnaValue);
//                break;
//            case EnumUmaParamters.forearmLength:
//                isUpdate = IsUpdate(ref umaDna.forearmLength, dnaValue);
//                break;
//            case EnumUmaParamters.forearmWidth:
//                isUpdate = IsUpdate(ref umaDna.forearmWidth, dnaValue);
//                break;
//            case EnumUmaParamters.foreheadPosition:
//                isUpdate = IsUpdate(ref umaDna.foreheadPosition, dnaValue);
//                break;
//            case EnumUmaParamters.foreheadSize:
//                isUpdate = IsUpdate(ref umaDna.foreheadSize, dnaValue);
//                break;
//            case EnumUmaParamters.gluteusSize:
//                isUpdate = IsUpdate(ref umaDna.gluteusSize, dnaValue);
//                break;
//            case EnumUmaParamters.handsSize:
//                isUpdate = IsUpdate(ref umaDna.handsSize, dnaValue);
//                break;
//            case EnumUmaParamters.headSize:
//                isUpdate = IsUpdate(ref umaDna.headSize, dnaValue);
//                break;
//            case EnumUmaParamters.headWidth:
//                isUpdate = IsUpdate(ref umaDna.headWidth, dnaValue);
//                break;
//            case EnumUmaParamters.height:
//                isUpdate = IsUpdate(ref umaDna.height, dnaValue);
//                break;
//            case EnumUmaParamters.jawsPosition:
//                isUpdate = IsUpdate(ref umaDna.jawsPosition, dnaValue);
//                break;
//            case EnumUmaParamters.jawsSize:
//                isUpdate = IsUpdate(ref umaDna.jawsSize, dnaValue);
//                break;
//            case EnumUmaParamters.legSeparation:
//                isUpdate = IsUpdate(ref umaDna.legSeparation, dnaValue);
//                break;
//            case EnumUmaParamters.legsSize:
//                isUpdate = IsUpdate(ref umaDna.legsSize, dnaValue);
//                break;
//            case EnumUmaParamters.lowCheekPosition:
//                isUpdate = IsUpdate(ref umaDna.lowCheekPosition, dnaValue);
//                break;
//            case EnumUmaParamters.lowCheekPronounced:
//                isUpdate = IsUpdate(ref umaDna.lowCheekPronounced, dnaValue);
//                break;
//            case EnumUmaParamters.lowerMuscle:
//                isUpdate = IsUpdate(ref umaDna.lowerMuscle, dnaValue);
//                break;
//            case EnumUmaParamters.lowerWeight:
//                isUpdate = IsUpdate(ref umaDna.lowerWeight, dnaValue);
//                break;
//            case EnumUmaParamters.mandibleSize:
//                isUpdate = IsUpdate(ref umaDna.mandibleSize, dnaValue);
//                break;
//            case EnumUmaParamters.mouthSize:
//                isUpdate = IsUpdate(ref umaDna.mouthSize, dnaValue);
//                break;
//            case EnumUmaParamters.neckThickness:
//                isUpdate = IsUpdate(ref umaDna.neckThickness, dnaValue);
//                break;
//            case EnumUmaParamters.noseCurve:
//                isUpdate = IsUpdate(ref umaDna.noseCurve, dnaValue);
//                break;
//            case EnumUmaParamters.noseFlatten:
//                isUpdate = IsUpdate(ref umaDna.noseFlatten, dnaValue);
//                break;
//            case EnumUmaParamters.noseInclination:
//                isUpdate = IsUpdate(ref umaDna.noseInclination, dnaValue);
//                break;
//            case EnumUmaParamters.nosePosition:
//                isUpdate = IsUpdate(ref umaDna.nosePosition, dnaValue);
//                break;
//            case EnumUmaParamters.nosePronounced:
//                isUpdate = IsUpdate(ref umaDna.nosePronounced, dnaValue);
//                break;
//            case EnumUmaParamters.noseSize:
//                isUpdate = IsUpdate(ref umaDna.noseSize, dnaValue);
//                break;
//            case EnumUmaParamters.noseWidth:
//                isUpdate = IsUpdate(ref umaDna.noseWidth, dnaValue);
//                break;
//            case EnumUmaParamters.upperMuscle:
//                isUpdate = IsUpdate(ref umaDna.upperMuscle, dnaValue);
//                break;
//            case EnumUmaParamters.upperWeight:
//                isUpdate = IsUpdate(ref umaDna.upperWeight, dnaValue);
//                break;
//            case EnumUmaParamters.waist:
//                isUpdate = IsUpdate(ref umaDna.waist, dnaValue);
//                break;
//        }
//        if (isUpdate)
//        {
//            TaskManager.CreateTask(UpdateUMAShape()).Start();
//        }
//    }

//    public List<UmaDnaItem> getUmaDna()
//    {

//        List<UmaDnaItem> ubs = new List<UmaDnaItem>();
//        IniUmaData(ref ubs, EnumUmaParamters.armLength, umaDna.armLength);
//        IniUmaData(ref ubs, EnumUmaParamters.armWidth, umaDna.armWidth);
//        IniUmaData(ref ubs, EnumUmaParamters.belly, umaDna.belly);
//        IniUmaData(ref ubs, EnumUmaParamters.breastSize, umaDna.breastSize);
//        IniUmaData(ref ubs, EnumUmaParamters.cheekPosition, umaDna.cheekPosition);
//        IniUmaData(ref ubs, EnumUmaParamters.cheekSize, umaDna.cheekSize);
//        IniUmaData(ref ubs, EnumUmaParamters.chinPosition, umaDna.chinPosition);
//        IniUmaData(ref ubs, EnumUmaParamters.chinPronounced, umaDna.chinPronounced);
//        IniUmaData(ref ubs, EnumUmaParamters.chinSize, umaDna.chinSize);
//        IniUmaData(ref ubs, EnumUmaParamters.earsPosition, umaDna.earsPosition);
//        IniUmaData(ref ubs, EnumUmaParamters.earsRotation, umaDna.earsRotation);
//        IniUmaData(ref ubs, EnumUmaParamters.earsSize, umaDna.earsSize);
//        IniUmaData(ref ubs, EnumUmaParamters.eyeRotation, umaDna.eyeRotation);
//        IniUmaData(ref ubs, EnumUmaParamters.eyeSize, umaDna.eyeSize);
//        IniUmaData(ref ubs, EnumUmaParamters.feetSize, umaDna.feetSize);
//        IniUmaData(ref ubs, EnumUmaParamters.forearmLength, umaDna.forearmLength);
//        IniUmaData(ref ubs, EnumUmaParamters.forearmWidth, umaDna.forearmWidth);
//        IniUmaData(ref ubs, EnumUmaParamters.foreheadPosition, umaDna.foreheadPosition);
//        IniUmaData(ref ubs, EnumUmaParamters.foreheadSize, umaDna.foreheadSize);
//        IniUmaData(ref ubs, EnumUmaParamters.gluteusSize, umaDna.gluteusSize);
//        IniUmaData(ref ubs, EnumUmaParamters.handsSize, umaDna.handsSize);
//        IniUmaData(ref ubs, EnumUmaParamters.headSize, umaDna.headSize);
//        IniUmaData(ref ubs, EnumUmaParamters.headWidth, umaDna.headWidth);
//        IniUmaData(ref ubs, EnumUmaParamters.height, umaDna.height);
//        IniUmaData(ref ubs, EnumUmaParamters.jawsPosition, umaDna.jawsPosition);
//        IniUmaData(ref ubs, EnumUmaParamters.jawsSize, umaDna.jawsSize);
//        IniUmaData(ref ubs, EnumUmaParamters.legSeparation, umaDna.legSeparation);
//        IniUmaData(ref ubs, EnumUmaParamters.legsSize, umaDna.legsSize);
//        IniUmaData(ref ubs, EnumUmaParamters.lipsSize, umaDna.lipsSize);
//        IniUmaData(ref ubs, EnumUmaParamters.lowCheekPosition, umaDna.lowCheekPosition);
//        IniUmaData(ref ubs, EnumUmaParamters.lowCheekPronounced, umaDna.lowCheekPronounced);
//        IniUmaData(ref ubs, EnumUmaParamters.lowerMuscle, umaDna.lowerMuscle);
//        IniUmaData(ref ubs, EnumUmaParamters.lowerWeight, umaDna.lowerWeight);
//        IniUmaData(ref ubs, EnumUmaParamters.mandibleSize, umaDna.mandibleSize);
//        IniUmaData(ref ubs, EnumUmaParamters.mouthSize, umaDna.mouthSize);
//        IniUmaData(ref ubs, EnumUmaParamters.neckThickness, umaDna.neckThickness);
//        IniUmaData(ref ubs, EnumUmaParamters.noseCurve, umaDna.noseCurve);
//        IniUmaData(ref ubs, EnumUmaParamters.noseFlatten, umaDna.noseFlatten);
//        IniUmaData(ref ubs, EnumUmaParamters.noseInclination, umaDna.noseInclination);
//        IniUmaData(ref ubs, EnumUmaParamters.nosePosition, umaDna.nosePosition);
//        IniUmaData(ref ubs, EnumUmaParamters.nosePronounced, umaDna.nosePronounced);
//        IniUmaData(ref ubs, EnumUmaParamters.noseSize, umaDna.noseSize);
//        IniUmaData(ref ubs, EnumUmaParamters.noseWidth, umaDna.noseWidth);
//        IniUmaData(ref ubs, EnumUmaParamters.upperMuscle, umaDna.upperMuscle);
//        IniUmaData(ref ubs, EnumUmaParamters.upperWeight, umaDna.upperWeight);
//        IniUmaData(ref ubs, EnumUmaParamters.waist, umaDna.waist);
//        return ubs;
//    }

//    #region private

//    void Update()
//    {
//        List<UmaDnaItem> data = characterData.dna;

//        if (data == null)
//            return;

//        for (int i = 0; i < data.Count; i++)
//        {
//            if (data[i].dnaKey == (int)EnumUmaParamters.armLength)
//            {
//                umaDna.armLength = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.belly)
//            {
//                umaDna.belly = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.breastSize)
//            {
//                umaDna.breastSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.cheekPosition)
//            {
//                umaDna.cheekPosition = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.cheekSize)
//            {
//                umaDna.cheekSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.chinPosition)
//            {
//                umaDna.chinPosition = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.chinPronounced)
//            {
//                umaDna.chinPronounced = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.chinSize)
//            {
//                umaDna.chinSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.earsPosition)
//            {
//                umaDna.earsPosition = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.earsRotation)
//            {
//                umaDna.earsRotation = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.earsSize)
//            {
//                umaDna.earsSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.eyeRotation)
//            {
//                umaDna.eyeRotation = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.eyeSize)
//            {
//                umaDna.eyeSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.feetSize)
//            {
//                umaDna.feetSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.forearmLength)
//            {
//                umaDna.forearmLength = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.forearmWidth)
//            {
//                umaDna.forearmWidth = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.foreheadPosition)
//            {
//                umaDna.foreheadPosition = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.foreheadSize)
//            {
//                umaDna.foreheadSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.gluteusSize)
//            {
//                umaDna.gluteusSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.handsSize)
//            {
//                umaDna.handsSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.headSize)
//            {
//                umaDna.headSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.headWidth)
//            {
//                umaDna.headWidth = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.height)
//            {
//                umaDna.height = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.jawsPosition)
//            {
//                umaDna.jawsPosition = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.jawsSize)
//            {
//                umaDna.jawsSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.legSeparation)
//            {
//                umaDna.legSeparation = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.legsSize)
//            {
//                umaDna.legsSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.lipsSize)
//            {
//                umaDna.lipsSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.lowCheekPosition)
//            {
//                umaDna.lowCheekPosition = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.lowCheekPronounced)
//            {
//                umaDna.lowCheekPronounced = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.lowerMuscle)
//            {
//                umaDna.lowerMuscle = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.lowerWeight)
//            {
//                umaDna.lowerWeight = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.mandibleSize)
//            {
//                umaDna.mandibleSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.mouthSize)
//            {
//                umaDna.mouthSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.neckThickness)
//            {
//                umaDna.neckThickness = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.noseCurve)
//            {
//                umaDna.noseCurve = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.noseFlatten)
//            {
//                umaDna.noseFlatten = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.noseInclination)
//            {
//                umaDna.noseInclination = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.nosePosition)
//            {
//                umaDna.nosePosition = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.nosePronounced)
//            {
//                umaDna.nosePronounced = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.noseSize)
//            {
//                umaDna.noseSize = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.noseWidth)
//            {
//                umaDna.noseWidth = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.upperMuscle)
//            {
//                umaDna.upperMuscle = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.upperWeight)
//            {
//                umaDna.upperWeight = (float)data[i].dnaValue;
//                continue;
//            }
//            else if (data[i].dnaKey == (int)EnumUmaParamters.waist)
//            {
//                umaDna.waist = (float)data[i].dnaValue;
//                continue;
//            }
//        }
//        TaskManager.CreateTask(UpdateUMAShape()).Start();
//    }

//    bool changeDanFlag = false;
//    IEnumerator UpdateUMAShape()
//    {
//        if (changeDanFlag)
//            yield break;

//        characterAnim.recordAnim();
//        changeDanFlag = true;

//        if (umaData != null && umaData.skeleton != null)
//        {
//            umaData.isShapeDirty = true;
//            umaData.Dirty();
//        }

//        yield return null;

//        characterAnim.continueAnim();
//        changeDanFlag = false;
//    }

//    bool IsUpdate(ref float dnaV, float v)
//    {
//        if (Math.Abs(dnaV - v) > 0.02f)
//        {
//            dnaV = v;
//            return true;
//        }
//        return false;
//    }

//    void IniUmaData(ref List<UmaDnaItem> ubs, EnumUmaParamters type, float value)
//    {
//        if (value != 0.5f)
//        {
//            ubs.Add(UmaDnaItem.transfer(type, value));
//        }
//    }
//    #endregion
//}
