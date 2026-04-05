[System.Serializable]
public class GameData 
{
    public string fileName;
    public string sceneName;
    // Character stats to be loaded and saved
    public int health;
    public int maxHealth = 100;
    public int walkingSpeed = 5;
    public int runningSpeed = 10;
    public float posX, posY, posZ;
    public bool isDefaultPosition = true;
}