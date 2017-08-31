#if UNITY_EDITOR
using UnityEngine;
using System.Collections;

public class Template_Male3 : Template {

    public Template_Male3() : base(EnumCharacterType.Charater_Male) { }
    public override int id
    {
        get { return 3; }
    }

    public override string path
    {
        get { return CharacterConst.ResUrl + "/formdata/male"; }
    }
}
#endif
