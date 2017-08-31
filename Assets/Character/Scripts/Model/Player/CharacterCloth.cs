
using System.Collections.Generic;
public class CharacterCloth : ICharacterCloth
{
    UMAContext umaContext;
    CharacterData characterData;
    ICharacterSlotOverly characterSlotOverlay;
    ICharacterPlayer character;
    ICharacterBase characterBase;
    ECharacterResType resType = ECharacterResType.Height;
    public CharacterCloth
        (ECharacterResType type,CharacterData _characterData, ICharacterSlotOverly _characterSlotOverlay, ICharacterPlayer _character, ICharacterBase _characterBase)
    {
        resType = type;
        umaContext = UMAContext.FindInstance();
        characterData = _characterData;
        characterSlotOverlay = _characterSlotOverlay;
        character = _character;
        characterBase = _characterBase;
    }

    List<CharacterClothItem> clothItems = new List<CharacterClothItem>();

    public void PutOn(List<ClothModel> cms)
    {
        CharacterClothItem cloth = new CharacterClothItem(resType,umaContext, characterData, characterSlotOverlay, character, characterBase);
        clothItems.Add(cloth);
        cloth.AddListenerOn(ClothActionFinish);
        cloth.PutOn(cms);
    }

    public void PutOn(ClothModel cm)
    {
        CharacterClothItem cloth = new CharacterClothItem(resType,umaContext, characterData, characterSlotOverlay, character, characterBase);
        clothItems.Add(cloth);
        cloth.AddListenerOn(ClothActionFinish);
        cloth.PutOn(cm);
    }

    void ClothActionFinish(CharacterClothItem item)
    {
        clothItems.Remove(item);
    }

    public void TakeOff(ClothModel cm)
    {
        CharacterClothItem cloth = new CharacterClothItem(resType,umaContext, characterData, characterSlotOverlay, character, characterBase);
        cloth.TakeOff(cm);
    }

    public void TakeOffAll()
    {
        CharacterClothItem cloth = new CharacterClothItem(resType,umaContext, characterData, characterSlotOverlay, character, characterBase);
        cloth.TakeOffAll();
    }

    public void Initialize()
    {
        CharacterClothItem cloth = new CharacterClothItem(resType,umaContext, characterData, characterSlotOverlay, character, characterBase);
        cloth.PutOn(characterData.avatars,true);
    }

   public void Dispose()
    {
        for (int i = 0; i < clothItems.Count; i++)
        {
            clothItems[i].Dispose();
        }
        clothItems.Clear();
    }
}


