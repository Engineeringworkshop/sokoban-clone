using UnityEngine;

namespace LevelEditor
{
    public class LevelEditorController : MonoBehaviour
    {

        private Map generatedMap;

        public Map generateMap(int xSize, int ySize, Sprite backgroundTerrain)
        {
            generatedMap = new Map(xSize, ySize, backgroundTerrain);

            return generatedMap;
        }
    }
}
