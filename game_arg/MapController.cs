using System;
using System.Drawing;

namespace game_arg
{
    public class MapController
    {
        public Image grafic;
        public const int mapHeight = 30;
        public const int mapWidth = 20;
        public int[,] map = new int[mapHeight, mapWidth];
        public int currPlatform;

        public MapController(){
        }
        public void AddLine()
        {
            for (int i = mapHeight - 2; i > 0; i--)
            {
                for (int j = 0; j < mapWidth; j += 2)
                {
                    map[i, j] = map[i - 1, j];
                }
            }
            Random random = new Random();
            for (int j = 0; j < mapWidth; j += 2)
            {
                currPlatform = random.Next(1, 5);
                map[0, j] = currPlatform;
                map[0, j + 1] = currPlatform + currPlatform * 10;
            }
        }
        public void DrawArea(Graphics g)
        {
            g.DrawRectangle(Pens.Black, new Rectangle(0, 0, mapWidth * 20, mapHeight * 20));
        }
        public void DrawMap(Graphics g)
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (map[i, j] == 9)
                    {

                        g.DrawImage(grafic, new Rectangle(new Point(j * 20, i * 20), new Size(60, 20)), 398, 17, 150, 50, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 8)
                    {

                        g.DrawImage(grafic, new Rectangle(new Point(j * 20, i * 20), new Size(20, 20)), 806, 548, 73, 73, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 1)
                    {

                        g.DrawImage(grafic, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16 + 77 * (map[i, j] - 1), 170, 59, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 2)
                    {

                        g.DrawImage(grafic, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16 + 77 * (map[i, j] - 1), 170, 59, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 3)
                    {

                        g.DrawImage(grafic, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16 + 77 * (map[i, j] - 1), 170, 59, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 4)
                    {

                        g.DrawImage(grafic, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16 + 77 * (map[i, j] - 1), 170, 59, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 5)
                    {

                        g.DrawImage(grafic, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16 + 77 * (map[i, j] - 1), 170, 59, GraphicsUnit.Pixel);
                    }

                }
            }
        }
    }
}
