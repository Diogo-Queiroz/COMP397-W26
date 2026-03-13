using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MySystems.Persistence
{
    public class SaveLoadSystem : PersistentSingleton<SaveLoadSystem>
    {
        [SerializeField] public GameData gameData;
        IDataService dataService;

        protected override void Awake()
        {
            base.Awake();
            dataService = new FileDataService(new JsonSerializer());
        }

        public void SaveGame()
        {
            dataService.Save(gameData);
        }
        public void LoadGame(string gameName)
        {
            gameData = dataService.Load(gameName);
            if (String.IsNullOrWhiteSpace(gameData.CurrentLevelName))
            {
                gameData.CurrentLevelName = "Menu";
            }
            SceneManager.LoadScene(gameData.CurrentLevelName);
        }
        public void DeleteGame(string gameName)
        {
            dataService.Delete(gameName);
        }
        public IEnumerable<string> ListAllSaves()
        {
            return dataService.ListSaves();
        }
    }
}
