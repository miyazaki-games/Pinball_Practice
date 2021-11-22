//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//using UnityEditor;

//[CustomEditor(typeof(MissionManager))]
//public class MissionListEditor : Editor
//{
//    MissionManager manager;
//    SerializedObject getTraget;
//    SerializedProperty theList;
//    int listSize;

//    List<bool> newShowFoldout = new List<bool>();
//    bool showfold;

//    void OnEnabled()
//    {
//        manager = (MissionManager)target;
//        getTraget = new SerializedObject(manager);
//        theList = getTraget.FindProperty("missionList");
//    }

//    public override void OnInspectorGUI()
//    {
//        //base.OnInspectorGUI();
//        getTraget.Update();

//        EditorGUILayout.LabelField("Mission List Size");
//        listSize = theList.arraySize;
//        listSize = EditorGUILayout.IntField("List Size", listSize);

//        if (listSize != theList.arraySize)
//        {
//            while (listSize > theList.arraySize)
//            {
//                theList.InsertArrayElementAtIndex(theList.arraySize);
//            }

//            while (listSize < theList.arraySize)
//            {
//                theList.DeleteArrayElementAtIndex(theList.arraySize - 1);
//            }
//        }

//        while (newShowFoldout.Count > theList.arraySize)
//        {
//            newShowFoldout.RemoveAt(newShowFoldout.Count - 1);
//        }

//        while (newShowFoldout.Count < theList.arraySize)
//        {
//            newShowFoldout.Add(true);
//        }

//        if (GUILayout.Button("Add New Mission"))
//        {
//            manager.missionList.Add(new Mission());
//        }

//        for (int i = 0; i < theList.arraySize; i++)
//        {
//            EditorGUI.indentLevel++;
//            EditorGUILayout.BeginVertical(GUI.skin.box);
//            newShowFoldout[i] = EditorGUILayout.Foldout(newShowFoldout[i], "Mission" + (i + 1));

//            SerializedProperty myListRef = theList.GetArrayElementAtIndex(i);
//            SerializedProperty myId = myListRef.FindPropertyRelative("missionId");

//            SerializedProperty myActive = myListRef.FindPropertyRelative("active");
//            SerializedProperty myComplete = myListRef.FindPropertyRelative("missionComplete");

//            SerializedProperty myRestart = myListRef.FindPropertyRelative("restartOnNextBall");
//            SerializedProperty myStopOnEnd = myListRef.FindPropertyRelative("stopOnBallEnd");
//            SerializedProperty myResetOnComplete = myListRef.FindPropertyRelative("resetOnComplete");

//            SerializedProperty myTimeComplete = myListRef.FindPropertyRelative("timeToComplete");

//            SerializedProperty myScore = myListRef.FindPropertyRelative("score");
//            SerializedProperty myAmounToComplete = myListRef.FindPropertyRelative("amountToComplete");
//            SerializedProperty myCurrentAmount = myListRef.FindPropertyRelative("currentAmount");

//            if (newShowFoldout[i])
//            {
//                EditorGUILayout.PropertyField(myId);

//                EditorGUILayout.PropertyField(myActive);
//                EditorGUILayout.PropertyField(myComplete);

//                EditorGUILayout.PropertyField(myRestart);
//                EditorGUILayout.PropertyField(myStopOnEnd);
//                EditorGUILayout.PropertyField(myResetOnComplete);

//                EditorGUILayout.PropertyField(myTimeComplete);

//                EditorGUILayout.PropertyField(myScore);
//                EditorGUILayout.PropertyField(myAmounToComplete);
//                EditorGUILayout.PropertyField(myCurrentAmount);
//            }

//            if (GUILayout.Button("Delete Mission"))
//            {
//                theList.DeleteArrayElementAtIndex(i);
//            }

//            EditorGUI.indentLevel++;
//            EditorGUILayout.EndVertical();
//            EditorGUILayout.Separator();
//        }

//        getTraget.ApplyModifiedProperties();
//    }
//}
