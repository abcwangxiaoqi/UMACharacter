#if UNITY_EDITOR
using UnityEditor.Animations;
using UnityEngine;
public abstract class EditorAnimationItem
{
    public EnumCharacterType sex;
    public AnimatorState state;
    protected ECharacterResType resType = ECharacterResType.Height;
    public EditorAnimationItem(ECharacterResType type, AnimatorControllerLayer layer, EnumCharacterType _sex)
    {
        resType = type;
        AnimatorStateMachine baseSm = layer.stateMachine;
        state = baseSm.AddState(ClipName);
        sex = _sex;
        state.motion = motion;
    }

    abstract public string ClipName { get; }
    abstract public Motion motion { get; }
    public void AddTransition(EditorAnimationItem Anim, AnimatorConditionMode mode, float v, string parameter, bool hasExitTime = true)
    {
        AnimatorStateTransition st = state.AddTransition(Anim.state);
        st.AddCondition(mode, v, parameter);
        st.hasExitTime = hasExitTime;
    }
}
#endif