using System;
using UnityEngine;

namespace LevelEditor.Models
{
    [Serializable]
    public class Cell
    {
        [SerializeField] private int x;
        [SerializeField] private int y;
        [SerializeField] private string type;
        [SerializeField] private string color;



        public Cell(int x, int y,string type, string color)
        {
            this.x = x;
            this.y = y;
            this.type = type;
            this.color = color;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Color: {1}, Type: {2}, Color: {3}", type, color, Type, Color);
        }
    }
}
