
public abstract class ClothFactory
{
    public static ICloths CreatCloth
        (ECharacterResType type,UMAContext _umaContext, CharacterData _characterData, ICharacterSlotOverly _characterSlotOverlay, ICharacterPlayer _character,ICharacterBase _characterBase, ClothModel _cm)
    {
        ICloths ich = null;
        switch (_cm.wearpos)
        {
            case WearPosConst.WAER_POS_CLOTH:
                ich = new Coat(type,_umaContext, _characterData, _characterSlotOverlay, _character, _characterBase, _cm);
                break;
            case WearPosConst.WEAR_POS_PANT:
                ich = new Pant(type, _umaContext, _characterData, _characterSlotOverlay, _character, _characterBase, _cm);
                break;
            case WearPosConst.WEAR_POS_SUIT:
                ich = new Suit(type, _umaContext, _characterData, _characterSlotOverlay, _character, _characterBase, _cm);
                break;
            case WearPosConst.WAER_POS_HAIR:
                ich = new Hair(type, _umaContext, _characterData, _characterSlotOverlay, _character, _characterBase, _cm);
                break;
            case WearPosConst.WEAR_POS_SHOE:
                ich = new Shoe(type, _umaContext, _characterData, _characterSlotOverlay, _character, _characterBase, _cm);
                break;
        }
        return ich;
    }
}