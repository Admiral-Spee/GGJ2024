using UnityEditor;
using UnityEngine;
public class PlayerWindow : EditorWindow
{
    public Manage Manage;
    private SerializedObject serializedObject;
    private SerializedObject _serializedObject;
    private SerializedObject _serializedObjectboss;
    private SerializedProperty _serializedProperty;
    private Vector2 _vector2;
    [MenuItem("Player/Set Manage",false)]
    private static void CreateWindow()
    {
        PlayerWindow window = EditorWindow.CreateWindow<PlayerWindow>();
        window.Show();
    }

    private void OnEnable()
    {
        serializedObject = new SerializedObject(GameObject.Find("Manage").GetComponent<Manage>());
        _serializedObject = new SerializedObject(GameObject.Find("Player").GetComponent<Player>());
        _serializedObjectboss = new SerializedObject(GameObject.Find("Boss").GetComponent<Boss>());
    }

    private void OnGUI()
    {
        serializedObject.Update();
        _serializedObject.Update();
        _serializedObjectboss.Update();

        _vector2=EditorGUILayout.BeginScrollView(_vector2);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Come_Idle_Slary"),new GUIContent("老板在+闲置->业绩"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Come_Idle_Energy"),new GUIContent("老板在+闲置->精力"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Come_Work_Slary"),new GUIContent("老板在+工作->业绩"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Come_Work_Energy"),new GUIContent("老板在+工作->精力"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Come_WorkAdd_Slary"),new GUIContent("老板在+加班->业绩"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Come_WorkAdd_Energy"),new GUIContent("老板在+加班->精力"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Come_WorkLess_Slary"),new GUIContent("老板在+摸鱼->业绩"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Come_WorkLess_Energy"),new GUIContent("老板在+摸鱼->精力"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Come_Recharge_Slary"),new GUIContent("老板在+氪金->业绩"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Come_Recharge_Energy"),new GUIContent("老板在+氪金->精力"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Come_WordAdd_Award"),new GUIContent("老板在+加班->奖金"));
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("NoCome_Idle_Slary"),new GUIContent("老板不在+闲置->业绩"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("NoCome_Idle_Energy"),new GUIContent("老板不在+闲置->精力"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("NoCome_Work_Slary"),new GUIContent("老板不在+工作->业绩"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("NoCome_Work_Energy"),new GUIContent("老板不在+工作->精力"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("NoCome_WorkAdd_Slary"),new GUIContent("老板不在+加班->业绩"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("NoCome_WorkAdd_Energy"),new GUIContent("老板不在+加班->精力"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("NoCome_WorkLess_Slary"),new GUIContent("老板不在+摸鱼->业绩"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("NoCome_WorkLess_Energy"),new GUIContent("老板不在+摸鱼->精力"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("NoCome_Recharge_Slary"),new GUIContent("老板不在+氪金->业绩"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("NoCome_Recharge_Energy"),new GUIContent("老板不在+氪金->精力"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("NoCome_Recharhe_Award"),new GUIContent("老板不在+氪金->奖金"));

        EditorGUILayout.PropertyField(_serializedObject.FindProperty("energy"), new GUIContent("玩家精力"));
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("award"), new GUIContent("玩家奖金"));
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("salary"), new GUIContent("玩家业绩"));
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("initialEnergyMax"), new GUIContent("初始精力最大"));
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("initialSalaryMax"), new GUIContent("初始业绩最大"));
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("energyMax"), new GUIContent("最大精力"));
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("energyMin"), new GUIContent("最小精力"));
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("salaryMax"), new GUIContent("最大业绩"));
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("salaryMin"), new GUIContent("最小业绩"));
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("salaryUp"), new GUIContent("业绩最高值增加"));
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("energyUp"), new GUIContent("精力最大值增加"));
        
        EditorGUILayout.PropertyField(_serializedObjectboss.FindProperty("walkTimeMax"), new GUIContent("随机休息时间最大"));
        EditorGUILayout.PropertyField(_serializedObjectboss.FindProperty("stopTimeMax"), new GUIContent("随机注视时间最大"));
        
        EditorGUILayout.EndScrollView();

        _serializedObjectboss.ApplyModifiedProperties();
        _serializedObject.ApplyModifiedProperties();
        serializedObject.ApplyModifiedProperties();
    }
}
