using UnityEngine;
using System.Collections;

public class AnimsPanel : MonoBehaviour {

    GameObject idle;
    GameObject talk;
    GameObject walk;
    GameObject hello;
    GameObject change_cloth;
    GameObject change_shoe;
    GameObject dress_idle;
	// Use this for initialization
	void Start () {
        idle = gameObject.FindInChildren("idle");
        talk = gameObject.FindInChildren("talk");
        walk = gameObject.FindInChildren("walk");
        hello = gameObject.FindInChildren("hello");
        change_cloth = gameObject.FindInChildren("change_cloth");
        change_shoe = gameObject.FindInChildren("change_shoe");
        dress_idle = gameObject.FindInChildren("dress_idle");

        EventTriggerListener.Get(idle).onClicks.Add(idle_Click);
        EventTriggerListener.Get(talk).onClicks.Add(talk_Click);
        EventTriggerListener.Get(walk).onClicks.Add(walk_Click);
        EventTriggerListener.Get(hello).onClicks.Add(hello_Click);
        EventTriggerListener.Get(change_cloth).onClicks.Add(change_cloth_Click);
        EventTriggerListener.Get(change_shoe).onClicks.Add(change_shoe_Click);
        EventTriggerListener.Get(dress_idle).onClicks.Add(dress_idle_Click);
	}

    void dress_idle_Click()
    {
        UISystem.Instance.player.PlayAnimation(ActionConst.DRESS_IDLE);
    }

    void idle_Click()
    {
        UISystem.Instance.player.PlayAnimation(ActionConst.IDLE);
    }
    void talk_Click()
    {
        UISystem.Instance.player.PlayAnimation(ActionConst.TALK);
    }
    void walk_Click() 
    {
        UISystem.Instance.player.PlayAnimation(ActionConst.WALK);
    }
    void hello_Click() 
    {
        UISystem.Instance.player.PlayAnimation(ActionConst.HELLO);
    }
    void change_cloth_Click() 
    {
        UISystem.Instance.player.PlayAnimation(ActionConst.CHANGE_CLOTH);
    }
    void change_shoe_Click() 
    {
    }
}
