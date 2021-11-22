using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(MissionManager))]
public class MissionListEditor : Editor
{
    MissionManager manager;
    SerializedObject getTarget;
    SerializedProperty theList;
    int listSize;

    List<bool> newShowFoldout = new List<bool>();
    bool showfold;

    void OnEnable()
    {
        manager = (MissionManager)target;
        getTarget = new SerializedObject(manager);
        theList = getTarget.FindProperty("missionList");
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        getTarget.Update();

        //LIST SIZE
        EditorGUILayout.LabelField("Mission List Size");
        listSize = theList.arraySize;
        listSize = EditorGUILayout.IntField("List Size", listSize);

        if (listSize != theList.arraySize)
        {
            while (listSize > theList.arraySize)
            {
                theList.InsertArrayElementAtIndex(theList.arraySize);
            }

            while (listSize < theList.arraySize)
            {
                theList.DeleteArrayElementAtIndex(theList.arraySize - 1);
            }
        }

        while (newShowFoldout.Count > theList.arraySize)
        {
            newShowFoldout.RemoveAt(newShowFoldout.Count - 1);
        }

        while (newShowFoldout.Count < theList.arraySize)
        {
            newShowFoldout.Add(true);
        }

        if (GUILayout.Button("Add New Mission"))
        {

        }

        for (int i = 0; i < theList.arraySize; i++)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.BeginVertical(GUI.skin.box);
            newShowFoldout[i] = EditorGUILayout.Foldout(newShowFoldout[i], "Mission" + (i + 1));

            SerializedProperty myListRef = theList.GetArrayElementAtIndex(i);
            SerializedProperty myId = myListRef.FindPropertyRelative("missionId");

            if (newShowFoldout[i])
            {
                EditorGUILayout.PropertyField(myId);
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
            EditorGUILayout.Separator();
        }

        getTarget.ApplyModifiedProperties();
    }
}
