#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
public interface IEditorAnimationLayer
{
    void Create();
}

abstract public class EditorAnimationLayer : IEditorAnimationLayer
{
    AnimatorController controller;
    public EnumCharacterType sex;
    protected ECharacterResType resType = ECharacterResType.Height;
    public EditorAnimationLayer(ECharacterResType type, AnimatorController _controller, EnumCharacterType _sex)
    {
        resType = type;
        controller = _controller;
        sex = _sex;       
    }

    abstract public string LayerName { get; }

    abstract public void Initialize(AnimatorControllerLayer layer);

    public void Create()
    {
        AnimatorControllerLayer layer = new AnimatorControllerLayer();
        AnimatorStateMachine stateMachine = new AnimatorStateMachine();
        AnimatorState state = new AnimatorState();
        stateMachine.AddEntryTransition(state);
        stateMachine.name = LayerName;
        stateMachine.hideFlags = HideFlags.HideInHierarchy;
        layer.stateMachine = stateMachine;

        AssetDatabase.AddObjectToAsset(layer.stateMachine, controller);
     

        layer.name = LayerName;
        
        Initialize(layer);

        controller.AddLayer(layer);
    }
}
#endif