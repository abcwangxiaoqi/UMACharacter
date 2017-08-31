
using System.Collections.Generic;
using UMA;
using UMA.PoseTools;
using UnityEngine;
public static class CharacterPlayerFactory
{
    public static ICharacterPlayer Creat(CharacterData characterData, ECharacterResType type = ECharacterResType.Height)
    {
        return new CharacterPlayer(characterData, type);
    }
}

public sealed class CharacterPlayer : ICharacterPlayer
{

    bool isExpress = false;//是否需要表情动画
    ECharacterResType resType = ECharacterResType.Height;
    public CharacterPlayer(CharacterData _data,ECharacterResType type=ECharacterResType.Height)
    {
        characterData = _data.Copy<CharacterData>();
        resType = type;
    }

    public void Creat()
    {
        destroyFlag = false;

        Initialize();

        #region base
        characterBase.Initialize(() => 
        {
            #region cloths
            characterCloth.Initialize();
            #endregion
        });
        #endregion
    }

    public void PutOn(List<ClothModel> cms)
    {
        characterCloth.PutOn(cms);
    }

    public void PutOn(ClothModel cm)
    {
        characterCloth.PutOn(cm);
    }

    public void TakeOff(ClothModel cm)
    {
        characterCloth.TakeOff(cm);
    }

    public void TakeOff(string weapon)
    {
        if (string.IsNullOrEmpty(weapon))
            return;

        List<ClothModel> cms = characterData.avatars;
        ClothModel cm = cms.Find((ClothModel c) => 
        {
            return c.wearpos == weapon;
        });

        if (cm == null)
            return;

        TakeOff(cm.Copy<ClothModel>());
    }

    public void TakeOffAll()
    {
        characterCloth.TakeOffAll();
    }

    public void Destroy(float t = 0f)
    {
        if (destroyFlag)
            return;

        destroyFlag = true;
        if (gameObject != null)
        {
            GameObject.Destroy(gameObject, t);
        }

        #region 所有请求连接中断

        characterBase.Dispose();
        characterCloth.Dispose();

        #endregion
    }

    public CharacterData GetcharacterData()
    {
        //characterData.dna = characterDna.getUmaDna();
        return characterData.Copy<CharacterData>();
    }

    public void SetLayer(string layer)
    {
        Layer = layer;
        Updatelayer();
    }

    public void SetParent(Transform _parent)
    {
        Parent = _parent;
        UpdateVec();
    }

    public void SetLocalPosition(Vector3 pos)
    {
        Position = pos;
        UpdateVec();
    }

    public void SetLocalEulerAngles(Vector3 euler)
    {
        EulerAngles = euler;
        UpdateVec();
    }

    //public void SetDNA(EnumUmaParamters dna, float dnaValue)
    //{
    //    characterDna.changeDna(dna, dnaValue);
    //}

    public void PlayAnimation(string actionName,float speed=1f)
    {
        characterAnim.SetAction(actionName, speed);
    }

    public void Updata()
    {
        if (destroyFlag)
            return;
        characterAnim.recordAnim();
        umaDynamicAvatar.UpdateNewRace();
    }

    public void CompressMesh(int level)
    {
        if (gameObject == null)
            return;

        if (lodMesh==null)
        {
            lodMesh = new LODMesh(gameObject);
        }
        
        lodMesh.Lod(level);
    }

    #region private

    void Updatelayer()
    {
        if (!string.IsNullOrEmpty(Layer) && Layer != "Default")
        {
            gameObject.SetLayer(Layer);
        }
    }

    void UpdateVec()
    {
        if (destroyFlag)
            return;

        if (gameObject != null)
        {
            gameObject.transform.parent = Parent;
            gameObject.transform.localEulerAngles = EulerAngles;
            gameObject.transform.localPosition = Position;
            gameObject.transform.localScale = Vector3.one;
        }
    }

    void Initialize()
    {
        UMAInstance();

        gameObject = new GameObject(objectName);
        UpdateVec();

        umaContext = UMAContext.FindInstance();
        UMAGenerator generator = umaContext.umaGenerator;
        
        umaDynamicAvatar = gameObject.AddComponent<UMADynamicAvatar>();
        umaDynamicAvatar.Initialize();

        UMAData umaData = umaDynamicAvatar.umaData;
        umaDynamicAvatar.umaGenerator = generator;
        umaData.umaGenerator = generator;

        UMATextRecipe recipe = UMATextRecipe.CreateInstance<UMATextRecipe>();
        recipe.Load(umaData.umaRecipe, umaContext);
        umaDynamicAvatar.umaRecipe = recipe;
        umaData.AddAdditionalRecipes(new UMARecipeBase[] { umaContext.umaTextRecipe }, umaContext);
        umaData.OnCharacterCreated += CharacterCreated;
        umaData.OnCharacterUpdated += CharacterUpdated;
        umaData.OnCharacterDestroyed += CharacterDestroyed;

        if (isExpress)
        {
            expressionPlayer = gameObject.AddComponent<UMAExpressionPlayer>();
            expressionPlayer.overrideMecanimEyes = true;
            expressionPlayer.overrideMecanimHead = true;
            expressionPlayer.overrideMecanimJaw = true;
            expressionPlayer.overrideMecanimNeck = true;
        }

        umaData.umaRecipe.slotDataList = new SlotData[100];
        UMADnaHumanoid umaDna = new UMADnaHumanoid();
        UMADnaTutorial umaTutorialDNA = new UMADnaTutorial();
        umaData.umaRecipe.AddDna(umaDna);
        umaData.umaRecipe.AddDna(umaTutorialDNA);

        ICharacterSlotOverly characterSlotOverlay = new CharacterSlotOverly(umaDynamicAvatar);
        characterAnim = new CharacterAnim(umaDynamicAvatar);
        //characterDna = new CharacterDna(umaDna, umaData, characterAnim, characterData);
        characterBase = new CharacterBase(resType,characterSlotOverlay, umaData, umaDynamicAvatar, characterData);
        characterCloth = new CharacterCloth(resType,characterData, characterSlotOverlay, this, characterBase);        
    }

    static GameObject umaObj = null;
    GameObject UMAInstance()
    {
        if (umaObj == null)
        {
            Object uma = Resources.Load<GameObject>("UMA");
            umaObj = GameObject.Instantiate(uma) as GameObject;
            umaObj.name = "UMA";
        }
        return umaObj;
    }

    void CharacterCreated(UMAData umaData)
    {
        Debug.Log("CharacterCreated");

        if (isExpress)
        {
            expressionPlayer.expressionSet = umaDynamicAvatar.umaData.umaRecipe.raceData.expressionSet;
            expressionPlayer.umaData = umaDynamicAvatar.umaData;
            expressionPlayer.Initialize();
        }

        if(CreateFinish!=null)
        {
            CreateFinish();
            CreateFinish = null;
        }
    }

    void CharacterUpdated(UMAData umaData)
    {
        if (destroyFlag)
            return;

        gameObject.RefreshShader();

        Debug.Log("CharacterUpdated");
        characterAnim.continueAnim();

        Updatelayer();

        Resources.UnloadUnusedAssets();
    }   

    void CharacterDestroyed(UMAData umaData)
    {
        Debug.Log("CharacterDestroy");
    }
    #endregion

    #region Parmaters

    #region public

    string _objectName = "player";
    public string objectName
    {
        get
        {
            return _objectName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }
            _objectName = value;
            if (gameObject != null)
            {
                gameObject.name = _objectName;
            }
        }
    }

    public CallBack CreateFinish { get; set; }

    Vector3 Position = Vector3.zero;
    public Vector3 localPosition
    {
        get { return Position; }
    }

    Vector3 EulerAngles = Vector3.zero;
    public Vector3 localEulerAngles
    {
        get { return EulerAngles; }
    }

    Transform Parent = null;
    public Transform parent
    {
        get { return Parent; }
    }
    #endregion

    #region private
    UMADynamicAvatar umaDynamicAvatar;
    //ICharacterDna characterDna;
    ICharacterAnim characterAnim;
    ICharacterCloth characterCloth;
    ICharacterBase characterBase;

    CharacterData characterData = null;
    GameObject gameObject = null;
    string Layer = "";
    bool destroyFlag = false;

    UMAExpressionPlayer expressionPlayer;
    UMAContext umaContext;
    LODMesh lodMesh;
    #endregion

    #endregion
}
