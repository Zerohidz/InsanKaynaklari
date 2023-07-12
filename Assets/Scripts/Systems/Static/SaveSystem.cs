using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class SaveSystem
{
    private static GameData _gameData;
    public static GameData GameData
    {
        get => _gameData ??= GetGameData();
        set => _gameData = value;
    }

    public static bool GameDataExists => File.Exists(_savePath);
    public static bool CareerDataExists => !GameData.CareerData.Equals(new CareerData()); 

    private const string EncryptionCodeWord = "EntabiyleKodYazmaca";
    private const string SaveFileName = "GameData.durs";
    private static string _savePath => Path.Combine(Application.persistentDataPath, SaveFileName);

    public static GameData GetGameData()
    {
        Debug.Log("Loading Game Data!");
        if (!GameDataExists)
            return new GameData();

        Debug.Log("Game Data Exists!");
        string encryptedGameDataString = ReadStringFromBinaryFile(_savePath);
        string gameDataString = Decrypt(encryptedGameDataString);
        return JsonConvert.DeserializeObject<GameData>(gameDataString);
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
        Systems.Instance?.Reset();
    }

    public static void ResetCareerData()
    {
        GameData.CareerData = new();
        SaveGameData();
        Systems.Instance.Reset();
    }

    public static void ResetGameData()
    {
        GameData = new();
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
        using var encryptor = Aes.Create();

        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionCodeWord, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        encryptor.Key = pdb.GetBytes(32);
        encryptor.IV = pdb.GetBytes(16);

        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write);

        cs.Write(clearBytes, 0, clearBytes.Length);
        cs.Close();

        clearString = Convert.ToBase64String(ms.ToArray());
        return clearString;
    }

    private static string Decrypt(string cipherString)
    {
        cipherString = cipherString.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(cipherString);
        using var encryptor = Aes.Create();

        var pdb = new Rfc2898DeriveBytes(EncryptionCodeWord, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        encryptor.Key = pdb.GetBytes(32);
        encryptor.IV = pdb.GetBytes(16);

        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write);

        cs.Write(cipherBytes, 0, cipherBytes.Length);
        cs.Close();

        cipherString = Encoding.Unicode.GetString(ms.ToArray());
        return cipherString;
    }

    public static void SaveCareerData(int? day = null, int? money = null, FamilyStatusData spendings = null)
    {
        if (day != null)
            GameData.CareerData.Day = day.Value;
        if (money != null)
            GameData.CareerData.Money = money.Value;
        if (spendings != null)
            GameData.CareerData.FamilyStatus = spendings;

        SaveGameData();
    }

    public static void SaveGameState(GameState gameState)
    {
        GameData.Config.GameState = gameState;
        SaveGameData();
        Debug.Log($"Saved Game State: {gameState}");
    }

    public static void SaveWonGame()
    {
        GameData.Config.GameState = GameState.WinScreen;
        SaveGameData();
    }

    public static void SaveLostGame()
    {
        GameData.Config.GameState = GameState.LoseScreen;
        SaveGameData();
    }

    public static void SaveMaxScore(int day)
    {
        GameData.Config.MaxScore = day;
        SaveGameData();
    }
}

public class GameData
{
    public ConfigData Config = new();
    public CareerData CareerData = new();
}

public class ConfigData
{
    public GameState GameState = GameState.Tutorial;
    // TODO: Max score
    public int MaxScore = 0;
    public float SoundVolume = 0.6f;
}

public class CareerData
{
    public int Day = 1;
    public int Money = 0;
    public FamilyStatusData FamilyStatus = new();

    //TODO: Temizle buray�
    public override bool Equals(object obj)
    {
        if (obj is not CareerData)
            return false;

        var other = (CareerData)obj;

        return other.Day.Equals(Day) 
            && other.Money.Equals(Money) 
            && other.FamilyStatus.Equals(FamilyStatus);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class FamilyStatusData
{
    public StatusData Father = new("Baba");
    public StatusData Mother = new("Anne");
    public StatusData Sister = new("K�z Karde�");

    public int NeededMedicineCount => Father.NeededMedicine
                                    + Mother.NeededMedicine
                                    + Sister.NeededMedicine;

    public StatusData[] AllStatuses => new StatusData[] { Father, Mother, Sister };

    public bool AllAlive => AllStatuses.Select(s => s.IsDead).Where(s => s == true).Any() == false;
    public bool AllDead => AllStatuses.Select(s => s.IsDead).Where(s => s == false).Any() == false;

    //TODO: Temizle buray�
    public override bool Equals(object obj)
    {
        if (obj is not FamilyStatusData)
            return false;

        var other = (FamilyStatusData)obj;

        return other.Father.Equals(Father)
            && other.Mother.Equals(Mother)
            && other.Sister.Equals(Sister);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class StatusData
{
    public string Name;
    public bool HasJustDied = false;
    private State _hungerState = State.Well;
    public State HungerState
    {
        get => _hungerState;
        set
        {
            value = EnumHelper.GetClamped(value);
            _hungerState = value;
            if (_hungerState == State.Dead)
                HasJustDied = true;
        }
    }
    private State _coldState = State.Well;
    public State ColdState
    {
        get => _coldState;
        set
        {
            value = EnumHelper.GetClamped(value);
            _coldState = value;
            if (_coldState == State.Dead)
                HasJustDied = true;
        }
    }

    public bool IsWell => HungerState == State.Well && ColdState == State.Well;
    public bool IsAlive => !IsDead;
    public bool IsDead => HungerState == State.Dead || ColdState == State.Dead;
    public bool IsChangable => !IsDead || HasJustDied;
    public bool NeedsMedicine => ColdState == State.NearDead;
    public int NeededMedicine => NeedsMedicine ? 1 : 0;

    public StatusData(string name)
    {
        Name = name;
    }

    public void Kill()
    {
        HungerState = State.Dead;
        ColdState = State.Dead;
    }

    public enum State
    {
        Dead,
        NearDead,
        NotWell,
        Well,
    }

    //TODO: Temizle buray�
    public override bool Equals(object obj)
    {
        if (obj is not StatusData)
            return false;

        var other = (StatusData)obj;

        return other.Name.Equals(Name)
            && other.HasJustDied.Equals(HasJustDied)
            && other.HungerState.Equals(HungerState)
            && other.ColdState.Equals(ColdState);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}