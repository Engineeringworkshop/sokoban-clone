using Boo.Lang;
using LevelEditor;
using LevelEditor.Models;
using UnityEngine;

namespace Game
{
    public class LevelsController
    {
        private List<Map> levels;

        private LevelsEditorDataController levelsEditorDataController;
        // Start is called before the first frame update

        public LevelsController()
        {
            levelsEditorDataController = new LevelsEditorDataController();
            levels = levelsEditorDataController.getAllMaps();
        }

        public List<Map> getAllLevelList()
        {
            return levels;
        }

        public Cell[,] generateGrid(Map map)
        {
            Cell[,] grid = new Cell[map.XSize, map.YSize];

            foreach (var cell in map.cells)
            {
                if (!cell.Type.Equals(""))
                {
                    grid[cell.X, cell.Y] = cell;
                }
             }

            return grid;
        }
    }
}
