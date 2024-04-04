using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataManager : SingletonDontDestroyOnLoad<DataManager>
{
    private string savePath;

    protected override void Awake()
    {
        base.Awake();
        // Xác định đường dẫn lưu trữ dữ liệu
        savePath = Path.Combine(Application.dataPath + "/Json", "board.json");
    }

    public void SaveData(ArrayDisplay data)
    {
        // Serialize dữ liệu thành chuỗi JSON
        string jsonData = JsonUtility.ToJson(data.GetArrayDisplay(), true);

        // Lưu chuỗi JSON vào tệp tin
        File.WriteAllText(savePath, jsonData);

        Debug.Log("Saved data to: " + savePath);
    }

    public ArrayDisplay LoadData()
    {
        if (File.Exists(savePath))
        {
            // Đọc chuỗi JSON từ tệp tin
            string jsonData = File.ReadAllText(savePath);

            // Deserialize chuỗi JSON thành đối tượng PlayerData
            ArrayDisplay data = JsonUtility.FromJson<ArrayDisplay>(jsonData);

            Debug.Log("Loaded data from: " + savePath);
            return data;
        }
        else
        {
            Debug.LogWarning("No saved data found at: " + savePath);
            return null;
        }
    }
}
