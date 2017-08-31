using UnityEngine;
using System.Collections;

public class CacheSOAData_Resource : CacheBase<SOAData_Resource>
{
    public CacheSOAData_Resource(string key) : base(key) { }
    protected override void unload()
    {
        _t.Dispose();
        base.unload();
    }
}
