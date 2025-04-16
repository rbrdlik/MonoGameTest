using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame.Entity;

public class Platform
{
    private Texture2D _texture;
    private Vector2 _position;
    
    public Rectangle BoundingBox => new Rectangle((int)_position.X + 30, (int)_position.Y, 90, 30);

    
    public Platform(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        _position = position;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, new Rectangle((int)_position.X, (int)_position.Y, 256, 256), new Rectangle(0, 8, 120, 120), Color.White);
        spriteBatch.Draw(_texture, new Rectangle((int)_position.X + 30, (int)_position.Y, 256, 256), new Rectangle(3, 8, 120, 120), Color.White);
        spriteBatch.Draw(_texture, new Rectangle((int)_position.X + 60, (int)_position.Y, 256, 256), new Rectangle(3, 8, 120, 120), Color.White);
    }
    
}