
using System.Collections.Generic;
public class CharacterClothItem
{
    UMAContext umaContext;
    CharacterData characterData;
    ICharacterSlotOverly characterSlotOverlay;
    ICharacterPlayer character;
    ICharacterBase characterBase;
    ECharacterResType resType=ECharacterResType.Height;
    public CharacterClothItem(
        ECharacterResType type,
        UMAContext _umaContext,
        CharacterData _characterData,
        ICharacterSlotOverly _characterSlotOverlay,
        ICharacterPlayer _character,
        ICharacterBase _characterBase)
    {
        resType = type;
        umaContext = _umaContext;
        characterData = _characterData;
        characterSlotOverlay = _characterSlotOverlay;
        character = _character;
        characterBase = _characterBase;
    }

    int OffCurCout = 0;
    int OffCount = 0;
    public void TakeOff(ClothModel cm)
    {
        OffCount = 1;
        ICloths ich = ClothFactory.CreatCloth(resType,umaContext, characterData, characterSlotOverlay, character, characterBase, cm);
        ich.TakeOff(OffFinish);
    }

    public void TakeOffAll()
    {
        List<ClothModel> avs = new List<ClothModel>(characterData.avatars);
        OffCount = avs.Count;
        for (int i = 0; i < avs.Count; i++)
        {
            ICloths ich = ClothFactory.CreatCloth(resType,umaContext, characterData, characterSlotOverlay, character, characterBase, avs[i]);
            ich.TakeOff(OffFinish);
        }
    }

    List<ICloths> cloths = new List<ICloths>();
    public void PutOn(ClothModel cm)
    {
        OnCount = 1;
        ICloths ich = ClothFactory.CreatCloth(resType,umaContext, characterData, characterSlotOverlay, character, characterBase, cm);
        cloths.Add(ich);
        ich.PutOn(OnFinish);
    }
    int OnCurCout = 0;
    int OnCount = 0;
    public void PutOn(List<ClothModel> cms, bool isInitialze = false)
    {
        OnCount = cms.Count;

        for (int i = 0; i < cms.Count; i++)
        {
            ICloths ich = ClothFactory.CreatCloth(resType,umaContext, characterData, characterSlotOverlay, character, characterBase, cms[i]);
            cloths.Add(ich);
            if (isInitialze)
            {
                ich.Initilze(OnFinish);
            }
            else
            {
                ich.PutOn(OnFinish);
            }
        }
    }

    void OffFinish()
    {
        OffCurCout++;
        if (OffCurCout == OffCount)
        {
            character.Updata();
            if (OffFinishCallback != null)
            {
                OffFinishCallback(this);
                OffFinishCallback = null;
            }
        }
    }

    void OnFinish()
    {
        OnCurCout++;
        if (OnCurCout == OnCount)
        {
            character.Updata();
            if (OnFinishCallback != null)
            {
                OnFinishCallback(this);
                OnFinishCallback = null;
            }
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < cloths.Count; i++)
        {
            cloths[i].Dispose();
        }
    }

    CallBackWithParams<CharacterClothItem> OnFinishCallback = null;
    public void AddListenerOn(CallBackWithParams<CharacterClothItem> callback)
    {
        if (callback != null)
        {
            OnFinishCallback += callback;
        }
    }

    CallBackWithParams<CharacterClothItem> OffFinishCallback = null;
    public void AddListenerOff(CallBackWithParams<CharacterClothItem> callback)
    {
        if (callback != null)
        {
            OffFinishCallback += callback;
        }
    }
}