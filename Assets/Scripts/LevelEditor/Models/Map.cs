using System;
using UnityEngine;

namespace LevelEditor.Models
{
    [Serializable]
    public class Map {
    
        [SerializeField] private int xSize;
        [SerializeField] private int ySize;

        [SerializeField] private string backgroundTerrain;

        [SerializeField] private Cell[,] grid; //FIX don't support json

        internal Map() {}
    
        internal Map(int xSize, int ySize, string backgroundTerrain)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            this.backgroundTerrain = backgroundTerrain;
            grid = new Cell[this.xSize, this.ySize];
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

        public Cell[,] Grid
        {
            get { return grid; }
            set { grid = value; }
        }

        public override string ToString()
        {
            return string.Format("XSize: {0}, YSize: {1}, BackgroundTerrain: {2}, Grid: {3}, XSize: {4}, YSize: {5}, BackgroundTerrain: {6}, Grid: {7}", xSize, ySize, backgroundTerrain, grid, XSize, YSize, BackgroundTerrain, Grid);
        }
    }
}
