using System.Windows.Forms;

namespace game_arg
{
    public class Physics
    {
        public bool IsCollide(Player player, MapController map, int dirX, int dirY, int ballX, int ballY, Label score)
        {
            bool isColliding = false;
            if (player.ballX + dirX > MapController.mapWidth - 1 || ballX + dirX < 0)
            {
                player.dirX *= -1;
                isColliding = true;
            }
            else if (player.ballY + dirY < 0)
            {
                player.dirY *= -1;
                isColliding = true;
            }
            else if (map.map[ballY + dirY, ballX] != 0)
            {
                bool addScore = false;
                if (map.map[ballY + dirY, ballX] > 10 && map.map[ballY + dirY, ballX] < 99)
                {
                    map.map[ballY + dirY, ballX] = 0;
                    map.map[ballY + dirY, ballX - 1] = 0;
                    addScore = true;
                }
                else if (map.map[ballY + dirY, ballX] < 9)
                {
                    map.map[ballY + dirY, ballX] = 0;
                    map.map[ballY + dirY, ballX + 1] = 0;
                    addScore = true;
                }
                if (addScore)
                {
                    player._score += 50;
                    if (player._score % 200 == 0 && player._score > 0)
                    {
                        map.AddLine();
                    }
                }
                player.dirY *= -1;
                isColliding = true;
            }
            else if (map.map[ballY, ballX + dirX] != 0)
            {
                bool addScore = false;
                if (map.map[ballY, ballX + dirX] > 10 && map.map[ballY, ballX + dirX] < 99)
                {
                    map.map[ballY, ballX + dirX] = 0;
                    map.map[ballY, ballX + dirX - 1] = 0;
                    addScore = true;
                }
                else if (map.map[ballY, ballX + dirX] < 9)
                {
                    map.map[ballY, ballX + dirX] = 0;
                    map.map[ballY, ballX + dirX + 1] = 0;
                    addScore = true;
                }
                if (addScore)
                {
                    player._score += 50;
                    if (player._score % 200 == 0 && player._score > 0)
                    {
                        map.AddLine();
                    }
                }
                player.dirX *= -1;
                isColliding = true;
            }
            
            return isColliding;
        }
    }
}
