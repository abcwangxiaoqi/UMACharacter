#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using UMA;
using UMA.PoseTools;

public class RaceMap
{
    static RaceMap _Instance;
    public static RaceMap Instance
    {
        get
        {
            if(_Instance==null)
            {
                _Instance = new RaceMap();
            }
            return _Instance;
        }
    }

    const string FemaleExpression = "Assets/Character/UMA/Content/UMA/Humanoid/Expressions/Expression Sets/Female_Expression_Set.asset";
    const string MaleExpression = "Assets/Character/UMA/Content/UMA/Humanoid/Expressions/Expression Sets/Male_Expression_Set.asset";
    const string FemaleDNA = "Assets/Character/UMA/Content/UMA/Humanoid/DNA/HumanFemaleDNAConverterBehaviour.prefab";
    const string MaleDNA = "Assets/Character/UMA/Content/UMA/Humanoid/DNA/HumanMaleDNAConverterBehaviour.prefab";
    const string TutorialDNA = "Assets/Character/UMA/Content/UMA/Humanoid/DNA/TutorialDNAConverterBehaviour.prefab";
    const string FemaleDNARange = "Assets/Character/UMA/Content/UMA/Humanoid/Races/Human_Female_UMADNAHumanoid_Ranges.asset";
    const string MaleDNARange = "Assets/Character/UMA/Content/UMA/Humanoid/Races/Human_Male_UMADNAHumanoid_Ranges.asset";

    public UMAExpressionSet femaleExpression { get; private set; }
    public UMAExpressionSet maleExpression { get; private set; }
    public DnaConverterBehaviour femaleDan { get; private set; }
    public DnaConverterBehaviour maleDan { get; private set; }
    public DnaConverterBehaviour tutorialDan { get; private set; }
    public DNARangeAsset femaleDanRange { get; private set; }
    public DNARangeAsset maleDanRange { get; private set; }
    public RaceMap()
    {        
        femaleExpression = (UMAExpressionSet)AssetDatabase.LoadAssetAtPath(FemaleExpression, typeof(UMAExpressionSet));
        maleExpression = (UMAExpressionSet)AssetDatabase.LoadAssetAtPath(MaleExpression, typeof(UMAExpressionSet));
        femaleDan = (DnaConverterBehaviour)AssetDatabase.LoadAssetAtPath(FemaleDNA, typeof(DnaConverterBehaviour));
        maleDan = (DnaConverterBehaviour)AssetDatabase.LoadAssetAtPath(MaleDNA, typeof(DnaConverterBehaviour));
        tutorialDan = (DnaConverterBehaviour)AssetDatabase.LoadAssetAtPath(TutorialDNA, typeof(DnaConverterBehaviour));
        femaleDanRange = (DNARangeAsset)AssetDatabase.LoadAssetAtPath(FemaleDNARange, typeof(DNARangeAsset));
        maleDanRange = (DNARangeAsset)AssetDatabase.LoadAssetAtPath(MaleDNARange, typeof(DNARangeAsset));
    }
}
#endif
