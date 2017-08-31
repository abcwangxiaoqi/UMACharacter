#if UNITY_EDITOR
using UnityEditor.Animations;
using UnityEngine;
public class EditorAnimationLayer_fittingroom : EditorAnimationLayer
{
    public EditorAnimationLayer_fittingroom(ECharacterResType type, AnimatorController _controller, EnumCharacterType _sex) : base(type,_controller, _sex) { }

    public override void Initialize(AnimatorControllerLayer layer)
    {
        EditorAnimationItem dressidle = new EditorAnimationItem_dressidle(resType, layer, sex);
        EditorAnimationItem changecloth = new EditorAnimationItem_changecloth(resType, layer, sex);
        changecloth.AddTransition(dressidle, AnimatorConditionMode.IfNot, 0f, ActionConst.CHANGE_CLOTH);
        dressidle.AddTransition(changecloth, AnimatorConditionMode.If, 0f, ActionConst.CHANGE_CLOTH, false);
    }

    public override string LayerName
    {
        get { return CharacterAnimLayer.fittingroomLayer; }
    }
}
#endif