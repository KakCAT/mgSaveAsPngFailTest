using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Game1
{
/// <summary>
/// This is the main type for your game.
/// </summary>
public class Game1 : Game
{
GraphicsDeviceManager graphics;
SpriteBatch spriteBatch;
RenderTarget2D rt2d;
Texture2D tex;
int numPng=0;

public Game1()
{
	graphics = new GraphicsDeviceManager(this);
	Content.RootDirectory = "Content";
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

	// TODO: use this.Content to load your game content here
	rt2d=new RenderTarget2D (GraphicsDevice,1920,1080);
	tex=Content.Load<Texture2D> ("testImg");
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

	// TODO: Add your update logic here

	base.Update(gameTime);
}

/// <summary>
/// This is called when the game should draw itself.
/// </summary>
/// <param name="gameTime">Provides a snapshot of timing values.</param>
protected override void Draw(GameTime gameTime)
{
int i;
Random rnd=new Random ();

	GraphicsDevice.SetRenderTarget (rt2d);
	GraphicsDevice.Clear(Color.CornflowerBlue);

	spriteBatch.Begin ();
	for (i=0;i<1000;i++)
	{
	
		Rectangle rect=new Rectangle (rnd.Next()%1920,rnd.Next()%1080,256,256);
		spriteBatch.Draw (tex,rect,Color.White);
	}

	spriteBatch.End();

	GraphicsDevice.SetRenderTarget (null);


	spriteBatch.Begin ();
	spriteBatch.Draw (rt2d,new Rectangle (0,0,800,600),Color.White);
	spriteBatch.End();


	MemoryStream ms=new MemoryStream ();
	rt2d.SaveAsPng (ms,rt2d.Width,rt2d.Height);

	string fn=String.Format ("o:\\test\\output_{0:0000}.png",numPng++);
	File.WriteAllBytes (fn,ms.ToArray());


	base.Draw(gameTime);
}
}
}
