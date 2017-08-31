
using System.Collections.Generic;
public class Suit : Cloth
{
    public Suit(ECharacterResType type, UMAContext _umaContext, CharacterData _characterData, ICharacterSlotOverly _characterSlotOverlay, ICharacterPlayer _character, ICharacterBase _characterBase, ClothModel _cm)
        : base(type,_umaContext, _characterData, _characterSlotOverlay, _character, _characterBase, _cm) { }

    public override void PutOnAction()
    {
        base.PutOnAction();

        List<ClothModel> avs = characterData.avatars;

        List<ClothModel> result = avs.FindAll(
                    delegate(ClothModel v)
                    {
                        string type = v.wearpos;
                        if (type == WearPosConst.WEAR_POS_PANT ||
                            type == WearPosConst.WAER_POS_CLOTH)
                        {
                            return true;
                        }
                        return false;
                    });

        for (int i = 0; i < result.Count; i++)
        {
            ClothModel c = result[i];
            PutOnDelete.Add(c.wearpos);
            avs.Remove(result[i]);
        }
    }
    public override string wearpon
    {
        get { return WearPosConst.WEAR_POS_SUIT; }
    }
}