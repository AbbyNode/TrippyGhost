using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    // To run these tests: Window -> General -> TestRunner, select Tests folder and run all
    public class UnitTests
    {
        [Test]
        public void TestRandomNumberGenerator()
        {
            Generator generator = new Generator();
            int min = -1000;
            int max = 1000;
            int tests = 1000;
            for (int i = 0; i < tests; i++)
            {
                var rand = generator.GetRndInteger(min, max);
                Assert.IsTrue(rand >= min && rand <= max);
            }
        }

        [Test]
        public void TestBirdNourishment()
        {
            // Mock the bird object
            GameObject greenBar = new GameObject();
            NourishmentBar nourishmentBar = new NourishmentBar();
            nourishmentBar.greenBar = greenBar;
            GameObject go = Object.Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Prefabs/playerBird.prefab", typeof(GameObject))) as GameObject;
            PlayerBird bird = go.GetComponent<PlayerBird>();
            bird.nourishmentBar = nourishmentBar;

            // Test
            bird.SetNourishment(0.5f);
            Assert.AreEqual(0.5f, bird.nourishment);
            bird.AddNourishment(0.25f);
            Assert.AreEqual(0.75, bird.nourishment);
        }

        [Test]
        public void TestBirdMovementX()
        {
            GameObject go = Object.Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Prefabs/playerBird.prefab", typeof(GameObject))) as GameObject;
            PlayerBird bird = go.GetComponent<PlayerBird>();
            Vector3 oldPos = bird.transform.position;
            bird.Update();
            Assert.True(bird.transform.position.x > oldPos.x);
        }

        [Test]
        public void TestBirdMovementY()
        {
            GameObject go = Object.Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Prefabs/playerBird.prefab", typeof(GameObject))) as GameObject;
            PlayerBird bird = go.GetComponent<PlayerBird>();
            Vector3 oldPos = bird.transform.position;
            bird.Update();
            Assert.True(bird.transform.position.y < oldPos.y);
        }

        [Test]
        public void TestInitialNourishment()
        {
            GameObject go = Object.Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Prefabs/playerBird.prefab", typeof(GameObject))) as GameObject;
            PlayerBird bird = go.GetComponent<PlayerBird>();
            Assert.AreEqual(1.0f, bird.GetNourishment());
        }
    }
}
