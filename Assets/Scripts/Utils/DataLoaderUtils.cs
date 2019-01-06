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
            return getData();
        }

        public List<Map> getData()
        {
            FileInfo[] filesInfo = getFiles();
            var actualMaps = new List<Map>();

            for (int i = 0; i < filesInfo.Length; i++)
            {
                var map = loadGameData(filesInfo[i].FullName);

                actualMaps.Add(map);
            }

         

            return actualMaps;
        }


        public Map loadGameData(string file)
        {
            Map map = null;
            if (File.Exists(file))
            {
                var dataAsJson = File.ReadAllText(file);
                map = JsonUtility.FromJson<Map>(dataAsJson);
            }
            else
            {
                Debug.LogError("File doesnt exist" + file);
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
            return filesInfo;
        }
    }
}