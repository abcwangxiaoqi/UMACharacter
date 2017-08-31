using System.Collections;
using UnityEngine;
public class NativeTimer
{
    float time = -1f;
    bool Loop = true;
    Task task = null;
    CallBack callback = null;
    public NativeTimer(CallBack _callback, float t, bool loop = true)
    {
        callback = _callback;
        time = t;
        Loop = loop;
    }

    public void Start()
    {
        Stop();
        task = new Task(timeStart(), false);
        task.Start();
    }

    IEnumerator timeStart()
    {
        if (Loop)
        {
            while (true)
            {
                yield return new WaitForSeconds(time);
                if (callback != null)
                {
                    callback();
                }
            }
        }
        else
        {
            yield return new WaitForSeconds(time);
            if (callback != null)
            {
                callback();
            }
        }
        task = null;
    }

    public void Stop()
    {
        if (task != null)
        {
            Debug.Log("Stop--1");
            task.Stop();
            task = null;
        }
    }
}

public class Framer
{

    int frame = 0;
    bool Loop = true;
    Task task = null;
    CallBack callback = null;
    public Framer(CallBack _callback, int _frame, bool loop = true)
    {
        callback = _callback;
        frame = _frame;
        Loop = loop;
    }

    public void Start()
    {
        Stop();
        task = new Task(frameStart(), false);
        task.Start();
    }

    IEnumerator frameStart()
    {
        if (Loop)
        {
            while (true)
            {
                yield return frame;
                if (callback != null)
                {
                    callback();
                }
            }
        }
        else
        {
            yield return frame;
            if (callback != null)
            {
                callback();
            }
        }
        task = null;
    }

    public void Stop()
    {
        if (task != null)
        {
            task.Stop();
            task = null;
        }
    }
}

