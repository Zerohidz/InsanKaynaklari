using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MonoBehaviour), true)]
public class MultiSelectTool : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MonoBehaviour myScript = (MonoBehaviour)target;

        if (GUILayout.Button("Load Selected Objects"))
        {
            var selectedObjects = Selection.gameObjects;
            var fields = myScript.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(field => field.IsPublic || field.GetCustomAttributes(typeof(SerializeField), false).Length > 0).ToArray();

            int selectedObjectIndex = 0;
            foreach (var field in fields)
            {
                if (field.GetValue(myScript) == null && selectedObjectIndex < selectedObjects.Length)
                {
                    var t = field.GetType();
                    field.SetValue(myScript, selectedObjects[selectedObjectIndex].GetComponent(field.FieldType));
                    selectedObjectIndex++;
                }
            }
        }
    }
}
