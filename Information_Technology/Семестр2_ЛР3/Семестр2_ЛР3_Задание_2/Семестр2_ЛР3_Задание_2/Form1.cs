using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; // Для OrderBy
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D; // Для LinearGradientBrush

namespace Семестр2_ЛР3_Задание_2
{
    public partial class FormCardsTable : Form
    {
        private List<Card> tableCards = new List<Card>();
        private Stack<Image> deck = new Stack<Image>();
        private Image backImage;

        private Card draggingCard = null;
        private Point dragOffset;
        private Random random = new Random();

        public FormCardsTable()
        {
            InitializeComponent();

            LoadCards();
        }

        private void LoadCards()
        {
            var files = Directory.GetFiles("cards", "*.png");

            foreach (var file in files)
            {
                var img = Image.FromFile(file);
                var resizedImg = ResizeImage(img, 140, 210); // Уменьшаем размер

                if (Path.GetFileName(file).ToLower() == "back.png")
                {
                    backImage = resizedImg;
                    continue;
                }

                deck.Push(resizedImg);
            }

            ShuffleDeck();
        }

        // Метод для изменения размера изображения
        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return bmp;
        }


        private void ShuffleDeck()
        {
            var shuffledList = deck.ToList().OrderBy(x => random.Next()).ToList();
            deck = new Stack<Image>(shuffledList);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void DrawCard(Graphics g, Card card, bool isDragging = false)
        {
            g.TranslateTransform(card.Position.X, card.Position.Y);
            g.RotateTransform(card.Rotation);

            var image = card.Image;
            g.DrawImage(image, -image.Width / 2, -image.Height / 2, image.Width, image.Height);

            g.ResetTransform();
        }

        private void FormCardsTable_MouseDown(object sender, MouseEventArgs e)
        {
            if (deck.Count > 0 && new Rectangle(50, 50, backImage.Width, backImage.Height).Contains(e.Location))
            {
                var cardImage = deck.Pop();

                draggingCard = new Card
                {
                    Image = cardImage,
                    Position = e.Location,
                    Rotation = 0
                };

                dragOffset = new Point(cardImage.Width / 2, cardImage.Height / 2);
            }

            Invalidate();
        }

        private void FormCardsTable_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggingCard != null)
            {
                draggingCard.Position = e.Location;
                Invalidate();
            }
        }

        private void FormCardsTable_MouseUp(object sender, MouseEventArgs e)
        {
            if (draggingCard != null)
            {
                draggingCard.Position = e.Location;
                draggingCard.Rotation = random.Next(-20, 20);
                tableCards.Add(draggingCard);
                draggingCard = null;
                Invalidate();
            }
        }

        private void FormCardsTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                foreach (var card in tableCards)
                {
                    deck.Push(card.Image);
                }

                tableCards.Clear();
                ShuffleDeck();
                Invalidate();
            }
        }

        private void FormCardsTable_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Градиентный фон
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                Color.DarkGreen, Color.LightGreen, LinearGradientMode.ForwardDiagonal))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }

            // Отрисовка карт на столе
            foreach (var card in tableCards)
            {
                DrawCard(g, card);
            }

            // Колода
            if (deck.Count > 0)
            {
                g.DrawImage(backImage, 50, 50, backImage.Width, backImage.Height);
            }

            // Перетаскиваемая карта
            if (draggingCard != null)
            {
                DrawCard(g, draggingCard, true);
            }
        }

        private void FormCardsTable_Resize(object sender, EventArgs e)
        {
            this.Invalidate(); // Отрисовываем форму снова. Это нужно для градиентного заднего фона
        }
    }

    public class Card
    {
        public Image Image;
        public PointF Position;
        public float Rotation;
    }
}
