using System;
using System.Drawing;

namespace Game.Entities
{
    public static class Entity
    {
        public int posX;
        public int posY;
        public int idleFrames; // кадры для анимации простоя
        public int runFrames;
        public int attackFrames;
        public int deathFrames;
        public Image spriteSheet;

        public Entity(int posX,int posY, int idleFrames, int runFrames, int attackFrames, int deathFrames, Image spriteSheet)
        {
            this.posX = posX;
            this.posY = posY;
            this.idleFrames = idleFrames; 
            this.runFrames = runFrames;
            this.attackFrames = attackFrames;
            this.deathFrames = deathFrames;

    }
    }
}
