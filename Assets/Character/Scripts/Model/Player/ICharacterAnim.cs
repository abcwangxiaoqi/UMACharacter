
using UnityEngine;
public interface ICharacterAnim
{
    void SetAction(string actionName, float speed);
    void recordAnim();
    void continueAnim();
}

