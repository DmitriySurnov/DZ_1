using System;
using System.Windows.Forms;

namespace DZ_1_1{
    public partial class Form1 : Form{
        private enum Znacs{
            plus = 0, minus = 1, ymnoz = 2, delit = 3,
            pysto = 4, ravno = 5
        }
        private Znacs znac = Znacs.pysto;
        private bool drob = false;
        private string istoriy = "";
        private float namber;
        private bool isnamber = false;
        public Form1(){
            InitializeComponent();
        }
        private void AddNamber(int namber)
        {
            if (textBox_tec.Text == "0" || znac == Znacs.ravno)
                textBox_tec.Text = namber.ToString();
            else
                textBox_tec.Text += namber;
            if (znac == Znacs.ravno)
                znac = Znacs.pysto;
        }
        private void Button_1_Click(object sender, EventArgs e)
        {
            AddNamber(1);
        }
        private void Button_2_Click(object sender, EventArgs e)
        {
            AddNamber(2);
        }
        private void Button_3_Click(object sender, EventArgs e)
        {
            AddNamber(3);
        }
        private void Button_4_Click(object sender, EventArgs e)
        {
            AddNamber(4);
        }
        private void Button_5_Click(object sender, EventArgs e)
        {
            AddNamber(5);
        }
        private void Button_6_Click(object sender, EventArgs e)
        {
            AddNamber(6);
        }
        private void Button_7_Click(object sender, EventArgs e)
        {
            AddNamber(7);
        }
        private void Button_8_Click(object sender, EventArgs e)
        {
            AddNamber(8);
        }
        private void Button_9_Click(object sender, EventArgs e)
        {
            AddNamber(9);
        }
        private void Button_0_Click(object sender, EventArgs e)
        {
            AddNamber(0);
        }
        private void Button_toch_Click(object sender, EventArgs e)
        {
            if (drob)
                return;
            if (IsPysto(textBox_tec) || znac == Znacs.ravno)
                Button_0_Click(sender, e);
            textBox_tec.Text += ",";
            drob = true;
        }
        private void Button_C_Click(object sender, EventArgs e)
        {
            Stor_tec();
            textBox_histori.Text = "";
            istoriy = "";
            znac = Znacs.pysto;
        }
        private void Stor_tec()
        {
            textBox_tec.Text = "";
            drob = false;
        }
        private void Button_del_Click(object sender, EventArgs e)
        {
            if (znac == Znacs.ravno)
            {
                textBox_tec.Text = "";
                znac = Znacs.pysto;
                return;
            }
            string str = textBox_tec.Text;
            if (str.Length == 0)
                return;
            textBox_tec.Text = "";
            for (int i = 0; i < str.Length - 1; i++)
                textBox_tec.Text += str[i];
            if (str[str.Length - 1] == '.')
                drob = false;
        }
        private bool IsPysto(TextBox pole)
        {
            string str = pole.Text;
            if (str.Length == 0)
                return true;
            else
                return false;
        }
        private float Deistv(float namber1)
        {
            switch (znac)
            {
                case 0:
                    return namber + namber1;
                case (Znacs)1:
                    return namber - namber1;
                case (Znacs)2:
                    return namber * namber1;
                case (Znacs)3:
                    return namber / namber1;
                default:
                    return -1;
            }
        }
        private void Button_znac(string text, Znacs zn) {
            if (IsPysto(textBox_tec)){
                if (!IsPysto(textBox_histori) && znac != Znacs.pysto){
                    textBox_histori.Text = istoriy + text;
                    znac = zn;
                }
            }
            else if (isnamber){
                float d = Convert.ToSingle(textBox_tec.Text);
                namber = Deistv(d);
                znac = zn;
                istoriy = textBox_histori.Text;
                istoriy += d;
                textBox_histori.Text = istoriy + text;
                Stor_tec();
            }
            else if (znac == Znacs.ravno){
                isnamber = true;
                istoriy += "  " + namber;
                znac = zn;
                textBox_histori.Text = istoriy + text;
                Stor_tec();
            }
            else if (znac == Znacs.pysto){
                namber = Convert.ToSingle(textBox_tec.Text);
                znac = zn;
                istoriy += "  " + namber;
                textBox_histori.Text = istoriy + text;
                isnamber = true;
                Stor_tec();
            }
        }
        private void Button_plus_Click(object sender, EventArgs e)
        {
            Button_znac(" + ", Znacs.plus);
        }
        private void Button_CE_Click(object sender, EventArgs e)
        {
            Stor_tec();
            znac = Znacs.pysto;
        }
        private void Button_minus_Click(object sender, EventArgs e)
        {
            Button_znac(" - ", Znacs.minus);
        }
        private void Button_rovno_Click(object sender, EventArgs e)
        {
            if (znac == Znacs.ravno)
                return;
            else if (isnamber && !IsPysto(textBox_tec))
            {
                float d = Convert.ToSingle(textBox_tec.Text);
                namber = Deistv(d);
                isnamber = false;
                znac = Znacs.ravno;
                istoriy = textBox_histori.Text;
                istoriy += d + " = " + namber;
                textBox_histori.Text = istoriy;
                textBox_tec.Text = " = " + namber;
                drob = false;
            }
        }
        private void Button_ymnoz_Click(object sender, EventArgs e)
        {
            Button_znac(" * ", Znacs.ymnoz);
        }
        private void Button_delit_Click(object sender, EventArgs e)
        {
            Button_znac(" / ", Znacs.delit);
        }

        private void Button_x_2_Click(object sender, EventArgs e)
        {
            if (znac == Znacs.ravno){
                namber *= namber;
                textBox_tec.Text = namber.ToString();
                
            }
            else if (!IsPysto(textBox_tec) && znac != Znacs.ravno){
                float f = Convert.ToSingle(textBox_tec.Text);
                textBox_tec.Text = (f * f).ToString();
            }
        }
    }
}
