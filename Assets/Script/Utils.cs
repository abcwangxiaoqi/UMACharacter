using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Random = System.Random;
using System.Xml;

public class Utils 
{

    public static string GetHMACSHA256Base64String(string str, string keyStr)
    {
        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(str);
        byte[] key = System.Text.Encoding.ASCII.GetBytes(keyStr);
        using (System.Security.Cryptography.HMACSHA256 hmacsha256 = new System.Security.Cryptography.HMACSHA256(key))
        {
            byte[] s = hmacsha256.ComputeHash(bytes);
            return Convert.ToBase64String(s);
        }
    }
}