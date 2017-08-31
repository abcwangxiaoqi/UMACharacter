
using System.Collections.Generic;
using UMA;
using UnityEngine;
public class CharacterBase : ICharacterBase
{
    UMAContext umaContext;
    ICharacterSlotOverly characterSlotOverlay;
    UMAData umaData;
    UMADynamicAvatar umaDynamicAvatar;
    CharacterData characterData;
    ECharacterResType resType = ECharacterResType.Height;
    public CharacterBase
        (ECharacterResType type,
        ICharacterSlotOverly _characterSlotOverlay, 
        UMAData _umaData,
        UMADynamicAvatar _umaDynamicAvatar,
        CharacterData _characterData)
    {
        resType = type;
        umaContext = UMAContext.FindInstance();
        characterSlotOverlay = _characterSlotOverlay;
        umaData = _umaData;
        umaDynamicAvatar = _umaDynamicAvatar;
        characterData = _characterData;
    }

    CallBack InitializeCb = null;
    CharacterLoad load = null;
    public void Initialize(CallBack callback)
    {
        InitializeCb = callback;
        load = new RoleLoad(resType);
        load.LoadRes(new object[] { characterData, PutOnBase as CallBackWithParams<Object> });
    }

    bool InitilzeFlag = false;

    void PutOnBase(Object baseObj)
    {
        GameObject data = GameObject.Instantiate(baseObj) as GameObject;

        PlayerData pd = data.GetComponent<PlayerData>();
        RaceData race = pd.race;
        umaContext.raceLibrary.AddRace(race);
        umaData.umaRecipe.SetRace(race);

        if (pd.anim != null && pd.anim.animationClips != null && pd.anim.animationClips.Length > 0)
        {
            umaDynamicAvatar.context = umaContext;
            umaDynamicAvatar.animationController = pd.anim;
        }

        pd.InitializeSlotData(characterSlotOverlay);
        GameObject.DestroyImmediate(data);

        InitilzeFlag = true;

        if(InitializeCb!=null)
        {
            InitializeCb();
        }
    }


    public bool isExist(string[] weapons)
    {
        List<ClothModel> list = characterData.avatars;
        bool res = list.Exists((ClothModel cm) =>
        {
            bool r = false;
            for (int i = 0; i < weapons.Length; i++)
            {
                if (cm.wearpos == weapons[i].Trim())
                {
                    r = true;
                    break;
                }
            }
            return r;
        });
        return res;
    }

    public void Dispose()
    {
        if(load!=null)
        {
            load.Stop();
        }
    }
}
