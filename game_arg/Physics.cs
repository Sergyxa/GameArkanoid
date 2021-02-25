using System.Windows.Forms;

namespace game_arg
{
    class Physics
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
                if (map.map[ballY + dirY, ballX] > 10 && map.map[ballY + dirY, ballX] < 99)
                {
                    map.map[ballY + dirY, ballX] = 0;
                    map.map[ballY + dirY, ballX - 1] = 0;
                }
                else if (map.map[ballY + dirY, ballX] < 9)
                {
                    map.map[ballY + dirY, ballX] = 0;
                    map.map[ballY + dirY, ballX + 1] = 0;
                }
                player._score += 50;
                player.dirY *= -1;
                isColliding = true;
            }
            else if (map.map[ballY, ballX + dirX] != 0)
            { 
                if (map.map[ballY, ballX + dirX] > 10 && map.map[ballY, ballX + dirX] < 99)
                {
                    map.map[ballY, ballX + dirX] = 0;
                    map.map[ballY, ballX + dirX - 1] = 0;
                }
                else if (map.map[ballY, ballX + dirX] < 9)
                {
                    map.map[ballY, ballX + dirX] = 0;
                    map.map[ballY, ballX + dirX + 1] = 0;
                }
                player._score += 50;
                player.dirX *= -1;
                isColliding = true;
            }
            score.Text = "Счёт:" + player._score;
            return isColliding;
        }
    }
}
