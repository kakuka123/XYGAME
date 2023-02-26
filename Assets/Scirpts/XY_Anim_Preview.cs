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
    [MenuItem("Tools/С�㹤��/��ɫ����Ԥ��")]



    static public void MyAlign()//�����򿪴��ڵľ�̬����
    {
        EditorWindow window = EditorWindow.GetWindow<Xy_012_FBX>();
        window.minSize = new Vector2(400, 500);
        window.maxSize = new Vector2(400, 500);
        window.Show();
        //Selection.selectionChanged += SelectObj;
    }
    [LabelText("��ɫPrefab")]
    public GameObject Character;
    [LabelText("����������")]
    public RuntimeAnimatorController animator;

    public AnimationClip clip1;


    [PropertySpace(20)]
    [Button("Test", ButtonSizes.Large)]
    public void Player()
    {
        //��ȡ��ǰ��ɫ���õĿ�����
        animator = Character.GetComponent<Animator>().runtimeAnimatorController;
        animator.animationClips[0]= clip1;
        Debug.Log(Character.name);
        Debug.Log(Character.GetComponent<Animator>().runtimeAnimatorController.name);
    }
}




