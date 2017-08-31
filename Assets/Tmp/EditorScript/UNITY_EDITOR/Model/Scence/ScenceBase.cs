using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public interface IScence
{
    void Load();
}

abstract public class ScenceBase : IScence
{
    abstract public string name { get; }
    public void Load()
    {
        SceneManager.LoadScene(name);
    }

    public AsyncOperation LoadAsync()
    {
        return SceneManager.LoadSceneAsync(name);
    }
}

public class ScenceFittingroom : ScenceBase
{

    public override string name
    {
        get { return "changePersonSceenThreeUI"; }
    }
}

public class ScenceEditor : ScenceBase
{
    public override string name
    {
        get { return "CharacterBasisUISceen"; }
    }
}

public class ScenceExpression : ScenceBase
{

    public override string name
    {
        get { return "ExpressionSceenUI"; }
    }
}
public class ScenceResources : ScenceBase
{

    public override string name
    {
        get { return "ResourceSceenUI"; }
    }
}