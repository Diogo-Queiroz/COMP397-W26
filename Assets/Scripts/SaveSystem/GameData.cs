using System;

namespace MySystems.Persistence
{
    [Serializable]
    public class GameData
    {
        public string Name;
        public string CurrentLevelName; // Describes which scene we are at.
    }
}
