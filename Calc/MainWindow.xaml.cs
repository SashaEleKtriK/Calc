using System;
using System.Collections.Generic;
using System.Data;
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

namespace Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string sum = "";
        string stepen_text = "";
        public bool stepen = false;
        private bool Engin = false;
        private bool More = true;
        List<string> Collect = new List<string>();
        List<List<string>> keys = new List<List<string>>();
        List<List<string>> tip_list = new List<List<string>>();
        Qadr NewWin;
        private bool isQadr = false;
        bool factorialWait = true;


        public void setStyle(string file_name)
        {
            try
            {
                var uri = new Uri(file_name, UriKind.Relative);
                // загружаем словарь ресурсов
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                // очищаем коллекцию ресурсов приложения
                Application.Current.Resources.Clear();
                // добавляем загруженный словарь ресурсов
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        public void KeyInit(bool Engine)
        {
            List<string> list_zero = new List<string>();
            List<string> tip_zero = new List<string>();
            list_zero.Add("7"); tip_zero.Add("7");
            list_zero.Add("8"); tip_zero.Add("8");
            list_zero.Add("9"); tip_zero.Add("9");
            list_zero.Add("+"); tip_zero.Add("sum");
            if (Engine)
            {
                list_zero.Add("1/x"); tip_zero.Add("1/(current string)");
                list_zero.Add("Tg"); tip_zero.Add("tangent(current string)");
            }
            // 7, 8, 9, +
            List<string> list_one = new List<string>();
            List<string> tip_one = new List<string>();
            list_one.Add("4"); tip_one.Add("4");
            list_one.Add("5"); tip_one.Add("5");
            list_one.Add("6"); tip_one.Add("6");
            list_one.Add("-"); tip_one.Add("difference");
            if (Engine)
            {
                list_one.Add("x^(1/2)"); tip_one.Add("(current string)^(1/2)");
                list_one.Add("Ctg"); tip_one.Add("cotangent(current string)");
            }
            // 4, 5, 6, -
            List<string> list_two = new List<string>();
            List<string> tip_two = new List<string>();
            list_two.Add("1"); tip_two.Add("1");
            list_two.Add("2"); tip_two.Add("2");
            list_two.Add("3"); tip_two.Add("3");
            list_two.Add("="); tip_two.Add("equals");
            if (Engine)
            {
                list_two.Add("x^2"); tip_two.Add("(current string)^2");
                list_two.Add("Cos"); tip_two.Add("cosinus(current string)");
            }
            // 1, 2, 3, = 
            List<string> list_three = new List<string>();
            List<string> tip_three = new List<string>();
            list_three.Add("*"); tip_three.Add("multiply");
            list_three.Add("0"); tip_three.Add("0");
            list_three.Add("/"); tip_three.Add("divide");
            if (More)
            {
                list_three.Add("More"); tip_three.Add("More functions");
            }
            else
            {
                list_three.Add("Less"); tip_three.Add("Less functions");
            }

            if (Engine)
            {
                list_three.Add("x^y"); tip_three.Add("(current string)^(input)");
                list_three.Add("Sin"); tip_three.Add("sinus(current string)");
            }
            List<string> list_four = new List<string>();
            List<string> tip_four = new List<string>();
            list_four.Add("Clear"); tip_four.Add("Clear");
            list_four.Add("."); tip_four.Add("point");
            list_four.Add("Del"); tip_four.Add("Delete last char");
            list_four.Add("Close"); tip_four.Add("Close window");
            if (Engine)
            {
                list_four.Add("x^(1/3)"); tip_four.Add("(current string)^(1/3)");
                list_four.Add("x!"); tip_four.Add("(current string)! {only int}");
            }
            // *, 0, /, More
            KeyAdd(list_zero, list_one, list_two, list_three, list_four);
            TipKeyAdd(tip_zero, tip_one, tip_two, tip_three, tip_four);
        }
        private void KeyAdd(List<string> a, List<string> b, List<string> c, List<string> d, List<string> e)
        {
            keys.Add(a);
            keys.Add(b);
            keys.Add(c);
            keys.Add(d);
            keys.Add(e);
        }
        private void TipKeyAdd(List<string> a, List<string> b, List<string> c, List<string> d, List<string> e)
        {
            tip_list.Add(a);
            tip_list.Add(b);
            tip_list.Add(c);
            tip_list.Add(d);
            tip_list.Add(e);
        }


        public MainWindow()
        {
            InitializeComponent();
            setStyle("Matrix.xaml");
            keyBoardSimp(Engin);
            alsoKeysInit();
            NewWin = new Qadr();




        }
        private void alsoKeysInit()
        {
            List<string> alsoKeys_list = new List<string>();
            alsoKeys_list.Add("(");
            alsoKeys_list.Add(")");
            alsoKeys_list.Add("E");
            for (int i = 0; i < 3; i++)
            {
                Button btt = new Button();

                btt.SetResourceReference(Button.StyleProperty, "culcControl");
                btt.Content = alsoKeys_list[i];
                if (btt.Content.ToString() == "E")
                {
                    btt.ToolTip = "*10^n Example: 22E-10 = 22*10^-10";
                }


                Grid.SetColumn(btt, i);
                alsoKeys.Children.Add(btt);
            }
        }
        private void keyBoardSimp(bool Engine)
        {
            keys.Clear();
            tip_list.Clear();
            KeyInit(Engine);
            int max = 4;
            if (Engine)
            {
                max = 6;
            }
            for (int i = 0; i < 5; i++)
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

        private void culcEngin()
        {
            ColumnDefinition newCol = new ColumnDefinition();
            newCol.Width = column.Width;
            KeyBoard.ColumnDefinitions.Add(newCol);
            ColumnDefinition newColl = new ColumnDefinition();
            newColl.Width = column.Width;
            KeyBoard.ColumnDefinitions.Add(newColl);
            Engin = true;
            keyBoardSimp(Engin);


        }

        async Task factorial()
        {
            factorialBox.Text = " Start of process";
            try
            {
                factorialWait = false;
                sum = culcBox.Text;
                string local_sum = sum;
                double result_one = Convert.ToDouble(new DataTable().Compute(local_sum, null));
                int res = Int32.Parse(result_one.ToString());

                long result = 1;
                for (int i = 1; i <= res; i++)
                {
                    await Task.Delay(1000);
                    result = result * i;
                    factorialBox.Text = i.ToString() + "! = " + result.ToString();

                }
                culcBox.Text = "(" + local_sum + ")" + "!"; ;
                CulculateHistory(result);
                sum = string.Empty;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                factorialBox.Text = "ERROR";
                culcBox.Text = string.Empty;

            }
            factorialWait = true;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Collect.Add(culcBox.Text);
            culcHistoryBox.Items.Clear();
            foreach (string item in Collect)
            {
                culcHistoryBox.Items.Insert(0, item);
            }




        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CulculateHistory(double res)
        {
            string text_result;
            text_result = res.ToString().Replace(',', '.');
            string text = "     =" + text_result;
            Collect.Add(text);
            Collect.Add(culcBox.Text);
            culcHistoryBox.Items.Clear();
            foreach (string item in Collect)
            {
                culcHistoryBox.Items.Insert(0, item);
            }
            culcBox.Text = text_result;
        }
        private void Qdr(double a, double b, double c)
        {

            double x1;
            double x2;

            if (a == 0)
            {
                x1 = b / (-c);
                culcBox.Text = "(" + a.ToString() + ")x^2+(" + b.ToString() + ")x+(" + c.ToString() + ")=0    x1 =";
                CulculateHistory(x1);
                MessageBox.Show("x1 = " + x1.ToString());
            }
            else
            {
                double Disc = Math.Pow(b, 2) - 4 * a * c;

                if (Disc == 0)
                {
                    x1 = -b / (2 * a);
                    culcBox.Text = "(" + a.ToString() + ")x^2+(" + b.ToString() + ")x+(" + c.ToString() + ")=0    x1 =";
                    CulculateHistory(x1);
                    MessageBox.Show("x1 = " + x1.ToString());
                }
                else if (Disc < 0)
                {
                    culcBox.Text = "(" + a.ToString() + ")x^2+(" + b.ToString() + ")x+(" + c.ToString() + ")=0    there are no real roots";
                    CulculateHistory(0);
                    MessageBox.Show("there are no real roots");
                }
                else if (Disc > 0)
                {
                    x1 = (-b - (Math.Pow(Disc, 0.5))) / (2 * a);
                    x2 = (-b + (Math.Pow(Disc, 0.5))) / (2 * a);
                    culcBox.Text = "(" + a.ToString() + ")x^2+(" + b.ToString() + ")x+(" + c.ToString() + ")=0    x1 =";
                    CulculateHistory(x1);
                    culcBox.Text = "(" + a.ToString() + ")x^2+(" + b.ToString() + ")x+(" + c.ToString() + ")=0    x2 =";
                    CulculateHistory(x2);
                    MessageBox.Show("x1 = " + x1.ToString() + "; X2 = " + x2.ToString());
                }
            }

        }

        private async void KeyBoard_Click(object sender, RoutedEventArgs e)
        {


            Button btn = e.Source as Button;
            string text = btn.Content.ToString();


            if (text == "More")
            {
                More = false;
                culcEngin();
                if (factorialWait)
                {
                    factorialBox.Text = "Click on 'X!' to calculate         the factorial ";
                }


            }
            else if (text == "Less")
            {
                More = true;
                KeyBoard.ColumnDefinitions.RemoveAt(4);
                KeyBoard.ColumnDefinitions.RemoveAt(3);
                keyBoardSimp(false);
                if (factorialWait)
                {
                    factorialBox.Text = "Click on 'More' to calculate    the factorial ";
                }


            }
            else if (text == "Clear")
            {
                culcBox.Text = string.Empty;
                stepen = false;
            }
            else if (text == "Del" && culcBox.Text.Length > 0)
            {

                culcBox.Text = culcBox.Text.Remove(culcBox.Text.Length - 1);

            }
            else if ((text == "Del" || text == "=") && culcBox.Text.Length == 0)
            {

            }
            else if (text == "Close")
            {
                Close();
            }
            else if (stepen && text != "=")
            {
                stepen_text += text;
                try
                {
                    culcBox.Text = "(" + sum + ")" + "^(" + stepen_text + ")";
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    culcBox.Text = string.Empty;
                    stepen = false;
                }
            }
            else if (text == "x^y")
            {

                sum = culcBox.Text;
                culcBox.Text = "(" + sum + ")" + "^({input})";
                stepen = true;

            }
            else if (text == "=" && stepen)
            {
                try
                {

                    double result_one = Convert.ToDouble(new DataTable().Compute(sum, null));
                    double result_stepen = Convert.ToDouble(stepen_text);


                    culcBox.Text = "(" + sum + ")" + "^(" + stepen_text + ")" + text;

                    double result = Math.Pow(result_one, result_stepen);
                    CulculateHistory(result);
                    stepen = false;
                    stepen_text = string.Empty;
                    sum = string.Empty;

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    culcBox.Text = string.Empty;
                    stepen = false;
                    stepen_text = string.Empty;
                }
            }
            else if (text == "1/x")
            {
                culcBox.Text = "1/" + "(" + culcBox.Text + ")";
            }
            else if (text == "x^(1/2)")
            {
                try
                {
                    sum = culcBox.Text;
                    double result_one = Convert.ToDouble(new DataTable().Compute(sum, null));
                    culcBox.Text = "(" + sum + ")" + "^(1/2)";
                    double result = Math.Pow(result_one, 0.5);
                    CulculateHistory(result);
                    sum = string.Empty;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    culcBox.Text = string.Empty;
                }

            }
            else if (text == "x^(1/3)")
            {
                try
                {
                    sum = culcBox.Text;
                    double result_one = Convert.ToDouble(new DataTable().Compute(sum, null));
                    culcBox.Text = "(" + sum + ")" + "^(1/3)";
                    double result = Math.Pow(result_one, 0.3333333333333333333333333333333);
                    CulculateHistory(result);
                    sum = string.Empty;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    culcBox.Text = string.Empty;
                }

            }
            else if (text == "Sin" || text == "Cos" || text == "Tg" || text == "Ctg")
            {
                try
                {
                    sum = culcBox.Text;
                    double result_one = Convert.ToDouble(new DataTable().Compute(sum, null));
                    culcBox.Text = text + "(" + sum + ")";
                    double result = 0;
                    if (Convert.ToBoolean(Rad.IsChecked))
                    {
                        if (text == "Sin")
                        {
                            result = Math.Sin(result_one);
                        }
                        else if (text == "Cos")
                        {
                            result = Math.Cos(result_one);
                        }
                        else if (text == "Tg")
                        {
                            result = Math.Tan(result_one);
                        }
                        else if (text == "Ctg")
                        {
                            result = 1 / Math.Tan(result_one);
                        }

                    }
                    else if (Convert.ToBoolean(Deg.IsChecked))
                    {
                        if (text == "Sin")
                        {
                            result = Math.Sin(result_one * Math.PI / 180);
                        }
                        else if (text == "Cos")
                        {
                            result = Math.Cos(result_one * Math.PI / 180);
                        }
                        else if (text == "Tg")
                        {
                            result = Math.Tan(result_one * Math.PI / 180);
                        }
                        else if (text == "Ctg")
                        {
                            result = 1 / Math.Tan(result_one * Math.PI / 180);
                        }

                    }

                    CulculateHistory(Math.Round(result, 2));
                    sum = string.Empty;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    culcBox.Text = string.Empty;
                }

            }
            else if (text == "x!")
            {
                if (factorialWait)
                {
                    await factorial();
                }


            }

            else if (text == "x^2")
            {
                try
                {
                    sum = culcBox.Text;
                    double result_one = Convert.ToDouble(new DataTable().Compute(sum, null));
                    culcBox.Text = "(" + sum + ")" + "^(2)";
                    double result = Math.Pow(result_one, 2);
                    CulculateHistory(result);
                    sum = string.Empty;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    culcBox.Text = string.Empty;
                }

            }

            else if (text != "=")
            {
                culcBox.Text = culcBox.Text + text;
            }

            else if (text == "=")
            {

                try
                {

                    double result = Convert.ToDouble(new DataTable().Compute(culcBox.Text, null));
                    culcBox.Text = culcBox.Text + text;

                    CulculateHistory(result);


                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    culcBox.Text = string.Empty;
                }

            }



        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window1 NewW = new Window1();
            NewW.Owner = this;
            if (!Convert.ToBoolean(NewW.ShowDialog()))
            {

                e.Cancel = true;

            }

        }



        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MenuItem btn = e.Source as MenuItem;
            string text = btn.Header.ToString();
            if (text == "1000X800")
            {
                this.Height = 800;
                this.Width = 1000;

            }
            else if (text == "800X600")
            {
                this.Height = 600;
                this.Width = 800;
            }
            else if (text == "600X400")
            {
                this.Height = 400;
                this.Width = 600;
            }
        }

        private void Style_Click(object sender, RoutedEventArgs e)
        {
            MenuItem btn = e.Source as MenuItem;
            string text = btn.Header.ToString();
            setStyle(text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isQadr)
                {

                    NewWinFunc();
                    isQadr = true;




                }
                else
                {
                    MessageBox.Show("Window is already open");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private void NewWin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            List<string> strings = new List<string>();



            if (NewWin.confirm)
            {
                strings = NewWin.coef();
                double a = Convert.ToDouble(strings[0]);
                double b = Convert.ToDouble(strings[1]);
                double c = Convert.ToDouble(strings[2]);
                Qdr(a, b, c);


            }
            else
            {

            }
            isQadr = false;







        }
        private void NewWinFunc()
        {
            try
            {
                NewWin.Show();
                NewWin.Owner = this;
                NewWin.Activate();
                NewWin.Closing += new System.ComponentModel.CancelEventHandler(NewWin_Closing);
            }
            catch (InvalidOperationException ex)
            {


                NewWin = new Qadr();

                NewWin.Show();
                NewWin.Owner = this;
                NewWin.Activate();
                NewWin.Closing += new System.ComponentModel.CancelEventHandler(NewWin_Closing);



            }


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
