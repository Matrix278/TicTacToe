using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace TicTacToe
{
    [Activity(MainLauncher = true, Icon = "@drawable/tictactoe")]
    public class MainActivity : Activity
    {
        List<Button> computerButtons;//Массив кнопок

        Random random = new Random();
        private bool computerPage = false; //страница с игрой компьютера
        private bool playerTurn = true; //ход игрока
        private bool computerTurn = false; //ход компьютера
        private bool onRussian = false;
        private bool onEnglish = false;
        string thereIsAWinner = "nobody"; //есть ли победитель
        private string sigh = "X"; //начало с Х
        private ViewFlipper vf; //viewFlipper
        private TableLayout tlLanguages; // Languages

        private TableLayout tlMainMenu; //1.Menu
        private TableLayout tlSubmenu1; //2.SetkaSIgrokom
        private TableLayout tlComputerMenu; //2.SetkaSComputerom
        private TableLayout tlSubmenu2; //3.RezultatwIgrw
        private TableLayout tlSubmenu3; //4.Avtor

        private Button btnRussian;
        private Button btnEnglish;

        private Button btnSubmenu1;   // компьютер
        private Button btnSubmenu2;   // игрок
        private Button button1; //1 кнопка
        private Button button2; //2 кнопка
        private Button button3; //3 кнопка
        private Button button4; //4 кнопка
        private Button button5; //5 кнопка
        private Button button6; //6 кнопка
        private Button button7; //7 кнопка
        private Button button8; //8 кнопка
        private Button button9; //9 кнопка

        private Button btnCancel1; //выход на странице с сеткой с игроком
        private Button btnCancel2; //выход на странице с результатом

        private Button btnCancel3; //выход на странице с сеткой компьютера
        private Button computerButton1; //1 кнопка
        private Button computerButton2; //2 кнопка
        private Button computerButton3; //3 кнопка
        private Button computerButton4; //4 кнопка
        private Button computerButton5; //5 кнопка
        private Button computerButton6; //6 кнопка
        private Button computerButton7; //7 кнопка
        private Button computerButton8; //8 кнопка
        private Button computerButton9; //9 кнопка

        private Button btnCancel; //выход на странице с меню
        private Button btnExit; //выход из программы на 4 странице
        private Button btnExitToMenu; //выход в меню на 1 страницу меню

        private Button restartGame1; //повторить игру на странице с результатом
        private Button restartGame2; //играть снова на 4 странице с автором

        private ImageView imageWinner; //картинка победителя на странице с результатом
        private TextView textWinner; // текст победа и ничья н странице с результатом
        private TextView gameName;
        private TextView developer;

        protected override void OnCreate(Bundle savedInstanceState)

        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            vf = FindViewById<ViewFlipper>(Resource.Id.viewFlipper);

            tlLanguages = FindViewById<TableLayout>(Resource.Id.tlLanguages);
            tlMainMenu = FindViewById<TableLayout>(Resource.Id.tlMainMenu);
            tlSubmenu3 = FindViewById<TableLayout>(Resource.Id.tlSubmenu3);
            tlSubmenu2 = FindViewById<TableLayout>(Resource.Id.tlSubmenu2);

            btnRussian = FindViewById<Button>(Resource.Id.btnRussian);
            btnEnglish = FindViewById<Button>(Resource.Id.btnEnglish);

            btnSubmenu1 = FindViewById<Button>(Resource.Id.btnSubmenu1);
            btnSubmenu2 = FindViewById<Button>(Resource.Id.btnSubmenu2);
            tlSubmenu3 = FindViewById<TableLayout>(Resource.Id.tlSubmenu3);
            btnCancel = FindViewById<Button>(Resource.Id.btnCancel);
            btnExit = FindViewById<Button>(Resource.Id.btnExit);
            btnExitToMenu = FindViewById<Button>(Resource.Id.btnExitToMenu);

            //Играть занова при нажатии на кнопку в странице с результатом
            restartGame1 = FindViewById<Button>(Resource.Id.restartGame1);

            //Играть занова при нажатии на кнопку в странице с автором
            restartGame2 = FindViewById<Button>(Resource.Id.restartGame2);

            //Игрок
            tlSubmenu1 = FindViewById<TableLayout>(Resource.Id.tlSubmenu1);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            button3 = FindViewById<Button>(Resource.Id.button3);
            button4 = FindViewById<Button>(Resource.Id.button4);
            button5 = FindViewById<Button>(Resource.Id.button5);
            button6 = FindViewById<Button>(Resource.Id.button6);
            button7 = FindViewById<Button>(Resource.Id.button7);
            button8 = FindViewById<Button>(Resource.Id.button8);
            button9 = FindViewById<Button>(Resource.Id.button9);
            btnCancel1 = FindViewById<Button>(Resource.Id.btnCancel1);

            //Телефон
            tlComputerMenu = FindViewById<TableLayout>(Resource.Id.tlComputerMenu);
            computerButton1 = FindViewById<Button>(Resource.Id.computerButton1);
            computerButton2 = FindViewById<Button>(Resource.Id.computerButton2);
            computerButton3 = FindViewById<Button>(Resource.Id.computerButton3);
            computerButton4 = FindViewById<Button>(Resource.Id.computerButton4);
            computerButton5 = FindViewById<Button>(Resource.Id.computerButton5);
            computerButton6 = FindViewById<Button>(Resource.Id.computerButton6);
            computerButton7 = FindViewById<Button>(Resource.Id.computerButton7);
            computerButton8 = FindViewById<Button>(Resource.Id.computerButton8);
            computerButton9 = FindViewById<Button>(Resource.Id.computerButton9);
            btnCancel3 = FindViewById<Button>(Resource.Id.btnCancel3);


            //выход на странице с результатом
            btnCancel2 = FindViewById<Button>(Resource.Id.btnCancel2);

            //Победитель
            imageWinner = FindViewById<ImageView>(Resource.Id.imageWinner);
            textWinner = FindViewById<TextView>(Resource.Id.textWinner);
            gameName = FindViewById<TextView>(Resource.Id.gameName);
            developer = FindViewById<TextView>(Resource.Id.developer);

            btnRussian.Click += delegate {
                loadRussian();
                vf.SetInAnimation(this, Resource.Animation.slide_in_right); //анимация перехода в право
                vf.SetOutAnimation(this, Resource.Animation.slide_out_left); //анимация перехода на лево
                vf.DisplayedChild = vf.IndexOfChild(tlMainMenu);
            };

            btnEnglish.Click += delegate {
                loadEnglish();
                vf.SetInAnimation(this, Resource.Animation.slide_in_right); //анимация перехода в право
                vf.SetOutAnimation(this, Resource.Animation.slide_out_left); //анимация перехода на лево
                vf.DisplayedChild = vf.IndexOfChild(tlMainMenu);
            };

            //При клике на кнопку в меню Играть с телефоном
            btnSubmenu1.Click += delegate {
                computerPage = true; //страница с компьютером истина, чтобы знать какую страницу запустить
                loadButtons(); // загрузка функции кнопок
                vf.SetInAnimation(this, Resource.Animation.slide_in_right); //анимация перехода в право
                vf.SetOutAnimation(this, Resource.Animation.slide_out_left); //анимация перехода на лево
                vf.DisplayedChild = vf.IndexOfChild(tlComputerMenu); //переход на игру сетку с компьютером
                sigh = "X"; // начало с Х
                playerTurn = true; // игрок ходит истина
                computerTurn = false; // ход компьютера
                computerButton1.Text = ""; // 1 кнопка компьютера 
                computerButton2.Text = ""; // 2 кнопка компьютера
                computerButton3.Text = ""; // 3 кнопка компьютера
                computerButton4.Text = ""; // 4 кнопка компьютера
                computerButton5.Text = ""; // 5 кнопка компьютера
                computerButton6.Text = ""; // 6 кнопка компьютера
                computerButton7.Text = ""; // 7 кнопка компьютера
                computerButton8.Text = ""; // 8 кнопка компьютера
                computerButton9.Text = ""; // 9 кнопка компьютера
                computerButtons[0].Enabled = true; // 1 кнопка в массиве computerButtons включена
                computerButtons[1].Enabled = true; // 2 кнопка в массиве computerButtons включена
                computerButtons[2].Enabled = true; // 3 кнопка в массиве computerButtons включена
                computerButtons[3].Enabled = true; // 4 кнопка в массиве computerButtons включена
                computerButtons[4].Enabled = true; // 5 кнопка в массиве computerButtons включена
                computerButtons[5].Enabled = true; // 6 кнопка в массиве computerButtons включена
                computerButtons[6].Enabled = true; // 7 кнопка в массиве computerButtons включена
                computerButtons[7].Enabled = true; // 8 кнопка в массиве computerButtons включена
                computerButtons[8].Enabled = true; // 9 кнопка в массиве computerButtons включена
            };

            //При клике на кнопку в меню Играть в 2
            btnSubmenu2.Click += delegate {
                vf.SetInAnimation(this, Resource.Animation.slide_in_right);
                vf.SetOutAnimation(this, Resource.Animation.slide_out_left);
                vf.DisplayedChild = vf.IndexOfChild(tlSubmenu1); //переход на игру сетку с игроком
                computerPage = false; //страница с компьютером истина, чтобы знать какую страницу запустить
                sigh = "X"; // начало с Х
                button1.Text = ""; // 1 кнопка
                button2.Text = ""; // 2 кнопка
                button3.Text = ""; // 3 кнопка
                button4.Text = ""; // 4 кнопка
                button5.Text = ""; // 5 кнопка
                button6.Text = ""; // 6 кнопка
                button7.Text = ""; // 7 кнопка
                button8.Text = ""; // 8 кнопка
                button9.Text = ""; // 9 кнопка
            };

            //При клике на кнопку в меню Выход
            btnCancel.Click += delegate {
                vf.SetInAnimation(this, Resource.Animation.slide_in_right);
                vf.SetOutAnimation(this, Resource.Animation.slide_out_left);
                vf.DisplayedChild = vf.IndexOfChild(tlSubmenu3); //переход на 4 страницу об авторе
            };

            //При клике на кнопку в меню Играть в 2
            restartGame1.Click += delegate {
                if (computerPage == true)// если игра с компьютером, то переход на сетку с компьютером истина
                {
                    loadButtons();
                    vf.SetInAnimation(this, Resource.Animation.slide_in_right);
                    vf.SetOutAnimation(this, Resource.Animation.slide_out_left);
                    vf.DisplayedChild = vf.IndexOfChild(tlComputerMenu);
                    sigh = "X";
                    playerTurn = true;
                    computerTurn = false;
                    computerButton1.Text = "";
                    computerButton2.Text = "";
                    computerButton3.Text = "";
                    computerButton4.Text = "";
                    computerButton5.Text = "";
                    computerButton6.Text = "";
                    computerButton7.Text = "";
                    computerButton8.Text = "";
                    computerButton9.Text = "";
                    computerButtons[0].Enabled = true;
                    computerButtons[1].Enabled = true;
                    computerButtons[2].Enabled = true;
                    computerButtons[3].Enabled = true;
                    computerButtons[4].Enabled = true;
                    computerButtons[5].Enabled = true;
                    computerButtons[6].Enabled = true;
                    computerButtons[7].Enabled = true;
                    computerButtons[8].Enabled = true;
                } // если игра с компьютером false, то переход на сетку с игроком
                else
                {
                    vf.SetInAnimation(this, Resource.Animation.slide_in_right);
                    vf.SetOutAnimation(this, Resource.Animation.slide_out_left);
                    vf.DisplayedChild = vf.IndexOfChild(tlSubmenu1);
                    sigh = "X"; // начало с Х
                    button1.Text = ""; // 1 кнопка
                    button2.Text = ""; // 2 кнопка
                    button3.Text = ""; // 3 кнопка
                    button4.Text = ""; // 4 кнопка
                    button5.Text = ""; // 5 кнопка
                    button6.Text = ""; // 6 кнопка
                    button7.Text = ""; // 7 кнопка
                    button8.Text = ""; // 8 кнопка
                    button9.Text = ""; // 9 кнопка
                }
            };

            //При клике на кнопку Играть снова на 4 странице об авторе
            restartGame2.Click += delegate {
                if (computerPage == true) // если игра с компьютером, то переход на сетку с компьютером истина
                {
                    loadButtons();
                    vf.SetInAnimation(this, Resource.Animation.slide_in_right);
                    vf.SetOutAnimation(this, Resource.Animation.slide_out_left);
                    vf.DisplayedChild = vf.IndexOfChild(tlComputerMenu);
                    sigh = "X";
                    playerTurn = true;
                    computerTurn = false;
                    computerButton1.Text = "";
                    computerButton2.Text = "";
                    computerButton3.Text = "";
                    computerButton4.Text = "";
                    computerButton5.Text = "";
                    computerButton6.Text = "";
                    computerButton7.Text = "";
                    computerButton8.Text = "";
                    computerButton9.Text = "";
                    computerButtons[0].Enabled = true;
                    computerButtons[1].Enabled = true;
                    computerButtons[2].Enabled = true;
                    computerButtons[3].Enabled = true;
                    computerButtons[4].Enabled = true;
                    computerButtons[5].Enabled = true;
                    computerButtons[6].Enabled = true;
                    computerButtons[7].Enabled = true;
                    computerButtons[8].Enabled = true;
                }// если игра с компьютером false, то переход на сетку с игроком
                else
                {
                    vf.SetInAnimation(this, Resource.Animation.slide_in_right);
                    vf.SetOutAnimation(this, Resource.Animation.slide_out_left);
                    vf.DisplayedChild = vf.IndexOfChild(tlSubmenu1);
                    sigh = "X"; // начало с Х
                    button1.Text = ""; // 1 кнопка
                    button2.Text = ""; // 2 кнопка
                    button3.Text = ""; // 3 кнопка
                    button4.Text = ""; // 4 кнопка
                    button5.Text = ""; // 5 кнопка
                    button6.Text = ""; // 6 кнопка
                    button7.Text = ""; // 7 кнопка
                    button8.Text = ""; // 8 кнопка
                    button9.Text = ""; // 9 кнопка
                }
            };

            //При клике на кнопку Выход в меню, выходит на 1 страницу в меню
            btnExitToMenu.Click += delegate {
                vf.SetInAnimation(this, Resource.Animation.slide_in_left);
                vf.SetOutAnimation(this, Resource.Animation.slide_out_right);
                vf.DisplayedChild = vf.IndexOfChild(tlMainMenu);
            };

            //При клике на кнопку Выход на странице с игроком, выходит на 4 страницу об авторе
            btnCancel1.Click += delegate {
                vf.SetInAnimation(this, Resource.Animation.slide_in_left);
                vf.SetOutAnimation(this, Resource.Animation.slide_out_right);
                vf.DisplayedChild = vf.IndexOfChild(tlMainMenu);
                sigh = "X"; // начало с Х
                button1.Text = ""; // 1 кнопка
                button2.Text = ""; // 2 кнопка
                button3.Text = ""; // 3 кнопка
                button4.Text = ""; // 4 кнопка
                button5.Text = ""; // 5 кнопка
                button6.Text = ""; // 6 кнопка
                button7.Text = ""; // 7 кнопка
                button8.Text = ""; // 8 кнопка
                button9.Text = ""; // 9 кнопка
            };

            //При клике на кнопку Выход на странице с результатом, выходит на 4 страницу об авторе
            btnCancel2.Click += delegate {
                vf.SetInAnimation(this, Resource.Animation.slide_in_left);
                vf.SetOutAnimation(this, Resource.Animation.slide_out_right);
                vf.DisplayedChild = vf.IndexOfChild(tlMainMenu);
            };

            //При клике на кнопку Выход на странице с компьютером, выходит на 4 страницу об авторе
            btnCancel3.Click += delegate {
                vf.SetInAnimation(this, Resource.Animation.slide_in_left);
                vf.SetOutAnimation(this, Resource.Animation.slide_out_right);
                vf.DisplayedChild = vf.IndexOfChild(tlMainMenu);
            };
            btnExit.Click += delegate { //Выход из приложения на 4 странице с автором
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            };




            //Игра с игроком
            //При клике на 1 кнопку в сетке с игроком
            button1.Click += delegate {
                if (sigh == "X" && button1.Text == "") // если переменная равна Х и кнопка пустая
                {
                    button1.Text = string.Format("X"); //вписываем в текст кнопки Х
                    sigh = "0"; // присваиваем перемнной 0
                    imageWinner.SetImageResource(Resource.Drawable.x); // картинку на 3 странице с результатами поставить победителя картинку Х
                }
                else if (button1.Text != "") // если кнопка не пустая то ничего не делаем
                {

                }
                else // если переменная sigh равна 0
                {
                    button1.Text = string.Format("O"); // вписываем в текст кнопки О
                    sigh = "X"; // присваиваем перемнной Х
                    imageWinner.SetImageResource(Resource.Drawable.o); // картинку на 3 странице с результатами поставить победителя картинку О
                }

                checkForWinnerWithPlayer(); // запуск функции проверки выигрыша
                if (thereIsAWinner != "nobody") // если функция checkForWinnerWithPlayer() нашла победителя, то
                {
                    goNext(); //запуск функции результатов
                }
                else //если функция функция checkForWinnerWithPlayer() не нашла победителя, то
                {
                    draw(); //запуск функции ничьи
                }
            };

            //При клике на 2 кнопку в сетке с игроком
            button2.Click += delegate {
                if (sigh == "X" && button2.Text == "")
                {
                    button2.Text = string.Format("X");
                    sigh = "0";
                    imageWinner.SetImageResource(Resource.Drawable.x);
                }
                else if (button2.Text != "")
                {

                }
                else
                {
                    button2.Text = string.Format("O");
                    sigh = "X";
                    imageWinner.SetImageResource(Resource.Drawable.o);
                }

                checkForWinnerWithPlayer();
                if (thereIsAWinner != "nobody")
                {
                    goNext();
                }
                else
                {
                    draw();
                }

            };

            //При клике на 3 кнопку в сетке с игроком
            button3.Click += delegate {
                if (sigh == "X" && button3.Text == "")
                {
                    button3.Text = string.Format("X");
                    sigh = "0";
                    imageWinner.SetImageResource(Resource.Drawable.x);
                }
                else if (button3.Text != "")
                {

                }
                else
                {
                    button3.Text = string.Format("O");
                    sigh = "X";
                    imageWinner.SetImageResource(Resource.Drawable.o);
                }

                checkForWinnerWithPlayer();
                if (thereIsAWinner != "nobody")
                {
                    goNext();
                }
                else
                {
                    draw();
                }

            };

            //При клике на 4 кнопку в сетке с игроком
            button4.Click += delegate {
                if (sigh == "X" && button4.Text == "")
                {
                    button4.Text = string.Format("X");
                    sigh = "0";
                    imageWinner.SetImageResource(Resource.Drawable.x);
                }
                else if (button4.Text != "")
                {

                }
                else
                {
                    button4.Text = string.Format("O");
                    sigh = "X";
                    imageWinner.SetImageResource(Resource.Drawable.o);
                }

                checkForWinnerWithPlayer();
                if (thereIsAWinner != "nobody")
                {
                    goNext();
                }
                else
                {
                    draw();
                }

            };

            //При клике на 5 кнопку в сетке с игроком
            button5.Click += delegate {
                if (sigh == "X" && button5.Text == "")
                {
                    button5.Text = string.Format("X");
                    sigh = "0";
                    imageWinner.SetImageResource(Resource.Drawable.x);
                }
                else if (button5.Text != "")
                {

                }
                else
                {
                    button5.Text = string.Format("O");
                    sigh = "X";
                    imageWinner.SetImageResource(Resource.Drawable.o);
                }
                checkForWinnerWithPlayer();
                if (thereIsAWinner != "nobody")
                {
                    goNext();
                }
                else
                {
                    draw();
                }

            };

            //При клике на 6 кнопку в сетке с игроком
            button6.Click += delegate {
                if (sigh == "X" && button6.Text == "")
                {
                    button6.Text = string.Format("X");
                    sigh = "0";
                    imageWinner.SetImageResource(Resource.Drawable.x);
                }
                else if (button6.Text != "")
                {

                }
                else
                {
                    button6.Text = string.Format("O");
                    sigh = "X";
                    imageWinner.SetImageResource(Resource.Drawable.o);
                }
                checkForWinnerWithPlayer();
                if (thereIsAWinner != "nobody")
                {
                    goNext();
                }
                else
                {
                    draw();
                }

            };

            //При клике на 7 кнопку в сетке с игроком
            button7.Click += delegate {
                if (sigh == "X" && button7.Text == "")
                {
                    button7.Text = string.Format("X");
                    sigh = "0";
                    imageWinner.SetImageResource(Resource.Drawable.x);
                }
                else if (button7.Text != "")
                {

                }
                else
                {
                    button7.Text = string.Format("O");
                    sigh = "X";
                    imageWinner.SetImageResource(Resource.Drawable.o);
                }
                checkForWinnerWithPlayer();
                if (thereIsAWinner != "nobody")
                {
                    goNext();
                }
                else
                {
                    draw();
                }

            };

            //При клике на 8 кнопку в сетке с игроком
            button8.Click += delegate {
                if (sigh == "X" && button8.Text == "")
                {
                    button8.Text = string.Format("X");
                    sigh = "0";
                    imageWinner.SetImageResource(Resource.Drawable.x);
                }
                else if (button8.Text != "")
                {

                }
                else
                {
                    button8.Text = string.Format("O");
                    sigh = "X";
                    imageWinner.SetImageResource(Resource.Drawable.o);
                }
                checkForWinnerWithPlayer();
                if (thereIsAWinner != "nobody")
                {
                    goNext();
                }
                else
                {
                    draw();
                }

            };

            //При клике на 9 кнопку в сетке с игроком
            button9.Click += delegate {
                if (sigh == "X" && button9.Text == "")
                {
                    button9.Text = string.Format("X");
                    sigh = "0";
                    imageWinner.SetImageResource(Resource.Drawable.x);
                }
                else if (button9.Text != "")
                {

                }
                else
                {
                    button9.Text = string.Format("O");
                    sigh = "X";
                    imageWinner.SetImageResource(Resource.Drawable.o);
                }
                checkForWinnerWithPlayer();
                if (thereIsAWinner != "nobody")
                {
                    goNext();
                }
                else
                {
                    draw();
                }

            };
            //Конец кнопок игры с игроком

            //Игра с компьютером

            //При клике на 1 кнопку в сетке с компьютером
            computerButton1.Click += delegate
            {
                if (playerTurn == true) // если ход игрока истина, то
                {
                    if (sigh == "X" && computerButtons[0].Text == "") // если переменная равна Х и 1 кнопка в массиве computerButtons пустая
                    {
                        sigh = "0"; // присваиваем переменной sigh 0
                        computerButtons[0].Text = string.Format("X"); //вписываем в текст 1 кнопки в массиве computerButtons Х
                        imageWinner.SetImageResource(Resource.Drawable.x); // картинку на 3 странице с результатами поставить победителя картинку Х
                        //computerButtons[0].Enabled = false; // выключить 1 кнопку в массиве computerButtons
                        computerButtons.RemoveAt(0); // убрать из массива computerButtons 1 кнопку, чтобы компьютер больше не мог использовать ее
                    }
                    else if (computerButtons[0].Text != "") // если 1 кнопка в массиве computerButtons не пустая, то ничего не делаем
                    {

                    }

                    checkForWinnerWithComputer(); // запуск функции проверки выигрыша с компьютером
                    if (thereIsAWinner != "nobody") // если функция checkForWinnerWithPlayer() нашла победителя, то
                    {
                        goNextComputer(); // запуск функции результатов
                    }
                    else
                    {
                        computerDraw(); //запуск функции ничьей с компьютером
                    }
                }
                playerTurn = false; // ход игрока false
                computerTurn = true; // ход компьюетра истина
                ComputerMove(); // запуск функции для хода компьютера
            };

            //При клике на 2 кнопку в сетке с компьютером
            computerButton2.Click += delegate
            {
                if (playerTurn == true)
                {
                    if (sigh == "X" && computerButtons[1].Text == "")
                    {
                        sigh = "0";
                        computerButtons[1].Text = string.Format("X");
                        imageWinner.SetImageResource(Resource.Drawable.x);
                        //computerButtons[1].Enabled = false;
                        computerButtons.RemoveAt(1);
                    }
                    else if (computerButtons[1].Text != "")
                    {

                    }

                    checkForWinnerWithComputer();
                    if (thereIsAWinner != "nobody")
                    {
                        goNextComputer();
                    }
                    else
                    {
                        computerDraw();
                    }
                }
                playerTurn = false;
                computerTurn = true;
                ComputerMove();
            };

            //При клике на 3 кнопку в сетке с компьютером
            computerButton3.Click += delegate
            {
                if (playerTurn == true)
                {
                    if (sigh == "X" && computerButtons[2].Text == "")
                    {
                        sigh = "0";
                        computerButtons[2].Text = string.Format("X");
                        imageWinner.SetImageResource(Resource.Drawable.x);
                        //computerButtons[2].Enabled = false;
                        computerButtons.RemoveAt(2);
                    }
                    else if (computerButtons[2].Text != "")
                    {

                    }

                    checkForWinnerWithComputer();
                    if (thereIsAWinner != "nobody")
                    {
                        goNextComputer();
                    }
                    else
                    {
                        computerDraw();
                    }
                }
                playerTurn = false;
                computerTurn = true;
                ComputerMove();
            };

            //При клике на 4 кнопку в сетке с компьютером
            computerButton4.Click += delegate
            {
                if (playerTurn == true)
                {
                    if (sigh == "X" && computerButtons[3].Text == "")
                    {
                        sigh = "0";
                        computerButtons[3].Text = string.Format("X");
                        imageWinner.SetImageResource(Resource.Drawable.x);
                        //computerButtons[3].Enabled = false;
                        computerButtons.RemoveAt(3);
                    }
                    else if (computerButtons[3].Text != "")
                    {

                    }

                    checkForWinnerWithComputer();
                    if (thereIsAWinner != "nobody")
                    {
                        goNextComputer();
                    }
                    else
                    {
                        computerDraw();
                    }
                }
                playerTurn = false;
                computerTurn = true;
                ComputerMove();
            };

            //При клике на 5 кнопку в сетке с компьютером
            computerButton5.Click += delegate
            {
                if (playerTurn == true)
                {
                    if (sigh == "X" && computerButtons[4].Text == "")
                    {
                        sigh = "0";
                        computerButtons[4].Text = string.Format("X");
                        imageWinner.SetImageResource(Resource.Drawable.x);
                        //computerButtons[4].Enabled = false;
                        computerButtons.RemoveAt(4);
                    }
                    else if (computerButtons[4].Text != "")
                    {

                    }

                    checkForWinnerWithComputer();
                    if (thereIsAWinner != "nobody")
                    {
                        goNextComputer();
                    }
                    else
                    {
                        computerDraw();
                    }
                }
                playerTurn = false;
                computerTurn = true;
                ComputerMove();
            };

            //При клике на 6 кнопку в сетке с компьютером
            computerButton6.Click += delegate
            {
                if (playerTurn == true)
                {
                    if (sigh == "X" && computerButtons[5].Text == "")
                    {
                        sigh = "0";
                        computerButtons[5].Text = string.Format("X");
                        imageWinner.SetImageResource(Resource.Drawable.x);
                        //computerButtons[5].Enabled = false;
                        computerButtons.RemoveAt(5);
                    }
                    else if (computerButtons[5].Text != "")
                    {

                    }

                    checkForWinnerWithComputer();
                    if (thereIsAWinner != "nobody")
                    {
                        goNextComputer();
                    }
                    else
                    {
                        computerDraw();
                    }
                }
                playerTurn = false;
                computerTurn = true;
                ComputerMove();
            };

            //При клике на 7 кнопку в сетке с компьютером
            computerButton7.Click += delegate
            {
                if (playerTurn == true)
                {
                    if (sigh == "X" && computerButtons[6].Text == "")
                    {
                        sigh = "0";
                        computerButtons[6].Text = string.Format("X");
                        imageWinner.SetImageResource(Resource.Drawable.x);
                        //computerButtons[6].Enabled = false;
                        computerButtons.RemoveAt(6);
                    }
                    else if (computerButtons[6].Text != "")
                    {

                    }

                    checkForWinnerWithComputer();
                    if (thereIsAWinner != "nobody")
                    {
                        goNextComputer();
                    }
                    else
                    {
                        computerDraw();
                    }
                }
                playerTurn = false;
                computerTurn = true;
                ComputerMove();
            };

            //При клике на 8 кнопку в сетке с компьютером
            computerButton8.Click += delegate
            {
                if (playerTurn == true)
                {
                    if (sigh == "X" && computerButtons[7].Text == "")
                    {
                        sigh = "0";
                        computerButtons[7].Text = string.Format("X");
                        imageWinner.SetImageResource(Resource.Drawable.x);
                        //computerButtons[7].Enabled = false;
                        computerButtons.RemoveAt(7);
                    }
                    else if (computerButtons[7].Text != "")
                    {

                    }

                    checkForWinnerWithComputer();
                    if (thereIsAWinner != "nobody")
                    {
                        goNextComputer();
                    }
                    else
                    {
                        computerDraw();
                    }
                }
                playerTurn = false;
                computerTurn = true;
                ComputerMove();
            };

            //При клике на 9 кнопку в сетке с компьютером
            computerButton9.Click += delegate
            {
                if (playerTurn == true)
                {
                    if (sigh == "X" && computerButtons[8].Text == "")
                    {;
                        sigh = "0";
                        computerButtons[8].Text = string.Format("X");
                        imageWinner.SetImageResource(Resource.Drawable.x);
                        //computerButtons[8].Enabled = false;
                        computerButtons.RemoveAt(8);
                    }
                    else if(computerButtons[8].Text != "")
                    {

                    }

                    checkForWinnerWithComputer();
                    if (thereIsAWinner != "nobody")
                    {
                        goNextComputer();
                    }
                    else
                    {
                        computerDraw();
                    }
                }
                playerTurn = false;
                computerTurn = true;
                ComputerMove();
            };


            //Функции с сеткой с компьютером

            void loadButtons() // функция с массивом кнопок для игры с компьютером
            {
                computerButtons = new List<Button> { computerButton1, computerButton2, computerButton3, computerButton4, computerButton5, computerButton6, computerButton7, computerButton8, computerButton9 }; //в массив computerButtons добавляем все 9 кнопок с игрой компьютером
            }

            void ComputerMove() // функция для хода компьютера
            {
                if (computerTurn == true) // если ход компьютера истина, то
                {
                    if (sigh == "0" && computerButtons.Count > 0) // если переменная sigh  равна 0 и кнопок в массиве computerButtons не ноль
                    {
                        randomMove(); // запуск функции генерации рандомных ходов копмьютера в оставшиеся пустые кнопки

                        void randomMove() // функция генерации рандомных ходов копмьютера в оставшиеся пустые кнопки
                        {
                            int index = random.Next(0, 8); // переменная index с рандомными числами от 0 до 8

                            if (index == 0 && computerButtons.Contains(computerButton1)) // если переменная index равна 0 и в массиве кнопок computerButtons существует 1 кнопка из сетки игры с компьютером
                            {
                                if (computerButtons[0].Text == "") // если 1 кнопка в массиве computerButtons пустая, то
                                {
                                    sigh = "X"; //присваиваем переменной sigh Х
                                    computerButtons[0].Text = string.Format("O"); //на 1 кнопка в массиве computerButtons ставим текст с О
                                    imageWinner.SetImageResource(Resource.Drawable.o); // картинку на 3 странице с результатами поставить победителя картинку О
                                    //computerButtons[0].Enabled = false; // выключаем 1 кнопку в массиве computerButtons, чтобы больше не нажимать
                                    computerButtons.RemoveAt(0); // удаляем из массива с кнопками computerButtons 1 кнопку
                                    computerTurn = false; // ход компьютера false
                                    playerTurn = true; // ход игрока истина
                                }
                                else // если 1 кнопка в массиве computerButtons не пустая, то
                                {
                                    randomMove(); //запускаем функцию сначала
                                }

                            }
                            else if (index == 1 && computerButtons.Contains(computerButton2))
                            {
                                if (computerButtons[1].Text == "")
                                {
                                    sigh = "X";
                                    computerButtons[1].Text = string.Format("O");
                                    imageWinner.SetImageResource(Resource.Drawable.o);
                                    //computerButtons[1].Enabled = false;
                                    computerButtons.RemoveAt(1);
                                    computerTurn = false;
                                    playerTurn = true;
                                }
                                else
                                {
                                    randomMove();
                                }

                            }
                            else if (index == 2 && computerButtons.Contains(computerButton3))
                            {
                                if (computerButtons[2].Text == "")
                                {
                                    sigh = "X";
                                    computerButtons[2].Text = string.Format("O");
                                    imageWinner.SetImageResource(Resource.Drawable.o);
                                    //computerButtons[2].Enabled = false;
                                    computerButtons.RemoveAt(2);
                                    computerTurn = false;
                                    playerTurn = true;
                                }
                                else
                                {
                                    randomMove();
                                }
                            }
                            else if (index == 3 && computerButtons.Contains(computerButton4))
                            {
                                if (computerButtons[3].Text == "")
                                {
                                    sigh = "X";
                                    computerButtons[3].Text = string.Format("O");
                                    imageWinner.SetImageResource(Resource.Drawable.o);
                                    //computerButtons[3].Enabled = false;
                                    computerButtons.RemoveAt(3);
                                    computerTurn = false;
                                    playerTurn = true;
                                }
                                else
                                {
                                    randomMove();
                                }
                            }
                            else if (index == 4 && computerButtons.Contains(computerButton5))
                            {
                                if (computerButtons[4].Text == "")
                                {
                                    sigh = "X";
                                    computerButtons[4].Text = string.Format("O");
                                    imageWinner.SetImageResource(Resource.Drawable.o);
                                    //computerButtons[4].Enabled = false;
                                    computerButtons.RemoveAt(4);
                                    computerTurn = false;
                                    playerTurn = true;
                                }
                                else
                                {
                                    randomMove();
                                }

                            }
                            else if (index == 5 && computerButtons.Contains(computerButton6))
                            {
                                if (computerButtons[5].Text == "")
                                {
                                    sigh = "X";
                                    computerButtons[5].Text = string.Format("O");
                                    imageWinner.SetImageResource(Resource.Drawable.o);
                                    //computerButtons[5].Enabled = false;
                                    computerButtons.RemoveAt(5);
                                    computerTurn = false;
                                    playerTurn = true;
                                }
                                else
                                {
                                    randomMove();
                                }
                            }
                            else if (index == 6 && computerButtons.Contains(computerButton7))
                            {
                                if (computerButtons[6].Text == "")
                                {
                                    sigh = "X";
                                    computerButtons[6].Text = string.Format("O");
                                    imageWinner.SetImageResource(Resource.Drawable.o);
                                    //computerButtons[6].Enabled = false;
                                    computerButtons.RemoveAt(6);
                                    computerTurn = false;
                                    playerTurn = true;
                                }
                                else
                                {
                                    randomMove();
                                }
                            }
                            else if (index == 7 && computerButtons.Contains(computerButton8))
                            {
                                if (computerButtons[7].Text == "")
                                {
                                    sigh = "X";
                                    computerButtons[7].Text = string.Format("O");
                                    imageWinner.SetImageResource(Resource.Drawable.o);
                                    //computerButtons[7].Enabled = false;
                                    computerButtons.RemoveAt(7);
                                    computerTurn = false;
                                    playerTurn = true;
                                }
                                else
                                {
                                    randomMove();
                                }

                            }
                            else if (index == 8 && computerButtons.Contains(computerButton9))
                            {
                                if (computerButtons[8].Text == "")
                                {
                                    sigh = "X";
                                    computerButtons[8].Text = string.Format("O");
                                    imageWinner.SetImageResource(Resource.Drawable.o);
                                    //computerButtons[8].Enabled = false;
                                    computerButtons.RemoveAt(8);
                                    computerTurn = false;
                                    playerTurn = true;
                                }
                                else
                                {
                                    randomMove();
                                }
                            } // если переменная index не равна 0-8 и в массиве кнопок computerButtons не существует этой кнопки из сетки игры с компьютером, то ничего не делаем
                            else
                            {

                            }
                        }//конец функции randomMove()
                        
                        checkForWinnerWithComputer(); // запуск функции проверки победителя с компьютером
                            if (thereIsAWinner != "nobody") // если функция checkForWinnerWithComputer() нашла победителя, то
                            {
                                goNextComputer(); //запуск функции результатов с компьютером
                            }
                            else
                            {
                                computerDraw(); //запуск функции ничьей с компьютером
                            }

                    }
                }
            }

            void checkForWinnerWithComputer() // функция проверки победителя с компьютером
            {
                /*---*/
                // проверка результатов горизонтально
                if (((computerButton1.Text == computerButton2.Text) && computerButton1.Text != "" && computerButton2.Text != "") && ((computerButton2.Text == computerButton3.Text) && computerButton2.Text != "" && computerButton3.Text != ""))
                {
                    thereIsAWinner = computerButton1.Text; // присваиваем переменной thereIsAWinner победителя

                }
                else if (((computerButton4.Text == computerButton5.Text) && computerButton4.Text != "" && computerButton5.Text != "") && ((computerButton5.Text == computerButton6.Text) && computerButton5.Text != "" && computerButton6.Text != ""))
                {
                    thereIsAWinner = computerButton4.Text; // присваиваем переменной thereIsAWinner победителя
                }
                else if (((computerButton7.Text == computerButton8.Text) && computerButton7.Text != "" && computerButton8.Text != "") && ((computerButton8.Text == computerButton9.Text) && computerButton8.Text != "" && computerButton9.Text != ""))
                {
                    thereIsAWinner = computerButton7.Text; // присваиваем переменной thereIsAWinner победителя
                }

                /*-
                  -
                  -*/
                // проверка результатов вертикально
                else if (((computerButton1.Text == computerButton4.Text) && computerButton1.Text != "" && computerButton4.Text != "") && ((computerButton4.Text == computerButton7.Text) && computerButton4.Text != "" && computerButton7.Text != ""))
                {
                    thereIsAWinner = computerButton1.Text; // присваиваем переменной thereIsAWinner победителя
                }
                else if (((computerButton2.Text == computerButton5.Text) && computerButton2.Text != "" && computerButton5.Text != "") && ((computerButton5.Text == computerButton8.Text) && computerButton5.Text != "" && computerButton8.Text != ""))
                {
                    thereIsAWinner = computerButton2.Text; // присваиваем переменной thereIsAWinner победителя
                }
                else if (((computerButton3.Text == computerButton6.Text) && computerButton3.Text != "" && computerButton6.Text != "") && ((computerButton6.Text == computerButton9.Text) && computerButton6.Text != "" && computerButton9.Text != ""))
                {
                    thereIsAWinner = computerButton3.Text; // присваиваем переменной thereIsAWinner победителя
                }
                /*-
                    -
                       -*/
                // проверка результатов диагонально
                else if (((computerButton1.Text == computerButton5.Text) && computerButton1.Text != "" && computerButton5.Text != "") && ((computerButton5.Text == computerButton9.Text) && computerButton5.Text != "" && computerButton9.Text != ""))
                {
                    thereIsAWinner = computerButton1.Text; // присваиваем переменной thereIsAWinner победителя
                }
                else if (((computerButton7.Text == computerButton5.Text) && computerButton7.Text != "" && computerButton5.Text != "") && ((computerButton5.Text == computerButton3.Text) && computerButton5.Text != "" && computerButton3.Text != ""))
                {
                    thereIsAWinner = computerButton1.Text; // присваиваем переменной thereIsAWinner победителя
                }
                else //если из победителей никого нет, то
                {
                    thereIsAWinner = "nobody"; // переменной thereIsWinner присваиваем nobody
                }



            } // конец функции проверки победителя с компьютером

            void goNextComputer() // функция результатов с компьютером
            {
                if (thereIsAWinner != "nobody") // если нашел победителя, то
                {
                    vf.SetInAnimation(this, Resource.Animation.slide_in_right);
                    vf.SetOutAnimation(this, Resource.Animation.slide_out_left);
                    vf.DisplayedChild = vf.IndexOfChild(tlSubmenu2); // переход на страницу с результатами

                    //textWinner.Text = "Победитель"; // текст на странице с результатами = Победитель
                    if (onRussian == true)
                    {
                        textWinner.Text = "Победитель";
                    }
                    else if (onEnglish == true)
                    {
                        textWinner.Text = "Winner";
                    }
                    sigh = "X"; // присваиваем переменной sigh Х
                    computerPage = true; // страница с игрой компьютера равна истине
                    playerTurn = true; // ход игрока истина
                    computerTurn = false; // ход компьютера false

                    //текст на кнопке ставим пустым
                    computerButton1.Text = "";
                    computerButton2.Text = "";
                    computerButton3.Text = "";
                    computerButton4.Text = "";
                    computerButton5.Text = "";
                    computerButton6.Text = "";
                    computerButton7.Text = "";
                    computerButton8.Text = "";
                    computerButton9.Text = "";
                }
                loadButtons(); // запуск функции с массивом кнопок для игры с компьютером
            } //конец функции результатов с компьютером

            void computerDraw() //функция ничьей с компьютером
            {
                //если текст на кнопках с игрой компьютера не пустые, то
                if (computerButton1.Text != "" && computerButton2.Text != "" && computerButton3.Text != "" && computerButton4.Text != "" && computerButton5.Text != "" && computerButton6.Text != "" && computerButton7.Text != "" && computerButton8.Text != "" && computerButton9.Text != "")
                {
                    vf.SetInAnimation(this, Resource.Animation.slide_in_right);
                    vf.SetOutAnimation(this, Resource.Animation.slide_out_left);
                    vf.DisplayedChild = vf.IndexOfChild(tlSubmenu2);

                    sigh = "X"; // присваиваем переменной sigh Х
                    //textWinner.Text = "Ничья"; // текст на странице с результатами = Ничьей
                    if (onRussian == true)
                    {
                        textWinner.Text = "Ничья";
                    }
                    else if (onEnglish == true)
                    {
                        textWinner.Text = "Draw";
                    }
                    imageWinner.SetImageResource(Resource.Drawable.draw); // картинку на 3 странице с результатами поставить картинку Ничьей
                    computerPage = true; // страница с игрой компьютера равна истине
                    playerTurn = true; // ход игрока истина
                    computerTurn = false; // ход компьютера false

                    //текст на кнопке ставим пустым
                    computerButton1.Text = "";
                    computerButton2.Text = "";
                    computerButton3.Text = "";
                    computerButton4.Text = "";
                    computerButton5.Text = "";
                    computerButton6.Text = "";
                    computerButton7.Text = "";
                    computerButton8.Text = "";
                    computerButton9.Text = "";
                }
                loadButtons(); // запуск функции с массивом кнопок для игры с компьютером
            } // конец функции ничьей с компьютером


            /*                     Функции с сеткой с игроком                        */
            void checkForWinnerWithPlayer()
            {
                /*---*/
                if (((button1.Text == button2.Text) && button1.Text != "" && button2.Text != "") && ((button2.Text == button3.Text) && button2.Text != "" && button3.Text != ""))
                {
                    thereIsAWinner = button1.Text;

                } else if (((button4.Text == button5.Text) && button4.Text != "" && button5.Text != "") && ((button5.Text == button6.Text) && button5.Text != "" && button6.Text != ""))
                {
                    thereIsAWinner = button4.Text;
                } else if (((button7.Text == button8.Text) && button7.Text != "" && button8.Text != "") && ((button8.Text == button9.Text) && button8.Text != "" && button9.Text != ""))
                {
                    thereIsAWinner = button7.Text;
                }
                /*-
                  -
                  -*/
                else if (((button1.Text == button4.Text) && button1.Text != "" && button4.Text != "") && ((button4.Text == button7.Text) && button4.Text != "" && button7.Text != ""))
                {
                    thereIsAWinner = button1.Text;
                }
                else if (((button2.Text == button5.Text) && button2.Text != "" && button5.Text != "") && ((button5.Text == button8.Text) && button5.Text != "" && button8.Text != ""))
                {
                    thereIsAWinner = button2.Text;
                }
                else if (((button3.Text == button6.Text) && button3.Text != "" && button6.Text != "") && ((button6.Text == button9.Text) && button6.Text != "" && button9.Text != ""))
                {
                    thereIsAWinner = button3.Text;
                }
                /*-
                    -
                       -*/
                else if (((button1.Text == button5.Text) && button1.Text != "" && button5.Text != "") && ((button5.Text == button9.Text) && button5.Text != "" && button9.Text != ""))
                {
                    thereIsAWinner = button1.Text;
                }
                else if (((button7.Text == button5.Text) && button7.Text != "" && button5.Text != "") && ((button5.Text == button3.Text) && button5.Text != "" && button3.Text != ""))
                {
                    thereIsAWinner = button1.Text;
                }
                else
                {
                    thereIsAWinner = "nobody";
                }


           
            }

            void draw()
            {
                if (button1.Text != "" && button2.Text != "" && button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "" && thereIsAWinner == "nobody")
                {
                    vf.SetInAnimation(this, Resource.Animation.slide_in_right);
                    vf.SetOutAnimation(this, Resource.Animation.slide_out_left);
                    vf.DisplayedChild = vf.IndexOfChild(tlSubmenu2);

                    sigh = "X";
                    if (onRussian == true)
                    {
                        textWinner.Text = "Ничья";
                    }
                    else if (onEnglish == true)
                    {
                        textWinner.Text = "Draw";
                    }
                    imageWinner.SetImageResource(Resource.Drawable.draw);
                    computerPage = false;

                    button1.Text = "";
                    button2.Text = "";
                    button3.Text = "";
                    button4.Text = "";
                    button5.Text = "";
                    button6.Text = "";
                    button7.Text = "";
                    button8.Text = "";
                    button9.Text = "";
                }
            }

            void goNext()
            {
                if (thereIsAWinner != "nobody")
                {
                    vf.SetInAnimation(this, Resource.Animation.slide_in_right);
                    vf.SetOutAnimation(this, Resource.Animation.slide_out_left);
                    vf.DisplayedChild = vf.IndexOfChild(tlSubmenu2);

                    if (onRussian == true)
                    {
                        textWinner.Text = "Победитель";
                    }
                    else if(onEnglish == true)
                    {
                        textWinner.Text = "Winner";
                    }
                    sigh = "X";
                    computerPage = false;

                    button1.Text = "";
                    button2.Text = "";
                    button3.Text = "";
                    button4.Text = "";
                    button5.Text = "";
                    button6.Text = "";
                    button7.Text = "";
                    button8.Text = "";
                    button9.Text = "";
                }
            }

            void loadRussian()
            {
                onRussian = true;
                gameName.Text = "Крестики-Нолики";
                btnSubmenu1.Text = "Играть с телефоном";
                btnSubmenu2.Text = "Играть в 2";
                btnCancel.Text = "Выход";
                btnCancel1.Text = "Выход";
                btnCancel2.Text = "Выход";
                btnCancel3.Text = "Выход";
                restartGame1.Text = "Повторить игру";
                developer.Text = "Разработчик";
                restartGame2.Text = "Играть снова";
                btnExitToMenu.Text = "Выход в меню";
                btnExit.Text = "Выход из игры";
            }

            void loadEnglish()
            {
                onEnglish = true;
                gameName.Text = "Tic-Tac-Toe";
                btnSubmenu1.Text = "Play with telephone";
                btnSubmenu2.Text = "Play with friend";
                btnCancel.Text = "Exit";
                btnCancel1.Text = "Exit";
                btnCancel2.Text = "Exit";
                btnCancel3.Text = "Exit";
                restartGame1.Text = "Repeat game";
                developer.Text = "Developer";
                restartGame2.Text = "Play again";
                btnExitToMenu.Text = "Exit to menu";
                btnExit.Text = "Exit game";
            }
        }

    }
}
