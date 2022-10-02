using System;
using System.Windows.Forms;

namespace D_1_3{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e){
            bool ys = true;
            while (ys){
                DialogResult result;
                bool ys1 = true;
                int countDialog = 0, min = 1,max=2000,namber;
                while (ys1){
                    namber = new Random().Next(min, max);
                    result = MessageBox.Show($" это оно {namber}", "Вы загадали число", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    countDialog++;
                    if (result == DialogResult.Yes){
                        MessageBox.Show($"Количество запросов {countDialog}", "Успех", MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                        countDialog = 0;
                        ys1 = false;
                        result = MessageBox.Show($"Хотите продолжить?", "Выход", MessageBoxButtons.YesNo, 
                            MessageBoxIcon.Question);
                        ys = result == DialogResult.Yes;
                        if (result == DialogResult.Yes)
                            MessageBox.Show("Загадайте число от 1 до 2 000", "задание", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                    else{
                        result = MessageBox.Show($"Загадонное число больше чем {namber}", "Вопрос",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                            min = namber + 1;
                        else
                            max = namber - 1;
                        if (min > max || max < 1){
                            MessageBox.Show("возможно вы забыли число которое загадали", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }
    }
}
