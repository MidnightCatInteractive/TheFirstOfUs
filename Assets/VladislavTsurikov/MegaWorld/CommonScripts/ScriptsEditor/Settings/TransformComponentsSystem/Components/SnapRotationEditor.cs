﻿#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using VladislavTsurikov.ComponentStack.ScriptsEditor;
using VladislavTsurikov.ComponentStack.ScriptsEditor.ReorderableListSupport;
using VladislavTsurikov.MegaWorld.CommonScripts.Scripts.Settings.TransformComponentsSystem.Components;

namespace VladislavTsurikov.MegaWorld.CommonScripts.ScriptsEditor.Settings.TransformComponentsSystem.Components
{
    [SettingsEditor(typeof(SnapRotation))]
    public class SnapRotationEditor : ReorderableListComponentEditor
    {
        private SnapRotation _snapRotation;
        public override void OnEnable()
        {
            _snapRotation = (SnapRotation)Target;
        }
        
        public override void OnGUI(Rect rect, int index) 
        {
            _snapRotation.RotateAxisX = EditorGUI.Toggle(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), 
                new GUIContent("Rotate Axis X"), _snapRotation.RotateAxisX);
            rect.y += EditorGUIUtility.singleLineHeight;
            _snapRotation.RotateAxisY = EditorGUI.Toggle(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), 
                new GUIContent("Rotate Axis Y"), _snapRotation.RotateAxisY);
            rect.y += EditorGUIUtility.singleLineHeight;
            _snapRotation.RotateAxisZ = EditorGUI.Toggle(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), 
                new GUIContent("Rotate Axis Z"), _snapRotation.RotateAxisZ);
            rect.y += EditorGUIUtility.singleLineHeight;
            _snapRotation.SnapRotationAngle = EditorGUI.FloatField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), 
                new GUIContent("Snap Rotation Angle"), _snapRotation.SnapRotationAngle);
            rect.y += EditorGUIUtility.singleLineHeight;
        }

        public override float GetElementHeight(int index) 
        {
            float height = EditorGUIUtility.singleLineHeight;

            height += EditorGUIUtility.singleLineHeight;
            height += EditorGUIUtility.singleLineHeight;
            height += EditorGUIUtility.singleLineHeight;
            height += EditorGUIUtility.singleLineHeight;

            return height;
        }
    }
}
#endif