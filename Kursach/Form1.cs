using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Init();
            this.Paint += DrawMap;
            this.MouseClick += MouseClickd;
        }

        private void DrawMap(object sender, PaintEventArgs e)
        {
            ReDrawAllMap();
            HighlightPossibleShashki();
            ReDrawAllMap();
        }

        void MouseClickd(object sender, MouseEventArgs args)
        {
            var location = args.Location;// Переменная, куда нажали мышку
                if (turn == 1)
                {

                    if (hodidet) // Если шашка уже выбрана
                {
                        for (int i = 0; i < map_size; i++)
                        {
                            for (int j = 0; j < map_size; j++)
                            {
                                if (RectangleMap[i, j].rect.Contains(location) && map[i, j] == 5)
                                {
                                    map[i, j] = 1;
                                    map[CurrentShashka.i, CurrentShashka.j] = 0;
                                    hodidet = false;
                                    ReConstructAllMap();
                                    ReDrawAllMap();
                                    ChangeTurn();
                                    ReCountInfo();
                                    BecomeQueen();
                                    HighlightPossibleShashki();
                                    ReDrawAllMap();
                                    CurrentShashka = null;
                                }

                                if (RectangleMap[i, j].rect.Contains(location) && map[i, j] == 12)
                                {
                                    map[i, j] = 7;
                                    map[CurrentShashka.i, CurrentShashka.j] = 0;
                                    hodidet = false;
                                    ReConstructAllMap();
                                    ReDrawAllMap();
                                    ChangeTurn();
                                    ReCountInfo();
                                    BecomeQueen();
                                    HighlightPossibleShashki();
                                    ReDrawAllMap();
                                    CurrentShashka = null;
                                }

                                if (RectangleMap[i, j].rect.Contains(location) && map[i, j] == 6)
                                    {
                                        if (j - CurrentShashka.j > 0 && i - CurrentShashka.i <= 0)
                                        {
                                            map[i + 1, j - 1] = 0;
                                        }
                                        if (j - CurrentShashka.j > 0 && i - CurrentShashka.i > 0)
                                        {
                                            map[i - 1, j - 1] = 0;
                                        }
                                        if (j - CurrentShashka.j <= 0 && i - CurrentShashka.i <= 0)
                                        {
                                            map[i + 1, j + 1] = 0;
                                        }
                                        if (j - CurrentShashka.j <= 0 && i - CurrentShashka.i > 0)
                                        {
                                            map[i - 1, j + 1] = 0;
                                        }
                                        map[CurrentShashka.i, CurrentShashka.j] = 0;
                                        map[i, j] = 1;
                                        hodidet = false;
                                        ReConstructAllMap();
                                        ReDrawAllMap();
                                        ReCountInfo();
                                        BecomeQueen();
                                        CurrentShashka = null;
                                        HighlightPossibleShashki();
                                        if (noDifficultTurn)
                                        {
                                            ReConstructAllMap();
                                            ChangeTurn();
                                            ReCountInfo();
                                            BecomeQueen();
                                            HighlightPossibleShashki();
                                        }
                                        ReDrawAllMap();
                                        if (WinCheck())
                                        {
                                            OpenWinForm();
                                        }
                                }

                                if (RectangleMap[i, j].rect.Contains(location) && map[i, j] == 11) // Ход со съеданием 
                                {
                                    if (j - CurrentShashka.j > 0 && i - CurrentShashka.i <= 0) // В левый низ
                                    {
                                        int temp_i = i + 1;
                                        int temp_j = j - 1;
                                        while (temp_i != CurrentShashka.i && temp_j != CurrentShashka.j)
                                        {
                                            map[temp_i, temp_j] = 0;
                                            temp_i++;
                                            temp_j--;
                                        }
                                    }

                                    if (j - CurrentShashka.j > 0 && i - CurrentShashka.i > 0) // В левый вверх
                                    {
                                        int temp_i = i - 1;
                                        int temp_j = j - 1;
                                        while (temp_i != CurrentShashka.i && temp_j != CurrentShashka.j)
                                        {
                                            map[temp_i, temp_j] = 0;
                                            temp_i--;
                                            temp_j--;
                                        }
                                    }

                                    if (j - CurrentShashka.j <= 0 && i - CurrentShashka.i <= 0) //В правый низ
                                    {
                                        int temp_i = i + 1;
                                        int temp_j = j + 1;
                                        while (temp_i != CurrentShashka.i && temp_j != CurrentShashka.j)
                                        {
                                            map[temp_i, temp_j] = 0;
                                            temp_i++;
                                            temp_j++;
                                        }

                                    }

                                    if (j - CurrentShashka.j <= 0 && i - CurrentShashka.i > 0) // В правый верх
                                    {
                                        int temp_i = i - 1;
                                        int temp_j = j + 1;
                                        while(temp_i != CurrentShashka.i && temp_j!= CurrentShashka.j)
                                        {
                                            map[temp_i, temp_j] = 0;
                                            temp_i--;
                                            temp_j++;
                                        }
                                    }

                                    map[CurrentShashka.i, CurrentShashka.j] = 0;
                                    map[i, j] = 7;
                                    hodidet = false;
                                    ReConstructAllMap();
                                    ReDrawAllMap();
                                    ReCountInfo();
                                    BecomeQueen();
                                    CurrentShashka = null;
                                    HighlightPossibleShashki();
                                    if (noDifficultTurn)
                                    {
                                        ReConstructAllMap();
                                        ChangeTurn();
                                        ReCountInfo();
                                        BecomeQueen();
                                        HighlightPossibleShashki();
                                    }
                                    ReDrawAllMap();
                                    if (WinCheck())
                                    {
                                        OpenWinForm();
                                    }
                                }


                            }




                        }
                    }
                    else // Если выбор шашки
                    {
                    for (int i = 0; i < map_size; i++)
                        {
                            for (int j = 0; j < map_size; j++)
                            {
                                if (map[i, j] == 1) // Выбрана шашка обычная
                                {
                                    if (RectangleMap[i, j].rect.Contains(location))
                                    {
                                        CurrentShashka = RectangleMap[i, j];
                                        ReConstructAllMap();
                                        ReCountInfo();
                                        map[i, j] = 4;
                                        DrawPossibleTurns();
                                        hodidet = true;
                                        BecomeQueen();
                                    }
                                }
                                if (map[i, j] == 7) // Выбрана дамка
                                {
                                    if (RectangleMap[i, j].rect.Contains(location))
                                    {
                                        CurrentShashka = RectangleMap[i, j];
                                        ReConstructAllMap();
                                        ReCountInfo();
                                        map[i, j] = 10;
                                        DrawPossibleTurns();
                                        hodidet = true;
                                        BecomeQueen();
                                    }
                                }
                            }
                        }
                    }

                }
                else if (turn == 2)
                {
                    if (hodidet) // Шашка уже выбрана
                    {
                        for (int i = 0; i < map_size; i++)
                        {
                            for (int j = 0; j < map_size; j++)
                            {
                                if (RectangleMap[i, j].rect.Contains(location) && map[i, j] == 5) // Обычный ход обычной шашки
                                {
                                    map[i, j] = 2;
                                    map[CurrentShashka.i, CurrentShashka.j] = 0;
                                    hodidet = false;
                                    ReConstructAllMap();
                                    ReDrawAllMap();
                                    ChangeTurn();
                                    BecomeQueen();
                                    ReCountInfo();
                                    CurrentShashka = null;
                                    HighlightPossibleShashki();
                                    ReDrawAllMap();
                                }

                                if (RectangleMap[i, j].rect.Contains(location) && map[i, j] == 12) // Обычный ход дамки
                                {
                                    map[i, j] = 8;
                                    map[CurrentShashka.i, CurrentShashka.j] = 0;
                                    hodidet = false;
                                    ReConstructAllMap();
                                    ReDrawAllMap();
                                    ChangeTurn();
                                    BecomeQueen();
                                    ReCountInfo();
                                    CurrentShashka = null;
                                    HighlightPossibleShashki();
                                    ReDrawAllMap();
                                }

                                if (RectangleMap[i, j].rect.Contains(location) && map[i, j] == 6) // Код со съеданием обычной шашки
                                    {
                                        if(j-CurrentShashka.j > 0 && i - CurrentShashka.i <=0)
                                        {
                                            map[i + 1, j - 1] = 0;
                                        }
                                        if (j - CurrentShashka.j > 0 && i - CurrentShashka.i > 0)
                                        {
                                            map[i - 1, j - 1] = 0;
                                        }
                                        if(j - CurrentShashka.j <=0 && i - CurrentShashka.i <= 0)
                                        {
                                            map[i + 1, j + 1] = 0;
                                        }
                                        if (j - CurrentShashka.j <= 0 && i - CurrentShashka.i > 0)
                                        {
                                            map[i - 1, j + 1] = 0;
                                        }
                                        map[CurrentShashka.i, CurrentShashka.j] = 0;
                                        map[i, j] = 2;
                                        hodidet = false;
                                        ReConstructAllMap();
                                        ReDrawAllMap();
                                        ReCountInfo();
                                        BecomeQueen();
                                        CurrentShashka = null;
                                        HighlightPossibleShashki();
                                        if (noDifficultTurn)
                                        {
                                            ReConstructAllMap();
                                            ChangeTurn();
                                            BecomeQueen();
                                            ReCountInfo();
                                            HighlightPossibleShashki();
                                        }
                                        ReDrawAllMap();
                                        if (WinCheck())
                                        {
                                            OpenWinForm();
                                        }

                                }
                                        if (RectangleMap[i, j].rect.Contains(location) && map[i, j] == 11)  // Код со съеданием дамки
                                        {
                                            if (j - CurrentShashka.j > 0 && i - CurrentShashka.i <= 0)
                                            {
                                                int temp_i = i + 1;
                                                int temp_j = j - 1;
                                                while (temp_i != CurrentShashka.i && temp_j != CurrentShashka.j)
                                                {
                                                    map[temp_i, temp_j] = 0;
                                                    temp_i++;
                                                    temp_j--;
                                                }
                                            }
                                            if (j - CurrentShashka.j > 0 && i - CurrentShashka.i > 0)
                                            {
                                                int temp_i = i - 1;
                                                int temp_j = j - 1;
                                                while (temp_i != CurrentShashka.i && temp_j != CurrentShashka.j)
                                                {
                                                    map[temp_i, temp_j] = 0;
                                                    temp_i--;
                                                    temp_j--;
                                                }
                                            }
                                            if (j - CurrentShashka.j <= 0 && i - CurrentShashka.i <= 0)
                                            {
                                                int temp_i = i + 1;
                                                int temp_j = j + 1;
                                                while (temp_i != CurrentShashka.i && temp_j != CurrentShashka.j)
                                                {
                                                    map[temp_i, temp_j] = 0;
                                                    temp_i++;
                                                    temp_j++;
                                                }

                                            }

                                            if (j - CurrentShashka.j <= 0 && i - CurrentShashka.i > 0)
                                            {
                                                int temp_i = i - 1;
                                                int temp_j = j + 1;
                                                while (temp_i != CurrentShashka.i && temp_j != CurrentShashka.j)
                                                {
                                                    map[temp_i, temp_j] = 0;
                                                    temp_i--;
                                                    temp_j++;
                                                }
                                            }
                                            map[CurrentShashka.i, CurrentShashka.j] = 0;
                                            map[i, j] = 8;
                                            hodidet = false;
                                            ReConstructAllMap();
                                            ReDrawAllMap();
                                            ReCountInfo();
                                            BecomeQueen();
                                            CurrentShashka = null;
                                            HighlightPossibleShashki();
                                            if (noDifficultTurn)
                                            {
                                                ReConstructAllMap();
                                                ChangeTurn();
                                                ReCountInfo();
                                                BecomeQueen();
                                                HighlightPossibleShashki();
                                            }
                                            ReDrawAllMap();
                                            if (WinCheck())
                                            {
                                                OpenWinForm();
                                            }
                                        }

                        }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < map_size; i++)
                        {
                            for (int j = 0; j < map_size; j++)
                            {
                                if (map[i, j] == 2)
                                {
                                    if (RectangleMap[i, j].rect.Contains(location))
                                    {
                                        CurrentShashka = RectangleMap[i, j];
                                        ReConstructAllMap();
                                        map[i, j] = 4;
                                        DrawPossibleTurns();
                                        hodidet = true;
                                    }
                                }
                                if (map[i, j] == 8)
                                {
                                    if (RectangleMap[i, j].rect.Contains(location))
                                    {
                                        CurrentShashka = RectangleMap[i, j];
                                        ReConstructAllMap();
                                        ReCountInfo();
                                        map[i, j] = 10;
                                        DrawPossibleTurns();
                                        hodidet = true;
                                        BecomeQueen();
                                    }
                                }
                            }
                        }
                    }
                }
            
        }
        void DrawPossibleTurns() // функция, которая рисует возможные ходы для выбранной шашки
        {
            Pen orange = new Pen(Color.Orange,3);
            noDifficultTurn = true;
            if(turn == 1)
            {
                for (int i = 0; i < map_size; i++)
                {
                    for (int j = 0; j < map_size; j++)
                    {
                        if (map[i, j] == 4)
                        {

                            if (i + 1 < map_size)
                            {
                                if (j + 1 < map_size)
                                {
                                    if (map[i + 1, j + 1] == 2 || map[i + 1, j + 1] == 8)
                                    {
                                        if (i + 2 < map_size)
                                        {
                                            if (j + 2 < map_size)
                                            {
                                                if (map[i + 2, j + 2] == 0)
                                                {
                                                    g.DrawEllipse(orange, RectangleMap[i + 2, j + 2].rect);
                                                    map[i+2, j+2] = 6;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }

                                    }
                                }
                                if (j - 1 >= 0)
                                {
                                    if (map[i + 1, j - 1] == 2 || map[i + 1, j - 1] == 8)
                                    {
                                        if (i + 2 < map_size)
                                        {
                                            if (j - 2 >= 0)
                                            {
                                                if (map[i + 2, j - 2] == 0)
                                                {
                                                    g.DrawEllipse(orange, RectangleMap[i + 2, j - 2].rect);
                                                    map[i + 2, j - 2] = 6;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                            if (i - 1 >= 0)
                            {
                                if (j + 1 < map_size)
                                {
                                    if (map[i - 1, j + 1] == 2 || map[i - 1, j + 1] == 8)
                                    {
                                        if (i - 2 >= 0)
                                        {
                                            if (j + 2 < map_size)
                                            {
                                                if (map[i - 2, j + 2] == 0)
                                                {
                                                    g.DrawEllipse(orange, RectangleMap[i - 2, j + 2].rect);
                                                    map[i - 2, j + 2] = 6;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }

                                    }
                                }
                                if (j - 1 >= 0)
                                {
                                    if (map[i - 1, j - 1] == 2 || map[i - 1, j - 1] == 8)
                                    {
                                        if (i - 2 >= 0)
                                        {
                                            if (j - 2 >= 0)
                                            {
                                                if (map[i - 2, j - 2] == 0)
                                                {
                                                    g.DrawEllipse(orange, RectangleMap[i - 2, j - 2].rect);
                                                    map[i - 2, j - 2] = 6;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }

                                    }
                                }
                            }


                            if (noDifficultTurn)
                            {
                                if (i + 1 < map_size)
                                {
                                    if (j + 1 < map_size)
                                    {
                                        if (map[i + 1, j + 1] == 0)
                                        {
                                            g.DrawEllipse(orange, RectangleMap[i + 1, j + 1].rect);
                                            map[i + 1, j + 1] = 5;
                                        }
                                    }
                                    if (j - 1 >= 0)
                                    {
                                        if (map[i + 1, j - 1] == 0)
                                        {
                                            g.DrawEllipse(orange, RectangleMap[i + 1, j - 1].rect);
                                            map[i + 1, j - 1] = 5;

                                        }
                                    }
                                }
                            }
                        }
                        if(map[i,j] == 10)
                        {
                            if ((i + 1 < map_size) && (j - 1 >= 0)) // Ходить(бить) в левый низ
                            {
                                int temp_i = i + 1;
                                int temp_j = j - 1;
                                while ((temp_i < map_size) && (temp_j >= 0))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 1)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 2 || map[temp_i, temp_j] == 8)
                                    {
                                        while ((temp_i < map_size) && (temp_j >= 0))
                                        {

                                            if (temp_i + 1 < map_size && temp_j - 1 >= 0 && map[temp_i + 1, temp_j - 1] == 0)
                                            {
                                                g.DrawEllipse(orange, RectangleMap[temp_i + 1, temp_j - 1].rect);
                                                map[temp_i + 1, temp_j - 1] = 11;
                                                noDifficultTurn = false;
                                                temp_i++;
                                                temp_j--;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }
                                        break;
                                    }
                                    temp_i++;
                                    temp_j--;
                                }
                            }

                            if ((i + 1 < map_size) && (j + 1 < map_size)) // Ходить(бить) в правый низ
                            {
                                int temp_i = i + 1;
                                int temp_j = j + 1;
                                while ((temp_i < map_size) && (temp_j < map_size))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 1)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 2 || map[temp_i, temp_j] == 8)
                                    {
                                        while ((temp_i < map_size) && (temp_j < map_size))
                                        {

                                            if (temp_i + 1 < map_size && temp_j + 1 < map_size && map[temp_i + 1, temp_j + 1] == 0)
                                            {
                                                g.DrawEllipse(orange, RectangleMap[temp_i + 1, temp_j + 1].rect);
                                                map[temp_i + 1, temp_j + 1] = 11;
                                                noDifficultTurn = false;
                                                temp_i++;
                                                temp_j++;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }
                                        break;
                                    }
                                    temp_i++;
                                    temp_j++;
                                }
                            }

                            if ((i - 1 >= 0) && (j + 1 < map_size)) // Ходить(бить) в правый верх
                            {
                                int temp_i = i - 1;
                                int temp_j = j + 1;
                                while ((temp_i >= 0) && (temp_j < map_size))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 1)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 2 || map[temp_i, temp_j] == 8)
                                    {
                                        while ((temp_i >= 0) && (temp_j < map_size))
                                        {

                                            if (temp_i - 1 >= 0 && temp_j + 1 < map_size && map[temp_i - 1, temp_j + 1] == 0)
                                            {
                                                g.DrawEllipse(orange, RectangleMap[temp_i - 1, temp_j + 1].rect);
                                                map[temp_i - 1, temp_j + 1] = 11;
                                                noDifficultTurn = false;
                                                temp_i--;
                                                temp_j++;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }
                                        break;
                                    }
                                    temp_i--;
                                    temp_j++;
                                }


                            }

                            if ((i - 1 >= 0) && (j + 1 >= 0)) // Ходить(бить) в Левый верх
                            {
                                int temp_i = i - 1;
                                int temp_j = j - 1;
                                while ((temp_i >= 0) && (temp_j >= 0))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 1)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 2 || map[temp_i, temp_j] == 8)
                                    {
                                        while ((temp_i >= 0) && (temp_j >= 0))
                                        {

                                            if (temp_i - 1 >= 0 && temp_j - 1 >= 0 && map[temp_i - 1, temp_j - 1] == 0)
                                            {
                                                g.DrawEllipse(orange, RectangleMap[temp_i - 1, temp_j - 1].rect);
                                                map[temp_i - 1, temp_j - 1] = 11;
                                                noDifficultTurn = false;
                                                temp_i--;
                                                temp_j--;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }
                                        break;
                                    }
                                    temp_i--;
                                    temp_j--;
                                }


                            }


                            if (noDifficultTurn)
                            {
                                if ((i - 1 >= 0) && (j + 1 >= 0)) // Ходить в Левый верх
                                {
                                    int temp_i = i - 1;
                                    int temp_j = j - 1;
                                    while ((temp_i >= 0) && (temp_j >= 0))
                                    {
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            g.DrawEllipse(orange, RectangleMap[temp_i, temp_j].rect);
                                            map[temp_i, temp_j] = 12;
                                        }
                                        temp_i--;
                                        temp_j--;
                                    }
                                }

                                if ((i - 1 >= 0) && (j + 1 < map_size)) // Ходить в правый верх
                                {
                                    int temp_i = i - 1;
                                    int temp_j = j + 1;
                                    while ((temp_i >= 0) && (temp_j < map_size))
                                    {
                                        if(map[temp_i, temp_j] != 0)
                                        {
                                            break;
                                        }
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            g.DrawEllipse(orange, RectangleMap[temp_i, temp_j].rect);
                                            map[temp_i, temp_j] = 12;
                                        }
                                        temp_i--;
                                        temp_j++;
                                    }
                                }

                                if ((i + 1 < map_size) && (j + 1 < map_size)) // Ходить в правый низ
                                {
                                    int temp_i = i + 1;
                                    int temp_j = j + 1;
                                    while ((temp_i < map_size) && (temp_j < map_size))
                                    {
                                        if (map[temp_i, temp_j] != 0)
                                        {
                                            break;
                                        }
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            g.DrawEllipse(orange, RectangleMap[temp_i, temp_j].rect);
                                            map[temp_i, temp_j] = 12;
                                        }
                                        temp_i++;
                                        temp_j++;
                                    }
                                }

                                if ((i + 1 < map_size) && (j - 1 >= 0)) // Ходить в левый низ
                                {
                                    int temp_i = i + 1;
                                    int temp_j = j - 1;
                                    while ((temp_i < map_size) && (temp_j >= 0))
                                    {
                                        if (map[temp_i, temp_j] != 0)
                                        {
                                            break;
                                        }
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            g.DrawEllipse(orange, RectangleMap[temp_i, temp_j].rect);
                                            map[temp_i, temp_j] = 12;
                                        }
                                        temp_i++;
                                        temp_j--;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            else if (turn == 2)
            {
                noDifficultTurn = true;
                for (int i = 0; i < map_size; i++)
                {
                    for (int j = 0; j < map_size; j++)
                    {
                        if (map[i, j] == 4)
                        {
                            if (i - 1 >= 0)
                            {
                                if (j + 1 < map_size)
                                {
                                    if (map[i - 1, j + 1] == 1 || map[i - 1, j + 1] == 7)
                                    {
                                        if (i - 2 >= 0)
                                        {
                                            if (j + 2 < map_size)
                                            {
                                                if (map[i - 2, j + 2] == 0)
                                                {
                                                    g.DrawEllipse(orange, RectangleMap[i - 2, j + 2].rect);
                                                    map[i - 2, j + 2] = 6;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (j - 1 >= 0)
                                {
                                    if (map[i - 1, j - 1] == 1 || map[i - 1, j - 1] == 7)
                                    {
                                        if (i - 2 >= 0)
                                        {
                                            if (j - 2 >= 0)
                                            {
                                                if (map[i - 2, j - 2] == 0)
                                                {
                                                    g.DrawEllipse(orange, RectangleMap[i - 2, j - 2].rect);
                                                    map[i - 2, j - 2] = 6;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (i + 1 < map_size)
                            {
                                if (j + 1 < map_size)
                                {
                                    if (map[i + 1, j + 1] == 1 || map[i + 1, j + 1] == 7)
                                    {
                                        if (i + 2 < map_size)
                                        {
                                            if (j + 2 < map_size)
                                            {
                                                if (map[i + 2, j + 2] == 0)
                                                {
                                                    g.DrawEllipse(orange, RectangleMap[i + 2, j + 2].rect);
                                                    map[i + 2, j + 2] = 6;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (j - 1 >= 0)
                                {
                                    if (map[i + 1, j - 1] == 1 || map[i + 1, j - 1] == 7)
                                    {
                                        if (i + 2 < map_size)
                                        {
                                            if (j - 2 >= 0)
                                            {
                                                if (map[i + 2, j - 2] == 0)
                                                {
                                                    g.DrawEllipse(orange, RectangleMap[i + 2, j - 2].rect);
                                                    map[i + 2, j - 2] = 6;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }




                            if (noDifficultTurn)
                            {
                                if (i - 1 >= 0)
                                {
                                    if (j + 1 < map_size)
                                    {
                                        if (map[i - 1, j + 1] == 0)
                                        {
                                            g.DrawEllipse(orange, RectangleMap[i - 1, j + 1].rect);
                                            map[i - 1, j + 1] = 5;
                                        }
                                    }

                                    if (j - 1 >= 0)
                                    {
                                        if (map[i - 1, j - 1] == 0)
                                        {
                                            g.DrawEllipse(orange, RectangleMap[i - 1, j - 1].rect);
                                            map[i - 1, j - 1] = 5;

                                        }
                                    }
                                }
                            }
                        }

                        if(map[i,j] == 10)
                        {
                            if ((i + 1 < map_size) && (j - 1 >= 0)) // Ходить в левый низ
                            {
                                int temp_i = i + 1;
                                int temp_j = j - 1;
                                while ((temp_i < map_size) && (temp_j >= 0))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 2)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 1 || map[temp_i, temp_j] == 7)
                                    {
                                        while ((temp_i < map_size) && (temp_j >= 0))
                                        {

                                            if (temp_i + 1 < map_size && temp_j - 1 >= 0 && map[temp_i + 1, temp_j - 1] == 0)
                                            {
                                                g.DrawEllipse(orange, RectangleMap[temp_i + 1, temp_j - 1].rect);
                                                map[temp_i + 1, temp_j - 1] = 11;
                                                noDifficultTurn = false;
                                                temp_i++;
                                                temp_j--;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    temp_i++;
                                    temp_j--;
                                }
                            }

                            if ((i + 1 < map_size) && (j + 1 < map_size)) // Ходить(бить) в правый низ
                            {
                                int temp_i = i + 1;
                                int temp_j = j + 1;
                                while ((temp_i < map_size) && (temp_j < map_size))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 2)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 1 || map[temp_i, temp_j] == 7)
                                    {
                                        while ((temp_i < map_size) && (temp_j < map_size))
                                        {

                                            if (temp_i + 1 < map_size && temp_j + 1 < map_size && map[temp_i + 1, temp_j + 1] == 0)
                                            {
                                                g.DrawEllipse(orange, RectangleMap[temp_i + 1, temp_j + 1].rect);
                                                map[temp_i + 1, temp_j + 1] = 11;
                                                noDifficultTurn = false;
                                                temp_i++;
                                                temp_j++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    temp_i++;
                                    temp_j++;
                                }
                            }

                            if ((i - 1 >= 0) && (j + 1 < map_size)) // Ходить(бить) в правый верх
                            {
                                int temp_i = i - 1;
                                int temp_j = j + 1;
                                while ((temp_i >= 0) && (temp_j < map_size))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 2)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 1 || map[temp_i, temp_j] == 7)
                                    {
                                        while ((temp_i >= 0) && (temp_j < map_size))
                                        {

                                            if (temp_i - 1 >= 0 && temp_j + 1 < map_size && map[temp_i - 1, temp_j + 1] == 0)
                                            {
                                                g.DrawEllipse(orange, RectangleMap[temp_i - 1, temp_j + 1].rect);
                                                map[temp_i - 1, temp_j + 1] = 11;
                                                noDifficultTurn = false;
                                                temp_i--;
                                                temp_j++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    temp_i--;
                                    temp_j++;
                                }
                            }

                            if ((i - 1 >= 0) && (j + 1 >= 0)) // Ходить(бить) в Левый верх
                            {
                                int temp_i = i - 1;
                                int temp_j = j - 1;
                                while ((temp_i >= 0) && (temp_j >= 0))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 2)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 1 || map[temp_i, temp_j] == 7)
                                    {
                                        while ((temp_i >= 0) && (temp_j >= 0))
                                        {

                                            if (temp_i - 1 >= 0 && temp_j - 1 >= 0 && map[temp_i - 1, temp_j - 1] == 0)
                                            {
                                                g.DrawEllipse(orange, RectangleMap[temp_i - 1, temp_j - 1].rect);
                                                map[temp_i - 1, temp_j - 1] = 11;
                                                noDifficultTurn = false;
                                                temp_i--;
                                                temp_j--;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    temp_i--;
                                    temp_j--;
                                }
                            }

                            if (noDifficultTurn)
                            {



                                if ((i - 1 >= 0) && (j + 1 >= 0)) // Ходить в Левый верх
                                {
                                    int temp_i = i - 1;
                                    int temp_j = j - 1;
                                    while ((temp_i >= 0) && (temp_j >= 0))
                                    {
                                        if (map[temp_i, temp_j] != 0)
                                        {
                                            break;
                                        }
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            g.DrawEllipse(orange, RectangleMap[temp_i, temp_j].rect);
                                            map[temp_i, temp_j] = 12;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                        temp_i--;
                                        temp_j--;
                                    }
                                }

                                if ((i - 1 >= 0) && (j + 1 < map_size)) // Ходить в правый верх
                                {
                                    int temp_i = i - 1;
                                    int temp_j = j + 1;
                                    while ((temp_i >= 0) && (temp_j < map_size))
                                    {
                                        if (map[temp_i, temp_j] != 0)
                                        {
                                            break;
                                        }
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            g.DrawEllipse(orange, RectangleMap[temp_i, temp_j].rect);
                                            map[temp_i, temp_j] = 12;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                        temp_i--;
                                        temp_j++;
                                    }
                                }

                                if ((i + 1 < map_size) && (j + 1 < map_size)) // Ходить в правый низ
                                {
                                    int temp_i = i + 1;
                                    int temp_j = j + 1;
                                    while ((temp_i < map_size) && (temp_j < map_size))
                                    {
                                        if (map[temp_i, temp_j] != 0)
                                        {
                                            break;
                                        }
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            g.DrawEllipse(orange, RectangleMap[temp_i, temp_j].rect);
                                            map[temp_i, temp_j] = 12;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                        temp_i++;
                                        temp_j++;
                                    }
                                }

                                if ((i + 1 < map_size) && (j - 1 >= 0)) // Ходить в левый низ
                                {
                                    int temp_i = i + 1;
                                    int temp_j = j - 1;
                                    while ((temp_i < map_size) && (temp_j >= 0))
                                    {
                                        if (map[temp_i, temp_j] != 0)
                                        {
                                            break;
                                        }
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            g.DrawEllipse(orange, RectangleMap[temp_i, temp_j].rect);
                                            map[temp_i, temp_j] = 12;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                        temp_i++;
                                        temp_j--;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        void ReConstructAllMap()// Функция, которая возвращает матрицу в нормальное положение
        {
            for (int i = 0; i < map_size; i++)
            {
                for (int j = 0; j < map_size; j++)
                {
                    if (map[i, j] ==3 || map[i,j]==4)
                    {
                        map[i, j] = turn;
                    }
                    if (map[i, j] == 5 || map[i, j] == 6 || map[i, j] == 11 || map[i, j] == 12)
                    {
                        map[i, j] = 0;
                    }
                    if(map[i,j] == 9 || map[i,j]==10)
                    {
                        map[i, j] = turn + 6;
                    }
                }
            }
        }

        public void ReDrawAllMap()// Функция перерисовки всей матрицы
        {
            g = this.CreateGraphics();
            SolidBrush white = new SolidBrush(Color.White);
            SolidBrush black = new SolidBrush(Color.Black);
            SolidBrush red = new SolidBrush(Color.Red);
            SolidBrush blue = new SolidBrush(Color.Blue);
            SolidBrush gray = new SolidBrush(Color.Gray);
            Pen green = new Pen(Color.Green,5);
            Pen grayPen = new Pen(Color.Gray, 5);
            Pen orange = new Pen(Color.Orange,3);
            
            for (int i = 0; i < map_size; i++)
            {
                for (int j = 0; j < map_size; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        RectangleMap[i,j].rect = new Rectangle(10 + j * rectangle_size, 10 + i * rectangle_size, rectangle_size, rectangle_size);
                        RectangleMap[i, j].i = i;
                        RectangleMap[i, j].j = j;
                        g.FillRectangle(black, RectangleMap[i, j].rect);
                    }
                    if ((i + j) % 2 == 0)
                    {
                        RectangleMap[i, j].rect = new Rectangle(10 + j * rectangle_size, 10 + i * rectangle_size, rectangle_size, rectangle_size);
                        RectangleMap[i, j].i = i;
                        RectangleMap[i, j].j = j;
                        g.FillRectangle(white, RectangleMap[i, j].rect);
                    }
                     if (map[i, j] == 1)
                    {
                        g.FillEllipse(red, RectangleMap[i,j].rect);
                    }
                    if (map[i, j] == 2)
                    {
                        g.FillEllipse(blue, RectangleMap[i, j].rect);
                    }
                    if (map[i, j] == 3)
                    {
                        g.FillEllipse(gray, RectangleMap[i, j].rect);
                    }
                    if (map[i, j] == 6)
                    {

                    }
                    if (map[i, j] == 7)
                    {
                        g.FillEllipse(red, RectangleMap[i, j].rect);
                        g.DrawEllipse(green, RectangleMap[i, j].rect);
                    }
                    if (map[i, j] == 8)
                    {
                        g.FillEllipse(blue, RectangleMap[i, j].rect);
                        g.DrawEllipse(green, RectangleMap[i, j].rect);
                    }
                    if (map[i, j] == 9)
                    {
                        g.FillEllipse(gray, RectangleMap[i, j].rect);
                        g.DrawEllipse(grayPen, RectangleMap[i, j].rect);
                    }
                }
            }
            
        }

        public void HighlightPossibleShashki() // Функция, которая "подсвечивает" возможные шашки
        {
            noDifficultTurn = true;
            if (turn == 1) {
                noDifficultTurn = true;
                for (int i = 0; i < map_size; i++)
                {
                    for (int j = 0; j < map_size; j++)
                    {
                        if (map[i, j] == 1)
                        {
                            map[i, j] = 3;
                            if (i + 1 < map_size)
                            {
                                if (j + 1 < map_size)
                                {
                                    if (map[i + 1, j + 1] == 2 || map[i + 1, j + 1] == 8)
                                    {
                                        if(i + 2 < map_size)
                                        {
                                            if(j + 2 < map_size)
                                            {
                                                if (map[i + 2, j + 2] == 0)
                                                {
                                                    map[i, j] = 1;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }
                                        
                                    }
                                }
                                if (j - 1 >= 0)
                                {
                                    if (map[i + 1, j - 1] == 2 || map[i + 1, j - 1] == 8)
                                    {
                                        if (i + 2 < map_size)
                                        {
                                            if (j - 2 >=0)
                                            {
                                                if (map[i + 2, j - 2] == 0)
                                                {
                                                    map[i, j] = 1;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                            if (i - 1 >= 0)
                            {
                                if (j + 1 < map_size)
                                {
                                    if (map[i - 1, j + 1] == 2 || map[i - 1, j + 1] == 8)
                                    {
                                        if (i - 2 >=0)
                                        {
                                            if (j + 2 < map_size)
                                            {
                                                if (map[i - 2, j + 2] == 0)
                                                {
                                                    map[i, j] = 1;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }

                                    }
                                }
                                if (j - 1 >= 0)
                                {
                                    if (map[i - 1, j - 1] == 2 || map[i - 1, j - 1] == 8)
                                    {
                                        if (i - 2 >=0)
                                        {
                                            if (j - 2 >= 0)
                                            {
                                                if (map[i - 2, j - 2] == 0)
                                                {
                                                    map[i, j] = 1;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }

                        if (map[i, j] == 7)
                        {
                            map[i, j] = 9;

                            if ((i + 1 < map_size) && (j - 1 >= 0)) // Ходить в левый низ
                            {
                                int temp_i = i + 1;
                                int temp_j = j - 1;
                                while ((temp_i < map_size) && (temp_j >= 0))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 1)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 2 || map[temp_i, temp_j] == 8)
                                    {
                                        while ((temp_i < map_size) && (temp_j >= 0))
                                        {

                                            if (temp_i + 1 < map_size && temp_j - 1 >= 0 && map[temp_i + 1, temp_j - 1] == 0)
                                            {
                                                map[i, j] = 7;
                                                noDifficultTurn = false;
                                                temp_i++;
                                                temp_j--;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }
                                        break;
                                    }
                                    temp_i++;
                                    temp_j--;
                                }
                            }

                            if ((i + 1 < map_size) && (j + 1 < map_size)) // Ходить(бить) в правый низ
                            {
                                int temp_i = i + 1;
                                int temp_j = j + 1;
                                while ((temp_i < map_size) && (temp_j < map_size))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 1)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 2 || map[temp_i, temp_j] == 8)
                                    {
                                        while ((temp_i < map_size) && (temp_j < map_size))
                                        {

                                            if (temp_i + 1 < map_size && temp_j + 1 < map_size && map[temp_i + 1, temp_j + 1] == 0)
                                            {
                                                map[i, j] = 7;
                                                noDifficultTurn = false;
                                                temp_i++;
                                                temp_j++;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }
                                        break;
                                    }
                                    temp_i++;
                                    temp_j++;
                                }
                            }

                            if ((i - 1 >= 0) && (j + 1 < map_size)) // Ходить(бить) в правый верх
                            {
                                int temp_i = i - 1;
                                int temp_j = j + 1;
                                while ((temp_i >= 0) && (temp_j < map_size))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 1)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 2 || map[temp_i, temp_j] == 8)
                                    {
                                        while ((temp_i >= 0) && (temp_j < map_size))
                                        {

                                            if (temp_i - 1 >= 0 && temp_j + 1 < map_size && map[temp_i - 1, temp_j + 1] == 0)
                                            {
                                                map[i, j] = 7;
                                                noDifficultTurn = false;
                                                temp_i--;
                                                temp_j++;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }
                                        break;
                                    }
                                    temp_i--;
                                    temp_j++;
                                }


                            }

                            if ((i - 1 >= 0) && (j + 1 >= 0)) // Ходить(бить) в Левый верх
                            {
                                int temp_i = i - 1;
                                int temp_j = j - 1;
                                while ((temp_i >= 0) && (temp_j >= 0))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 1)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 2 || map[temp_i, temp_j] == 8)
                                    {
                                        while ((temp_i >= 0) && (temp_j >= 0))
                                        {

                                            if (temp_i - 1 >= 0 && temp_j - 1 >= 0 && map[temp_i - 1, temp_j - 1] == 0)
                                            {
                                                map[i, j] = 7;
                                                noDifficultTurn = false;
                                                temp_i--;
                                                temp_j--;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }
                                        break;
                                    }
                                    temp_i--;
                                    temp_j--;
                                }


                            }

                        }
                    }
                }

                if (noDifficultTurn)
                {
                    ReConstructAllMap();
                    for (int i = 0; i < map_size; i++)
                    {
                        for (int j = 0; j < map_size; j++)
                        {
                            if (map[i, j] == 1)
                            {
                                map[i, j] = 3;
                                if (i + 1 < map_size)
                                {
                                    if (j + 1 < map_size)
                                    {
                                        if (map[i + 1, j + 1] == 0)
                                        {
                                            map[i, j] = 1; //Третьее состояние, серый цвет 
                                        }
                                    }
                                    if (j - 1 >= 0)
                                    {
                                        if (map[i + 1, j - 1] == 0)
                                        {
                                            map[i, j] = 1;
                                        }
                                    }
                                }
                            }
                            if (map[i, j] == 7)
                            {
                                map[i, j] = 9;
                                if ((i - 1 >= 0) && (j + 1 >= 0)) // Ходить в Левый верх
                                {
                                    int temp_i = i - 1;
                                    int temp_j = j - 1;
                                    while ((temp_i >= 0) && (temp_j >= 0))
                                    {
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            map[i, j] = 7;
                                        }
                                        temp_i--;
                                        temp_j--;
                                    }
                                }

                                if ((i - 1 >= 0) && (j + 1 < map_size)) // Ходить в правый верх
                                {
                                    int temp_i = i - 1;
                                    int temp_j = j + 1;
                                    while ((temp_i >= 0) && (temp_j < map_size))
                                    {
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            map[i, j] = 7;
                                        }
                                        temp_i--;
                                        temp_j++;
                                    }
                                }

                                if ((i + 1 < map_size) && (j + 1 < map_size)) // Ходить в правый низ
                                {
                                    int temp_i = i + 1;
                                    int temp_j = j + 1;
                                    while ((temp_i < map_size) && (temp_j < map_size))
                                    {
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            map[i, j] = 7;
                                        }
                                        temp_i++;
                                        temp_j++;
                                    }
                                }

                                if ((i + 1 < map_size) && (j - 1 >= 0)) // Ходить в левый низ
                                {
                                    int temp_i = i + 1;
                                    int temp_j = j - 1;
                                    while ((temp_i < map_size) && (temp_j >= 0))
                                    {
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            map[i, j] = 7;
                                        }
                                        temp_i++;
                                        temp_j--;
                                    }
                                }

                            }

                        }
                    }
                }
            }

            else if (turn == 2)
            {
                noDifficultTurn = true;
                for (int i = 0; i < map_size; i++)
                {
                    for (int j = 0; j < map_size; j++)
                    {
                        if (map[i, j] == 2)
                        {
                            map[i, j] = 3;
                            if (i - 1 >= 0)
                            {
                                if (j + 1 < map_size)
                                {
                                    if (map[i - 1, j + 1] == 1 || map[i - 1, j + 1] == 7)
                                    {
                                        if (i - 2 >= 0)
                                        {
                                            if (j + 2 < map_size)
                                            {
                                                if (map[i - 2, j + 2] == 0)
                                                {
                                                    map[i, j] = 2;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (j - 1 >= 0)
                                {
                                    if (map[i - 1, j - 1] == 1 || map[i - 1, j - 1] == 7)
                                    {
                                        if (i - 2 >= 0)
                                        {
                                            if (j - 2 >= 0)
                                            {
                                                if (map[i - 2, j - 2] == 0)
                                                {
                                                    map[i, j] = 2;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (i + 1 < map_size)
                            {
                                if (j + 1 < map_size)
                                {
                                    if (map[i + 1, j + 1] == 1 || map[i + 1, j + 1] == 7)
                                    {
                                        if (i + 2 < map_size)
                                        {
                                            if (j + 2 < map_size)
                                            {
                                                if (map[i + 2, j + 2] == 0)
                                                {
                                                    map[i, j] = 2;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (j - 1 >= 0)
                                {
                                    if (map[i + 1, j - 1] == 1 || map[i + 1, j - 1] == 7)
                                    {
                                        if (i + 2 < map_size)
                                        {
                                            if (j - 2 >= 0)
                                            {
                                                if (map[i + 2, j - 2] == 0)
                                                {
                                                    map[i, j] = 2;
                                                    noDifficultTurn = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (map[i, j] == 8)
                        {
                            map[i, j] = 9;

                            if ((i + 1 < map_size) && (j - 1 >=0) ) // Ходить в левый низ
                            {
                                int temp_i = i + 1;
                                int temp_j = j - 1;
                                while ((temp_i < map_size) && (temp_j >= 0))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 2)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 1 || map[temp_i, temp_j] == 7)
                                    {
                                        while ((temp_i < map_size) && (temp_j >= 0))
                                        {
                                            
                                            if (temp_i+1<map_size && temp_j-1>=0 &&  map[temp_i+1, temp_j - 1] == 0)
                                            {
                                                map[i, j] = 8;
                                                noDifficultTurn = false;
                                                temp_i++;
                                                temp_j--;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }
                                        break;
                                    }
                                    temp_i++;
                                    temp_j--;
                                }
                            }

                            if ((i + 1 < map_size) && (j + 1 < map_size)) // Ходить(бить) в правый низ
                            {
                                int temp_i = i + 1;
                                int temp_j = j + 1;
                                while ((temp_i < map_size) && (temp_j < map_size))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 2)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 1 || map[temp_i, temp_j] == 7)
                                    {
                                        while ((temp_i < map_size) && (temp_j < map_size))
                                        {

                                            if (temp_i + 1 < map_size && temp_j + 1 < map_size && map[temp_i + 1, temp_j + 1] == 0)
                                            {
                                                map[i, j] = 8;
                                                noDifficultTurn = false;
                                                temp_i++;
                                                temp_j++;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }
                                        break;
                                    }
                                    temp_i++;
                                    temp_j++;
                                }
                            }

                            if ((i - 1 >= 0) && (j + 1 < map_size)) // Ходить(бить) в правый верх
                            {
                                int temp_i = i - 1;
                                int temp_j = j + 1;
                                while ((temp_i >=0) && (temp_j < map_size))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 2)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 1 || map[temp_i, temp_j] == 7)
                                    {
                                        while ((temp_i >= 0) && (temp_j < map_size))
                                        {

                                            if (temp_i - 1 >= 0 && temp_j + 1 < map_size && map[temp_i -1, temp_j + 1] == 0)
                                            {
                                                map[i, j] = 8;
                                                noDifficultTurn = false;
                                                temp_i--;
                                                temp_j++;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }
                                        break;
                                    }
                                    temp_i--;
                                    temp_j++;
                                }


                            }

                            if ((i - 1 >= 0) && (j + 1 >= 0)) // Ходить(бить) в Левый верх
                            {
                                int temp_i = i - 1;
                                int temp_j = j - 1;
                                while ((temp_i >= 0) && (temp_j >= 0))
                                {
                                    if (map[temp_i, temp_j] == 3 || map[temp_i, temp_j] == 9 || map[temp_i, temp_j] == 2)
                                    {
                                        break;
                                    }
                                    if (map[temp_i, temp_j] == 1 || map[temp_i, temp_j] == 7)
                                    {
                                        while ((temp_i >= 0) && (temp_j >= 0))
                                        {

                                            if (temp_i - 1 >= 0 && temp_j - 1 >= 0 && map[temp_i - 1, temp_j - 1] == 0)
                                            {
                                                map[i, j] = 8;
                                                noDifficultTurn = false;
                                                temp_i--;
                                                temp_j--;
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }
                                        break;
                                    }
                                    temp_i--;
                                    temp_j--;
                                }


                            }

                        }
                    }
                }

                if (noDifficultTurn)
                {
                    ReConstructAllMap();
                    for (int i = 0; i < map_size; i++)
                    {
                        for (int j = 0; j < map_size; j++)
                        {
                            if (map[i, j] == 2)
                            {
                                map[i, j] = 3;
                                if (i - 1 >= 0)
                                {
                                    if (j + 1 < map_size)
                                    {
                                        if (map[i - 1, j + 1] == 0)
                                        {
                                            map[i, j] = 2; //Третьее состояние, серый цвет 
                                        }
                                    }
                                    
                                    if (j - 1 >= 0)
                                    {
                                        if (map[i - 1, j - 1] == 0)
                                        {
                                            map[i, j] = 2;
                                        }
                                    }
                                }
                            }

                            if (map[i, j] == 8)
                            {
                                map[i, j] = 9;
                                if ((i - 1 >= 0) && (j + 1 >= 0)) // Ходить в Левый верх
                                {
                                    int temp_i = i - 1;
                                    int temp_j = j - 1;
                                    while ((temp_i >= 0) && (temp_j >= 0))
                                    {
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            map[i, j] = 8;
                                        }
                                        temp_i--;
                                        temp_j--;
                                    }
                                }

                                if ((i - 1 >= 0) && (j + 1 < map_size)) // Ходить в правый верх
                                {
                                    int temp_i = i - 1;
                                    int temp_j = j + 1;
                                    while ((temp_i >= 0) && (temp_j < map_size))
                                    {
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            map[i, j] = 8;
                                        }
                                        temp_i--;
                                        temp_j++;
                                    }
                                }

                                if ((i + 1 < map_size) && (j + 1 < map_size)) // Ходить в правый низ
                                {
                                    int temp_i = i + 1;
                                    int temp_j = j + 1;
                                    while ((temp_i < map_size) && (temp_j < map_size))
                                    {
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            map[i, j] = 8;
                                        }
                                        temp_i++;
                                        temp_j++;
                                    }
                                }

                                if ((i + 1 < map_size) && (j - 1 >= 0)) // Ходить в левый низ
                                {
                                    int temp_i = i + 1;
                                    int temp_j = j - 1;
                                    while ((temp_i < map_size) && (temp_j >= 0))
                                    {
                                        if (map[temp_i, temp_j] == 0)
                                        {
                                            map[i, j] = 8;
                                        }
                                        temp_i++;
                                        temp_j--;
                                    }
                                }

                            }

                        }
                    }
                }
            }
        }


        public void ReCountInfo() // Пересчитывает информацию для табло 
        {
            int count_1 = 0;
            int count_2 = 0;

            for(int i = 0; i < map_size; i++)
            {
                for(int j = 0; j < map_size; j++)
                {
                    if(map[i,j] == 1 || map[i, j] == 7)
                    {
                        count_1 += 1;
                    }
                    if (map[i, j] == 2 || map[i, j] == 8)
                    {
                        count_2 += 1;
                    }
                }
            }

            CountKillBlue.Text = (12 - count_2).ToString() +" убитых";
            CountKillRed.Text = (12 - count_1).ToString() + " убитых";

            if(turn == 1)
            {
                CurrentTurn.Text = "Ход Красных";
                CurrentTurn.BackColor = Color.Red;
            }
            else
            {
                CurrentTurn.Text = "Ход Синих";
                CurrentTurn.BackColor = Color.Blue;
            }
        }

        void BecomeQueen() // функция проверки на становление дамки
        {
            for(int i = 0; i < map_size; i++)
            {
                if(map[0,i] == 2)
                {
                    map[0, i] = 8;
                }
                if (map[7, i] == 1)
                {
                    map[7, i] = 7;
                }
            }
        }

        
        public void RestartGame()// Функция рестарта игры
        {
            map = new int[map_size, map_size] {
                                                    { 0,1,0,1,0,1,0,1},
                                                    { 1,0,1,0,1,0,1,0},
                                                    { 0,1,0,1,0,1,0,1},
                                                    { 0,0,0,0,0,0,0,0},
                                                    { 0,0,0,0,0,0,0,0},
                                                    { 2,0,2,0,2,0,2,0},
                                                    { 0,2,0,2,0,2,0,2},
                                                    { 2,0,2,0,2,0,2,0}
            };
            noDifficultTurn = true;
            turn = 1;
            hodidet = false;
            CountBlue = 12;
            CountRed = 12;
        }

        public bool WinCheck() // Функция проверки победы какой-то стороны
        {
            int count_1 = 0;
            int count_2 = 0;

            for (int i = 0; i < map_size; i++)
            {
                for (int j = 0; j < map_size; j++)
                {
                    if (map[i, j] == 1 || map[i, j] == 7)
                    {
                        count_1 += 1;
                    }
                    if (map[i, j] == 2 || map[i, j] == 8)
                    {
                        count_2 += 1;
                    }
                }
            }
            CountBlue =  count_1;
            CountRed =  count_2;
            if (count_1 ==0 ||  count_2 == 0)
            {
                return true;
            }
            return false;
        }

        void OpenWinForm() // Функция которая открывает окно с победителем
        {
            Form2 win = new Form2();
            if(CountBlue == 0)
            {
                win.TxtForLabel = "Победа за синими";
                win.BackColor = Color.Blue;
            }
            if(CountRed == 0)
            {
                win.TxtForLabel = "Победа за красными";
                win.BackColor = Color.Red;
            }
            win.Show();
            
        }

        void ChangeTurn() // функция смены хода
        {
            if(turn == 1)
            {
                turn = 2;
            }
            else
            {
                turn = 1;
            }
        }

        public void Init()// Инициалиация формы
        {
            /*
             0 - пустая клетка
             1 - Обычная шашка красных
             2 - Обычная шашка синих
             3 - Серая шашка(ход недоступен)
             4 - выбрана для хода
             5 - возможные ходы обычного перемещения
             6 - возможные ходы для того что-бы побить шашку
             7 - Дамка красных
             8 - Дамка синих
             9 - Серая дамка
             10 - дамка выбрана для хода
             11 - возможные ходы дамки что бы побить шашку
             12 - возможные обычные ходы дамки
             */
            map = new int[map_size, map_size] {
                                                    { 0,1,0,1,0,1,0,1},
                                                    { 1,0,1,0,1,0,1,0},
                                                    { 0,1,0,1,0,1,0,1},
                                                    { 0,0,0,0,0,0,0,0},
                                                    { 0,0,0,0,0,0,0,0},
                                                    { 2,0,2,0,2,0,2,0},
                                                    { 0,2,0,2,0,2,0,2},
                                                    { 2,0,2,0,2,0,2,0}
            };
            Program.f1 = this;
            RectangleMap = new Shashki[map_size, map_size];
            for(int i = 0; i < map_size; i++)
            {
                for(int j = 0; j < map_size; j++)
                {
                    RectangleMap[i, j] = new Shashki();
                }
            }


            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        bool noDifficultTurn = true;
        const int map_size = 8;
        const int rectangle_size = 50;
        int[,] map;
        Graphics g;
        int turn = 1;
        bool hodidet = false;

        int CountBlue = 12;
        int CountRed = 12;

        class Shashki
        {
            public Rectangle rect;
            public int i;
            public int j;
        }

        Shashki[,] RectangleMap;

        Shashki CurrentShashka;
    }
}
