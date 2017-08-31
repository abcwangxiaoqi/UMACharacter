using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UMA;
using System.IO;

public class ClothType
{
    public ClothType(string _value, string _name)
    {
        value = _value;
        name = _name;
    }
    public string value;
    public string name;
}

public class UISystem : MonoBehaviour
{
    public RawImage playerImg;
    public SuperSampling_SSAA sample;

    List<ClothType> cloths = new List<ClothType>();
    public static UISystem Instance;

    ECharacterResType resType = ECharacterResType.Low;
    void Awake()
    {
        Instance = this;

        ClothType hair = new ClothType(WearPosConst.WAER_POS_HAIR, "头发");
        cloths.Add(hair);
        ClothType cloth = new ClothType(WearPosConst.WAER_POS_CLOTH, "衣服");
        cloths.Add(cloth);
        ClothType pant = new ClothType(WearPosConst.WEAR_POS_PANT, "裤子");
        cloths.Add(pant);
        ClothType shoe = new ClothType(WearPosConst.WEAR_POS_SHOE, "鞋");
        cloths.Add(shoe);
        ClothType suit = new ClothType(WearPosConst.WEAR_POS_SUIT, "套装");
        cloths.Add(suit);
    }
    public Camera cam;

    public GameObject male;
    public GameObject female;

    public DnaPanel danPnael;
    public GameObject tempBtn;

    public GameObject lod1;
    public GameObject lod2;
    public GameObject lod3;
    public GameObject lod4;
    public GameObject lod5;
    public GameObject lod6;

    public VerticalLayoutGroup patchDetial;
    public VerticalLayoutGroup patch;
    GameObject playerParent;
    List<ClothModel> clothData = new List<ClothModel>();
    EnumCharacterType currentType = EnumCharacterType.Charater_Female;//current sex
    string currentPatch = string.Empty;//current patch; 
    // Use this for initialization

    IEnumerator Start()
    {
        ICharacterSystem sys = new CharacterSystem();
        yield return StartCoroutine(sys.Initialize());

        clothData = ClothModel.GetData();
        IniClothType();
        playerParent = GameObject.Find("Stage/playerRoot");

        EventTriggerListener.Get(male).onClicks.Add(male_Click);
        EventTriggerListener.Get(female).onClicks.Add(female_Click);

        EventTriggerListener.Get(lod1).onClicks.Add(delegate() { TaskServices.CreateTask(lod_Click(1)).Start(); });
        EventTriggerListener.Get(lod2).onClicks.Add(delegate() { TaskServices.CreateTask(lod_Click(2)).Start(); });
        EventTriggerListener.Get(lod3).onClicks.Add(delegate() { TaskServices.CreateTask(lod_Click(3)).Start(); });
        EventTriggerListener.Get(lod4).onClicks.Add(delegate() { TaskServices.CreateTask(lod_Click(4)).Start(); });
        EventTriggerListener.Get(lod5).onClicks.Add(delegate() { TaskServices.CreateTask(lod_Click(5)).Start(); });
        EventTriggerListener.Get(lod6).onClicks.Add(delegate() { TaskServices.CreateTask(lod_Click(0)).Start(); });
        EventTriggerListener.Get(tempBtn).onClicks.Add(tempBtn_Click);

        female_Click();
        //male_Click();

        UseTimeAlphaManager.StartTimeAlpha(UseTimeAlphaManager.LoadRole);

    }

    IEnumerator change()
    {
        yield return new WaitForEndOfFrame();
        //After Unity4,you have to do this function after WaitForEndOfFrame in Coroutine
        //Or you will get the error:"ReadPixels was called to read pixels from system frame buffer, while not inside drawing frame"
        zzTransparencyCapture.captureScreenshot("Assets/TTT.png");
        yield break;
        string pngName = "player.png";
        string loadpath = string.Format("file:///{0}/{1}", Application.persistentDataPath, pngName);

        string shotPath = string.Format("{0}/{1}", Application.persistentDataPath, pngName);
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            shotPath = pngName;
        }

        danPnael.gameObject.SetActive(false);

        Application.CaptureScreenshot(shotPath);

        yield return 1;

        danPnael.gameObject.SetActive(true);

        while (!System.IO.File.Exists(shotPath))
        {
            yield return 1;
        }

        WWW w = new WWW(loadpath);
        yield return w;
        if(w.error!=null)
        {
            Debug.LogError(w.error);
            yield break;
        }

        Texture2D t = w.texture;
        playerImg.texture = t;
    }

    void loadicon(SOAData_Resource sr)
    {
        Debug.Log(sr.texture);
    }

    void tempBtn_Click()
    {
        //SOAService_Resource_Character_ICON _icon = new SOAService_Resource_Character_ICON("0204_0001");
        //_icon.AddListener(loadicon);
        //_icon.Run();

        //sample.TakeHighScaledShot(1080, 1920, sample.screenshotScale, sample.screenshotFilter, "/../" + sample.relativeScreenshotPath);
        //return;

        StartCoroutine(change());
        return;
        danPnael.gameObject.SetActive(false);
        string p = Application.dataPath + "/player.png";

        Camera c = Camera.main;
        Rect r = new Rect();
        r.width = 1080f;
        r.height = 1920f;

        CameraPng.CaptureCamera(c, r, p);
        //Application.CaptureScreenshot(p);
        danPnael.gameObject.SetActive(true);
        return;

#if UNITY_EDITOR

        //IExpressModel male = new ExpressModel_Male();//实例化男性
        //IExpressModel female = new ExpressModel_Female();//实例化女性

        CompressAssetbundleZip com = new CompressAssetbundleZip();
        com.Compress();
        return;
        ITemplate male2 = new Template_Male2();//女性模板2
        List<TemplateClothItem> cloths= male2.LoadCloths();
        TemplateIcon icon = male2.LoadIcon();
        return;

        TemplateCloth cloth = new TemplateCloth();
        List<TemplateClothItem> list= cloth.Load(EnumCharacterType.Charater_Female, "04");
        return;

        ImportBase female = new ImportFemale();
        female.Import();

        ImportBase male = new ImportMale();
        male.Import();

        ImportBase import = new ImportIcon();
        import.Import();

        IniEditor.iniData();

        PackagerEditor.Assetbundle_All();

        BuildPlayer build = new BuildPlayer_Android();
        build.Build();

        ExportBase export = new CharacterCustomExport();
        export.ExportAsset();

        ClearLocalData.clear();
        
        CharacterConst.assetBundle = true;//使用
        CharacterConst.assetBundle = false;//不使用

        ITemplate female1 = new Template_Female1();//女性模板1
        ITemplate female2 = new Template_Female1();//女性模板2
        ITemplate male1 = new Template_Male1();//女性模板1
        

        /*IScence scence = new ScenceExpression();
        scence.Load();
        return;

        BuildPlayer build = new BuildPlayer_Android();
        build.Build();
        return;

        ExportBase export = new CharacterCustomExport();
        export.ExportAsset();
        return;

        ClearLocalData.clear();
        return;

        ImportBase import = new ImportIcon();
        import.Import();
        return;*/
        //IniEditor.iniData();


        // ImportBase female = new ImportFemale();
        //female.Import();
        //string path3 = EditorUtility.OpenFolderPanel("import female fold", "C:/Users/Administrator/Desktop", "");
        //string url = "http://192.168.1.151:90/Characters/face/0203_0111.png";
        //player.ChangeFace(url);
        //    player.CompressMesh(1);
#endif
    }

    void IniClothType()
    {
        patch.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 80 * (cloths.Count));
        for (int i = 0; i < cloths.Count; i++)
        {
            ClothType ct = cloths[i];
            GameObject g = Resources.Load<GameObject>("UI/patchItem");
            GameObject go = GameObject.Instantiate(g);
            patchItem pi = go.GetComponent<patchItem>();
            pi.Ini(ct);
            go.transform.parent = patch.transform;
            go.transform.localScale = Vector3.one;

            EventTriggerListener.Get(go).onClicks.Add(() =>
            {
                currentPatch = ct.value;
                IniatializeScroll();
            });
        }
    }


    void male_Click()
    {
        if (player != null)
        {
            player.Destroy();
        }
        player = new CharacterPlayer(CharacterData.defData(EnumCharacterType.Charater_Male), resType);
        player.SetParent(playerParent.transform);
        player.Creat();
        currentType = EnumCharacterType.Charater_Male;
    }

    public ICharacterPlayer player { get; private set; }
    void female_Click()
    {
        if (player != null)
        {
            player.Destroy();
            Resources.UnloadUnusedAssets();
        }

        CharacterData data = CharacterData.defData(EnumCharacterType.Charater_Female);
        player = new CharacterPlayer(data, resType);
        player.SetParent(playerParent.transform);
        player.Creat();
    }

    void IniatializeScroll()
    {
        patchDetial.transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;

        foreach (Transform item in patchDetial.transform)
        {
            Destroy(item.gameObject);
        }

        List<ClothModel> list = clothData.FindAll((ClothModel m) =>
        {
            string sex = currentType == EnumCharacterType.Charater_Female ? "02" : "01";
            return m.sex == sex && m.wearpos == currentPatch;
        });

        if (list.Count == 0)
            return;

        Object o = Resources.Load("UI/patchDetialItem");
        patchDetial.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 80 * (list.Count + 1));

        GameObject go = null;
        for (int i = 0; i < list.Count; i++)
        {
            ClothModel cm = list[i];
            go = Instantiate(o) as GameObject;
            go.transform.parent = patchDetial.transform;
            go.transform.localScale = Vector3.one;

            go.GetComponent<patchDetialItem>().Ini(cm);

            EventTriggerListener.Get(go).onClicks.Add(() =>
            {
                player.PutOn(cm);
            });
        }

        go = Instantiate(o) as GameObject;
        go.name = currentPatch + " take off";
        go.transform.parent = patchDetial.transform;
        go.transform.localScale = Vector3.one;

        go.GetComponent<patchDetialItem>().text.text = currentPatch + " take off";
        EventTriggerListener.Get(go).onClicks.Add(() =>
        {
            player.TakeOff(currentPatch);
        });
    }

    public void SetDna(EnumUmaParamters dan,float v)
    {
        if(player!=null)
        {
           // player.SetDNA(dan, v);
        }
    }

    IEnumerator lod_Click(int level)
    {
        //currentPlayer.CompressMesh(level);
        yield break;
    }
}