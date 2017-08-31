using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UMA;
public class DnaPanel : MonoBehaviour
{
    #region uma dan paramters
    private Slider HeightSlider;
    private Slider UpperMuscleSlider;
    private Slider UpperWeightSlider;
    private Slider LowerMuscleSlider;
    private Slider LowerWeightSlider;
    private Slider ArmLengthSlider;
    private Slider ForearmLengthSlider;
    private Slider LegSeparationSlider;
    private Slider HandSizeSlider;
    private Slider FeetSizeSlider;
    private Slider LegSizeSlider;
    private Slider ArmWidthSlider;
    private Slider ForearmWidthSlider;
    private Slider BreastSlider;
    private Slider BellySlider;
    private Slider WaistSizeSlider;
    private Slider GlueteusSizeSlider;
    private Slider HeadSizeSlider;
    private Slider NeckThickSlider;
    private Slider EarSizeSlider;
    private Slider EarPositionSlider;
    private Slider EarRotationSlider;
    private Slider NoseSizeSlider;
    private Slider NoseCurveSlider;
    private Slider NoseWidthSlider;
    private Slider NoseInclinationSlider;
    private Slider NosePositionSlider;
    private Slider NosePronuncedSlider;
    private Slider NoseFlattenSlider;
    private Slider ChinSizeSlider;
    private Slider ChinPronouncedSlider;
    private Slider ChinPositionSlider;
    private Slider MandibleSizeSlider;
    private Slider JawSizeSlider;
    private Slider JawPositionSlider;
    private Slider CheekSizeSlider;
    private Slider CheekPositionSlider;
    private Slider lowCheekPronSlider;
    private Slider ForeHeadSizeSlider;
    private Slider ForeHeadPositionSlider;
    private Slider LipSizeSlider;
    private Slider MouthSlider;
    private Slider EyeSizeSlider;
    private Slider EyeRotationSlider;
    private Slider EyeSpacingSlider;
    private Slider LowCheekPosSlider;
    private Slider HeadWidthSlider;

    private Slider SkinRSlider;
    private Slider SkinGSlider;
    private Slider SkinBSlider;
    #endregion

    void Awake()
    {
        HeightSlider = GameObject.Find("HeightSlider").GetComponent<Slider>();
        UpperMuscleSlider = GameObject.Find("UpperMuscleSlider").GetComponent<Slider>();
        UpperWeightSlider = GameObject.Find("UpperWeightSlider").GetComponent<Slider>();
        LowerMuscleSlider = GameObject.Find("LowerMuscleSlider").GetComponent<Slider>();
        LowerWeightSlider = GameObject.Find("LowerWeightSlider").GetComponent<Slider>();
        // ArmLengthSlider = GameObject.Find("ArmLengthSlider").GetComponent<Slider>();
        // ForearmLengthSlider = GameObject.Find("ForearmLengthSlider").GetComponent<Slider>();
        LegSeparationSlider = GameObject.Find("LegSepSlider").GetComponent<Slider>();
        //HandSizeSlider = GameObject.Find("HandSizeSlider").GetComponent<Slider>();
        FeetSizeSlider = GameObject.Find("FeetSizeSlider").GetComponent<Slider>();
        LegSizeSlider = GameObject.Find("LegSizeSlider").GetComponent<Slider>();
        ArmWidthSlider = GameObject.Find("ArmWidthSlider").GetComponent<Slider>();
        ForearmWidthSlider = GameObject.Find("ForearmWidthSlider").GetComponent<Slider>();
        BreastSlider = GameObject.Find("BreastSizeSlider").GetComponent<Slider>();
        BellySlider = GameObject.Find("BellySlider").GetComponent<Slider>();
        WaistSizeSlider = GameObject.Find("WaistSizeSlider").GetComponent<Slider>();
        GlueteusSizeSlider = GameObject.Find("GluteusSlider").GetComponent<Slider>();
        HeadSizeSlider = GameObject.Find("HeadSizeSlider").GetComponent<Slider>();
        //HeadWidthSlider = GameObject.Find("HeadWidthSlider").GetComponent<Slider>();
        NeckThickSlider = GameObject.Find("NeckSlider").GetComponent<Slider>();
        EarSizeSlider = GameObject.Find("EarSizeSlider").GetComponent<Slider>();
        EarPositionSlider = GameObject.Find("EarPosSlider").GetComponent<Slider>();
        EarRotationSlider = GameObject.Find("EarRotSlider").GetComponent<Slider>();
        NoseSizeSlider = GameObject.Find("NoseSizeSlider").GetComponent<Slider>();
        NoseCurveSlider = GameObject.Find("NoseCurveSlider").GetComponent<Slider>();
        NoseWidthSlider = GameObject.Find("NoseWidthSlider").GetComponent<Slider>();
        NoseInclinationSlider = GameObject.Find("NoseInclineSlider").GetComponent<Slider>();
        NosePositionSlider = GameObject.Find("NosePosSlider").GetComponent<Slider>();
        NosePronuncedSlider = GameObject.Find("NosePronSlider").GetComponent<Slider>();
        NoseFlattenSlider = GameObject.Find("NoseFlatSlider").GetComponent<Slider>();
        //ChinSizeSlider = GameObject.Find("ChinSizeSlider").GetComponent<Slider>();
        ChinPronouncedSlider = GameObject.Find("ChinPronSlider").GetComponent<Slider>();
        ChinPositionSlider = GameObject.Find("ChinPosSlider").GetComponent<Slider>();
        // MandibleSizeSlider = GameObject.Find("MandibleSizeSlider").GetComponent<Slider>();
        JawSizeSlider = GameObject.Find("JawSizeSlider").GetComponent<Slider>();
        JawPositionSlider = GameObject.Find("JawPosSlider").GetComponent<Slider>();
        CheekSizeSlider = GameObject.Find("CheekSizeSlider").GetComponent<Slider>();
        CheekPositionSlider = GameObject.Find("CheekPosSlider").GetComponent<Slider>();
        lowCheekPronSlider = GameObject.Find("LowCheekPronSlider").GetComponent<Slider>();
        ForeHeadSizeSlider = GameObject.Find("ForeheadSizeSlider").GetComponent<Slider>();
        ForeHeadPositionSlider = GameObject.Find("ForeheadPosSlider").GetComponent<Slider>();
        LipSizeSlider = GameObject.Find("LipSizeSlider").GetComponent<Slider>();
        MouthSlider = GameObject.Find("MouthSizeSlider").GetComponent<Slider>();
        EyeSizeSlider = GameObject.Find("EyeSizeSlider").GetComponent<Slider>();
        EyeRotationSlider = GameObject.Find("EyeRotSlider").GetComponent<Slider>();
        EyeSpacingSlider = GameObject.Find("EyeSpaceSlider").GetComponent<Slider>();
        LowCheekPosSlider = GameObject.Find("LowCheekPosSlider").GetComponent<Slider>();
        SkinRSlider = GameObject.Find("RSlider").GetComponent<Slider>();
        SkinGSlider = GameObject.Find("GSlider").GetComponent<Slider>();
        SkinBSlider = GameObject.Find("BSlider").GetComponent<Slider>();

        Addlistener();
    }

    UMAData umaData;
    UMADnaHumanoid umaDna;
    UMADnaTutorial umaTutorialDna;

    public void IniatializeSlider(UMAData umadata)
    {
        if (umadata != null)
        {
            umaData = umadata;
            umaDna = umaData.GetDna<UMADnaHumanoid>();
            umaTutorialDna = umaData.GetDna<UMADnaTutorial>();
        }

        Removelistener();

        HeightSlider.value = umaDna.height;
        UpperMuscleSlider.value = umaDna.upperMuscle;
        UpperWeightSlider.value = umaDna.upperWeight;
        LowerMuscleSlider.value = umaDna.lowerMuscle;
        LowerWeightSlider.value = umaDna.lowerWeight;
        //ArmLengthSlider.value = umaDna.armLength;
        // ForearmLengthSlider.value = umaDna.forearmLength;
        LegSeparationSlider.value = umaDna.legSeparation;
        //HandSizeSlider.value = umaDna.handsSize;
        FeetSizeSlider.value = umaDna.feetSize;
        LegSizeSlider.value = umaDna.legsSize;
        ArmWidthSlider.value = umaDna.armWidth;
        ForearmWidthSlider.value = umaDna.forearmWidth;
        BreastSlider.value = umaDna.breastSize;
        BellySlider.value = umaDna.belly;
        WaistSizeSlider.value = umaDna.waist;
        GlueteusSizeSlider.value = umaDna.gluteusSize;
        HeadSizeSlider.value = umaDna.headSize;
        //HeadWidthSlider.value = umaDna.headWidth;
        NeckThickSlider.value = umaDna.neckThickness;
        EarSizeSlider.value = umaDna.earsSize;
        EarPositionSlider.value = umaDna.earsPosition;
        EarRotationSlider.value = umaDna.earsRotation;
        NoseSizeSlider.value = umaDna.noseSize;
        NoseCurveSlider.value = umaDna.noseCurve;
        NoseWidthSlider.value = umaDna.noseWidth;
        NoseInclinationSlider.value = umaDna.noseInclination;
        NosePositionSlider.value = umaDna.nosePosition;
        NosePronuncedSlider.value = umaDna.nosePronounced;
        NoseFlattenSlider.value = umaDna.noseFlatten;
        //ChinSizeSlider.value = umaDna.chinSize;
        ChinPronouncedSlider.value = umaDna.chinPronounced;
        ChinPositionSlider.value = umaDna.chinPosition;
        //MandibleSizeSlider.value = umaDna.mandibleSize;
        JawSizeSlider.value = umaDna.jawsSize;
        JawPositionSlider.value = umaDna.jawsPosition;
        CheekSizeSlider.value = umaDna.cheekSize;
        CheekPositionSlider.value = umaDna.cheekPosition;
        lowCheekPronSlider.value = umaDna.lowCheekPronounced;
        ForeHeadSizeSlider.value = umaDna.foreheadSize;
        ForeHeadPositionSlider.value = umaDna.foreheadPosition;
        LipSizeSlider.value = umaDna.lipsSize;
        MouthSlider.value = umaDna.mouthSize;
        EyeSizeSlider.value = umaDna.eyeSize;
        EyeRotationSlider.value = umaDna.eyeRotation;
        EyeSpacingSlider.value = umaTutorialDna.eyeSpacing;
        LowCheekPosSlider.value = umaDna.lowCheekPosition;

        Addlistener();
    }

    void Removelistener()
    {
        return;
        HeightSlider.onValueChanged.RemoveAllListeners();
        UpperMuscleSlider.onValueChanged.RemoveAllListeners();
        UpperWeightSlider.onValueChanged.RemoveAllListeners();
        LowerMuscleSlider.onValueChanged.RemoveAllListeners();
        LowerWeightSlider.onValueChanged.RemoveAllListeners();
        //ArmLengthSlider.onValueChanged.RemoveAllListeners();
        //ForearmLengthSlider.onValueChanged.RemoveAllListeners();
        LegSeparationSlider.onValueChanged.RemoveAllListeners();
        //HandSizeSlider.onValueChanged.RemoveAllListeners();
        FeetSizeSlider.onValueChanged.RemoveAllListeners();
        LegSizeSlider.onValueChanged.RemoveAllListeners();
        ArmWidthSlider.onValueChanged.RemoveAllListeners();
        ForearmWidthSlider.onValueChanged.RemoveAllListeners();
        BreastSlider.onValueChanged.RemoveAllListeners();
        BellySlider.onValueChanged.RemoveAllListeners();
        WaistSizeSlider.onValueChanged.RemoveAllListeners();
        GlueteusSizeSlider.onValueChanged.RemoveAllListeners();
        HeadSizeSlider.onValueChanged.RemoveAllListeners();
        //HeadWidthSlider.onValueChanged.RemoveAllListeners();
        NeckThickSlider.onValueChanged.RemoveAllListeners();
        EarSizeSlider.onValueChanged.RemoveAllListeners();
        EarPositionSlider.onValueChanged.RemoveAllListeners();
        EarRotationSlider.onValueChanged.RemoveAllListeners();
        NoseSizeSlider.onValueChanged.RemoveAllListeners();
        NoseCurveSlider.onValueChanged.RemoveAllListeners();
        NoseWidthSlider.onValueChanged.RemoveAllListeners();
        NoseInclinationSlider.onValueChanged.RemoveAllListeners();
        NosePositionSlider.onValueChanged.RemoveAllListeners();
        NosePronuncedSlider.onValueChanged.RemoveAllListeners();
        NoseFlattenSlider.onValueChanged.RemoveAllListeners();
        // ChinSizeSlider.onValueChanged.RemoveAllListeners();
        ChinPronouncedSlider.onValueChanged.RemoveAllListeners();
        ChinPositionSlider.onValueChanged.RemoveAllListeners();
        //MandibleSizeSlider.onValueChanged.RemoveAllListeners();
        JawSizeSlider.onValueChanged.RemoveAllListeners();
        JawPositionSlider.onValueChanged.RemoveAllListeners();
        CheekSizeSlider.onValueChanged.RemoveAllListeners();
        CheekPositionSlider.onValueChanged.RemoveAllListeners();
        lowCheekPronSlider.onValueChanged.RemoveAllListeners();
        ForeHeadSizeSlider.onValueChanged.RemoveAllListeners();
        ForeHeadPositionSlider.onValueChanged.RemoveAllListeners();
        LipSizeSlider.onValueChanged.RemoveAllListeners();
        MouthSlider.onValueChanged.RemoveAllListeners();
        EyeSizeSlider.onValueChanged.RemoveAllListeners();
        EyeRotationSlider.onValueChanged.RemoveAllListeners();
        EyeSpacingSlider.onValueChanged.RemoveAllListeners();
        LowCheekPosSlider.onValueChanged.RemoveAllListeners();

        SkinRSlider.onValueChanged.RemoveAllListeners();
        SkinGSlider.onValueChanged.RemoveAllListeners();
        SkinBSlider.onValueChanged.RemoveAllListeners();
    }

    void Addlistener()
    {
        HeightSlider.onValueChanged.AddListener(OnHeightChange);
        UpperMuscleSlider.onValueChanged.AddListener(OnUpperMuscleChange);
        UpperWeightSlider.onValueChanged.AddListener(OnUpperWeightChange);
        LowerMuscleSlider.onValueChanged.AddListener(OnLowerMuscleChange);
        LowerWeightSlider.onValueChanged.AddListener(OnLowerWeightChange);
        //ArmLengthSlider.onValueChanged.AddListener(OnArmLengthChange);
        // ForearmLengthSlider.onValueChanged.AddListener(OnForearmLengthChange);
        LegSeparationSlider.onValueChanged.AddListener(OnLegSeparationChange);
        //HandSizeSlider.onValueChanged.AddListener(OnHandSizeChange);
        FeetSizeSlider.onValueChanged.AddListener(OnFootSizeChange);
        LegSizeSlider.onValueChanged.AddListener(OnLegSizeChange);
        ArmWidthSlider.onValueChanged.AddListener(OnArmWidthChange);
        ForearmWidthSlider.onValueChanged.AddListener(OnForearmWidthChange);
        BreastSlider.onValueChanged.AddListener(OnBreastSizeChange);
        BellySlider.onValueChanged.AddListener(OnBellySizeChange);
        WaistSizeSlider.onValueChanged.AddListener(OnWaistSizeChange);
        GlueteusSizeSlider.onValueChanged.AddListener(OnGluteusSizeChange);
        HeadSizeSlider.onValueChanged.AddListener(OnHeadSizeChange);
        //HeadWidthSlider.onValueChanged.AddListener(OnHeadWidthChange);
        NeckThickSlider.onValueChanged.AddListener(OnNeckThicknessChange);
        EarSizeSlider.onValueChanged.AddListener(OnEarSizeChange);
        EarPositionSlider.onValueChanged.AddListener(OnEarPositionChange);
        EarRotationSlider.onValueChanged.AddListener(OnEarRotationChange);
        NoseSizeSlider.onValueChanged.AddListener(OnNoseSizeChange);
        NoseCurveSlider.onValueChanged.AddListener(OnNoseCurveChange);
        NoseWidthSlider.onValueChanged.AddListener(OnNoseWidthChange);
        NoseInclinationSlider.onValueChanged.AddListener(OnNoseInclinationChange);
        NosePositionSlider.onValueChanged.AddListener(OnNosePositionChange);
        NosePronuncedSlider.onValueChanged.AddListener(OnNosePronouncedChange);
        NoseFlattenSlider.onValueChanged.AddListener(OnNoseFlattenChange);
        //ChinSizeSlider.onValueChanged.AddListener(OnChinSizeChange);
        ChinPronouncedSlider.onValueChanged.AddListener(OnChinPronouncedChange);
        ChinPositionSlider.onValueChanged.AddListener(OnChinPositionChange);
        //MandibleSizeSlider.onValueChanged.AddListener(OnMandibleSizeChange);
        JawSizeSlider.onValueChanged.AddListener(OnJawSizeChange);
        JawPositionSlider.onValueChanged.AddListener(OnJawPositionChange);
        CheekSizeSlider.onValueChanged.AddListener(OnCheekSizeChange);
        CheekPositionSlider.onValueChanged.AddListener(OnCheekPositionChange);
        lowCheekPronSlider.onValueChanged.AddListener(OnLowCheekPositionChange);
        ForeHeadSizeSlider.onValueChanged.AddListener(OnForeheadSizeChange);
        ForeHeadPositionSlider.onValueChanged.AddListener(OnForeheadPositionChange);
        LipSizeSlider.onValueChanged.AddListener(OnLipSizeChange);
        MouthSlider.onValueChanged.AddListener(OnMouthSizeChange);
        EyeSizeSlider.onValueChanged.AddListener(OnEyeSizechange);
        EyeRotationSlider.onValueChanged.AddListener(OnEyeRotationChange);
        EyeSpacingSlider.onValueChanged.AddListener(OnEyeSpacingChange);
        LowCheekPosSlider.onValueChanged.AddListener(OnLowCheekPositionChange);

        SkinRSlider.onValueChanged.AddListener(OnSkinColorChange);
        SkinGSlider.onValueChanged.AddListener(OnSkinColorChange);
        SkinBSlider.onValueChanged.AddListener(OnSkinColorChange);
    }

    ICharacterPlayer player
    {
        get
        {
            return UISystem.Instance.player;
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    void UpdateUMAShape()
    {
        if (umaData != null)
        {
            umaData.isShapeDirty = true;
            umaData.Dirty();
        }
    }

    // Slider callbacks 
    void OnHeightChange(float t) 
    {
        //player.SetDNA(EnumUmaParamters.height, HeightSlider.value);
        /*if (umaDna != null)  
            umaDna.height = HeightSlider.value; UpdateUMAShape(); */
    }
    void OnUpperMuscleChange(float t) { if (umaDna != null) umaDna.upperMuscle = UpperMuscleSlider.value; UpdateUMAShape(); }
    void OnUpperWeightChange(float t) { if (umaDna != null) umaDna.upperWeight = UpperWeightSlider.value; UpdateUMAShape(); }
    void OnLowerMuscleChange(float t) { if (umaDna != null) umaDna.lowerMuscle = LowerMuscleSlider.value; UpdateUMAShape(); }
    void OnLowerWeightChange(float t) { if (umaDna != null) umaDna.lowerWeight = LowerWeightSlider.value; UpdateUMAShape(); }
    void OnArmLengthChange(float t) { if (umaDna != null) umaDna.armLength = ArmLengthSlider.value; UpdateUMAShape(); }
    void OnForearmLengthChange(float t) { if (umaDna != null) umaDna.forearmLength = ForearmLengthSlider.value; UpdateUMAShape(); }
    void OnLegSeparationChange(float t) { if (umaDna != null) umaDna.legSeparation = LegSeparationSlider.value; UpdateUMAShape(); }
    void OnHandSizeChange(float t) { if (umaDna != null) umaDna.handsSize = HandSizeSlider.value; UpdateUMAShape(); }
    void OnFootSizeChange(float t) { if (umaDna != null) umaDna.feetSize = FeetSizeSlider.value; UpdateUMAShape(); }
    void OnLegSizeChange(float t) { if (umaDna != null) umaDna.legsSize = LegSizeSlider.value; UpdateUMAShape(); }
    void OnArmWidthChange(float t) { if (umaDna != null) umaDna.armWidth = ArmWidthSlider.value; UpdateUMAShape(); }
    void OnForearmWidthChange(float t) { if (umaDna != null) umaDna.forearmWidth = ForearmWidthSlider.value; UpdateUMAShape(); }
    void OnBreastSizeChange(float t) { if (umaDna != null) umaDna.breastSize = BreastSlider.value; UpdateUMAShape(); }
    void OnBellySizeChange(float t) { if (umaDna != null) umaDna.belly = BellySlider.value; UpdateUMAShape(); }
    void OnWaistSizeChange(float t) { if (umaDna != null) umaDna.waist = WaistSizeSlider.value; UpdateUMAShape(); }
    void OnGluteusSizeChange(float t) { if (umaDna != null) umaDna.gluteusSize = GlueteusSizeSlider.value; UpdateUMAShape(); }
    void OnHeadSizeChange(float t)
    {

        UISystem.Instance.SetDna(EnumUmaParamters.headSize, t);
        return;

        if (umaDna != null) 
            umaDna.headSize = HeadSizeSlider.value; 
        UpdateUMAShape(); 
    }
    void OnHeadWidthChange(float t) { if (umaDna != null) umaDna.headWidth = HeadWidthSlider.value; UpdateUMAShape(); }
    void OnNeckThicknessChange(float t) { if (umaDna != null) umaDna.neckThickness = NeckThickSlider.value; UpdateUMAShape(); }
    void OnEarSizeChange(float t) { if (umaDna != null) umaDna.earsSize = EarSizeSlider.value; UpdateUMAShape(); }
    void OnEarPositionChange(float t) { if (umaDna != null) umaDna.earsPosition = EarPositionSlider.value; UpdateUMAShape(); }
    void OnEarRotationChange(float t) { if (umaDna != null) umaDna.earsRotation = EarRotationSlider.value; UpdateUMAShape(); }
    void OnNoseSizeChange(float t) { if (umaDna != null) umaDna.noseSize = NoseSizeSlider.value; UpdateUMAShape(); }
    void OnNoseCurveChange(float t) { if (umaDna != null) umaDna.noseCurve = NoseCurveSlider.value; UpdateUMAShape(); }
    void OnNoseWidthChange(float t) { if (umaDna != null) umaDna.noseWidth = NoseWidthSlider.value; UpdateUMAShape(); }
    void OnNoseInclinationChange(float t) { if (umaDna != null) umaDna.noseInclination = NoseInclinationSlider.value; UpdateUMAShape(); }
    void OnNosePositionChange(float t) { if (umaDna != null) umaDna.nosePosition = NosePositionSlider.value; UpdateUMAShape(); }
    void OnNosePronouncedChange(float t) { if (umaDna != null) umaDna.nosePronounced = NosePronuncedSlider.value; UpdateUMAShape(); }
    void OnNoseFlattenChange(float t) { if (umaDna != null) umaDna.noseFlatten = NoseFlattenSlider.value; UpdateUMAShape(); }
    void OnChinSizeChange(float t) { if (umaDna != null) umaDna.chinSize = ChinSizeSlider.value; UpdateUMAShape(); }
    void OnChinPronouncedChange(float t) { if (umaDna != null) umaDna.chinPronounced = ChinPronouncedSlider.value; UpdateUMAShape(); }
    void OnChinPositionChange(float t) { if (umaDna != null) umaDna.chinPosition = ChinPositionSlider.value; UpdateUMAShape(); }
    void OnMandibleSizeChange(float t) { if (umaDna != null) umaDna.mandibleSize = MandibleSizeSlider.value; UpdateUMAShape(); }
    void OnJawSizeChange(float t) { if (umaDna != null) umaDna.jawsSize = JawSizeSlider.value; UpdateUMAShape(); }
    void OnJawPositionChange(float t) { if (umaDna != null) umaDna.jawsPosition = JawPositionSlider.value; UpdateUMAShape(); }
    void OnCheekSizeChange(float t) { if (umaDna != null) umaDna.cheekSize = CheekSizeSlider.value; UpdateUMAShape(); }
    void OnCheekPositionChange(float t) { if (umaDna != null) umaDna.cheekPosition = CheekPositionSlider.value; UpdateUMAShape(); }
    void OnCheekLowPronouncedChange(float t) { if (umaDna != null) umaDna.lowCheekPronounced = lowCheekPronSlider.value; UpdateUMAShape(); }
    void OnForeheadSizeChange(float t) { if (umaDna != null) umaDna.foreheadSize = ForeHeadSizeSlider.value; UpdateUMAShape(); }
    void OnForeheadPositionChange(float t) { if (umaDna != null) umaDna.foreheadPosition = ForeHeadPositionSlider.value; UpdateUMAShape(); }
    void OnLipSizeChange(float t) { if (umaDna != null) umaDna.lipsSize = LipSizeSlider.value; UpdateUMAShape(); }
    void OnMouthSizeChange(float t) { if (umaDna != null) umaDna.mouthSize = MouthSlider.value; UpdateUMAShape(); }
    void OnEyeSizechange(float t) { if (umaDna != null) umaDna.eyeSize = EyeSizeSlider.value; UpdateUMAShape(); }
    void OnEyeRotationChange(float t) { if (umaDna != null) umaDna.eyeRotation = EyeRotationSlider.value; UpdateUMAShape(); }
    void OnLowCheekPositionChange(float t) { if (umaDna != null) umaDna.lowCheekPosition = LowCheekPosSlider.value; UpdateUMAShape(); }
    void OnEyeSpacingChange(float t) { if (umaTutorialDna != null) umaTutorialDna.eyeSpacing = EyeSpacingSlider.value; UpdateUMAShape(); }

    void OnSkinColorChange(float t)
    {
        Color color = new Color(SkinRSlider.value, SkinGSlider.value, SkinBSlider.value);
        //player.ChangeSkinColor(color);
    }
}
