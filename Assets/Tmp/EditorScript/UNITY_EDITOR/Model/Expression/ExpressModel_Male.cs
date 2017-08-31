#if UNITY_EDITOR
public class ExpressModel_Male : ExpressModel
{
    public override string bodyDiff
    {
        get { return "Assets/Tmp/FBX/Human_Male/Human_Male_Skin_d.png"; }
    }

    public override string bodyNormal
    {
        get { return "Assets/Tmp/FBX/Human_Male/Human_Male_Skin_n.png"; }
    }

    public override string faceDiff
    {
        get { return "Assets/Tmp/FBX/Human_Male/Human_Male_Face_d.png"; }
    }

    public override string faceNormal
    {
        get { return "Assets/Tmp/FBX/Human_Male/Human_Male_Face_n.png"; }
    }

    public override string name
    {
        get { return CharacterConst.Male; }
    }

    public override string fbx
    {
        get { return "Assets/Tmp/FBX/Human_Male/Human_Male.fbx"; }
    }

    public override string rig
    {
        get { return "UMA_Male_Rig"; }
    }

    public override string expression_Set
    {
        get { return "Assets/Character/UMA/Content/UMA/Humanoid/Expressions/Expression Sets/Male_Expression_Set.asset"; }
    }

    public override string clipFold
    {
        get { return "Assets/Tmp/Expression/clips/male"; }
    }
}
#endif