#if UNITY_EDITOR
using UnityEngine;
using System.Collections;

public class Template_Female2 : Template
{
    public Template_Female2() : base(EnumCharacterType.Charater_Female) { }
    public override int id
    {
        get { return 2; }
    }

    public override string path
    {
        get { return CharacterConst.ResUrl + "/formdata/female"; }
    }
}
#endif
