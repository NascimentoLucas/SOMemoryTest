using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Nascimento.SO;

namespace Nascimento.Editor
{
    public class SODataEditorWindow : EditorWindow
    {
        private SOData data;
        private string _lastString;
        private float _lastFloat;
        private int _lastInt;
        private int _objectSize;
        private int _structSize;

        private Vector2 _scrollPos;

        [MenuItem("Dev/Window/" + nameof(SODataEditorWindow))]
        public static void ShowWindow()
        {
            GetWindow<SODataEditorWindow>(nameof(SODataEditorWindow));
        }

        private void OnGUI()
        {
            data = (SOData)EditorGUILayout.ObjectField("SOData", data, typeof(SOData), false);

            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos); // 👈 Begin scroll view

            if (data != null)
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Windown Values", EditorStyles.boldLabel);
                EditorGUILayout.LabelField("String:", _lastString);
                EditorGUILayout.LabelField("Float:", _lastFloat.ToString());
                EditorGUILayout.LabelField("Int:", _lastInt.ToString());
                EditorGUILayout.LabelField("Object List Size:", _objectSize.ToString());
                EditorGUILayout.LabelField("Struct List Size:", _structSize.ToString());


                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Data Values", EditorStyles.boldLabel);
                EditorGUILayout.LabelField("String:", data.String);
                EditorGUILayout.LabelField("Float:", data.Float.ToString());
                EditorGUILayout.LabelField("Int:", data.Int.ToString());
                EditorGUILayout.LabelField("Object List Size:", data.ObjectSize.ToString());
                EditorGUILayout.LabelField("Struct List Size:", data.StructSize.ToString());

                EditorGUILayout.Space();

                if (GUILayout.Button("Generate Random String"))
                {
                    _lastString = data.GenerateRandomString();
                    EditorUtility.SetDirty(data);
                }

                if (GUILayout.Button("Set Random Float"))
                {
                    _lastFloat = data.SetRandomFloat();
                    EditorUtility.SetDirty(data);
                }

                if (GUILayout.Button("Set Random Int"))
                {
                    _lastInt = data.SetRandomInt();
                    EditorUtility.SetDirty(data);
                }

                if (GUILayout.Button("Add Object"))
                {
                    _objectSize = data.AddObject();
                    EditorUtility.SetDirty(data);
                }

                if (GUILayout.Button("Add Struct"))
                {
                    _structSize = data.AddStruct();
                    EditorUtility.SetDirty(data);
                }
            }
            else
            {
                EditorGUILayout.HelpBox("Assign a SOData ScriptableObject to view and edit its values.", MessageType.Info);
            }

            EditorGUILayout.EndScrollView();
        }
    }
}
