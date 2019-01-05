using LevelEditor.Models;
using Utils;

namespace LevelEditor
{
    public class LevelsEditorDataController
    {

        private DataLoaderUtils dataLoaderUtils;

        public LevelsEditorDataController()
        {
            dataLoaderUtils = new DataLoaderUtils();
        }

        public Map getAllMaps()
        {
            var map = new Map();

            return map;
        }
        
        public Map getMapNyName()
        {
            var map = new Map();

            return map;
        }

        public void saveMap(Map map)
        {
            dataLoaderUtils.saveGameData(map);
        }

        public void loadMap(Map map)
        {
        }
        
        public void deleteMap(Map map)
        {
        }


    }
}
