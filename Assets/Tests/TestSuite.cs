using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestSuite
    {

        [UnityTest]
        public IEnumerator UpgradeObjectCreationTest()
        {
            Upgrade testUpgrade = new Upgrade(new Pair<string, int>("Attack", 1));
            Assert.IsNotNull(testUpgrade);
            int tempUpgradeLevel = testUpgrade.GetUpgradeLevel();
            testUpgrade.IncreaseLevel();
            Assert.Greater(testUpgrade.GetUpgradeLevel(), tempUpgradeLevel);
            yield return null;
        }

        [UnityTest]
        public IEnumerator UpgradeSystemObjectCreationTest()
        {
            UpgradeSystem upgradeSystem = new UpgradeSystem();
            int listCount = upgradeSystem.GetUpgradeCount();
            Assert.AreEqual(listCount, 0);
            Upgrade testUpgrade = new Upgrade(new Pair<string, int>("Attack", 1));
            upgradeSystem.AddUpgrade(testUpgrade);
            listCount = upgradeSystem.GetUpgradeCount();
            Assert.AreEqual(listCount, 1);
            yield return null;
        }

        [UnityTest]
        public IEnumerator UpgradeObjectRetrievalTest()
        {
            UpgradeSystem upgradeSystem = new UpgradeSystem();
            Upgrade testUpgrade = new Upgrade(new Pair<string, int>("Attack", 1));
            upgradeSystem.AddUpgrade(testUpgrade);
            Upgrade testUpgrade2 = upgradeSystem.GetUpgrade("Attack");
            Assert.AreEqual("Attack", testUpgrade2.GetUpgradeName());
            yield return null;
        }

        [UnityTest]
        public IEnumerator UpgradeLevelTest()
        {
            UpgradeSystem upgradeSystem = new UpgradeSystem();
            Upgrade testUpgrade = new Upgrade(new Pair<string, int>("Attack", 1));
            upgradeSystem.AddUpgrade(testUpgrade);
            int upgradeLevel = upgradeSystem.GetUpgrade("Attack").GetUpgradeLevel();
            upgradeSystem.GetUpgrade("Attack").IncreaseLevel();
            Assert.AreNotEqual(upgradeLevel, upgradeSystem.GetUpgrade("Attack").GetUpgradeLevel());
            upgradeLevel = upgradeSystem.GetUpgrade("Attack").GetUpgradeLevel();
            upgradeSystem.GetUpgrade("Attack").SetLevel(0);
            Assert.AreNotEqual(upgradeLevel, upgradeSystem.GetUpgrade("Attack").GetUpgradeLevel());
            yield return null;
        }
    }
}
