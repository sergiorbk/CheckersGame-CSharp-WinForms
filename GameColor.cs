using System;

namespace Checkers
{
    public enum GameColor
    {
        None,
        White,
        Black
    }
    
    public static class GameColorExtensions
    {
        public static System.Drawing.Color ToDrawingColor(this GameColor color)
        {
            switch (color)
            {
                case GameColor.White:
                    return System.Drawing.Color.BurlyWood;
                case GameColor.Black:
                    return System.Drawing.Color.SaddleBrown;
                default:
                    throw new ArgumentException($"Unsupported GameColor: {color}");
            }
        }
        
        
    }
}