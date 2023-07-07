using System;
using System.IO;

namespace Checkers
{
    public static class Matherials
    {
        public readonly static string basePath = AppDomain.CurrentDomain.BaseDirectory;
        public readonly static string spritesPath = Path.Combine(basePath, "Resources", "Sprites");
        public readonly static string imagesPath = Path.Combine(basePath, "Resources", "Images");

        public readonly static string whiteSimpleCheckerPath =
            Path.Combine(spritesPath, "whiteChecker.png");
        
        public readonly static string blackSimpleCheckerPath =
            Path.Combine(spritesPath, "blackChecker.png");
        
        public readonly static string whiteKingCheckerPath =
            Path.Combine(spritesPath, "whiteKingChecker.png");
        
        public readonly static string blackKingCheckerPath =
            Path.Combine(spritesPath, "blackKingChecker.png");

        public readonly static string blurredGameFormBackgroundPath =
            Path.Combine(imagesPath, "blurredGameFormBackground.jpg");
    }
}