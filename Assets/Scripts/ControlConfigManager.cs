using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ControlConfigManager {

    private ControlConfig controlConfing;
    private string jsonSaveFilePath;
    private List<string> listKeyPressed;

    public ControlConfigManager(List<string> listKeyPressed)
    {
        this.listKeyPressed = listKeyPressed;
        this.Start();
    }

    // Use this for initialization
    void Start () {
        Debug.logger.Log("Start ControlConfigManager");
        this.jsonSaveFilePath = Application.dataPath + "/Resources/controlConfig";

        Debug.logger.Log("path : ", jsonSaveFilePath + "1.json");
        if(File.Exists(jsonSaveFilePath + "1.json"))
        {
            Debug.logger.Log("File exists in path :", jsonSaveFilePath + "1.json");
        } else
        {
            Debug.logger.Log("FILE DOES NOT EXISTS");
        }

        this.LoadFromJson(1);
    }


	
    public void SaveToJson(int playerIndex)
    {
        string jsonStringData = JsonUtility.ToJson(this.controlConfing);
        File.WriteAllText(this.jsonSaveFilePath + playerIndex + ".json", jsonStringData);
    }

    public bool LoadFromJson(int playerIndex)
    {
        if (File.Exists(this.jsonSaveFilePath + playerIndex + ".json"))
        {
            string jsonStringData = File.ReadAllText(this.jsonSaveFilePath + playerIndex + ".json");
            this.controlConfing = JsonUtility.FromJson<ControlConfig>(jsonStringData);
            return true;
        }
        else
        {
            this.controlConfing = new ControlConfig();
            this.controlConfing.Initialisation(playerIndex);
            this.SaveToJson(playerIndex);
            return false;
        }
    }

	// Update is called once per frame
	public void Update () {
        if (Input.GetKey("X"))
        {
            this.listKeyPressed.Add("A");
        }
        if (Input.GetKeyDown(this.controlConfing.B))
        {
            this.listKeyPressed.Add("B");
        }
        if (Input.GetKeyDown(this.controlConfing.X))
        {
            this.listKeyPressed.Add("X");
        }
        if (Input.GetKeyDown(this.controlConfing.Y))
        {
            this.listKeyPressed.Add("Y");
        }
        if (Input.GetKeyDown(this.controlConfing.up))
        {
            this.listKeyPressed.Add("up");
        }
        if (Input.GetKeyDown(this.controlConfing.down))
        {
            this.listKeyPressed.Add("down");
        }
        if (Input.GetKeyDown(this.controlConfing.left))
        {
            this.listKeyPressed.Add("left");
        }
        if (Input.GetKeyDown(this.controlConfing.right))
        {
            this.listKeyPressed.Add("right");
        }
    }
}
