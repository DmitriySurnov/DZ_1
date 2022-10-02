using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Shown += ShowMesBox;
        }

        private void ShowMesBox(object sender, EventArgs e)
        {
            string[] array = { "Студент: Сурнов Дитрий Валерьевич",
                "Предмет: Основы разработки приложений с использованием Windows Forms и WPF",
                "Группа: ПВ111" };
            int countSimval = 0;
            string zagolovok;

            for (int i = 0; i < array.Length; i++)
            {
                countSimval += array[i].Length;
                zagolovok = (array.Length - 1 == i) ? $"MessageBox {i + 1}. " +
                    $"Среднее число символов - {countSimval / array.Length}" : $"MessageBox {i + 1}";
                MessageBox.Show(array[i], zagolovok, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
