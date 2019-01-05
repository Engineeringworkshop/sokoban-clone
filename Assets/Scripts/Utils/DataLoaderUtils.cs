using System.IO;
using Boo.Lang;
using LevelEditor.Models;
using UnityEngine;

namespace Utils
{
    public class DataLoaderUtils
    {
        private const string GameDataLevelsFilePath = "/StreamingAssets/";
        private const string DataExtension = ".json";

        public List<Map> LoadData()
        {
            return getData(GameDataLevelsFilePath);
        }

        public List<Map> getData(string path)
        {
            var filePath = Path.Combine(Application.streamingAssetsPath, path);

            var actualMaps = new List<Map>();
            var map = loadGameData("filename" + DataExtension);

            actualMaps.Add(map);

            return actualMaps;
        }


        public Map loadGameData(string fileName)
        {
            var filePath = Application.dataPath + GameDataLevelsFilePath + fileName;
            Map map = null;
            if (File.Exists(filePath))
            {
                var dataAsJson = File.ReadAllText(filePath);
                map = JsonUtility.FromJson<Map>(dataAsJson);
            }
            else
            {
                Debug.LogError("File doesnt exist" + filePath);
            }

            return map;
        }

        public void saveGameData(Map map)
        {
            var dataAsJson = JsonUtility.ToJson(map);
            var number = getNextNumberFile();
            var filePath = Application.dataPath + GameDataLevelsFilePath + "level_" + number + DataExtension;
            File.WriteAllText(filePath, dataAsJson);
        }

        private int getNextNumberFile()
        {
            var fileInfo = getFiles();
            return fileInfo.Length + 1;
        }

        private static FileInfo[] getFiles()
        {
            var info = new DirectoryInfo(Application.dataPath + GameDataLevelsFilePath);
            var filesInfo = info.GetFiles("level_*.json");
            Debug.Log(filesInfo);
            return filesInfo;
        }
    }
}