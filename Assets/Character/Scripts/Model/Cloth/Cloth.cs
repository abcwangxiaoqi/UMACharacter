
using System.Collections.Generic;
using UnityEngine;
abstract public class Cloth : ICloths
{
    ECharacterResType resType = ECharacterResType.Height;
    UMAContext umaContext;
    ICharacterSlotOverly characterSlotOverlay;
    ICharacterPlayer character;
    ICharacterBase characterBase;
    protected CharacterData characterData;
    protected ClothModel cm { get; private set; }
    protected List<string> PutOnDelete;

    abstract public string wearpon { get; }

    public Cloth
        (ECharacterResType type,UMAContext _umaContext, CharacterData _characterData, ICharacterSlotOverly _characterSlotOverlay, ICharacterPlayer _character, ICharacterBase _characterBase, ClothModel _cm)
    {
        resType = type;
        umaContext = _umaContext;
        characterSlotOverlay = _characterSlotOverlay;
        character = _character;
        characterData = _characterData;
        characterBase = _characterBase;
        cm = _cm;
        PutOnDelete = new List<string>();
    }


    void PutOnObj(Object item)
    {
        for (int i = 0; i < PutOnDelete.Count; i++)
        {
            characterSlotOverlay.RemoveWeap(PutOnDelete[i]);
        }        

        GameObject go = GameObject.Instantiate(item) as GameObject;

        SlotOverlay so = go.GetComponent<SlotOverlay>();
        so.InitializeSlotData(characterSlotOverlay);

        GameObject.DestroyImmediate(go);

        if (OnCallback!=null)
        {
            OnCallback();
        }
    }

    virtual public void PutOnAction() { }

    CallBack OnCallback = null;
    public void PutOn(CallBack callback)
    {
        OnCallback = callback;

        #region modify data
        List<ClothModel> avs = characterData.avatars;

        PutOnAction();

        #region delete included

        int index1 = avs.FindIndex(delegate(ClothModel v)
        {
            string type = v.wearpos;
            if (type == wearpon)
            {
                return true;
            }
            return false;
        });
        if (index1 > -1)
        {
            ClothModel c = avs[index1];
            PutOnDelete.Add(c.wearpos);
            avs.RemoveAt(index1);
        }

        #endregion

        avs.Add(cm);
        #endregion

        #region load resoruces 

        Initilze(callback);

        #endregion
    }

    public void TakeOff(CallBack callback)
    {
        List<ClothModel> avs = characterData.avatars;
        ClothModel cmodel = avs.Find((ClothModel _cm) =>
        {
            return _cm.itemid == cm.itemid;
        });
        avs.Remove(cmodel);
        characterSlotOverlay.RemoveWeap(wearpon);

        if (callback!=null)
        {
            callback();
        }
    }

    CharacterLoad load = null;
    public void Initilze(CallBack callback)
    {
        OnCallback = callback;
        load = new ClothLoad(resType);
        load.LoadRes(new object[] { cm, PutOnObj as CallBackWithParams<Object> });
    }

    public void Dispose()
    {
        if(load!=null)
        {
            load.Stop();
        }
    }
}