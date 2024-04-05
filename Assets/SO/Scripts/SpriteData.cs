using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;


[CreateAssetMenu(fileName = "SpriteData", menuName = "ScriptableObjects/PlayerData")]
public class SpriteData : ScriptableObject
{
    [SerializeField]
    SerializedDictionary<string, listLevelSprite> dataSprite = new SerializedDictionary<string, listLevelSprite>();

    [Button]
    public void AddData()
    {
        dataSprite = new SerializedDictionary<string, listLevelSprite>();
        string x = "";
        Sprite icon = null;
        LevelSprite levelSprite = new LevelSprite();
        for (int i = 1; i <= 6; i++)
        {
            string keyString = "Number " + i;
            List<LevelSprite> sprites = new List<LevelSprite>(30);
            for (int j = 0; j < 30; j++)
            {
                x = "Sprite/number" + i + "/" + (j + 1) + ".png";
                icon = Resources.Load<Sprite>("Sprite/number" + i + "/" + (j + 1));
                levelSprite = new LevelSprite(j + 1, icon);
                sprites.Add(levelSprite);
            }
            dataSprite[keyString] = sprites;
        }
    }

}


[Serializable]
public class LevelSprite
{
    public int level;
    public Sprite iconBlock;

    public LevelSprite()
    {

    }
    public LevelSprite(int _level, Sprite _iconBlock)
    {
        level = _level;
        iconBlock = _iconBlock;
    }
}
[Serializable]
public class listLevelSprite
{
    public List<LevelSprite> levelSprites = new List<LevelSprite>(30);
}
[Serializable]
public class SerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField, HideInInspector]
    private List<TKey> keyData = new List<TKey>();

    [SerializeField, HideInInspector]
    private List<TValue> valueData = new List<TValue>();

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        Clear();
        for (int i = 0; i < keyData.Count && i < valueData.Count; i++)
        {
            this[keyData[i]] = valueData[i];
        }
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        keyData.Clear();
        valueData.Clear();

        foreach (var item in this)
        {
            keyData.Add(item.Key);
            valueData.Add(item.Value);
        }
    }
}




