#if UNITY_EDITOR
using UnityEngine;
using System.Collections;

public class Template_Male1 : Template {

    public Template_Male1() : base(EnumCharacterType.Charater_Male) { }
    public override int id
    {
        get { return 1; }
    }

    public override string path
    {
        get { return CharacterConst.ResUrl + "/formdata/male"; }
    }
}
#endif
