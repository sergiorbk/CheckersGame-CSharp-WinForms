using System.Drawing;
using System.IO;

namespace Checkers
{
    public class Checker{

        private GameColor _color;
        private CheckerType _type;
        private Image _image;
        
        public enum CheckerType
        {
            Simple,
            King
        }

        public Checker(GameColor color)
        {
            SetColor(color);
            _type = CheckerType.Simple;
        }

        public CheckerType GetType()
        {
            return _type;
        }

        public void SetType(CheckerType type)
        {
            _type = type;
            UpdateImage();
        }
        
        public GameColor GetColor()
        {
            return _color;
        }

        private void SetColor(GameColor color)
        {
            _color = color;
            UpdateImage();
        }
        
        private void UpdateImage()
        {
            if (_type == CheckerType.Simple)
            {
                switch (_color)
                {
                    case GameColor.White:
                        _image = Image.FromFile(Path.Combine(Matherials.whiteSimpleCheckerPath));
                        break;
                
                    case GameColor.Black:
                        _image = Image.FromFile(Path.Combine(Matherials.blackSimpleCheckerPath));
                        break;
                }
            }

            if (_type == CheckerType.King)
            {
                switch (_color)
                {
                    case GameColor.White:
                        _image = Image.FromFile(Matherials.whiteKingCheckerPath);
                        break;
                
                    case GameColor.Black:
                        _image = Image.FromFile(Matherials.blackKingCheckerPath);
                        break;
                }
            }
        }

        public Image GetImage()
        {
            return _image;
        }

        
    }
}