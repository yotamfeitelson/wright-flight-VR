using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(EasyExpandableTextBox))]
public class EasyExpandableTextBoxEditor : Editor
{
    private EasyExpandableTextBox controller;
    private Image textContainer;
    private VerticalLayoutGroup boxLayoutGroup;
    private VerticalLayoutGroup layoutGroup;
    private TextMeshProUGUI textTMP;
    private SerializedProperty boxSprite;
    private SerializedProperty font;
    private SerializedProperty fontSize;
    private SerializedProperty autoSize;
    private SerializedProperty autoSizeMin;
    private SerializedProperty autoSizeMax;
    private SerializedProperty text;
    private SerializedProperty color;
    private SerializedProperty alignment;
    private SerializedProperty boxAlignment;
    [SerializeField]
    private SerializedProperty style;
    
    //Padding
    private readonly AnimBool padding = new AnimBool();
    private SerializedProperty left;
    private SerializedProperty right;
    private SerializedProperty top;
    private SerializedProperty bottom;

    private SerializedProperty settings;

    private void OnEnable()
    {
        
        controller = (EasyExpandableTextBox) target;
        if (PrefabUtility.IsPartOfPrefabInstance(controller.transform.parent))
        {
            PrefabUtility.UnpackPrefabInstance(controller.transform.parent.gameObject, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
        }
        else if (PrefabUtility.IsPartOfPrefabInstance(controller))
        {
            PrefabUtility.UnpackPrefabInstance(controller.gameObject, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
        }
        textContainer = controller.transform.GetChild(0).GetComponent<Image>();
        boxLayoutGroup = textContainer.GetComponent<VerticalLayoutGroup>();
        layoutGroup = controller.GetComponent<VerticalLayoutGroup>();
        textTMP = controller.GetComponentInChildren<TextMeshProUGUI>();
        boxSprite = serializedObject.FindProperty("boxSprite");
        text = serializedObject.FindProperty("text");
        font = serializedObject.FindProperty("font");
        fontSize = serializedObject.FindProperty("fontSize");
        autoSize = serializedObject.FindProperty("autoSize");
        autoSizeMin = serializedObject.FindProperty("autoSizeMin");
        autoSizeMax = serializedObject.FindProperty("autoSizeMax");
        color = serializedObject.FindProperty("color");
        alignment = serializedObject.FindProperty("alignment");
        boxAlignment = serializedObject.FindProperty("boxAlignment");
        style = serializedObject.FindProperty("style");
        left = serializedObject.FindProperty("left");
        right = serializedObject.FindProperty("right");
        top = serializedObject.FindProperty("top");
        bottom = serializedObject.FindProperty("bottom");
        settings = serializedObject.FindProperty("settings");
    }
    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUIStyle boldLabelStyle = new GUIStyle {fontStyle = FontStyle.Bold};
        GUIStyle boldFoldoutStyle = new GUIStyle(EditorStyles.foldout) {fontStyle = FontStyle.Bold};
        GUIStyle normalFoldoutStyle = new GUIStyle(EditorStyles.foldout) {fontStyle = FontStyle.Normal};

        EditorGUILayout.Separator();
        EditorGUILayout.PropertyField(text);

        settings.boolValue = EditorGUILayout.Foldout(settings.boolValue, "Settings", true, boldFoldoutStyle);
        if (settings.boolValue)
        {
            EditorGUI.indentLevel = 1;
            EditorGUILayout.PropertyField(font);
            EditorGUILayout.PropertyField(style);
            EditorGUI.BeginDisabledGroup(autoSize.boolValue);
            EditorGUILayout.PropertyField(fontSize);
            EditorGUI.EndDisabledGroup();
            EditorGUI.indentLevel = 2;
            EditorGUILayout.PropertyField(autoSize);
            if (autoSize.boolValue)
            {
                EditorGUI.indentLevel = 3;
                autoSizeMin.intValue = EditorGUILayout.IntField("Min", autoSizeMin.intValue, GUILayout.Width(180));
                autoSizeMax.intValue = EditorGUILayout.IntField("Max", autoSizeMax.intValue, GUILayout.Width(180));
            }
            EditorGUI.indentLevel = 1;
            EditorGUILayout.PropertyField(color);
            EditorGUILayout.PropertyField(alignment);

            padding.value = EditorGUILayout.Foldout(padding.value, "Padding", true, normalFoldoutStyle);
            if (padding.value)
            {
                EditorGUILayout.PropertyField(left);
                EditorGUILayout.PropertyField(right);
                EditorGUILayout.PropertyField(top);
                EditorGUILayout.PropertyField(bottom);
            }
            EditorGUILayout.Separator();
            EditorGUILayout.PropertyField(boxAlignment);
            EditorGUILayout.PropertyField(boxSprite);
        }
        
        EditorGUILayout.Separator();
        textContainer.sprite = controller.boxSprite;
        textTMP.text = text.stringValue;
        //controller.text = textTMP.text;
        textTMP.font = controller.font;
        textTMP.fontStyle = controller.style;
        textTMP.fontSize = fontSize.intValue;
        textTMP.enableAutoSizing = autoSize.boolValue;
        textTMP.fontSizeMin = autoSizeMin.intValue;
        textTMP.fontSizeMax = autoSizeMax.intValue;
        textTMP.alignment = controller.alignment;
        textTMP.color = controller.color;
        boxLayoutGroup.padding = new RectOffset(left.intValue, right.intValue, top.intValue, bottom.intValue);
        layoutGroup.childAlignment = controller.boxAlignment;
        serializedObject.ApplyModifiedProperties();
    }
}
