using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour
{

    //IEnumerator Start()
    //{
    //    ICharacterSystem sys = new CharacterSystem();
    //    yield return StartCoroutine(sys.Initialize());
    //    CharacterData data = CharacterData.defData(EnumCharacterType.Charater_Female);
    //    data.avatars = ClothModel.GetDefault(EnumCharacterType.Charater_Female);
    //    data.dna = new List<UmaDnaItem>();
    //    UmaDnaItem item = new UmaDnaItem();
    //    item.dnaKey = (int)EnumUmaParamters.headSize;
    //    item.dnaValue = 0.1f;
    //    data.dna.Add(item);

    //    ICharacterPlayer player1 = CharacterPlayerFactory.Creat(data);
    //    player1.objectName = "female1";
    //    player1.Creat();
    //    yield break;
    //}

    // Use this for initialization
    IEnumerator Start()
    {
        ICharacterSystem sys = new CharacterSystem();
        yield return StartCoroutine(sys.Initialize());

        CharacterData data = CharacterData.defData(EnumCharacterType.Charater_Female);
        data.avatars = ClothModel.GetDefault(EnumCharacterType.Charater_Female);
        ICharacterPlayer player1 = CharacterPlayerFactory.Creat(data);
        player1.objectName = "female1";
        player1.Creat();

        ICharacterPlayer player1_L = CharacterPlayerFactory.Creat(data,ECharacterResType.Low);
        player1_L.objectName = "female1_low";
        player1_L.Creat();

        data.avatars = ClothModel.GetDefault(EnumCharacterType.Charater_Female, 2);
        ICharacterPlayer player2 = CharacterPlayerFactory.Creat(data);
        player2.objectName = "female2";
        player2.Creat();

        ICharacterPlayer player2_L = CharacterPlayerFactory.Creat(data,ECharacterResType.Low);
        player2_L.objectName = "female2_low";
        player2_L.Creat();

        data.avatars = ClothModel.GetDefault(EnumCharacterType.Charater_Female, 3);
        ICharacterPlayer player3 = CharacterPlayerFactory.Creat(data);
        player3.objectName = "female3";
        player3.Creat();

        ICharacterPlayer player3_L = CharacterPlayerFactory.Creat(data,ECharacterResType.Low);
        player3_L.objectName = "female3_low";
        player3_L.Creat();

        data = CharacterData.defData(EnumCharacterType.Charater_Male);
        data.avatars = ClothModel.GetDefault(EnumCharacterType.Charater_Male, 1);
        ICharacterPlayer Mplayer1 = CharacterPlayerFactory.Creat(data);
        Mplayer1.objectName = "male1";
        Mplayer1.Creat();

        ICharacterPlayer Mplayer1_L = CharacterPlayerFactory.Creat(data,ECharacterResType.Low);
        Mplayer1_L.objectName = "male1_low";
        Mplayer1_L.Creat();

        data.avatars = ClothModel.GetDefault(EnumCharacterType.Charater_Male, 2);
        ICharacterPlayer Mplayer2 = CharacterPlayerFactory.Creat(data);
        Mplayer2.objectName = "male2";
        Mplayer2.Creat();

        ICharacterPlayer Mplayer2_L = CharacterPlayerFactory.Creat(data,ECharacterResType.Low);
        Mplayer2_L.objectName = "male2_low";
        Mplayer2_L.Creat();

        data.avatars = ClothModel.GetDefault(EnumCharacterType.Charater_Male, 3);
        ICharacterPlayer Mplayer3 = CharacterPlayerFactory.Creat(data);
        Mplayer3.objectName = "male3";
        Mplayer3.Creat();

        ICharacterPlayer Mplayer3_L = CharacterPlayerFactory.Creat(data,ECharacterResType.Low);
        Mplayer3_L.objectName = "male3_low";
        Mplayer3_L.Creat();
    }
}
