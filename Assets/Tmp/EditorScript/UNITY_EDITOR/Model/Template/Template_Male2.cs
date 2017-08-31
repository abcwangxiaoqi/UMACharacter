#if UNITY_EDITOR
using UnityEngine;
using System.Collections;

public class Template_Male2 : Template {

    public Template_Male2() : base(EnumCharacterType.Charater_Male) { }
    public override int id
    {
        get { return 2; }
    }

    public override string path
    {
        get { return CharacterConst.ResUrl + "/formdata/male"; }
    }
}
#endif