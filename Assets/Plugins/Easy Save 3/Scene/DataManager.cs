using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ES3Internal;
using System;

[System.Serializable]
public class Datas
{
	public int level = 0;
}

public class DataManager : MonoBehaviour 
{

	public static DataManager instance;
	public Datas datas;
	
	public String keyName = "Datas";
	public String fileName = "SaveFile.es3";
	// Use this for initialization
	void Start () {
		instance = this;
		DataLoad();
	}
	
	public void DataSave()
	{
		ES3.Save(keyName, datas);
	}
	
	public void DataLoad()
	{
		if(ES3.FileExists(fileName))
		{
			ES3.LoadInto(keyName, datas);
		}
		else
		{
			DataSave();
		}
	}
}
