#if UNITY_EDITOR
public static class EditorUtil
{
    public static ClothModel CreateClothModelByAsset(IObjectBase iob)
    {
        if (iob == null)
            return null;
        ClothModel cm = new ClothModel();
        cm.itemid = iob.Name;
        cm.resname = iob.Name;
        cm.icon = iob.Name;
        cm.sex = iob.Name.Substring(0, 2);
        cm.wearpos = iob.Name.Substring(2, 2);
        return cm;
    }
}
#endif
