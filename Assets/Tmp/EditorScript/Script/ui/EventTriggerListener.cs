/*
 * 重载按钮的点击事件 效果
 */
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class EventTriggerListener : EventTrigger
{
    public delegate void TriggerDelegate();
    public List<TriggerDelegate> onClicks=new List<TriggerDelegate>();
    public List<TriggerDelegate> onDowns = new List<TriggerDelegate>();
    public List<TriggerDelegate> onEnters = new List<TriggerDelegate>();
    public List<TriggerDelegate> onExits = new List<TriggerDelegate>();
    public List<TriggerDelegate> onUps = new List<TriggerDelegate>();
    public List<TriggerDelegate> onSelects = new List<TriggerDelegate>();
    public List<TriggerDelegate> onUpdateSelects = new List<TriggerDelegate>();

    static public EventTriggerListener Get(GameObject go)
    {
        EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
        if (listener == null) listener = go.AddComponent<EventTriggerListener>();
        return listener;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (m_gray) return;

        if(onClicks!=null && onClicks.Count>0)
        {
            for (int i = 0; i < onClicks.Count; ++i)
            {
                onClicks[i]();
            }
        }
    }
    public override void OnPointerDown(PointerEventData eventData)
    {

        if (m_gray) return;

        clickDown();
        
        if (onDowns != null && onDowns.Count > 0)
        {
            for (int i = 0; i < onDowns.Count; ++i)
            {
                onDowns[i]();
            }
        }
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {

        if (m_gray) return;
       
        if (onEnters != null && onEnters.Count > 0)
        {
            for (int i = 0; i < onEnters.Count; ++i)
            {
                onEnters[i]();
            }
        }
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (m_gray) return;

        if (onExits != null && onExits.Count > 0)
        {
            for (int i = 0; i < onExits.Count; ++i)
            {
                onExits[i]();
            }
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (m_gray) return;

        clickUp();
       
        if (onUps != null && onUps.Count > 0)
        {
            for (int i = 0; i < onUps.Count; ++i)
            {
                onUps[i]();
            }
        }
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (m_gray) return;

        if (onSelects != null && onSelects.Count > 0)
        {
            for (int i = 0; i < onSelects.Count; ++i)
            {
                onSelects[i]();
            }
        }
    }
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (m_gray) return;

        if (onUpdateSelects != null && onUpdateSelects.Count > 0)
        {
            for (int i = 0; i < onUpdateSelects.Count; ++i)
            {
                onUpdateSelects[i]();
            }
        }
    }

    Vector3 startSize = Vector3.one;
    Vector3 endSize = new Vector3(1.1f, 1.1f, 1.1f);

    public void setAnimSize(Vector3 start,Vector3 end)
    {
        startSize = start;
        endSize = end;
    }

    public Image m_image;

    private GameObject m_obj;
    private bool m_gray = false;// 默认可用，变灰不可以再变色 

    Color startColor = Color.white;
    public void Awake()
    {
        m_obj = gameObject;
        if (null == m_image)
        {
            m_image = GetComponent<Image>();
            if(null!=m_image)
            {
                startColor = m_image.color;
            }
        }
            
    }

    public void SetGray(bool bGray)
    {
        m_gray = bGray;
        if (bGray)
            clickUnEnable();
        else
            clickUp();
    }  

    void clickUnEnable()
    {
        if (null == m_image)
        {
            return;
        }
        m_image.color = new Color(85 / 255f, 85 / 255f, 85 / 255f, 1);
    }

    void clickDown()
    {       
        if(null== m_image)
        {
            return;
        }
        m_image.color = new Color(85 / 255f, 85 / 255f, 85 / 255f, 1);
        transform.localScale = endSize;
    }

    void clickUp()
    {
        if (null == m_image)
        {
            return;
        }
        m_image.color = startColor;
        transform.localScale = startSize;
    }
}