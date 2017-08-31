
using System.Collections.Generic;
public class Pant : Cloth
{
    public Pant(ECharacterResType type, UMAContext _umaContext, CharacterData _characterData, ICharacterSlotOverly _characterSlotOverlay, ICharacterPlayer _character, ICharacterBase _characterBase, ClothModel _cm)
        : base(type, _umaContext, _characterData, _characterSlotOverlay, _character, _characterBase, _cm) { }

    public override void PutOnAction()
    {
        base.PutOnAction();

        List<ClothModel> avs = characterData.avatars;

        int index = avs.FindIndex(
          delegate(ClothModel v)
          {
              string type = v.wearpos;
              if (type == WearPosConst.WEAR_POS_SUIT)
              {
                  return true;
              }
              return false;
          });
        if (index > -1)
        {
            ClothModel c = avs[index];
            PutOnDelete.Add(c.wearpos);
            avs.RemoveAt(index);
        }
    }

    public override string wearpon
    {
        get { return WearPosConst.WEAR_POS_PANT; }
    }
}