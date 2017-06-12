using System;
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
    public class GameplayScreen : GameScreen
    {

        Player Player;
        Cenarios Cenario;
        Cenarios pressMWarning;
        Cenarios StageClear;
        Zombie Zombie;
       Prof prof;
        ControlsInfo controls;
        DeadScreen DeadScreen;

        List<Zombie> ListaZombies1 = new List<Zombie>();
        List<Zombie> ListaZombies2 = new List<Zombie>();
        List<Zombie> ListaZombies3 = new List<Zombie>();
        List<Zombie> ListaZombies4 = new List<Zombie>();
        List<Zombie> ListaZombies5 = new List<Zombie>();
        List<Zombie> ListaZombies6 = new List<Zombie>();
        HealthManager healthbar;
        HealthManager[] healthbars = new HealthManager[4];

        Random opcaozombie = new Random();
        Random SpeedReducer = new Random();
        Random miss = new Random();

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

        public int AttackZombie(Zombie z, ref Player Player)
        {
            z.Health -= Player.Attack;
            
            return z.Health;
        }

        public Player AttackPlayer(Zombie z, ref Player Player)
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
            XmlManager<Cenarios> stageClearLoader = new XmlManager<Cenarios>();
            XmlManager<Zombie> zombieLoader = new XmlManager<Zombie>();
            XmlManager<Cenarios> CenariosLoader = new XmlManager<Cenarios>();
            XmlManager<ControlsInfo> controlsLoader = new XmlManager<ControlsInfo>();
            XmlManager<HealthManager> HealthLoader = new XmlManager<HealthManager>();
            XmlManager<DeadScreen> DeathScreenLoader = new XmlManager<DeadScreen>();
            // XmlManager<Map> mapLoader = new XmlManager<Map>();
              prof = profLoader.Load("Content/Load/Prof.xml");
            Player = playerLoader.Load("Content/Load/Player.xml");
            StageClear = stageClearLoader.Load("Content/Load/StageClear.xml");

            Cenario = CenariosLoader.Load("Content/Load/Cenarios.xml");
            pressMWarning = pressMLoader.Load("Content/Load/pressMcontrols.xml");
            controls = controlsLoader.Load("Content/Load/ControlsInfo.xml");
            DeadScreen = DeathScreenLoader.Load("Content/Load/DeadScreen.xml");
            //map = mapLoader.Load("Content/Load/Map1.xml");

            while (ListaZombies1.Count < 3)
            {
                i = opcaozombie.Next(1, 6);
                o = SpeedReducer.Next(2, 7);
                Zombie = zombieLoader.Load("Content/Load/Zombie.xml");
                Zombie.LoadContent(i, o);
                ListaZombies1.Add(Zombie);
            }

            while (ListaZombies2.Count < 4)
            {
                i = opcaozombie.Next(1, 6);
                o = SpeedReducer.Next(2, 7);
                Zombie = zombieLoader.Load("Content/Load/Zombie.xml");
                Zombie.LoadContent(i, o);
                ListaZombies2.Add(Zombie);
            }

            while (ListaZombies3.Count < 4)
            {
                i = opcaozombie.Next(1, 6);
                o = SpeedReducer.Next(2, 7);
                Zombie = zombieLoader.Load("Content/Load/Zombie.xml");
                Zombie.LoadContent(i, o);
                ListaZombies3.Add(Zombie);
            }
            while (ListaZombies4.Count < 5)
            {
                i = opcaozombie.Next(1, 6);
                o = SpeedReducer.Next(2, 7);
                Zombie = zombieLoader.Load("Content/Load/Zombie.xml");
                Zombie.LoadContent(i, o);
                ListaZombies4.Add(Zombie);
            }
            while (ListaZombies5.Count < 5)
            {
                i = opcaozombie.Next(1, 6);
                o = SpeedReducer.Next(2, 7);
                Zombie = zombieLoader.Load("Content/Load/Zombie.xml");
                Zombie.LoadContent(i, o);
                ListaZombies5.Add(Zombie);
            }
            while (ListaZombies6.Count < 5)
            {
                i = opcaozombie.Next(1, 6);
                o = SpeedReducer.Next(2, 7);
                Zombie = zombieLoader.Load("Content/Load/Zombie.xml");
                Zombie.LoadContent(i, o);
                ListaZombies6.Add(Zombie);
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
            StageClear.LoadContent();
            StageClear.Image.Alpha = 0.0f;
            DeadScreen.LoadContent();
            DeadScreen.Image.Alpha = 0.0f;
            //map.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            
            foreach (Zombie z in ListaZombies1)
            {
                z.UnloadContent();
            }
            foreach (Zombie z in ListaZombies2)
            {
                z.UnloadContent();
            }
            foreach (Zombie z in ListaZombies3)
            {
                z.UnloadContent();
            }
            foreach (Zombie z in ListaZombies4)
            {
                z.UnloadContent();
            }
            foreach (Zombie z in ListaZombies5)
            {
                z.UnloadContent();
            }
            foreach (Zombie z in ListaZombies6)
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
       
        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);

            if (Player.isDead == true)
            {
                MediaPlayer.Volume = 0.0f;
                Player.Image.Alpha = 0.0f;
                DeadScreen.Image.Alpha = 1.0f;
            }


            if (stage == 2)
                prof.Image.Alpha = 0.0f;

            //-----------warning STAGE CLEAR update-----------


            if (stage == 1)
            {
                if (ListaZombies1.Count == 0)
                    StageClear.Image.Alpha = 1.0f;
               else
                    StageClear.Image.Alpha = 0.0f;
            }
            if (stage == 2)
            {
                if (ListaZombies2.Count == 0)
                    StageClear.Image.Alpha = 1.0f;
                else
                    StageClear.Image.Alpha = 0.0f;
            }
            if (stage == 3)
            {
                if (ListaZombies3.Count == 0)
                    StageClear.Image.Alpha = 1.0f;
                else
                    StageClear.Image.Alpha = 0.0f;
            }
            if (stage == 4)
            {
                if (ListaZombies4.Count == 0)
                    StageClear.Image.Alpha = 1.0f;
                else
                    StageClear.Image.Alpha = 0.0f;
            }
            if (stage == 5)
            {
                if (ListaZombies5.Count == 0)
                    StageClear.Image.Alpha = 1.0f;
                else
                    StageClear.Image.Alpha = 0.0f;
            }
            if (stage == 6)
            {
                if (ListaZombies6.Count == 0)
                    StageClear.Image.Alpha = 1.0f;
                else
                    StageClear.Image.Alpha = 0.0f;
            }



            //-------------------------------------------------



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
            if(stage == 1)
            {
                for (int i = 0; i < ListaZombies1.Count; i++)
                {
                    if (Player.Image.Position.X - ListaZombies1[i].Image.Position.X < 100 && Player.Image.Position.X - ListaZombies1[i].Image.Position.X > -100)
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
            }else if (stage == 2)
            {
                for (int i = 0; i < ListaZombies2.Count; i++)
                {
                    if (Player.Image.Position.X - ListaZombies2[i].Image.Position.X < 150 && Player.Image.Position.X - ListaZombies2[i].Image.Position.X > -150)
                    {
                        if (Player.isAttacking == true)
                        {
                            if (gameTime.TotalGameTime.TotalMilliseconds > GameplayScreen.attackTimer2 + GameplayScreen.attackCooldown2)
                            {
                                GameplayScreen.attackTimer2 = (float)gameTime.TotalGameTime.TotalMilliseconds;
                                ListaZombies2[i].Health = AttackZombie(ListaZombies2[i], ref Player);
                                Hit_Sound.Play(0.3f, 0, 1);
                            }
                        }

                    }
                }
            }else if(stage == 3)
            {
                for (int i = 0; i < ListaZombies3.Count; i++)
                {
                    if (Player.Image.Position.X - ListaZombies3[i].Image.Position.X < 100 && Player.Image.Position.X - ListaZombies3[i].Image.Position.X > -100)
                    {
                        if (Player.isAttacking == true)
                        {
                            if (gameTime.TotalGameTime.TotalMilliseconds > GameplayScreen.attackTimer2 + GameplayScreen.attackCooldown2)
                            {
                                GameplayScreen.attackTimer2 = (float)gameTime.TotalGameTime.TotalMilliseconds;
                                ListaZombies3[i].Health = AttackZombie(ListaZombies3[i], ref Player);
                                Hit_Sound.Play(0.3f, 0, 1);
                            }
                        }

                    }
                }
            }
            else if (stage == 4)
            {
                for (int i = 0; i < ListaZombies4.Count; i++)
                {
                    if (Player.Image.Position.X - ListaZombies4[i].Image.Position.X < 100 && Player.Image.Position.X - ListaZombies4[i].Image.Position.X > -100)
                    {
                        if (Player.isAttacking == true)
                        {
                            if (gameTime.TotalGameTime.TotalMilliseconds > GameplayScreen.attackTimer2 + GameplayScreen.attackCooldown2)
                            {
                                GameplayScreen.attackTimer2 = (float)gameTime.TotalGameTime.TotalMilliseconds;
                                ListaZombies4[i].Health = AttackZombie(ListaZombies4[i], ref Player);
                                Hit_Sound.Play(0.3f, 0, 1);
                            }
                        }

                    }
                }
            }
            else if (stage == 5)
            {
                for (int i = 0; i < ListaZombies5.Count; i++)
                {
                    if (Player.Image.Position.X - ListaZombies5[i].Image.Position.X < 100 && Player.Image.Position.X - ListaZombies5[i].Image.Position.X > -100)
                    {
                        if (Player.isAttacking == true)
                        {
                            if (gameTime.TotalGameTime.TotalMilliseconds > GameplayScreen.attackTimer2 + GameplayScreen.attackCooldown2)
                            {
                                GameplayScreen.attackTimer2 = (float)gameTime.TotalGameTime.TotalMilliseconds;
                                ListaZombies5[i].Health = AttackZombie(ListaZombies5[i], ref Player);
                                Hit_Sound.Play(0.3f, 0, 1);
                            }
                        }

                    }
                }
            }
            else if (stage == 6)
            {
                for (int i = 0; i < ListaZombies6.Count; i++)
                {
                    if (Player.Image.Position.X - ListaZombies6[i].Image.Position.X < 100 && Player.Image.Position.X - ListaZombies6[i].Image.Position.X > -100)
                    {
                        if (Player.isAttacking == true)
                        {
                            if (gameTime.TotalGameTime.TotalMilliseconds > GameplayScreen.attackTimer2 + GameplayScreen.attackCooldown2)
                            {
                                GameplayScreen.attackTimer2 = (float)gameTime.TotalGameTime.TotalMilliseconds;
                                ListaZombies6[i].Health = AttackZombie(ListaZombies6[i], ref Player);
                                Hit_Sound.Play(0.3f, 0, 1);
                            }
                        }

                    }
                }
            }

//-------------------------------------------------------------
            if (stage == 1)
            {
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
            }else if(stage == 2)
            {
                for (int i = 0; i < ListaZombies2.Count; i++)
                {
                    if (Player.Image.Position.X - ListaZombies2[i].Image.Position.X < 76 && Player.Image.Position.X - ListaZombies2[i].Image.Position.X > -76)
                    {

                        if (gameTime.TotalGameTime.TotalMilliseconds > GameplayScreen.attackTimer1 + GameplayScreen.attackCooldown1)
                        {
                            GameplayScreen.attackTimer1 = (float)gameTime.TotalGameTime.TotalMilliseconds;
                            Player = AttackPlayer(ListaZombies2[i], ref Player);
                        }


                    }

                }
            }else if(stage == 3)
            {
                for (int i = 0; i < ListaZombies3.Count; i++)
                {
                    if (Player.Image.Position.X - ListaZombies3[i].Image.Position.X < 76 && Player.Image.Position.X - ListaZombies3[i].Image.Position.X > -76)
                    {

                        if (gameTime.TotalGameTime.TotalMilliseconds > GameplayScreen.attackTimer1 + GameplayScreen.attackCooldown1)
                        {
                            GameplayScreen.attackTimer1 = (float)gameTime.TotalGameTime.TotalMilliseconds;
                            Player = AttackPlayer(ListaZombies3[i], ref Player);
                        }


                    }

                }
            }
            else if (stage == 4)
            {
                for (int i = 0; i < ListaZombies4.Count; i++)
                {
                    if (Player.Image.Position.X - ListaZombies4[i].Image.Position.X < 76 && Player.Image.Position.X - ListaZombies4[i].Image.Position.X > -76)
                    {

                        if (gameTime.TotalGameTime.TotalMilliseconds > GameplayScreen.attackTimer1 + GameplayScreen.attackCooldown1)
                        {
                            GameplayScreen.attackTimer1 = (float)gameTime.TotalGameTime.TotalMilliseconds;
                            Player = AttackPlayer(ListaZombies4[i], ref Player);
                        }


                    }

                }
            }


            else if (stage == 5)
            {
                for (int i = 0; i < ListaZombies5.Count; i++)
                {
                    if (Player.Image.Position.X - ListaZombies5[i].Image.Position.X < 76 && Player.Image.Position.X - ListaZombies5[i].Image.Position.X > -76)
                    {

                        if (gameTime.TotalGameTime.TotalMilliseconds > GameplayScreen.attackTimer1 + GameplayScreen.attackCooldown1)
                        {
                            GameplayScreen.attackTimer1 = (float)gameTime.TotalGameTime.TotalMilliseconds;
                            Player = AttackPlayer(ListaZombies5[i], ref Player);
                        }


                    }

                }
            }

            else if (stage == 6)
            {
                for (int i = 0; i < ListaZombies6.Count; i++)
                {
                    if (Player.Image.Position.X - ListaZombies6[i].Image.Position.X < 76 && Player.Image.Position.X - ListaZombies6[i].Image.Position.X > -76)
                    {

                        if (gameTime.TotalGameTime.TotalMilliseconds > GameplayScreen.attackTimer1 + GameplayScreen.attackCooldown1)
                        {
                            GameplayScreen.attackTimer1 = (float)gameTime.TotalGameTime.TotalMilliseconds;
                            Player = AttackPlayer(ListaZombies6[i], ref Player);
                        }


                    }

                }
            }
            if (Cenario.Image.Position.X == 0)
            {
                if (ListaZombies1.Count == 0)
                {
                    if (Player.Image.Position.X >= 795 && Player.IsLookingRight)
                    {

                        Cenario.Image.Position.X -= 50;

                        Player.Image.Position.X += 20;
                        

                        if (Cenario.Image.Position.X <= -900) ;
                        {
                            Cenario.Image.Position.X = -900;
                            Player.Image.Position.X = -40;
                            stage = 2;
                    }
                    
                    }
                }
            }

            if (Cenario.Image.Position.X == -900)
            {
                if(ListaZombies2.Count == 0)
                {
                    if (Player.Image.Position.X >= 795 && Player.IsLookingRight)
                    {

                        Cenario.Image.Position.X -= 50;

                        Player.Image.Position.X += 20;

                        
                            if (Cenario.Image.Position.X <= -1800) ;
                        {
                            Cenario.Image.Position.X = -1800;
                            Player.Image.Position.X = -35;
                            stage = 3;
                        }
                    }
                    
                }
                
            }
            if (Cenario.Image.Position.X == -1800)
            {
                if (ListaZombies3.Count == 0)
                {
                    if (Player.Image.Position.X >= 795 && Player.IsLookingRight)
                    {

                        Cenario.Image.Position.X -= 50;

                        Player.Image.Position.X += 20;


                        if (Cenario.Image.Position.X <= -2700) ;
                        {
                            Cenario.Image.Position.X = -2700;
                            Player.Image.Position.X = -30;
                            stage = 4;
                        }
                    }

                }

            }
            if (Cenario.Image.Position.X == -2700)
            {
                if (ListaZombies4.Count == 0)
                {
                    if (Player.Image.Position.X >= 795 && Player.IsLookingRight)
                    {

                        Cenario.Image.Position.X -= 50;

                        Player.Image.Position.X += 20;


                        if (Cenario.Image.Position.X <= -3600) ;
                        {
                            Cenario.Image.Position.X = -3600;
                            Player.Image.Position.X = -25;
                            stage = 5;
                        }
                    }

                }

            }
            if (Cenario.Image.Position.X == -3600)
            {
                if (ListaZombies5.Count == 0)
                {
                    if (Player.Image.Position.X >= 795 && Player.IsLookingRight)
                    {

                        Cenario.Image.Position.X -= 50;

                        Player.Image.Position.X += 20;


                        if (Cenario.Image.Position.X <= -4500) ;
                        {
                            Cenario.Image.Position.X = -4500;
                            Player.Image.Position.X = -20;
                            stage = 6;
                        }
                    }

                }

            }

            if (Player.Image.Position.X <= -30 && Player.Image.Position.X  >= -39)
            {
                Player.Image.Position.X += 5;

            }

            if (Player.Image.Position.X <= -40)
            {
                Player.Image.Position.X += 5;

            }

            if(stage == 1)
            {
                for (int i = 0; i < ListaZombies1.Count; i++)
                {
                    if (ListaZombies1[i].isDead == true)
                    {
                        ListaZombies1.Remove(ListaZombies1[i]);
                        ZombieDead_sound.Play(1.0f, 0, 0);
                    }
                }
            }else if(stage == 2)
            {
                for (int i = 0; i < ListaZombies2.Count; i++)
                {
                    if (ListaZombies2[i].isDead == true)
                    {
                        ListaZombies2.Remove(ListaZombies2[i]);
                        ZombieDead_sound.Play(1.0f, 0, 0);
                    }
                }
            }
            else if (stage == 3)
            {
                for (int i = 0; i < ListaZombies3.Count; i++)
                {
                    if (ListaZombies3[i].isDead == true)
                    {
                        ListaZombies3.Remove(ListaZombies3[i]);
                        ZombieDead_sound.Play(1.0f, 0, 0);
                    }
                }
            }
            else if (stage == 4)
            {
                for (int i = 0; i < ListaZombies4.Count; i++)
                {
                    if (ListaZombies4[i].isDead == true)
                    {
                        ListaZombies4.Remove(ListaZombies4[i]);
                        ZombieDead_sound.Play(1.0f, 0, 0);
                    }
                }
            }
            else if (stage == 5)
            {
                for (int i = 0; i < ListaZombies5.Count; i++)
                {
                    if (ListaZombies5[i].isDead == true)
                    {
                        ListaZombies5.Remove(ListaZombies5[i]);
                        ZombieDead_sound.Play(1.0f, 0, 0);
                    }
                }
            }
            else if (stage == 6)
            {
                for (int i = 0; i < ListaZombies6.Count; i++)
                {
                    if (ListaZombies6[i].isDead == true)
                    {
                        ListaZombies6.Remove(ListaZombies6[i]);
                        ZombieDead_sound.Play(1.0f, 0, 0);
                    }
                }
            }





            Player.Update(gameTime);

            foreach (Zombie z in ListaZombies1)
            {
                z.Update(gameTime, ref Player.Image);
            }

            foreach (Zombie z in ListaZombies2)
            {
                z.Update(gameTime, ref Player.Image);
            }

            foreach (Zombie z in ListaZombies3)
            {
                z.Update(gameTime, ref Player.Image);
            }
            foreach (Zombie z in ListaZombies4)
            {
                z.Update(gameTime, ref Player.Image);
            }
            foreach (Zombie z in ListaZombies5)
            {
                z.Update(gameTime, ref Player.Image);
            }
            foreach (Zombie z in ListaZombies6)
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

            if (stage == 6 && ListaZombies6.Count == 0)
            {

                //chiken_sound.Play();
                stage = 1;
                ScreenManager.Instance.ChangeScreens("TitleScreen");
                
            }


        }





        public override void Draw(SpriteBatch spriteBatch)
        { 
            base.Draw(spriteBatch);
            Cenario.Draw(spriteBatch);
            if(stage == 1)
            {
                for (i = 0; i < ListaZombies1.Count; i++)
                {
                        ListaZombies1[i].Draw(spriteBatch);
                        
                }  
            }else if(stage == 2 )
            {
                    for (i = 0; i < ListaZombies2.Count; i++)
                    {
                        ListaZombies2[i].Draw(spriteBatch);
                        
                    }
                
            }
            else if(stage == 3)
            {
                
                    for (i = 0; i < ListaZombies3.Count; i++)
                    {
                        ListaZombies3[i].Draw(spriteBatch);
                    }
                
            }
            else if (stage == 4)
            {

                for (i = 0; i < ListaZombies4.Count; i++)
                {
                    ListaZombies4[i].Draw(spriteBatch);
                }

            }
            else if (stage == 5)
            {

                for (i = 0; i < ListaZombies5.Count; i++)
                {
                    ListaZombies5[i].Draw(spriteBatch);
                }

            }
            else if (stage == 6)
            {

                for (i = 0; i < ListaZombies6.Count; i++)
                {
                    ListaZombies6[i].Draw(spriteBatch);
                }

            }



            Player.Draw(spriteBatch);
            for (int j = 0; j < healthbars.Length; j++)
            {

                healthbars[j].Draw(spriteBatch);
            }
            
            controls.Draw(spriteBatch);
            pressMWarning.Draw(spriteBatch);
            prof.Draw(spriteBatch);
            StageClear.Draw(spriteBatch);
            DeadScreen.Draw(spriteBatch);
          

        }

    }
}
