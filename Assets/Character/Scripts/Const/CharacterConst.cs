using UnityEngine;
public static class CharacterConst
{
    public const string Female = "Human_Female";//女性
    public const string Male = "Human_Male";//男性

    public const string ResHeight = "Height";//资源高版本目录
    public const string ResLow = "Low";//资源低版本目录

    public const string Common = "Common";//衣服 裤子 鞋子 要用的组件名字

    public const string Eyes = "Eyes";
    public const string Face = "Face";//face

    public const string Base = "Base";
    public const string AB_Android = "android";
    public const string AB_Ios = "ios";
    public const string AB_win = "win";

    public const string targetFold = "characters";    
    public const string CharacterLayer = "Player";

    public const bool useLocalServer = //是否使用本地资源服务器测试
#if CharacterEditor
        false;
#else 
    false;
#endif


#if CharacterEditor
    public static bool assetBundle = false;
    public static string ResUrl = Application.dataPath + "/Tmp/AllResoruces/" + targetFold;
    public const string rootPath = "Assets/Tmp/FBX";//资源路径
    public const string prefabPath = "Assets/Tmp/Prefab/Resources";//prefab路径
    public const string femaleAnim = "femaleAnim";//female animatorcontroller name
    public const string maleAnim = "maleAnim";//male animatorcontroller name
#endif
}
public static class CharacterAnimLayer
{
    public const string baseLayer = "Base";
    public const string fittingroomLayer = "Fittingroom";
    public const string expressionLayer = "Expression";
}
