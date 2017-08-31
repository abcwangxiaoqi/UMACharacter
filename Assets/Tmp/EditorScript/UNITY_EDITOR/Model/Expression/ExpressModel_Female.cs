#if UNITY_EDITOR
public class ExpressModel_Female : ExpressModel
{
    public override string bodyDiff
    {
        get { return "Assets/Tmp/FBX/Human_Female/Human_Female_Skin_d.png"; }
    }

    public override string bodyNormal
    {
        get { return "Assets/Tmp/FBX/Human_Female/Human_Female_Skin_n.png"; }
    }

    public override string faceDiff
    {
        get { return "Assets/Tmp/FBX/Human_Female/Human_Female_Face_d.png"; }
    }

    public override string faceNormal
    {
        get { return "Assets/Tmp/FBX/Human_Female/Human_Female_Face_n.png"; }
    }

    public override string name
    {
        get { return CharacterConst.Female; }
    }

    public override string fbx
    {
        get { return "Assets/Tmp/FBX/Human_Female/Human_Female.fbx"; }
    }

    public override string rig
    {
        get { return "UMA_Female_Rig"; }
    }

    public override string expression_Set
    {
        get { return "Assets/Character/UMA/Content/UMA/Humanoid/Expressions/Expression Sets/Female_Expression_Set.asset"; }
    }

    public override string clipFold
    {
        get { return "Assets/Tmp/Expression/clips/female"; }
    }
}
#endif