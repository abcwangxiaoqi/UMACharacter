using UnityEngine;
using System.Collections.Generic;

public interface ICharacterPlayer
{
    string objectName { get; set; }
    void Creat();//creat role
    CallBack CreateFinish { get; set; }
    void PutOn(List<ClothModel> cms);
    void PutOn(ClothModel cm);
    void TakeOff(ClothModel cm);
    void TakeOff(string weapon);
    void TakeOffAll();
    //void SetDNA(EnumUmaParamters dna, float dnaValue);
    void PlayAnimation(string actionName,float speed=1f);
    void Destroy(float t = 0f);
    CharacterData GetcharacterData();
    void SetLayer(string layer);
    void SetParent(Transform _parent);
    Transform parent { get; }
    void SetLocalPosition(Vector3 pos);
    Vector3 localPosition { get; }
    void SetLocalEulerAngles(Vector3 euler);
    Vector3 localEulerAngles { get; }
    void Updata();
    void CompressMesh(int level);
}