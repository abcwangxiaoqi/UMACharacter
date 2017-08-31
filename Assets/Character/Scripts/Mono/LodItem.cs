using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LODMesh
{
    LodMeshItem lodItem = null;
    public LODMesh(GameObject go)
    {
        if (go == null)
            return;
        lodItem = go.GetComponent<LodMeshItem>();
        if (lodItem == null)
        {
            lodItem = go.AddComponent<LodMeshItem>();
        }
    }

    /// <summary>
    /// compress mesh by level 
    /// level 0~8 , 0 restore, 1~8 compress ,you can modify it if you want
    /// </summary>
    /// <param name="level">compress level</param>
    public void Lod(int level)
    {
        if (level < 0)
        {
            level = 0;
        }        

        if (level > 8)
        {
            level = 8;
        }
        float lodV = 0.25f;
        switch (level)
        {
            case 0:
                lodV = 0f;
                break;
            case 1:
                lodV = 0.25f;
                break;
            case 2:
                lodV = 0.5f;
                break;
            case 3:
                lodV = 0.75f;
                break;
            case 4:
                lodV = 1f;
                break;
            case 5:
                lodV = 1.25f;
                break;
            case 6:
                lodV = 1.5f;
                break;
            case 7:
                lodV = 1.75f;
                break;
            case 8:
                lodV = 2f;
                break;
        }

        lodItem.LOD(lodV);
    }
}


public class LodMeshItem : MonoBehaviour {

    Dictionary<object, Mesh> originalMeshs = new Dictionary<object, Mesh>();//original mesh

    List<object> meshlist = new List<object>();
	// Use this for initialization
	void Awake () {

       SkinnedMeshRenderer[] smrs= gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
       MeshFilter[] mfs = gameObject.GetComponentsInChildren<MeshFilter>();

        if(smrs!=null)
        {
            meshlist.AddRange(new List<object>(smrs));
        }

        if (mfs != null)
        {
            meshlist.AddRange(new List<object>(mfs));
        }

        for (int i = 0; i < meshlist.Count; i++)
        {
            if(meshlist[i] is SkinnedMeshRenderer)
            {
                SkinnedMeshRenderer smr = meshlist[i] as SkinnedMeshRenderer;
                originalMeshs[meshlist[i]] = smr.sharedMesh;
            }
            else
            {
                MeshFilter mf = meshlist[i] as MeshFilter;
                originalMeshs[meshlist[i]] = mf.sharedMesh;
            }
        }
	}

    public void LOD(float lod)
    {
        for (int i = 0; i < meshlist.Count; i++)
        {
            Mesh original = originalMeshs[meshlist[i]];
            if(meshlist[i] is SkinnedMeshRenderer)
            {
                SkinnedMeshRenderer smr = meshlist[i] as SkinnedMeshRenderer;
                if(lod>0f)
                {                    
                    LODMaker.MakeLODMesh(original, smr, lod);
                }
                else
                {
                    smr.sharedMesh = original;
                }

            }
            else
            {
                MeshFilter mf = meshlist[i] as MeshFilter;
                if (lod > 0f)
                {                    
                    LODMaker.MakeLODMesh(original, mf, lod);
                }
                else
                {
                    mf.sharedMesh = original;
                }
            }
        }
    }
}
