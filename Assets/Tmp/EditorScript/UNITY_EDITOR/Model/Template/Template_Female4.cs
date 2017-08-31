#if UNITY_EDITOR
using UnityEngine;
using System.Collections;

public class Template_Female4 : Template
{

    public Template_Female4() : base(EnumCharacterType.Charater_Female) { }
    public override int id
    {
        get { return 4; }
    }

    public override string path
    {
        get { return CharacterConst.ResUrl + "/formdata/female"; }
    }
}
#endif
