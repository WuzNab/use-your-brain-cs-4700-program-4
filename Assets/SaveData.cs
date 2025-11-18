using System;

[Serializable]
public class SaveData
{
    public int[] levelBrains = new int[8]; // 0–3 brains per level
    public bool[] levelCompleted = new bool[8]; // true if level finished
}
