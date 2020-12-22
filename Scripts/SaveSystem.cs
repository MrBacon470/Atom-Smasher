using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine.SceneManagement;

public static class SimpleAES
{
    // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
    // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
    private const string initVector = "bkmspeed890t27fg";
    // This constant is used to determine the keysize of the encryption algorithm
    private const int keysize = 256;
    //Encrypt
    private static byte[] initVectorBytes;
    private static byte[] plainTextBytes;
    private static PasswordDeriveBytes password;
    private static byte[] keyBytes;
    private static RijndaelManaged symmetricKey = new RijndaelManaged()
    {
        Mode = CipherMode.CBC
    };


    public static string EncryptString(string plainText, string passPhrase)
    {
        initVectorBytes = Encoding.UTF8.GetBytes(initVector);
        plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        password = new PasswordDeriveBytes(passPhrase, null);
        keyBytes = password.GetBytes(keysize / 8);
        var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
        var memoryStream = new MemoryStream();
        var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
        cryptoStream.FlushFinalBlock();
        var cipherTextBytes = memoryStream.ToArray();
        memoryStream.Close();
        cryptoStream.Close();
        return Convert.ToBase64String(cipherTextBytes);
    }
    //Decrypt
    public static string DecryptString(string cipherText, string passPhrase)
    {
        initVectorBytes = Encoding.UTF8.GetBytes(initVector);
        var cipherTextBytes = Convert.FromBase64String(cipherText);
        password = new PasswordDeriveBytes(passPhrase, null);
        keyBytes = password.GetBytes(keysize / 8);
        var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
        var memoryStream = new MemoryStream(cipherTextBytes);
        var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        var plainTextBytes = new byte[cipherTextBytes.Length];
        var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        memoryStream.Close();
        cryptoStream.Close();
        return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
    }
}

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;

    private void Awake()
    {
        Instance = this;
    }

    public TMP_InputField importValue;
    public TMP_InputField exportValue;

    private static string encryptKey = "bls5tyupq7he93jdkeqipoch";
    private static string savePath => Application.persistentDataPath + "/Saves/";
    private static string savePathBackUP => Application.persistentDataPath + "/Backups/";

    private static int backUpCount = 0;

    public static void SavePlayer<T>(T Data, string name)
    {
        Directory.CreateDirectory(savePath);
        Directory.CreateDirectory(savePathBackUP);
        backUpCount++;
        Save(backUpCount % 4 == 0 ? savePathBackUP : savePath);

        PlayerPrefs.SetString("OfflineTime", DateTime.Now.ToBinary().ToString());
        void Save(string path)
        {
            using (var writer = new StreamWriter(path + name + ".txt"))
            {
                var formatter = new BinaryFormatter();
                var memoryStream = new MemoryStream();
                formatter.Serialize(memoryStream, Data);
                var dataToWrite = SimpleAES.EncryptString(Convert.ToBase64String(memoryStream.ToArray()), encryptKey);
                writer.WriteLine(dataToWrite);
            }
        }
    }

    public static T LoadPlayer<T>(string name)
    {
        Directory.CreateDirectory(savePath);
        Directory.CreateDirectory(savePathBackUP);
        T returnValue;
        var backUpNeeded = false;

        Load(savePath);
        if (backUpNeeded)
        {
            Load(savePathBackUP);
        }

        return returnValue;

        void Load(string path)
        {
            using (var reader = new StreamReader(path + name + ".txt"))
            {
                var formatter = new BinaryFormatter();
                var dataToRead = reader.ReadToEnd();
                var memoryStream = new MemoryStream(Convert.FromBase64String(SimpleAES.DecryptString(dataToRead, encryptKey)));
                try
                {
                    returnValue = (T)formatter.Deserialize(memoryStream);
                }
                catch
                {
                    returnValue = default;
                    backUpNeeded = true;
                }
            }
        }
    }

    public bool SaveExists(string key)
    {
        var path = savePath + key + ".txt";
        return File.Exists(path);
    }

    public void ImportPlayer2(int id)
    {
        var path = "";
        switch (id)
        {
            case 0:
                path = savePath;
                break;
        }

        using (var writer = new StreamWriter(path + "PlayerData" + ".txt"))
        {
            writer.WriteLine(importValue.text);
        }

        SceneManager.LoadSceneAsync("MainScene");
    }

    public void ExportPlayer2()
    {
        var dataToRead = "";
        var backUpNeeded = false;
        Load(savePath);
        if (backUpNeeded)
        {
            Load(savePathBackUP);
        }

        exportValue.text = dataToRead;

        void Load(string path)
        {
            using (var reader = new StreamReader(path + "PlayerData" + ".txt"))
            {
                try
                {
                    dataToRead = reader.ReadToEnd();
                }
                catch
                {
                    backUpNeeded = true;
                }
            }
        }
    }

    public void ClearFields()
    {
        exportValue.text = "";
        importValue.text = "";
    }
}