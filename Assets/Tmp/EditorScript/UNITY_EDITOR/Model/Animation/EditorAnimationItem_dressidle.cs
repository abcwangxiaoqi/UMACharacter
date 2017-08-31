#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
public class EditorAnimationItem_dressidle : EditorAnimationItem
{
    public EditorAnimationItem_dressidle(ECharacterResType type, AnimatorControllerLayer layer, EnumCharacterType _sex) : base(type,layer, _sex) { }
    public override Motion motion
    {
        get
        {
            string fbxpath = "";
            if (sex == EnumCharacterType.Charater_Female)
            {
                fbxpath = string.Format("{0}/{1}/{2}/{3}@{4}.fbx", CharacterConst.rootPath, resType.ToString(), CharacterConst.Female, CharacterConst.Female, ClipName);
            }
            else
            {
                fbxpath = string.Format("{0}/{1}/{2}/{3}@{4}.fbx", CharacterConst.rootPath, resType.ToString(), CharacterConst.Male, CharacterConst.Male, ClipName);
            }

            AnimationClip clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(fbxpath);
            return clip;
        }
    }

    public override string ClipName
    {
        get { return ActionConst.DRESS_IDLE; }
    }
}
#endif