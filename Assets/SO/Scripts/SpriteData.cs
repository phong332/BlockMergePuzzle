using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;


[CreateAssetMenu(fileName = "SpriteData", menuName = "ScriptableObjects/PlayerData")]
public class SpriteData : ScriptableObject
{
    [SerializeField]
    SerializedDictionary<string, List<LevelSprite>> dataSprite;

    [Button]
    public void AddData()
    {
        for (int i = 1; i <= 6; i++)
        {
            string keyString = "Number " + i;
            List<LevelSprite> sprites = new List<LevelSprite>(30);
            for (int j = 0; j < 30; j++)
            {
                string x = "Sprite/number" + i + "/" + (j + 1) + ".png";
                Debug.Log(x);
                Sprite icon = Resources.Load<Sprite>("Sprite/number" + i + "/" + (j + 1));

                sprites.Add(new LevelSprite(j + 1, icon));
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


    public LevelSprite(int _level, Sprite _iconBlock)
    {
        level = _level;
        iconBlock = _iconBlock;
    }
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




