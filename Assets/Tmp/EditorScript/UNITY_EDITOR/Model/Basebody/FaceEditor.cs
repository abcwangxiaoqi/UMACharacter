#if UNITY_EDITOR
using UnityEngine;
public class FaceEditor : BaseClothItemEditor
{
    public FaceEditor(IFbxItem go, ECharacterResType type) : base(go, type) { }

    public override string PartName
    {
        get { return CharacterConst.Face; }
    }

    public override int WearPos
    {
        get { return int.Parse(WearPosConst.WEAR_POS_BASE_FACE); }
    }
}
#endif