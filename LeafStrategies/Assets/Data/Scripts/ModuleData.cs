using UnityEngine;

[CreateAssetMenu(fileName = "ModuleData", menuName = "Modules/ModuleData", order = 2)]
public class ModuleData : ScriptableObject
{
    public ModuleType moduleType;
    public int sizeX;
    public int sizeY;
}

public enum ModuleType
{
    home,
    gold,
    iron,
    oil,
}