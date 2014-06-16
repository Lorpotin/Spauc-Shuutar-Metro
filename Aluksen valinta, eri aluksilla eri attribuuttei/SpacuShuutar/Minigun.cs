﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Windows.Devices.Input;
using Windows.UI.Xaml;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using Microsoft.Xna.Framework.Audio;

namespace SpacuShuutar
{
    public class Minigun
    {

        public Texture2D gunTexture;
        public Vector2 position;
        public Vector2 center;
        public Vector2 origin;
        public Vector2 direction;
        public Asteroid target;
        public Ufo target1;
        public Boss target2;
        public float rotation;
        public float rotation2;
        Player player;


        public Asteroid Target
        {
            get { return target; }
        }
        public Ufo Target1
        {
            get { return target1; }
        }
        public Boss Target2
        {
            get { return target2; }
        }

        public int Width
        {
            get { return gunTexture.Width; }
        }
        public int Height
        {
            get { return gunTexture.Height; }
        }

        public Minigun(Texture2D text, Player player)
        {
            this.gunTexture = text;
            this.player = player;
            position = new Vector2(player.arrowPosition.X + 35, player.arrowPosition.Y + 15);
            center = new Vector2(position.X + gunTexture.Width / 2, position.Y + gunTexture.Height / 2);
            origin = new Vector2(gunTexture.Width / 2, gunTexture.Height / 2);
        }

        public bool IsInRange(Vector2 position)
        {
            return Vector2.Distance(center, position) <= 300;
        }
        public void TurnTurret()
        {
            Vector2 direction = position - target.position;
            direction.Normalize();
            rotation = (float)Math.Atan2(-direction.X, direction.Y);
        }
        public void TurnTurret1()
        {
            Vector2 direction = position - target1.position;
            direction.Normalize();
            rotation = (float)Math.Atan2(-direction.X, direction.Y);
        }
        public void TurnTurret2()
        {
            Vector2 direction = position - target2.position;
            direction.Normalize();
            rotation = (float)Math.Atan2(-direction.X, direction.Y);
        }

        public void Update(GameTime gameTime)
        {
            position = player.arrowPosition;
            if (target != null)
            {
                TurnTurret();
            }
            if (target1 != null)
            {
                TurnTurret1();
            }
            if (target2 != null)
            {
                TurnTurret2();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(gunTexture, position, null, Color.White,
                rotation, origin, 1.0f, SpriteEffects.None, 0);
        }

    }
}