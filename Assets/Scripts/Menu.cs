using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : PersistentSingleton<Menu>
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button saveBtn;
    [SerializeField] private Button loadBtn;
    private InputAction menu;
    private bool menuIsOpen;
    private Canvas menuCanvas;
    public UnityAction getPlayerData;
    protected override void Awake()
    {
        base.Awake();
        menu = InputSystem.actions.FindAction("Player/Menu");
        menu.started += ToggleMenu;
        menuCanvas = GetComponent<Canvas>();
    }
    private void Start()
    {
        playBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("SampleScene"); // This will always be the level 1.
        });
        saveBtn.onClick.AddListener(() =>
        {
            SaveLoadSystem.instance.gameData.fileName = "Menu"; // Be able to use UI Input Fields to save the file name
            SaveLoadSystem.instance.gameData.sceneName = "SampleScene";
            if (getPlayerData != null)
                getPlayerData.Invoke();
            SaveLoadSystem.instance.SaveGame();
        });
        loadBtn.onClick.AddListener(() =>
        {
            SaveLoadSystem.instance.LoadGame("Menu");
        });
    }

    private void ToggleMenu(InputAction.CallbackContext ctx)
    {
        menuIsOpen = !menuIsOpen;
        menuCanvas.enabled = menuIsOpen;
    }
}
