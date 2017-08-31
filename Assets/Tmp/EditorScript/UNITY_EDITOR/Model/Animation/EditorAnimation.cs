#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
public abstract class EditorAnimation : IEditorAnimation
{
    abstract public string AnimPath { get; }
    abstract public EnumCharacterType sex { get; }

    protected ECharacterResType resType = ECharacterResType.Height;
    public EditorAnimation(ECharacterResType type)
    {
        resType = type;
    }

    public RuntimeAnimatorController Creat()
    {
        AnimatorController controller = new AnimatorController();

        controller.AddParameter(ActionConst.WALK, AnimatorControllerParameterType.Bool);
        controller.AddParameter(ActionConst.HELLO, AnimatorControllerParameterType.Bool);
        controller.AddParameter(ActionConst.TALK, AnimatorControllerParameterType.Bool);
        controller.AddParameter(ActionConst.CHANGE_CLOTH, AnimatorControllerParameterType.Bool);

        //if(CharacterConst.useExpAnim)
        //{
        //    controller.AddParameter(ActionConst.EXP_SMILE, AnimatorControllerParameterType.Bool);
        //    controller.AddParameter(ActionConst.EXP_TALK, AnimatorControllerParameterType.Bool);
        //}

        IObjectBase objBase = new ObjectBase(AnimPath);
        objBase.CreatAsset(controller);

        IEditorAnimationLayer baselayer = new EditorAnimationLayer_base(resType,controller, sex);
        baselayer.Create();
        IEditorAnimationLayer fittingroomlayer = new EditorAnimationLayer_fittingroom(resType,controller, sex);
        fittingroomlayer.Create();

        //if (CharacterConst.useExpAnim)
        //{
        //    IEditorAnimationLayer expressionlayer = new EditorAnimationLayer_expression(controller, sex);
        //    expressionlayer.Create();
        //}


        objBase.ImportAsset(ImportAssetOptions.ForceUpdate);

        return controller;
    }
}

public static class EditorAnimationFactory
{
    public static IEditorAnimation Creat(EnumCharacterType sex,ECharacterResType type)
    {
        if (sex == EnumCharacterType.Charater_Female)
        {
            return new EditorAnimation_Female(type);
        }
        else
        {
            return new EditorAnimation_Male(type);
        }
    }
}

public class EditorAnimation_Female : EditorAnimation
{
    public EditorAnimation_Female(ECharacterResType type)
        :base(type)
    { }
    public override string AnimPath
    {
        get { return string.Format("{0}/{1}/{2}/{3}.controller", CharacterConst.prefabPath, resType.ToString(),CharacterConst.Female, CharacterConst.femaleAnim); }
    }

    public override EnumCharacterType sex
    {
        get { return EnumCharacterType.Charater_Female; }
    }
}

public class EditorAnimation_Male : EditorAnimation
{
    public EditorAnimation_Male(ECharacterResType type)
        :base(type)
    { }

    public override string AnimPath
    {
        get { return string.Format("{0}/{1}/{2}/{3}.controller", CharacterConst.prefabPath, resType.ToString(), CharacterConst.Male, CharacterConst.maleAnim); }
    }
    public override EnumCharacterType sex
    {
        get { return EnumCharacterType.Charater_Male; }
    }
}
#endif