#if UNITY_EDITOR
using UnityEditor.Animations;
public class EditorAnimationLayer_base : EditorAnimationLayer
{
    public EditorAnimationLayer_base(ECharacterResType type, UnityEditor.Animations.AnimatorController _controller, EnumCharacterType _sex) : base(type,_controller, _sex) { }

    public override void Initialize(AnimatorControllerLayer layer)
    {

        EditorAnimationItem idle = new EditorAnimationItem_idle(resType,layer, sex);

        EditorAnimationItem walk = new EditorAnimationItem_walk(resType, layer, sex);
        walk.AddTransition(idle, AnimatorConditionMode.IfNot, 0f, ActionConst.WALK);
        idle.AddTransition(walk, AnimatorConditionMode.If, 0f, ActionConst.WALK, false);

        EditorAnimationItem hello = new EditorAnimationItem_hello(resType, layer, sex);
        hello.AddTransition(idle, AnimatorConditionMode.IfNot, 0f, ActionConst.HELLO);
        idle.AddTransition(hello, AnimatorConditionMode.If, 0f, ActionConst.HELLO, false);

        EditorAnimationItem_talk talk = new EditorAnimationItem_talk(resType, layer, sex);
        talk.AddTransition(idle, AnimatorConditionMode.IfNot, 0f, ActionConst.TALK);
        idle.AddTransition(talk, AnimatorConditionMode.If, 0f, ActionConst.TALK, false);
    }

    public override string LayerName
    {
        get { return CharacterAnimLayer.baseLayer; }
    }
}
#endif