using UnityEngine;
using System.Collections;

public class CharacterSystem : ICharacterSystem
{
    static bool hasload = false;
    public IEnumerator Initialize()
    {
        if (hasload)
        {
            yield break;
        }
        CharacterLoad load = new CharacterConfigLoad();
        load.LoadRes(new object[] {LoadCallback as CallBackWithParams<Object> });
        while(!hasload)
        {
            yield return 1;
        }
        yield return 0;
    }

    void LoadCallback(Object o)
    {
        if (o == null || hasload)
        {
            return;
        }

        ICharacterSysConfig config = new CharacterSysConfig();
        config.Initialize(o);

        hasload = true;
    }
}