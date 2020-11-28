using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Upgrade
{
    [SerializeField]
    private string m_upgradeName;
    [SerializeField]
    private int m_upgradeLevel;

    public Upgrade(string name, int level) 
    {
        m_upgradeName = name;
        m_upgradeLevel = level;
    }

    public void IncreaseLevel()
    {
        m_upgradeLevel += 1;
    }

    public void DecreaseLevel()
    {
        m_upgradeLevel -= 1;
    }

    public void SetLevel(int t_level)
    {
        m_upgradeLevel = t_level;
    }

    public string GetUpgradeName()
    {
        return m_upgradeName;
    }

    public int GetUpgradeLevel()
    {
        return m_upgradeLevel;
    }
}

public class UpgradeSystem
{
    private List<Upgrade> m_upgradeList = new List<Upgrade>();
    string jsonSavePath;

    public UpgradeSystem() { }

    public void AddUpgrade(Upgrade t_upgrade)
    {
        m_upgradeList.Add(t_upgrade);
    }

    public int GetUpgradeCount()
    {
        return m_upgradeList.Count;
    }

    public Upgrade GetUpgrade(string t_name)
    {
        foreach (Upgrade upgrade in m_upgradeList)
        {
            if (upgrade.GetUpgradeName() == t_name)
            {
                return upgrade;
            }
        }
        return null;
    }

    public void SaveUpgrades()
    {
        string jsonString = "";
        string finalString = "[";
        int listCount = m_upgradeList.Count;
        int index = 1;

        jsonSavePath = Application.persistentDataPath + "/upgrades.json";

        foreach (Upgrade upgrade in m_upgradeList)
        {
            if (index != listCount)
            {
                jsonString = JsonUtility.ToJson(upgrade, true);
                finalString += jsonString + ",";
            }
            else
            {
                jsonString = JsonUtility.ToJson(upgrade, true);
                finalString += jsonString;
            }
            index++;
        }

        finalString += "]";
        File.WriteAllText(jsonSavePath, finalString);
    }
}
