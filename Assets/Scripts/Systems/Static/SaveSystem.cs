using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class SaveSystem
{
    private static GameData _gameData;
    public static GameData GameData
    {
        get
        {
            if (_gameData == null)
                LoadGameData();
            return _gameData;
        }
        private set
        {
            _gameData = value;
        }
    }

    public static bool GameDataExists => File.Exists(_savePath);

    private const string EncryptionCodeWord = "EntabiyleKodYazmaca";
    private const string SaveFileName = "GameData.durs";
    private static string _savePath => Path.Combine(Application.persistentDataPath, SaveFileName);

    public static void LoadGameData()
    {
        Debug.Log("Loading Game Data!");
        if (GameDataExists)
        {
            Debug.Log("Game Data Exists!");
            string encryptedGameDataString = ReadStringFromBinaryFile(_savePath);
            string gameDataString = Decrypt(encryptedGameDataString);
            GameData = JsonConvert.DeserializeObject<GameData>(gameDataString);
        }
        else
        {
            GameData = new GameData();
        }
    }

    public static void SaveGameData()
    {
        string gameDataString = JsonConvert.SerializeObject(GameData);
        string encryptedGameDataString = Encrypt(gameDataString);
        SaveStringToBinaryFile(encryptedGameDataString, _savePath);
    }

    public static void DeleteGameData()
    {
        File.Delete(_savePath);
        GameData = null;
    }

    public static void ResetGameData()
    {
        GameData = new GameData();
        SaveGameData();
    }

    private static void SaveStringToBinaryFile(string str, string filePath)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        using FileStream fileStream = new(filePath, FileMode.Create);
        fileStream.Write(bytes, 0, bytes.Length);
    }

    private static string ReadStringFromBinaryFile(string filePath)
    {
        using StreamReader reader = new(filePath);
        using MemoryStream memoryStream = new();

        reader.BaseStream.CopyTo(memoryStream);
        byte[] bytes = memoryStream.ToArray();

        return Encoding.UTF8.GetString(bytes);
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

    public static void SaveCareerData(int day, int money)
    {
        GameData.CareerData.Day = day;
        GameData.CareerData.Money = money;

        SaveGameData();
    }
}

public class GameData
{
    public Config Config;
    public CareerData CareerData;

    public GameData()
    {
        Config = new Config();
        CareerData = new CareerData();
    }
}

public class Config
{
    public bool FirstTimeOpeningGame = true;
    public float SoundVolume = 0.6f;
}

public class CareerData
{
    public int Day = 1;
    public int Money = 0;
}