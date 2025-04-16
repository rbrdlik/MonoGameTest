using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame.Entity;

public class Player
{
    private Texture2D _texture;
    private Vector2 _position;
    private int[] _size;
    private float _velocityY = 0f;
    private float _gravity = 0.5f;  
    private float _aceleration = 0f;
    private float _speed = 4f;

    public int WindowWidth;
    public int WindowHeight;

    public Player(Texture2D texture, Vector2 position, int width, int height)
    {
        _texture = texture;
        _position = position;
        _size = new int[] { width , height};
    }
    
    public void Update(Viewport viewport)
    {
        KeyboardState keyboardState = Keyboard.GetState();
        
        WindowWidth = viewport.Width;
        WindowHeight = viewport.Height;
        
        _aceleration = _gravity;
        _velocityY += _aceleration;
        _position.Y += _velocityY;

        // Kolize se stěnami
        if (_position.Y > WindowHeight - _size[1])
        {
            _position.Y = WindowHeight - _size[1];
            _velocityY = 0f;
        }
        if (_position.X > WindowWidth - _size[0])
        {
            _position.X = WindowWidth - _size[0];
            _velocityY = 0f;
        }
        if (_position.X < 0)
        {
            _position.X = 0;
            _velocityY = 0f;
        }
        if (_position.Y < 0)
        {
            _position.Y = 0;
            _velocityY = 0f;
        }

        // Pohyb
        if (keyboardState.IsKeyDown(Keys.D))
        {
            _position.X += _speed;
        }
        if (keyboardState.IsKeyDown(Keys.A))
        {
            _position.X -= _speed;
        }
        // Skákání, pokud je na zemi
        if ((keyboardState.IsKeyDown(Keys.Space) || keyboardState.IsKeyDown(Keys.W)) && _position.Y >= WindowHeight - _size[1])
        {
            _velocityY = -_speed * 3f; // Skok
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Rectangle sourceRect = new Rectangle(0, 0, 8, 8);
        Rectangle destRect = new Rectangle((int) _position.X, (int) _position.Y, _size[0], _size[1]);
        spriteBatch.Draw(_texture, destRect, sourceRect, Color.White);
    }
}