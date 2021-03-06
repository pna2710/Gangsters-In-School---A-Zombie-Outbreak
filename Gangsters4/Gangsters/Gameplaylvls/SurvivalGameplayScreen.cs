﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Gangsters
{
    public class SurvivalGameplayScreen : GameScreen
    {

        Player Player;
        Cenarios Cenario;
        Cenarios StageClear;
        Cenarios pressMWarning;
        ZombieSurvival Zombies;
        Prof prof;
        // Image ControlsInfoKey;
        ControlsInfo controls;
        DeadScreen DeadScreen;
        

        List<ZombieSurvival> ListaZombies1 = new List<ZombieSurvival>();
 
        HealthManager healthbar;
        HealthManager[] healthbars = new HealthManager[4];

        Random opcaozombie = new Random();
        Random SpeedReducer = new Random();
        Random random = new Random();


        private Song song;
        private SoundEffect Hit_Sound;
        private SoundEffect bip_sound;
        private SoundEffect ZombieDead_sound;
        private SoundEffect footstep_sound;
        private SoundEffect gun_sound;
        private SoundEffect switch_sound;
        private SoundEffect chiken_sound;
        private SoundEffect miss_sound;

        // public List bullets = new List();
        static public float attackTimer1 = 0f, attackTimer2 = 0f;
        public const float attackCooldown1 = 3000f, attackCooldown2 = 1500f;
        public int countattack;
        static public int opcaopersonagem = 0;
        int i, o, stage = 1;

        static public int OpcaoPersona()
        {
            int opcao = opcaopersonagem;
            return opcao;
        }

        public int AttackZombie(ZombieSurvival z, ref Player Player)
        {
            z.Health -= Player.Attack;

            return z.Health;
        }

        public Player AttackPlayer(ZombieSurvival z, ref Player Player)
        {


            if (opcaopersonagem == 0)
            {
                Player.Health1 -= z.Attack;
            }
            else if (opcaopersonagem == 6)
            {
                Player.Health2 -= z.Attack;
            }
            else if (opcaopersonagem == 12)
            {
                Player.Health3 -= z.Attack;
            }
            else if (opcaopersonagem == 18)
            {
                Player.Health4 -= z.Attack;
            }

            return Player;
        }

        public override void LoadContent()
        {
            base.LoadContent();



            song = content.Load<Song>("GangstersInSchool");
            Hit_Sound = content.Load<SoundEffect>("HitSound");
            ZombieDead_sound = content.Load<SoundEffect>("ZombieDeathSound");
            footstep_sound = content.Load<SoundEffect>("footStep");
            bip_sound = content.Load<SoundEffect>("bip");
            switch_sound = content.Load<SoundEffect>("switchSound");
            gun_sound = content.Load<SoundEffect>("gunSound2");
            chiken_sound = content.Load<SoundEffect>("chiken");
            miss_sound = content.Load<SoundEffect>("miss");

            MediaPlayer.Volume = 0.5f;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);
            XmlManager<Player> playerLoader = new XmlManager<Player>();
            XmlManager<Cenarios> pressMLoader = new XmlManager<Cenarios>();
           
            XmlManager<Prof> profLoader = new XmlManager<Prof>();
            XmlManager<ZombieSurvival> zombieLoader = new XmlManager<ZombieSurvival>();
            XmlManager<Cenarios> CenariosLoader = new XmlManager<Cenarios>();
            XmlManager<ControlsInfo> controlsLoader = new XmlManager<ControlsInfo>();
            XmlManager<HealthManager> HealthLoader = new XmlManager<HealthManager>();
            XmlManager<DeadScreen> DeathScreenLoader = new XmlManager<DeadScreen>();
            // XmlManager<Map> mapLoader = new XmlManager<Map>();
            prof = profLoader.Load("Content/Load/Prof.xml");
            Player = playerLoader.Load("Content/Load/Player.xml");
            Cenario = CenariosLoader.Load("Content/Load/Cenarios.xml");
           
            pressMWarning = pressMLoader.Load("Content/Load/pressMcontrols.xml");
            controls = controlsLoader.Load("Content/Load/ControlsInfo.xml");
            DeadScreen = DeathScreenLoader.Load("Content/Load/DeadScreen.xml");
            //map = mapLoader.Load("Content/Load/Map1.xml");

            //   if(ListaZombies1.Count == 0)
            //   ListaZombies1 = new List<Zombie>();


            while (ListaZombies1.Count < 4)
            {
                i = opcaozombie.Next(1, 6);
                o = SpeedReducer.Next(2, 7);
                Zombies = zombieLoader.Load("Content/Load/ZombieSurvival.xml");
                Zombies.LoadContent(i, o);
                ListaZombies1.Add(Zombies);
            }

           


            Player.LoadContent();
            for (int j = 0; j < healthbars.Length; j++)
            {
                healthbar = HealthLoader.Load("Content/Load/HealthSprite.xml");
                healthbar.LoadContent(j, Player);
                healthbars[j] = healthbar;
            }





            Cenario.LoadContent();
            prof.LoadContent(10);
            pressMWarning.LoadContent();
            controls.LoadContent();

            DeadScreen.LoadContent();
            DeadScreen.Image.Alpha = 0.0f;
            //map.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();

            foreach (ZombieSurvival z in ListaZombies1)
            {
                z.UnloadContent();
            }



            for (int j = 0; j < healthbars.Length; j++)
            {

                healthbars[j].UnloadContent();
            }
            prof.UnloadContent();
            Player.UnloadContent();

            Cenario.UnloadContent();

            controls.UnloadContent();
            pressMWarning.UnloadContent();
            DeadScreen.UnloadContent();
        }

        float spawn = 0;

        public override void Update(GameTime gameTime)
        {

            spawn += (float)gameTime.ElapsedGameTime.TotalSeconds;

            
 

            if (Player.isDead == true)
            {
                MediaPlayer.Volume = 0.0f;
                Player.Image.Alpha = 0.0f;
                DeadScreen.Image.Alpha = 1.0f;
            }

            //  if (ListaZombies1.Count == 0)
            //  ListaZombies1.
            //  if (ListaZombies1.Count() < 2)
            //     ListaZombies1.Add(Zombies);

            //     if (ListaZombies1.Count == 0)
            //        ListaZombies1 = new List<Zombie>();


            if (opcaopersonagem == 12)
            {
                if (InputManager.Instance.KeyPressed(Keys.Space))
                    gun_sound.Play(0.3f, 0, 0);
            }

            if (opcaopersonagem == 18)
            {
                if (InputManager.Instance.KeyPressed(Keys.Space))
                    chiken_sound.Play(0.3f, 0, 0);
            }




            if (InputManager.Instance.KeyPressed(Keys.M))
                bip_sound.Play(1.0f, 0, 1);

            if (InputManager.Instance.KeyPressed(Keys.D1))
            {

                if (opcaopersonagem != 0)
                {
                    switch_sound.Play(0.1f, 0, 0);
                    opcaopersonagem = 0;
                }

            }
            else if (InputManager.Instance.KeyPressed(Keys.D2))
            {
                if (opcaopersonagem != 6)
                {
                    switch_sound.Play(0.1f, 0, 0);
                    opcaopersonagem = 6;
                }

            }
            else if (InputManager.Instance.KeyPressed(Keys.D3))
            {
                if (opcaopersonagem != 12)
                {
                    switch_sound.Play(0.1f, 0, 0);
                    opcaopersonagem = 12;
                }
            }
            else if (InputManager.Instance.KeyPressed(Keys.D4))
            {
                if (opcaopersonagem != 18)
                {
                    switch_sound.Play(0.1f, 0, 0);
                    opcaopersonagem = 18;
                }
            }
            /*
            if(ListaZombies.Count < 5)
            {
                i = opcaozombie.Next(1, 6);
                o = SpeedReducer.Next(2,7);
                Zombie.LoadContent(i, o);
                Zombie.isDead = false;
                ListaZombies.Add(Zombie);
            }
            */
            //Player.Rectangle.Intersects(enemy.Rectangle);


            for (int i = 0; i < ListaZombies1.Count; i++)
                {
                    if (Player.Image.Position.X - ListaZombies1[i].Image.Position.X < 150 && Player.Image.Position.X - ListaZombies1[i].Image.Position.X > -150)
                    {
                        if (Player.isAttacking == true)
                        {
                            if (gameTime.TotalGameTime.TotalMilliseconds > GameplayScreen.attackTimer2 + GameplayScreen.attackCooldown2)
                            {
                                GameplayScreen.attackTimer2 = (float)gameTime.TotalGameTime.TotalMilliseconds;
                                ListaZombies1[i].Health = AttackZombie(ListaZombies1[i], ref Player);
                                Hit_Sound.Play(0.3f, 0, 1);


                            }
                        }

                    }
                }
        


            //-------------------------------------------------------------


                for (int i = 0; i < ListaZombies1.Count; i++)
                {
                    if (Player.Image.Position.X - ListaZombies1[i].Image.Position.X < 76 && Player.Image.Position.X - ListaZombies1[i].Image.Position.X > -76)
                    {

                        if (gameTime.TotalGameTime.TotalMilliseconds > GameplayScreen.attackTimer1 + GameplayScreen.attackCooldown1)
                        {
                            GameplayScreen.attackTimer1 = (float)gameTime.TotalGameTime.TotalMilliseconds;

                            {
                                Player = AttackPlayer(ListaZombies1[i], ref Player);
                            }
                        }


                    }

                }
   




            if (Player.Image.Position.X <= -30 && Player.Image.Position.X >= -39)
            {
                Player.Image.Position.X += 5;

            }

            if (Player.Image.Position.X <= -40)
            {
                Player.Image.Position.X += 5;

            }


                for (int i = 0; i < ListaZombies1.Count; i++)
                {
                    if (ListaZombies1[i].isDead == true)
                    {
                        ListaZombies1.Remove(ListaZombies1[i]);
                        ZombieDead_sound.Play(1.0f, 0, 0);

                   
                    }
                }
    
 




            Player.Update(gameTime);

            foreach (ZombieSurvival z in ListaZombies1)
            {
                z.Update(gameTime, ref Player.Image);
            }

            Cenario.Update(gameTime);
            for (int j = 0; j < healthbars.Length; j++)
            {
                healthbars[j].Update(gameTime, Player, j);
            }
            prof.Update(gameTime, ref Player.Image);
            // prof.Update(gameTime);
            controls.Update(gameTime);
            pressMWarning.Update(gameTime);
            DeadScreen.Update(gameTime);

            if (ListaZombies1.Count == 0)
            {
            
                //chiken_sound.Play();
                // stage = 1;
                // List<Zombie> ListaZombies1 = new List<Zombie>();
                // ScreenManager.Instance.ChangeScreens("TitleScreen");

            }

            base.Update(gameTime);
        }
        public void LoadEnemies()
        {
                if (ListaZombies1.Count() < 2)
                    ListaZombies1.Add(Zombies);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Cenario.Draw(spriteBatch);
            if (stage == 1)
            {
                for (i = 0; i < ListaZombies1.Count; i++)
                    ListaZombies1[i].Draw(spriteBatch);

            }

            Player.Draw(spriteBatch);
            for (int j = 0; j < healthbars.Length; j++)
            {

                healthbars[j].Draw(spriteBatch);
            }

            controls.Draw(spriteBatch);
            pressMWarning.Draw(spriteBatch);
            prof.Draw(spriteBatch);
            DeadScreen.Draw(spriteBatch);


        }

    }
}
