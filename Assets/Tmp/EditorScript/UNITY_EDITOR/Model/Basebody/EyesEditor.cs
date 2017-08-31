#if UNITY_EDITOR
using UnityEngine;
public class EyesEditor : BaseClothItemEditor
{
    public EyesEditor(IFbxItem go, ECharacterResType type) : base(go, type) { }

    public override string PartName
    {
        get { return CharacterConst.Eyes; }
    }

    public override int WearPos
    {
        get { return int.Parse(WearPosConst.WEAR_POS_BASE_EYES); }
    }
}
#endif