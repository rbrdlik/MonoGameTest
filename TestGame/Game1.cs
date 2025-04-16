using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _playerTexture;

    private const float _gravity = 0.5f;
    private float _velocityY = 0f;
    private readonly float _playerSpeed = 5f;
    private Vector2 _playerPosition = new Vector2(0, 0);

    private readonly int[] _playerSize = [32, 32]; // Vyska, Sirka

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _playerTexture = Content.Load<Texture2D>("spritesheet");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        KeyboardState keyboardState = Keyboard.GetState();
        
        _spriteBatch.Begin();
        
        _velocityY += _gravity;
        _playerPosition.Y += _velocityY;
        
        Rectangle sourceRect = new Rectangle(0, 0, 8, 8);
        Rectangle destRect = new Rectangle((int) _playerPosition.X, (int) _playerPosition.Y, _playerSize[0], _playerSize[1]);
        _spriteBatch.Draw(_playerTexture, destRect, sourceRect, Color.White);
        
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}