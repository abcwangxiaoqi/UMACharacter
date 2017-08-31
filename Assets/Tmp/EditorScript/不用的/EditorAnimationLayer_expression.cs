//#if UNITY_EDITOR
//using UnityEditor;
//using UnityEditor.Animations;
//using UnityEngine;
//public class EditorAnimationLayer_expression : EditorAnimationLayer
//{
//    public EditorAnimationLayer_expression(AnimatorController _controller, EnumCharacterType _sex) : base(_controller, _sex) { }

//    public override void Initialize(AnimatorControllerLayer layer)
//    {

//        layer.defaultWeight = 1f;

//        #region AvatarMask
//        string maskPath = string.Format("{0}/Mask/HeadMask.mask", CharacterConst.rootPath);
//        IObjectBase maskobject = new ObjectBase(maskPath);
//        AvatarMask mask = maskobject.Load() as AvatarMask;
//        layer.avatarMask = mask;
//        #endregion
//        layer.name = CharacterAnimLayer.expressionLayer;

//        EditorAnimationItem blink = new EditorAnimationItem_expblink(layer, sex);

//        EditorAnimationItem smile = new EditorAnimationItem_expsmile(layer, sex);
//        smile.AddTransition(blink, AnimatorConditionMode.IfNot, 0f, ActionConst.EXP_SMILE);
//        blink.AddTransition(smile, AnimatorConditionMode.If, 0f, ActionConst.EXP_SMILE, false);

//        EditorAnimationItem talk = new EditorAnimationItem_exptalk(layer, sex);
//        talk.AddTransition(blink, AnimatorConditionMode.IfNot, 0f, ActionConst.EXP_TALK);
//        blink.AddTransition(talk, AnimatorConditionMode.If, 0f, ActionConst.EXP_TALK, false);
//    }

//    public override string LayerName
//    {
//        get { return CharacterAnimLayer.expressionLayer; }
//    }
//}
//#endif