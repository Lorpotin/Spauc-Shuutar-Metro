﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Xml.Serialization;
using Windows.Devices.Input;
using Windows.UI.Xaml;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using Microsoft.Xna.Framework.Audio;
using Windows.Storage;

namespace SpacuShuutar
{
    public class ScrollingBackground
    {
        private Vector2 screenPos, origin, textureSize;
        private Texture2D screenTexture;
        public bool credits;

        public ScrollingBackground(Texture2D texture, bool creditz)
        {
            screenTexture = texture;
            
            
            screenPos = new Vector2(1920 / 2, 1080 / 2);
            textureSize = new Vector2(0, screenTexture.Height);
            credits = creditz;
            if (credits)
                origin = new Vector2(screenTexture.Width / 2, 0);
            else
                origin = new Vector2(screenTexture.Width / 2, 0);
        }

        public void Update(GameTime gameTime)
        {
            if (credits)
            {
                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                screenPos.Y -= elapsed * 50;
                screenPos.Y = screenPos.Y % screenTexture.Height;
            }
            else
            {
                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                screenPos.Y += elapsed * 60;
                screenPos.Y = screenPos.Y % screenTexture.Height;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Piirretään, jos näytöllä
            if (screenPos.Y < 1080)
            {
                spriteBatch.Draw(screenTexture, screenPos, null, Color.White, 0, origin, 1, SpriteEffects.None, 0f);
            }
            //Piirretään toisen kerran ensimmäisen perään, jotta saadaan aikaiseksi luuppaava tausta.
            spriteBatch.Draw(screenTexture, screenPos - textureSize, null, Color.White, 0, origin, 1, SpriteEffects.None, 0f);
            
        }

    }
}