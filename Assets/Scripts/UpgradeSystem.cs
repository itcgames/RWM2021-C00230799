using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class Upgrade
{
    [JsonProperty]
    private string m_upgradeName;
    [JsonProperty]
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
    [JsonProperty]
    private List<Upgrade> m_upgradeList = new List<Upgrade>();
    string jsonSavePath = Application.persistentDataPath + "/upgrades.json";

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
        string jsonString;

        jsonString = JsonConvert.SerializeObject(m_upgradeList);
        Debug.Log("UPGRADE SAVE TEST : " + jsonString);
 
        File.WriteAllText(jsonSavePath, jsonString);
    }

    public void LoadUpgrades()
    {
        string jsonString;

        jsonString = File.ReadAllText(jsonSavePath);

        m_upgradeList = JsonConvert.DeserializeObject<List<Upgrade>>(jsonString);
        Debug.Log("UPGRADE LOAD TEST (UPGRADE COUNT) : " + GetUpgradeCount());
    }
}
