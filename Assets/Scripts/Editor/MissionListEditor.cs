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
    }
}
