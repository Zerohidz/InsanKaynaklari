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
            var serializedObject = new SerializedObject(myScript);
            var fields = myScript.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(field => field.IsPublic || field.GetCustomAttributes(typeof(SerializeField), false).Any()).ToArray();

            int selectedObjectIndex = 0;
            foreach (var field in fields)
            {
                var fieldValue = field.GetValue(myScript);
                if (fieldValue.ToString() == "null" && selectedObjectIndex < selectedObjects.Length)
                {
                    var serializedProperty = serializedObject.FindProperty(field.Name);
                    var currentGameObject = selectedObjects[selectedObjectIndex];
                    if (field.FieldType == typeof(Transform))
                    {
                        serializedProperty.objectReferenceValue = currentGameObject.transform;
                    }
                    else if (field.FieldType == typeof(GameObject))
                    {
                        serializedProperty.objectReferenceValue = currentGameObject;
                    }
                    else
                    {
                        serializedProperty.objectReferenceValue = currentGameObject.GetComponent(field.FieldType);
                    }
                    selectedObjectIndex++;
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
