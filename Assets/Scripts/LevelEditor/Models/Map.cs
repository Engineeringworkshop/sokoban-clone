using System;
using Boo.Lang;
using UnityEngine;

namespace LevelEditor.Models
{
    [Serializable]
    public class Map
    {
        [SerializeField] private int xSize;
        [SerializeField] private int ySize;

        [SerializeField] private string backgroundTerrain;

        [SerializeField] public Cell[] cells;


        internal Map()
        {
        }

        internal Map(int xSize, int ySize, string backgroundTerrain)
        {
            XSize = xSize;
            YSize = ySize;
            BackgroundTerrain = backgroundTerrain;
            cells = new Cell[XSize * YSize];
        }

        public int XSize
        {
            get { return xSize; }
            set { xSize = value; }
        }

        public int YSize
        {
            get { return ySize; }
            set { ySize = value; }
        }

        public string BackgroundTerrain
        {
            get { return backgroundTerrain; }
            set { backgroundTerrain = value; }
        }


        public override string ToString()
        {
            return string.Format("XSize: {0}, YSize: {1}, BackgroundTerrain: {2}, Cells: {3}, XSize: {4}, YSize: {5}, BackgroundTerrain: {6}", xSize, ySize, backgroundTerrain, cells, XSize, YSize, BackgroundTerrain);
        }
    }
}