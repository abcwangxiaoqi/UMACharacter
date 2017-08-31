using UnityEngine;
using System.Collections;

public class Global  {

    private  bool m_debug = true;
    private static Global instance;
    public static Global Instance()
    {
        if (instance == null)
        {
            instance = new Global();
        }
        return instance;
    }

    /// <summary>
    /// 3d加载错误打印日志
    /// </summary>
    public static bool load3DErrorPrint = false;
    /// <summary>
    /// 是否是原生（android IOS） 资源（false = 可能是PC资源）    注意： 如果Global.debug == false  将强制改变成  true
    /// </summary>
    public static bool loadNativeAssets = true;

    //****************************************SOA网关信息***********************************************
    //城市渲染服务
    public static string CityRendererPath = "/platform/geoinfo";
    public static string CityRendererURI = "/api/v1/geoinfo/info";
    //资源下载服务
    public static string DownloadPath = "/platform/resource";
    public static string DownloadURI = "/api/v1/resource/object";

    //开发网关账户
    public static string AppID = "9f34055b3238b6580bbc70cea2df2c25";
    public static string AppKey = "31EE074E257FE49D56934856E11859067A3174522C92D2BAD08717AB4F3B4E39";
    public static string GatewayUrl = "http://192.168.31.216:9905";
    //测试网关账户
    //public static string AppID = "b1a90b62a74261e2957724101c5f6f48";
    //public static string AppKey = "2705D4F6431AE2147A5BDBD9792A8120E33330C554FCA081862BC9C48C9E6454";
    //public static string GatewayUrl = "http://192.168.31.117:9905";
    //正式网关账户(演示 预发布)
    //public static string AppID = "b1a90b62a74261e2957724101c5f6f48";
    //public static string AppKey = "2705D4F6431AE2147A5BDBD9792A8120E33330C554FCA081862BC9C48C9E6454";
    //public static string GatewayUrl = "http://139.198.2.142:9905";
    //正式生产服务器
    //public static string AppID = "b1a90b62a74261e2957724101c5f6f48";
    //public static string AppKey = "2705D4F6431AE2147A5BDBD9792A8120E33330C554FCA081862BC9C48C9E6454";
    //public static string GatewayUrl = "http://139.198.0.68:9905";
    public static bool debug
    {
        get
        {
            if (instance.m_debug == false)
            {
                loadNativeAssets = true;
            }
            return instance.m_debug;
        }
        set
        {
            instance.m_debug = value;
            if (instance.m_debug == false)
            {
                loadNativeAssets = true;
            }
        }
    }

    public static string loadScenceName = "jiedao"; //要加载的场景名字
    public  GameObject street;  // 街道

    public static Canvas canvas;

    public static Camera mainCamera;
    public static GameObject mainApp;

    public static int version = 0;
    public static string javaUrl = "com.jhqc.pxsj.AndroidPlugin";
    //**********************************外网************************************************
    //public static string webUrl = "http://139.217.20.56:82/";              //外网
    //public static string webUrl1 = "http://139.217.20.56:84/";
    //// 服装Icon 前缀
    //public static string iconUrl = "http://source-img.oss-cn-beijing.aliyuncs.com/icon/";
    ////换脸Icon 前缀
    //public static string faceIconUrL = "http://u3ds.oss-cn-shanghai.aliyuncs.com/0028/icon/";
    ////PhP 通信 前缀
    //public static string phpUrl = "http://139.217.20.56/data/index.php/Mod/";
    ////获取周边信息
    //public static string PhpUrl1 = "http://139.217.20.56/data/index.php/";

    //public static string ip = "139.217.20.56";
    //**********************************外网************************************************


    //**********************************测试************************************************

      public static string pathUrl = "file:///"  + Application.dataPath + "/Resources/Path/";
  
   // public static string pathUrl = "file:///" + "C:/Users/Administrator/Desktop/028005/";

    public static string webUrl = "http://172.31.251.120:82/";
    public static string webUrl1 = "http://172.31.251.120:84/";
    // 服装Icon 前缀
    public static string iconUrl = "http://static.chinacloudapp.cn/test/u3ds/characters/icon/";
    //换脸Icon 前缀
    public static string faceIconUrL = "http://static.chinacloudapp.cn/test/u3ds/characters/icon/"; //"http://u3ds.oss-cn-shanghai.aliyuncs.com/0028/icon/";
    //PhP 通信 前缀
    public static string phpUrl = "http://172.31.251.120/data/mod/";
    //获取周边信息
    public static string PhpUrl1 = "http://172.31.251.120/data/";
   

    //换装 别墅资源

    //public static string ResUrl = "http://139.217.21.38/test/u3ds/";
    public static string ResUrl = "http://static.chinacloudapp.cn/test/u3ds/";
    //public static string ResUrl = "file://E:/ServerHost/";

    public static string ip = "172.31.251.69";
    //public static string ip = "172.31.251.224";
    //**********************************测试************************************************
    public static int port = 8000;

    #if UNITY_IPHONE
     public static string path = Application.dataPath +"/Raw/";

    #elif UNITY_ANDROID
    public static string path = "jar:file://" + Application.dataPath + "/!/assets/";
#endif

  
    public static string configInfo = "";
    public void Print(object log)
    {

    }

    public static int isNetWork()
    {
        int index = -1;
        //if (Application.internetReachability == NetworkReachability.NotReachable)
        //{
        //    NGUIDebug.Log("没有网络");
        //}
        //else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        //{
        //    index = 0;
        //    NGUIDebug.Log("数据流量连接");
        //}
        //else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        //{
        //    index = 1;
        //    NGUIDebug.Log("局域网WIFI连接");
        //}

        return index;
    }

#if UNITY_ANDROID && !UNITY_EDITOR
              public static int phoneType = 0;
#elif UNITY_IPHONE && !UNITY_EDITOR
            public static int phoneType = 1;
#elif UNITY_EDITOR_OSX
        public static int phoneType = 2;
#else
    public static int phoneType = 3;
#endif
}
