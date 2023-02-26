using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine.EventSystems;
using System.IO;
using System.Linq;
using UnityEditor.Animations;

public class Xy_012_FBX : OdinEditorWindow
{ 
    [MenuItem("Tools/小鱼工具/角色动作预览")]



    static public void MyAlign()//用来打开窗口的静态方法
    {
        EditorWindow window = EditorWindow.GetWindow<Xy_012_FBX>();
        window.minSize = new Vector2(400, 500);
        window.maxSize = new Vector2(400, 500);
        window.Show();
        //Selection.selectionChanged += SelectObj;
    }
    [LabelText("角色Prefab")]
    public GameObject Character;
    [LabelText("动作控制器")]
    public RuntimeAnimatorController animator;

    public AnimationClip clip1;


    [PropertySpace(20)]
    [Button("Test", ButtonSizes.Large)]
    public void Player()
    {
        //获取当前角色所用的控制器
        animator = Character.GetComponent<Animator>().runtimeAnimatorController;
        animator.animationClips[0]= clip1;
        Debug.Log(Character.name);
        Debug.Log(Character.GetComponent<Animator>().runtimeAnimatorController.name);
    }
}




