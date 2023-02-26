using UnityEngine;
using System.Collections;
using UnityEditor;

public class SetGameObjectActive1 : EditorWindow
{


     [MenuItem("Tools/小鱼工具/编辑器/切换物体显隐状态 &m")]
      public static void SetObjActive()
       {
        GameObject[] selectObjs = Selection.gameObjects;
        int objCtn = selectObjs.Length;
        for (int i = 0; i < objCtn; i++)
        { 
            bool isAcitve = selectObjs[i].activeSelf;
           selectObjs[i].SetActive(!isAcitve);
        }
        
       }

  
}