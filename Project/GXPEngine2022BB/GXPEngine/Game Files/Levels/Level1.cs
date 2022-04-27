using System;
using GXPEngine;

namespace GXPEngine
{
    public class Level1 : Sprite
    {
        MyGame myGame = MyGame.current;

        LevelManager levelManager;
        readonly Inventory inventory;

        readonly Player player;

        public Level1(LevelManager pLevelManager, Inventory pInventory) : base("colors.png", false, false)
        {
            levelManager = pLevelManager;
            inventory = pInventory;

            player = new Player(200, 200);
            LateAddChild(player);
        }

        void Update()
        {
            
        }
    }
}