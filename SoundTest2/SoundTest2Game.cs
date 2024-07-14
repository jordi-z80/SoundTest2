using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace SoundTest2
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class SoundTest2Game : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		SoundEffect effect;
		KeyboardState keyboardState;
		KeyboardState lastKeyboardState;

		public SoundTest2Game ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";

		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here

			base.Initialize ();

		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);

			// TODO: Use this.Content to load your game content here
			effect = Content.Load <SoundEffect> ("fall0");
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent ()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			MouseState mouseState = Mouse.GetState ();
			keyboardState = Keyboard.GetState ();
			GamePadState gamePadState = default;
			try { gamePadState = GamePad.GetState (PlayerIndex.One); }
			catch (NotImplementedException) { /* ignore gamePadState */ }

			if (keyboardState.IsKeyDown (Keys.Escape) ||
				keyboardState.IsKeyDown (Keys.Back) ||
				gamePadState.Buttons.Back == ButtonState.Pressed)
			{
				try { Exit (); }
				catch (PlatformNotSupportedException) { /* ignore */ }
			}


			if (justPressed (Keys.Q)) effect.Play (1.0f, -0.6f, 0);
			if (justPressed (Keys.W)) effect.Play (1.0f, -0.4f, 0);
			if (justPressed (Keys.E)) effect.Play (1.0f, -0.2f, 0);
			if (justPressed (Keys.R)) effect.Play ();
			if (justPressed (Keys.T)) effect.Play (1.0f, 0.2f, 0);
			if (justPressed (Keys.Y)) effect.Play (1.0f, 0.4f, 0);
			if (justPressed (Keys.U)) effect.Play (1.0f, 0.6f, 0);




			lastKeyboardState = keyboardState;
			base.Update (gameTime);
		}

		//=============================================================================
		/// <summary></summary>
		bool justPressed (Keys key)
		{
			return keyboardState.IsKeyDown (key) && !lastKeyboardState.IsKeyDown (key);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			GraphicsDevice.Clear (Color.CornflowerBlue);

			// TODO: Add your drawing code here

			base.Draw (gameTime);
		}
	}
}
