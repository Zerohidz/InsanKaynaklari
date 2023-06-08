using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class SaveSystem
{
    public static GameData GameData
    {
        get
        {
            if (_gameData == null)
                LoadGameData();
            return _gameData;
        }
        set { _gameData = value; }
    }

    private static GameData _gameData;
    private const string EncryptionCodeWord = "VefalilarGalipGelecek";

    public static void Test()
    {
        LoadGameData();
        SaveGameData();
        LoadGameData();
    }

    public static void LoadGameData()
    {
        if (PlayerPrefs.HasKey("GameData"))
        {
            string encryptedGameDataString = PlayerPrefs.GetString("GameData");
            string gameDataString = Decrypt(encryptedGameDataString);
            _gameData = JsonConvert.DeserializeObject<GameData>(gameDataString);
        }
        else
        {
            _gameData = new GameData
            {
                GlobalProperties = new GlobalProperties(),
                Fourly = new FourlyModeProperties(),
                Classic = new ClassicModeProperties(),
                Timed = new TimedModeProperties()
            };
        }
    }

    public static void SaveGameData()
    {
        string gameDataString = JsonConvert.SerializeObject(GameData);
        string encryptedGameDataString = Encrypt(gameDataString);
        PlayerPrefs.SetString("GameData", encryptedGameDataString);
        PlayerPrefs.Save();
    }

    private static string Encrypt(string clearString)
    {
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearString);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionCodeWord, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearString = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearString;
    }

    private static string Decrypt(string cipherString)
    {
        cipherString = cipherString.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(cipherString);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionCodeWord, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherString = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherString;
    }
}

[Serializable]
public class GameData
{
    public GlobalProperties GlobalProperties;
    public FourlyModeProperties Fourly;
    public ClassicModeProperties Classic;
    public TimedModeProperties Timed;
}

[Serializable]
public class GlobalProperties
{
    public bool FirstTimeOpeningGame = true;
    public bool AdRemoved = false;
    public float SliderValue = 0.6f;
}

[Serializable]
public class ClassicFourlyCommonProperties
{
    public bool WillStartEmpty;
    public bool FirstTimePlaying = true;
    public bool CanUndo;
    public int GamePoints;
    public int MaxPoints;
    public int LastPlacedLetterOrder;
    public char[] PlacableLetterList = new char[3];
    public char[] OldPlacableLetterList = new char[3];
    public char[][] PlacedLetterRows = new char[7][] { new char[7], new char[7], new char[7], new char[7], new char[7], new char[7], new char[7] };
    public string[] FoundWords = new string[0];
    public (int, int) LastPlacedLetterKey;
}

public class ClassicModeProperties : ClassicFourlyCommonProperties
{

}

public class FourlyModeProperties : ClassicFourlyCommonProperties
{

}

[Serializable]
public class TimedModeProperties
{
    public bool FirstTimePlaying = true;
    public int MaxPoints;
}