using System;
using UnityEngine;

namespace LevelEditor.Models
{
    [Serializable]
    public class Cell
    {
        [SerializeField] private string type;
        [SerializeField] private string color;

        public Cell(string type, string color)
        {
            this.type = type;
            this.color = color;
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
