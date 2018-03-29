using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreditScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        TextAsset textFile = (TextAsset) Resources.Load("JsonTestFile");
        string s = JsonUtility.FromJson<string>(textFile.text);
        Debug.Log(s);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

