using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
using Object = UnityEngine.Object;

// CopyComponents - by Michael L. Croswell for Colorado Game Coders, LLC
// March 2010

//Modified by Kristian Helle Jespersen
//June 2011

// Modified by FerJia, for using tags
// June 2016

public class ReplaceGameObjects : ScriptableWizard
{
    public bool copyValues = true;
    public GameObject NewType;
    public string TagName;

    [MenuItem("Custom/Replace GameObjects")]


    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Replace GameObjects", typeof(ReplaceGameObjects), "Replace");
    }

    void OnWizardCreate()
    {
        GameObject[] OldObjects = GameObject.FindGameObjectsWithTag(TagName);


        foreach (GameObject go in OldObjects)
        {
            GameObject newObject;
            newObject = (GameObject)Object.Instantiate(NewType, go.transform.position, go.transform.rotation);
            newObject.transform.position = go.transform.position;
            newObject.transform.rotation = go.transform.rotation;
            newObject.transform.Rotate(0, UnityEngine.Random.Range(0, 360), 0);
            newObject.transform.parent = go.transform.parent;

            DestroyImmediate(go);

        }

    }
}