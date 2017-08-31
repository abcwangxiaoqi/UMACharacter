
public class Hair : Cloth
{
    public Hair(ECharacterResType type, UMAContext _umaContext, CharacterData _characterData, ICharacterSlotOverly _characterSlotOverlay, ICharacterPlayer _character, ICharacterBase _characterBase, ClothModel _cm)
        : base(type, _umaContext, _characterData, _characterSlotOverlay, _character, _characterBase, _cm) { }

    public override string wearpon
    {
        get { return WearPosConst.WAER_POS_HAIR; }
    }
}