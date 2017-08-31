#if UNITY_EDITOR
using UnityEngine;
using System.Collections;

public class Template_Female3 : Template
{
    public Template_Female3() : base(EnumCharacterType.Charater_Female) { }
    public override int id
    {
        get { return 3; }
    }

    public override string path
    {
        get { return CharacterConst.ResUrl + "/formdata/female"; }
    }
}
#endif
