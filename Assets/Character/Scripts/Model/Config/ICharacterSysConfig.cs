using UnityEngine;
public interface ICharacterSysConfig
{
    TextAsset ItemList { get; }
    void Initialize(Object o);
}