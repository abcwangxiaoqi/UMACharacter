//#if UNITY_EDITOR
//using UnityEditor;
//using UnityEditor.Animations;
//using UnityEngine;
//public class EditorAnimationItem_exptalk : EditorAnimationItem
//{
//    public EditorAnimationItem_exptalk(AnimatorControllerLayer layer, EnumCharacterType _sex) : base(layer, _sex) { }
//    public override string ClipName
//    {
//        get { return ActionConst.EXP_TALK; }
//    }

//    public override Motion motion
//    {
//        get
//        {
//            string fbxpath = "";
//            if (sex == EnumCharacterType.Charater_Female)
//            {
//                fbxpath = string.Format("{0}/{1}/{2}@{3}.anim", CharacterConst.rootPath, CharacterConst.Female, CharacterConst.Female, ClipName);
//            }
//            else
//            {
//                fbxpath = string.Format("{0}/{1}/{2}@{3}.anim", CharacterConst.rootPath, CharacterConst.Male, CharacterConst.Male, ClipName);
//            }

//            AnimationClip clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(fbxpath);
//            return clip;
//        }
//    }
//}
//#endif