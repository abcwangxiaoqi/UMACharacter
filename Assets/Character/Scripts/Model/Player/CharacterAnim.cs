
using System.Collections;
using UnityEngine;
public class CharacterAnim : ICharacterAnim
{
    Animator animator;
    UMADynamicAvatar umaDynamicAvatar;
    int expressionLayer = 2;//expression layer
    public CharacterAnim(UMADynamicAvatar _umaDynamicAvatar)
    {
        umaDynamicAvatar = _umaDynamicAvatar;
    }
    void Initialize()
    {
        animator = umaDynamicAvatar.umaData.animator;
    }

    IEnumerator setAction(string actionName,float speed)
    {
        while(animator==null)
        {
            yield return 0;
        }

        if (animator.GetBool(actionName))
        {
            yield break;
        }

        animator.Rebind();

        if (actionName == ActionConst.CHANGE_CLOTH ||
            actionName == ActionConst.CHANGE_SHOE ||
            actionName == ActionConst.CHANGE_FACEHAIR ||
            actionName == ActionConst.DRESS_IDLE)
        {
            SetCurrentAnimLayer(CharacterAnimLayer.fittingroomLayer);
            if (actionName == ActionConst.DRESS_IDLE)
            {
                animator.SetBool(ActionConst.CHANGE_CLOTH, false);
                animator.SetBool(ActionConst.CHANGE_FACEHAIR, false);
                animator.SetBool(ActionConst.CHANGE_SHOE, false);
            }
            else
            {
                animator.SetBool(actionName, true);
                SimpleTaskServices.CreateTask(SetAnim(actionName)).Start();
            }
        }
        else
        {
            SetCurrentAnimLayer(CharacterAnimLayer.baseLayer);
            if (actionName == ActionConst.IDLE)
            {
                animator.SetBool(ActionConst.HELLO, false);
                animator.SetBool(ActionConst.TALK, false);
                animator.SetBool(ActionConst.WALK, false);
            }
            else
            {
                animator.SetBool(actionName, true);
                if (actionName != ActionConst.WALK)
                {
                    SimpleTaskServices.CreateTask(SetAnim(actionName)).Start();
                }
            }
        }
    }

    public void SetAction(string actionName, float speed)
    {
        if (string.IsNullOrEmpty(actionName))
        {
            Debug.LogWarning("action name is null !!!");
            return;
        }
        SimpleTaskServices.CreateTask(setAction(actionName, speed)).Start();
    }

    public void recordAnim()
    {
        normalizedTime = 0f;
        statename = 0;
        hello = false;
        talk = false;
        walk = false;
        change = false;
        if (animator != null)
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(animlayer);
            normalizedTime = info.normalizedTime;
            statename = info.nameHash;

            hello = animator.GetBool(ActionConst.HELLO);
            talk = animator.GetBool(ActionConst.TALK);
            walk = animator.GetBool(ActionConst.WALK);
            change = animator.GetBool(ActionConst.CHANGE_CLOTH);
        }
    }

    public void continueAnim()
    {
        Initialize();
        if (animator != null)
        {
            SetCurrentAnimLayer(currentAnimLayer);

            animator.SetBool(ActionConst.HELLO, hello);
            animator.SetBool(ActionConst.TALK, talk);
            animator.SetBool(ActionConst.WALK, walk);
            animator.SetBool(ActionConst.CHANGE_CLOTH, change);

            animator.Play(statename, animlayer, normalizedTime);
        }
    }

    #region private

    int animlayer = 0;
    string currentAnimLayer = CharacterAnimLayer.baseLayer;
    void SetCurrentAnimLayer(string layerName)
    {
        if (animator == null)
            return;

        int index = animator.GetLayerIndex(layerName);
        if (index < 0)
        {
            return;
        }

        animlayer = index;

        for (int i = 0; i < animator.layerCount; i++)
        {
            if (i == index || i == expressionLayer)
            {
                animator.SetLayerWeight(i, 1);
                continue;
            }
            animator.SetLayerWeight(i, 0);
        }

        currentAnimLayer = layerName;
    }

    IEnumerator SetAnim(string actionName)
    {
        bool start = false;
        while (!start)
        {
            float t = 0f;
            if (animator.GetAnimNormalizedTime(currentAnimLayer, actionName, out t))
            {
                if (t > 0.8f)
                {
                    animator.SetBool(actionName, false);
                    start = true;
                    yield return 0;
                }
                yield return 0;
            }
            yield return 0;
        }
        yield return 1;
    }

    #region  refresh anim . protect animations' seriality
    float normalizedTime = 0f;
    int statename = 0;
    bool hello = false;
    bool talk = false;
    bool walk = false;
    bool change = false;
    #endregion

    #endregion
}