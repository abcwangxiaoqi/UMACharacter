#if UNITY_EDITOR
using UnityEditor;
using UMA;
using UMA.PoseTools;

public abstract class TPoseEditor
{
    IFbxItem objBase;
    protected ECharacterResType resType = ECharacterResType.Height;
    public TPoseEditor(IFbxItem _objBase,ECharacterResType type)
    {
        objBase = _objBase;
        resType = type;
    }

    abstract public string Fold { get; }
    abstract public UMAExpressionSet expressionSet { get; }
    abstract public DnaConverterBehaviour dnaConverterBehaviour { get; }
    abstract public DNARangeAsset danRange { get; }

    public RaceData CreatTPose()//创建TPose文件
    {
        ModelImporter modelImporter = objBase.importer as ModelImporter;
        UmaTPose umaTpose = UmaTPose.CreateInstance<UMA.UmaTPose>();
        modelImporter.animationType = ModelImporterAnimationType.Human;//修改 animation类型 为 humanoid
        modelImporter.SaveAndReimport();
        umaTpose.ReadFromHumanDescription(modelImporter.humanDescription);

        string tempPath = string.Format("{0}/{1}_TPose.asset", Fold, objBase.Name);

        IObjectBase tpose = new ObjectBase(tempPath);
        tpose.CreatAsset(umaTpose);
        return CreatRace(umaTpose);
    }

    RaceData CreatRace(UmaTPose umaTpose)//创建Race文件
    {
        if (umaTpose == null)
            return null;

        RaceData rd = new RaceData();
        RaceData targetrd = new RaceData();
        rd.expressionSet = expressionSet;

        rd.dnaConverterList = new DnaConverterBehaviour[2];
        rd.dnaConverterList[0] = dnaConverterBehaviour;
        rd.dnaConverterList[1] = RaceMap.Instance.tutorialDan;

        rd.dnaRanges = new DNARangeAsset[1];
        rd.dnaRanges[0] = danRange;

        rd.TPose = umaTpose;
        rd.raceName = objBase.Name;
        string tempPath = string.Format("{0}/{1}_Race.asset", Fold, objBase.Name);

        IObjectBase race = new ObjectBase(tempPath);
        race.CreatAsset(rd);
        return rd;
    }
}
public static class TPoseEditorFactory
{
    public static TPoseEditor Creat(EnumCharacterType sex, IFbxItem objBase,ECharacterResType type)
    {
        if (sex == EnumCharacterType.Charater_Female)
        {
            return new TPoseEditor_Female(objBase, type);
        }
        else
        {
            return new TPoseEditor_Male(objBase, type);
        }
    }
}
public class TPoseEditor_Female : TPoseEditor
{
    public TPoseEditor_Female(IFbxItem _objBase, ECharacterResType type)
        : base(_objBase, type)
    {
    }

    public override string Fold
    {
        get { return string.Format("Assets/Tmp/Prefab/Resources/{0}/{1}",resType.ToString(), CharacterConst.Female); }
    }

    public override UMAExpressionSet expressionSet
    {
        get { return RaceMap.Instance.femaleExpression; }
    }

    public override DnaConverterBehaviour dnaConverterBehaviour
    {
        get { return RaceMap.Instance.femaleDan; }
    }

    public override DNARangeAsset danRange
    {
        get { return RaceMap.Instance.femaleDanRange; }
    }
}
public class TPoseEditor_Male : TPoseEditor
{
    public TPoseEditor_Male(IFbxItem _objBase,ECharacterResType type)
        : base(_objBase, type)
    {
    }
    public override string Fold
    {
        get { return string.Format("Assets/Tmp/Prefab/Resources/{0}/{1}", resType.ToString(), CharacterConst.Male); }
    }
    public override UMAExpressionSet expressionSet
    {
        get { return RaceMap.Instance.maleExpression; }
    }

    public override DnaConverterBehaviour dnaConverterBehaviour
    {
        get { return RaceMap.Instance.maleDan; }
    }

    public override DNARangeAsset danRange
    {
        get { return RaceMap.Instance.maleDanRange; }
    }
}
#endif