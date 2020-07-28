﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Mime;

namespace Arcada1
{
  public enum Stat
  {
    SplashScreen,
    Game,
    GameOver,
    Pause
  }
  public enum Direction : Byte
  {
    Up,
    Down,
    Left,
    Right
  }
  public enum TypesOfTarget : Byte
  {
    Cure,
    Poison,
    Death
  }
  public enum FrameOfTank : Byte
  {
    UpFirstFrame = 0,
    UpSecondFrame = 16,
    LeftFirstFrame = 32,
    LeftSecondFrame = 48,
    DownFirstFrame = 64,
    DownSecondFrame = 80,
    RightFirstFrame = 96,
    RightSecondFrame = 112
  }
  public enum TypeOfTank : Byte
  {
    TypeOne = 0,
    TypeTwo = 16,
    TypeThree = 32,
    TypeFour = 48,
    TypeFive = 64,
    TypeSix = 80,
    TypeSeven = 96,
    TypeEight = 112
  }
  public enum BulletDirectionSprite : Byte
  {
    Up = 67,
    Left = 74,
    Down = 83,
    Right = 90
  }
  /// <summary>
  /// This is the main type for your game.
  /// </summary>
  public class Game1 : Game
  {
    GraphicsDeviceManager graphics;
    static SpriteBatch spriteBatch;
    static Texture2D texture;
    Vector2 pos = new Vector2() { X = 0, Y = 0 };
    static Vector2 centerOfRotation = new Vector2() { X = 15, Y = 15 };
    Int64 counter = 0;
    //    sbyte dirX = 1, dirY = 1;
    Random rnd = new Random();
    Color BackgroundColor = new Color();
    //   Player player = new Player(100, 100, texture);
    Tank tank1 = new Tank(100, 100, 6);
    Stat Stat = Stat.SplashScreen;
    //List<Target>

    public Game1()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
    }

    protected void ChangeDirection(Single Position, ref SByte Direction,
                                Int32 ScreenSize, Int32 TextureSize)
    {
      if ((Position >= (ScreenSize - TextureSize)) || (Position <= 0))
        Direction *= -1;
    }

      
    

    /// <summary>
    /// Allows the game to perform any initialization it needs to before starting to run.
    /// This is where it can query for any required services and load any non-graphic
    /// related content.  Calling base.Initialize will enumerate through any components
    /// and initialize them as well.
    /// </summary>
    protected override void Initialize()
    {
      
      // TODO: Add your initialization logic here
      base.Initialize();
    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
      // Create a new SpriteBatch, which can be used to draw textures.
      spriteBatch = new SpriteBatch(GraphicsDevice);
      tank1.Texture = Content.Load<Texture2D>("yellow_tanks");
      //     player.SetTexture(texture);
      

      // TODO: use this.Content to load your game content here
    }

    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// game-specific content.
    /// </summary>
    protected override void UnloadContent()
    {
      // TODO: Unload any non ContentManager content here
    }

    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        Exit();

      switch (Stat)
      {
        case Stat.SplashScreen:
          if (Keyboard.GetState().IsKeyDown(Keys.Space))
            Stat = Stat.Game;
          break;

        case Stat.Game:
          if (Keyboard.GetState().IsKeyDown(Keys.Space))
            new Bullet(tank1.GetPosForFire, Direction.Up, 1);
          else
if (Keyboard.GetState().IsKeyDown(Keys.Up))
            BattleCity.Update(Direction.Up);
          else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            BattleCity.Update(Direction.Down);
          else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            BattleCity.Update(Direction.Left);
          else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            BattleCity.Update(Direction.Right);
          break;

        case Stat.GameOver:

          break;

        case Stat.Pause:

          break;
      }
      


      //pos.X += dirX;
      //pos.Y += dirY;

      //      ChangeDirection(pos.X, ref dirX, Window.ClientBounds.Width, texture.Width / 10);
      //      ChangeDirection(pos.Y, ref dirY, Window.ClientBounds.Height, texture.Height / 10);

      base.Update(gameTime);

      ++counter;
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.Black);

      spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

      switch (Stat)
      {
        case Stat.SplashScreen:

          break;

        case Stat.Game:
          tank1.Draw(spriteBatch);
          break;

        case Stat.GameOver:

          break;

        case Stat.Pause:

          break;
      }


      
      spriteBatch.End();

      // TODO: Add your drawing code here

      base.Draw(gameTime);
    }
  }
}
