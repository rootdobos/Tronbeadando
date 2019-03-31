using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tron
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer Clock;
        static int MainWidth = 1000;
        static int MainHeight = 800;
        static int speed = 50;
        Player Player1;
        Player Player2;
        int Size = 5;
        public MainWindow()
        {
            InitializeComponent();
            Clock = new DispatcherTimer();
            Player1 = new Player(MainWidth / 4, MainHeight / 2, "Green", "right");
            Player2 = new Player(MainWidth / 4 * 3, MainHeight / 2, "Red", "left");
            Clock.Interval = TimeSpan.FromMilliseconds(1000 / speed);
            Clock.Tick += Step;
          //  Clock.IsEnabled = true;
        }



        private void Make()
        {
            Rectangle maker = new Rectangle();
            Rectangle maker2 = new Rectangle();
            maker.Width = maker.Height = Size;
            maker.Fill = Brushes.Gold;
            Canvas.SetLeft(maker, Player1.MotorPos.X);
            Canvas.SetTop(maker, Player1.MotorPos.Y);
            cvArena.Children.Add(maker);
            maker2.Width = maker2.Height = Size;
            maker2.Fill = Brushes.Red;
            Canvas.SetLeft(maker2, Player2.MotorPos.X);
            Canvas.SetTop(maker2, Player2.MotorPos.Y);
            cvArena.Children.Add(maker2);
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                Clock.Start();
                lbStartInstruction.Visibility = Visibility.Hidden;
            }
            if (e.Key == Key.W && Player1.Direction != "down")
            { Player1.Direction = "up"; }
            else if (e.Key == Key.S && Player1.Direction != "up")
            { Player1.Direction = "down"; }
            else if (e.Key == Key.A && Player1.Direction != "right")
            { Player1.Direction = "left"; }
            else if (e.Key == Key.D && Player1.Direction != "left")
            { Player1.Direction = "right"; }
            else if (e.Key == Key.Up && Player2.Direction != "down")
            { Player2.Direction = "up"; }
            else if (e.Key == Key.Down && Player2.Direction != "up")
            { Player2.Direction = "down"; }
            else if (e.Key == Key.Left && Player2.Direction != "right")
            { Player2.Direction = "left"; }
            else if (e.Key == Key.Right && Player2.Direction != "left")
            { Player2.Direction = "right"; }
        }

        private void Step(object sender, EventArgs e)
        {
            if(Player1.Direction=="up")
            { Player1.MotorPos.Y -= Size;  }
                else if (Player1.Direction == "down")
            { Player1.MotorPos.Y += Size; }
            else if (Player1.Direction == "right")
            { Player1.MotorPos.X += Size;  }
            else if (Player1.Direction == "left")
            { Player1.MotorPos.X -= Size; }
            if (Player2.Direction == "up")
            { Player2.MotorPos.Y -= Size;  }
            else if (Player2.Direction == "down")
            { Player2.MotorPos.Y += Size;  }
            else if (Player2.Direction == "right")
            { Player2.MotorPos.X += Size;  }
            else if (Player2.Direction == "left")
            { Player2.MotorPos.X -= Size; }
            Position Help1 = new Position(Player1.MotorPos.X, Player1.MotorPos.Y);
            Position Help2 = new Position(Player2.MotorPos.X, Player2.MotorPos.Y);
            Player1.Line.Add(Help1);
           /* Help.X = Player2.MotorPos.X;
            Help.Y = Player2.MotorPos.Y;*/
            Player2.Line.Add(Help2);
            Make();
            
            CheckEnd();
            
        }

        private void CheckEnd()
        {
            
            if(Player1.MotorPos.X<0 || Player1.MotorPos.X>MainWidth||Player1.MotorPos.Y<0 || Player1.MotorPos.Y>MainHeight)
            {
                Clock.Stop();
                Endgame();
            }
            if (Player2.MotorPos.X < 0 || Player2.MotorPos.X > MainWidth || Player2.MotorPos.Y < 0 || Player2.MotorPos.Y > MainHeight)
            {
                Clock.Stop();
                Endgame();
            }
             for (int i =0; i < Player1.Line.Count()-1; i++)
              {
                  if (Player1.MotorPos.X == Player1.Line[i].X && Player1.MotorPos.Y == Player1.Line[i].Y)
                  {
                      Clock.Stop();
                      Endgame();
                 }
                  if (Player2.MotorPos.X == Player1.Line[i].X && Player2.MotorPos.Y == Player1.Line[i].Y)
                  {
                      Clock.Stop();
                      Endgame();
                 }
              }
            
             for (int i =0; i < Player2.Line.Count()-1 ; i++)
             {
                 if (Player1.MotorPos.X == Player2.Line[i].X && Player1.MotorPos.Y == Player2.Line[i].Y)
                 {
                     Clock.Stop();
                     Endgame();
                 }
                if (Player2.MotorPos.X == Player2.Line[i].X && Player2.MotorPos.Y == Player2.Line[i].Y)
                 {
                     Clock.Stop();
                     Endgame();
                 }
             }


        }

        private void Endgame()
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Make();
        }

       
    }
}
