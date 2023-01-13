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
using System.Windows.Shapes;

namespace Calc
{
    public partial class Qadr : Window
    {

        public bool confirm = false;
        public string currentBox;
        public string text;
        public string A_coef;
        public string B_coef;
        public string C_coef;
        List<List<string>> keys = new List<List<string>>();
        List<List<string>> tip_list = new List<List<string>>();

        public void KeyInit()
        {
            List<string> list_zero = new List<string>();
            List<string> tip_zero = new List<string>();
            list_zero.Add("7"); tip_zero.Add("7");
            list_zero.Add("8"); tip_zero.Add("8");
            list_zero.Add("9"); tip_zero.Add("9");


            // 7, 8, 9, 
            List<string> list_one = new List<string>();
            List<string> tip_one = new List<string>();
            list_one.Add("4"); tip_one.Add("4");
            list_one.Add("5"); tip_one.Add("5");
            list_one.Add("6"); tip_one.Add("6");


            // 4, 5, 6, 
            List<string> list_two = new List<string>();
            List<string> tip_two = new List<string>();
            list_two.Add("1"); tip_two.Add("1");
            list_two.Add("2"); tip_two.Add("2");
            list_two.Add("3"); tip_two.Add("3");


            // 1, 2, 3,  
            List<string> list_three = new List<string>();
            List<string> tip_three = new List<string>();
            list_three.Add("-"); tip_three.Add("minus");
            list_three.Add("0"); tip_three.Add("0");
            list_three.Add("."); tip_three.Add("point");



            // Del, 0, .
            KeyAdd(list_zero, list_one, list_two, list_three);
            TipKeyAdd(tip_zero, tip_one, tip_two, tip_three);
        }
        private void KeyAdd(List<string> a, List<string> b, List<string> c, List<string> d)
        {
            keys.Add(a);
            keys.Add(b);
            keys.Add(c);
            keys.Add(d);

        }
        private void TipKeyAdd(List<string> a, List<string> b, List<string> c, List<string> d)
        {
            tip_list.Add(a);
            tip_list.Add(b);
            tip_list.Add(c);
            tip_list.Add(d);

        }
        private void keyBoardSimp()
        {

            KeyInit();
            int max = 3;

            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < max; k++)
                {
                    Button btt = new Button();
                    btt.SetResourceReference(Button.StyleProperty, "culcControl");
                    btt.Content = keys[i][k];
                    ToolTip tt = new ToolTip();
                    tt.Content = tip_list[i][k];
                    btt.ToolTip = tt;

                    Grid.SetColumn(btt, k);
                    Grid.SetRow(btt, i);
                    KeyBoard.Children.Add(btt);

                }


            }
        }



        public Qadr()
        {

            InitializeComponent();
            keyBoardSimp();


        }


        public List<string> coef()
        {
            List<string> coeff = new List<string>();
            coeff.Add(A_coef);
            coeff.Add(B_coef);
            coeff.Add(C_coef);

            return coeff;
        }

        private void A_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (currentBox != "A")
            {
                text = string.Empty;
            }
            currentBox = "A";

        }

        private void B_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (currentBox != "B")
            {
                text = string.Empty;
            }
            currentBox = "B";

        }

        private void C_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (currentBox != "C")
            {
                text = string.Empty;
            }
            currentBox = "C";

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (A.Text.Length > 0 && A.Text != "A" && B.Text.Length > 0 && B.Text != "B" && C.Text.Length > 0 && C.Text != "C")
            {
                A_coef = A.Text;
                B_coef = B.Text;
                C_coef = C.Text;
                confirm = true;
                Close();








            }
            else
            {
                MessageBox.Show("Some coefficient is empty");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void KeyBoard_Click(object sender, RoutedEventArgs e)
        {

            Button btn = e.Source as Button;
            string t = btn.Content.ToString();
            if (t != "Del")
            {
                if (currentBox == "A")
                {
                    text = text + t;
                    A.Text = text;
                }
                else if (currentBox == "B")
                {
                    text = text + t;
                    B.Text = text;
                }
                else if (currentBox == "C")
                {
                    text = text + t;
                    C.Text = text;
                }
            }


            else if (t == "Del")

            {

                if (currentBox == "A" && A.Text.Length > 0 && A.Text != "A")
                {
                    text = text.Remove(text.Length - 1);
                    A.Text = text;
                }
                else if (currentBox == "B" && B.Text.Length > 0 && B.Text != "B")
                {
                    text = text.Remove(text.Length - 1);
                    B.Text = text;
                }
                else if (currentBox == "C" && C.Text.Length > 0 && C.Text != "C")
                {

                    text = text.Remove(text.Length - 1);
                    C.Text = text;
                }


            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
