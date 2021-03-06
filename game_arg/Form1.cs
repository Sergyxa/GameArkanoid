﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace game_arg
{
    public partial class Form1 : Form
    {
        MapController map = new MapController();
        Player player = new Player();
        Physics physics = new Physics();
        public Label score;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            InitializeComponent();
            score = new Label();
            score.Location = new Point((MapController.mapWidth + 1) * 20, 50);
            score.Text = "Счёт:" + player._score;
            this.Controls.Add(score);
            timer1.Tick += new EventHandler(update);
            this.KeyDown += new KeyEventHandler(inputCheck);
            Initialization();
        }
        private void inputCheck(object sender, KeyEventArgs e)
        {
            map.map[player.platformY, player.platformX] = 0;
            map.map[player.platformY, player.platformX + 1] = 0;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (player.platformX + 1 < MapController.mapWidth - 1)
                        player.platformX++;
                    break;
                case Keys.Left:
                    if (player.platformX > 0)
                        player.platformX--;
                    break;
            }
            map.map[player.platformY, player.platformX] = 9;
            map.map[player.platformY, player.platformX + 1] = 99;

        }
        public void GeneratePlatforms()
        {
            Random random = new Random();
            for (int i = 0; i < MapController.mapHeight / 3; i++)
            {
                for (int j = 0; j < MapController.mapWidth; j += 2)
                {
                    int currPlatform = random.Next(1, 5);
                    map.map[i, j] = currPlatform;
                    map.map[i, j + 1] = currPlatform + currPlatform * 10;
                }
            }
        }

        private void update(object sender, EventArgs e)
        {
            if (player.ballY + player.dirY > MapController.mapHeight - 1)
            {
                Initialization();
            }

            map.map[player.ballY, player.ballX] = 0;
            if (!physics.IsCollide(player, map, player.dirX, player.dirY, player.ballX, player.ballY, score))
            {
                player.ballX += player.dirX;
            }
            if (!physics.IsCollide(player, map, player.dirX, player.dirY, player.ballX, player.ballY, score))
            {
                player.ballY += player.dirY;
            }
            map.map[player.ballY, player.ballX] = 8;
            map.map[player.platformY, player.platformX] = 9;
            map.map[player.platformY, player.platformX + 1] = 99;
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            map.DrawMap(e.Graphics);
            map.DrawArea(e.Graphics);
        }

        public void Initialization()
        {
            
            this.Width = (MapController.mapWidth + 6) * 20;
            this.Height = (MapController.mapHeight + 2) * 20;
            timer1.Interval = 50;
            player._score = 0;
            score.Text = "Счёт:" + player._score;
            for (int i = 0; i < MapController.mapHeight; i++)
            {
                for (int j = 0; j < MapController.mapWidth; j++)
                {
                    map.map[i, j] = 0;
                }
            }

            player.platformX = (MapController.mapWidth - 1) / 2;
            player.platformY = MapController.mapHeight - 1;

            map.map[player.platformY, player.platformX] = 9;
            map.map[player.platformY, player.platformX + 1] = 99;

            player.ballX = player.platformX + 1;
            player.ballY = player.platformY - 1;
            map.map[player.ballY, player.ballX] = 8;

            player.dirX = 1;
            player.dirY = -1;
            GeneratePlatforms();
            timer1.Start();
        }
    }
}
