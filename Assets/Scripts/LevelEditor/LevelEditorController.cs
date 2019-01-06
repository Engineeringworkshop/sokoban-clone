using LevelEditor.Models;
using UnityEngine;

namespace LevelEditor
{
    public class LevelEditorController : MonoBehaviour
    {

        private Map generatedMap;
        private Cell[,] grid;

        private LevelsEditorDataController levelEditorDataController;

        private void Start()
        {
            levelEditorDataController = new LevelsEditorDataController();
        }

        public  Cell[,] generateMap(int xSize, int ySize, string backgroundTerrain)
        {
            generatedMap = new Map(xSize, ySize, backgroundTerrain);

            generateGrid(generatedMap);
            
            return grid;
        }

        private void generateGrid(Map map)
        {
            grid = new Cell[map.XSize, map.YSize];
        }

        public void updateMap(Cell[,] grid)
        {
           this.grid = grid;
        }

        public void saveActualMap()
        {
            convertGridToList();
            levelEditorDataController.saveMap(generatedMap);
        }

        private void convertGridToList()
        {
            var boundX = grid.GetUpperBound(0);
            var boundY = grid.GetUpperBound(1);
            var count = 0;
            for (var y = 0; y <= boundY; y++)
            {
                for (var x = 0; x <= boundX; x++)
                {
                    generatedMap.cells[count] = grid[x,y];
                    count++;
                }
            }
        }
    }
}
