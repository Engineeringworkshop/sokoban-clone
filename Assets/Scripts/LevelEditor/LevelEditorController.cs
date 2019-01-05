using LevelEditor.Models;
using UnityEngine;

namespace LevelEditor
{
    public class LevelEditorController : MonoBehaviour
    {

        private Map generatedMap;

        private LevelsEditorDataController levelEditorDataController;

        private void Start()
        {
            levelEditorDataController = new LevelsEditorDataController();
        }

        public Map generateMap(int xSize, int ySize, string backgroundTerrain)
        {
            generatedMap = new Map(xSize, ySize, backgroundTerrain);

            return generatedMap;
        }

        public void updateMap(Cell[,] grid)
        {
            generatedMap.Grid = grid;
        }

        public void saveActualMap()
        {
            levelEditorDataController.saveMap(generatedMap);
        }
    }
}
