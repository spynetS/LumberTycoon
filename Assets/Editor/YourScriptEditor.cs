using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Player;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{
    Dictionary<string, int> inventoryDictionary;
    string newKey = "";
    int newValue = 0;

    public override void OnInspectorGUI()
    {
        // Get a reference to the dictionary in the sCcript
        inventoryDictionary = ((Inventory)target).balleKlaa;

        // Display the dictionary in the inspector
        EditorGUILayout.LabelField("Inventory Dictionary");

        foreach (KeyValuePair<string, int> pair in inventoryDictionary)
        {
            EditorGUILayout.BeginHorizontal();

            string key = EditorGUILayout.TextField(pair.Key);
            int value = EditorGUILayout.IntField(pair.Value);

            if (GUILayout.Button("Remove"))
            {
                inventoryDictionary.Remove(pair.Key);
                PlayerPrefs.SetString("InventoryDictionary", SerializeDictionary(inventoryDictionary));
                break;
            }

            EditorGUILayout.EndHorizontal();

            // Update the dictionary if the key or value has changed
            if (key != pair.Key)
            {
                int tempValue = pair.Value;
                inventoryDictionary.Remove(pair.Key);
                inventoryDictionary.Add(key, tempValue);
                PlayerPrefs.SetString("InventoryDictionary", SerializeDictionary(inventoryDictionary));
            }
            else if (value != pair.Value)
            {
                inventoryDictionary[key] = value;
                PlayerPrefs.SetString("InventoryDictionary", SerializeDictionary(inventoryDictionary));
            }
        }

        // Allow the user to add a new element to the dictionary
        EditorGUILayout.Space();
        newKey = EditorGUILayout.TextField("New Key", newKey);
        newValue = EditorGUILayout.IntField("New Value", newValue);

        if (GUILayout.Button("Add"))
        {
            if (!inventoryDictionary.ContainsKey(newKey))
            {
                inventoryDictionary.Add(newKey, newValue);
                newKey = "";
                newValue = 0;
                PlayerPrefs.SetString("InventoryDictionary", SerializeDictionary(inventoryDictionary));
            }
            else
            {
                EditorUtility.DisplayDialog("Key Already Exists", "The specified key already exists in the dictionary.", "OK");
            }
        }

        // Call the default inspector
        base.OnInspectorGUI();
    }

    // Convert the dictionary to a serialized string for storage in player preferences
    string SerializeDictionary(Dictionary<string, int> dict)
    {
        List<string> keys = new List<string>(dict.Keys);
        List<int> values = new List<int>(dict.Values);

        Dictionary<string, object> serializedDict = new Dictionary<string, object>();
        serializedDict.Add("Keys", keys);
        serializedDict.Add("Values", values);

        return JsonUtility.ToJson(serializedDict);
    }
}