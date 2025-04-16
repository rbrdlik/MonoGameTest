using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestGame.Entity;

namespace TestGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _playerTexture;
    private Player _player;
    private Platform _platform;
    private List<Platform> _platforms;
    private List<Ground> _grounds;
    private Random _random;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _random = new Random();
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
        _player = new Player(_playerTexture, new Vector2(0, 0), 32, 32);
        GeneratePlatforms();
        _grounds = new List<Ground>();
        for(int i = -30; i < 760; i+=40){
            _grounds.Add(new Ground(_playerTexture, new Vector2(i, 465)));
        }

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        _player.Update(GraphicsDevice.Viewport);

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.LightBlue);
        
        _spriteBatch.Begin();
        _player.Draw(_spriteBatch);
        
        foreach (var platform in _platforms)
        {
            platform.Draw(_spriteBatch);
        }
        
        foreach (var ground in _grounds)
        {
            ground.Draw(_spriteBatch);
        }
        
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

    public void GeneratePlatforms()
    {
        _platforms = new List<Platform>();
        Random random = new Random();

        int numberOfPlatforms = 15;
        int platformWidth = 90;
        int screenWidth = _graphics.PreferredBackBufferWidth;
        int screenHeight = _graphics.PreferredBackBufferHeight;

        int minHorizontalOffset = 100;
        int maxHorizontalOffset = 200;

        int minVerticalOffset = 80;
        int maxVerticalOffset = 140;

        int leftBound = 0;
        int rightBound = screenWidth - platformWidth;
        
        Vector2 currentPosition = new Vector2(screenWidth / 2, screenHeight - 90);

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            _platforms.Add(new Platform(_playerTexture, currentPosition));

            int direction = random.Next(2) == 0 ? -1 : 1;
            float offsetX = random.Next(minHorizontalOffset, maxHorizontalOffset + 1) * direction;
            float offsetY = -random.Next(minVerticalOffset, maxVerticalOffset + 1);

            currentPosition += new Vector2(offsetX, offsetY);
            
            if (currentPosition.X < leftBound)
                currentPosition.X = leftBound + 10;
            if (currentPosition.X > rightBound)
                currentPosition.X = rightBound - 10;
        }
    }
}