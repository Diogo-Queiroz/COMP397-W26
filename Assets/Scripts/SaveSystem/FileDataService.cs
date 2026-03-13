using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace MySystems.Persistence
{
    public class FileDataService : IDataService
    {
        private ISerializer serializer;
        private string dataPath;
        private string fileExtension;

        public FileDataService(ISerializer serializer)
        {
            this.dataPath = Application.persistentDataPath;
            this.fileExtension = ".json";
            this.serializer = serializer;
        }
        private string GetPathToFile(string fileName)
        {
            return Path.Combine(dataPath, string.Concat(fileName, this.fileExtension));
        }
        public void Save(GameData data, bool overwrite = true)
        {
            string fileLocation = GetPathToFile(data.Name);
            if (!overwrite && File.Exists(fileLocation))
            {
                throw new IOException($"The file {data.Name}{fileExtension} already exists and cannot be overwritten.");
            }
            File.WriteAllText(fileLocation, serializer.Serialize(data));
        }
        public GameData Load(string name)
        {
            string fileLocation = GetPathToFile(name);
            if (!File.Exists(fileLocation))
            {
                throw new ArgumentException("No persisted GameData with name " + name);
            }
            return serializer.Deserialize<GameData>(File.ReadAllText(fileLocation));
        }
        public void Delete(string name)
        {
            string fileLocation = GetPathToFile(name);
            if (File.Exists(fileLocation))
            {
                File.Delete(fileLocation);
            }
        }
        public void DeleteAll()
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<string> ListSaves()
        {
            foreach (string path in Directory.EnumerateFiles(dataPath))
            {
                if (Path.GetExtension(path).Equals(fileExtension))
                {
                    yield return Path.GetFileNameWithoutExtension(path);
                }
            }
                
        }
    }
}
