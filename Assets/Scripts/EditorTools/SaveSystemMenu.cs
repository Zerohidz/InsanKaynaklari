#if UNITY_EDITOR
using UnityEditor;

public class SaveSystemMenu
{
    [MenuItem("Save System/Delete Game Data")]
    public static void DeleteGameData()
    {
        SaveSystem.DeleteGameData();
    }
}
#endif