#if UNITY_EDITOR
using UnityEngine;
using System.Collections;

public class Template_Female1 : Template
{
    public Template_Female1() : base(EnumCharacterType.Charater_Female) { }

    public override string path
    {
        get { return CharacterConst.ResUrl + "/formdata/female"; }
    }

    public override int id
    {
        get { return 1; }
    }
}
#endif