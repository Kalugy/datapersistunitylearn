using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static string userName;
    public TMP_InputField input;
    public TMP_Text textUserName;
    public MainManager Manager;
    public int points;

    private void Start()
    {
        if(input != null)
        {
            input.onEndEdit.AddListener(SubmitName);
        }
        LoadJson();
        UpdateTextUserScore(points, userName);
    }
    public void GoToMainScene()
    {
        SceneManager.LoadScene(1);
    }

    
    private void SubmitName(string arg0)
    {
        userName = arg0;
        Debug.Log(arg0);
    }

    public void UpdateScoreText()
    {
        int lastPoints = Manager.GetPoint();
        Debug.Log("points" + lastPoints);
        if(lastPoints > points)
            SaveJson(lastPoints);
    }
    public void UpdateTextUserScore(int points, string userName)
    {

        textUserName.text = "Best Score: " + points + " Name: " + userName;
    }

    [System.Serializable] 
    class Data
    {
        public int maxPoint;
        public string userName;
    }

    public void SaveJson(int newPoints)
    {
        Data newData = new Data();
        newData.maxPoint = newPoints;
        newData.userName = userName;

        string json = JsonUtility.ToJson(newData);

        File.WriteAllText(Application.persistentDataPath + "/user.json", json);
    }
    void LoadJson()
    {
        string path = Application.persistentDataPath + "/user.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data newData = JsonUtility.FromJson<Data>(json);
            userName = newData.userName;
            points= newData.maxPoint;
        }
    }

}
