using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simplification
{
    public partial class Akt_Sverki_Form : Form
    {
        public Akt_Sverki_Form()
        {
            InitializeComponent();

            #region Прозрачный фон
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            checkBox_as.BackColor = Color.Transparent;
            #endregion
        }

        private void copy_as_btn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(text_as.Text);
            MessageBox.Show("Текст скопирован.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exit_as_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Инициализация формы MainForm
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            this.Close();
        }

        private void addshablon_as_btn_Click(object sender, EventArgs e)
        {
            int hour;
            string vs, t1, t2, t3;
            var signdatestart = signDateStart.Value.ToShortDateString();
            var signdateend = signDateEnd.Value.ToShortDateString();
            var OC = our_company_textBox.Text;
            var AC = another_company_textBox.Text;

            hour = Convert.ToInt32(DateTime.Now.ToString("HH"));

            if ((hour >= 6) && (hour <= 12))
            {
                vs = "Доброе утро!";
            }
            else if ((hour >= 12) && (hour <= 18))
            {
                vs = "Добрый день!";
            }
            else if ((hour >= 18) && (hour <= 24))
            {
                vs = "Добрый вечер!";
            }
            else vs = "Доброй ночи!";

            t1 = "В приложенном файле акт сверки за период с " + signdatestart + " по " + signdateend + " (ООО \"" + OC + "\" – ООО \"" + AC + "\").";
            t2 = "Если данные совпадают, жду подписанный акт, (скан копию) или вопросы, если есть расхождения.";
            t3 = "Заранее спасибо за ответ.";
            text_as.Text = vs + Environment.NewLine + t1 + Environment.NewLine + t2 + Environment.NewLine +t3;
        }

        private void checkBox_as_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_as.Checked)
            {
                text_as.ReadOnly = false;
            }
            else text_as.ReadOnly = true;
        }

        private void clear_as_btn_Click(object sender, EventArgs e)
        {
            //Очистка значений в textBox(ах)
            another_company_textBox.Text = "";
            text_as.Text = "";
            checkBox_as.Checked = false;

            our_company_textBox.Focus();  //После очистки формы задаём фокус на элемент our_company_textBox
        }
    }
}
