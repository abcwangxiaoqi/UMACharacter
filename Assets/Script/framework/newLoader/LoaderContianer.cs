/// <summary>
/// loader 容器 
/// </summary>

using System.Collections.Generic;
using UnityEngine;
public class LoaderContianer
{
    #region Parmters

    List<LoaderTask> taskList = null;

    List<LoaderItem> loaderitemList = null;

    NativeTimer timer;
    #endregion

    public LoaderContianer(int synchronize = 1)
    {
        if (synchronize<1)
        {
            synchronize = 1;
        }

        taskList = new List<LoaderTask>();
        loaderitemList = new List<LoaderItem>();
        for (int i = 0; i < synchronize; i++)
        {
            LoaderItem item = new LoaderItem();
            item.AddListenerIdle(LoadFinish);
            loaderitemList.Add(item);
        }

        timer = new NativeTimer(Update, 0.3f);
        timer.Start();
    }

    void LoadFinish(LoaderItem loader)
    {
        #region 有相同的请求 统一执行回调

        List<LoaderTask> tasks = taskList.FindAll((LoaderTask t) =>
        {
            LoaderTask tk = loader.currentLoaderTask;
            return t.url == tk.url && 
                t.type == tk.type;
        });

        if (tasks != null)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                LoaderTask lt = tasks[i];
                lt.SetResponseData(loader.reponseData);
                taskList.Remove(tasks[i]);
            }
        }
        #endregion
    }

    LoaderItem GetIdleLoaderItem()
    {
        LoaderItem loader = loaderitemList.Find((LoaderItem li) =>
        {
            return li.isIdle;
        });
        return loader;
    }

    int GetLoaderTaskIndex()
    {
        int index = -1;
        for (int i = 0; i < taskList.Count; i++)
        {
            LoaderTask lt = taskList[i];

            bool exsitSame = loaderitemList.Exists((LoaderItem li) =>
            {
                return !li.isIdle && 
                    li.currentLoaderTask != null && 
                    li.currentLoaderTask.url == lt.url && 
                    li.currentLoaderTask.type == lt.type;
            });
            if (exsitSame)
            {
                continue;
            }
            else
            {
                index = i;
                break;
            }
        }
        return index;
    }

    void Update()
    {
        if (taskList.Count == 0)
        {
            return;
        }

        while (true)
        {
            LoaderItem loader = GetIdleLoaderItem();
            if (loader == null)
            {//没有空闲loader
                break;
            }

            int taskindex = GetLoaderTaskIndex();
            if (taskindex < 0)
            {//没有需要轮询的请求
                return;
            }

            LoaderTask lt = taskList[taskindex];
            taskList.RemoveAt(taskindex);
            loader.InsertTask(lt);
        }
    }

    public void InsertTask(LoaderTask task)
    {
        taskList.Add(task);
    }

    public void DeleteTask(LoaderTask task)
    {
        if(taskList.Contains(task))
        {
            taskList.Remove(task);
        }
        else
        {
           LoaderItem item= loaderitemList.Find((LoaderItem _loader) => 
            {
                return !_loader.isIdle &&
                    _loader.currentLoaderTask == task;
            });

            if(item!=null)
            {
                item.Dispose();
            }
        }
    }
}
