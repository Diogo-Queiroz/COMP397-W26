using KBCore.Refs;
using MySystems.Persistence;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button newGameBtn;
    [SerializeField] private Button saveGameBtn;
    [SerializeField] private Button loadGameBtn;
    
    private void Awake()
    {
        newGameBtn.onClick.AddListener(() => SceneManager.LoadScene("SampleScene")); 
        saveGameBtn.onClick.AddListener(() =>
        {
            SaveLoadSystem.Instance.gameData.Name = SceneManager.GetActiveScene().name;
            SaveLoadSystem.Instance.SaveGame();
        });
        loadGameBtn.onClick.AddListener(() => SaveLoadSystem.Instance.LoadGame(SaveLoadSystem.Instance.gameData.Name));
        //if (SaveLoadSystem.Instance.ListAllSaves().Count() <= 0)
        //{
        //    Debug.Log("No games are listed");
        //    saveGameBtn.interactable = true;
        //    loadGameBtn.interactable = false;
        //}
    }
}
