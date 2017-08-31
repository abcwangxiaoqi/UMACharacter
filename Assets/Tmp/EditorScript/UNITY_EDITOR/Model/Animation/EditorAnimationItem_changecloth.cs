#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
public class EditorAnimationItem_changecloth : EditorAnimationItem
{
    public EditorAnimationItem_changecloth(ECharacterResType type, AnimatorControllerLayer layer, EnumCharacterType _sex) : base(type,layer, _sex) { }
    public override Motion motion
    {
        get
        {
            string fbxpath = "";
            if (sex == EnumCharacterType.Charater_Female)
            {
                fbxpath = string.Format("{0}/{1}/{2}@{3}.fbx", CharacterConst.rootPath, CharacterConst.Female, CharacterConst.Female, ClipName);
            }
            else
            {
                fbxpath = string.Format("{0}/{1}/{2}@{3}.fbx", CharacterConst.rootPath, CharacterConst.Male, CharacterConst.Male, ClipName);
            }

            AnimationClip clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(fbxpath);
            return clip;
        }
    }

    public override string ClipName
    {
        get { return ActionConst.CHANGE_CLOTH; }
    }
}
#endif