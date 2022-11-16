using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simplification.Properties;  //Библиотека для сохранения введённых данных

namespace Simplification
{
    public partial class Kommunalka_Form : Form
    {
        public Kommunalka_Form()
        {
            InitializeComponent();

            #region Присваивание полей textBox к Параметру TextBoxSave (имена добавлены в Settings.settings)
            arenda_textBox.Text = Settings.Default["arenda_textBox"].ToString();
            svet_tarif_textBox.Text = Settings.Default["svet_tarif_textBox"].ToString();
            svet_t_textBox.Text = Settings.Default["svet_t_textBox"].ToString();
            svet_n_textBox.Text = Settings.Default["svet_t_textBox"].ToString();
            voda_cena_textBox.Text = Settings.Default["voda_cena_textBox"].ToString();
            voda_t_textBox.Text = Settings.Default["voda_t_textBox"].ToString();
            voda_n_textBox.Text = Settings.Default["voda_t_textBox"].ToString();
            voda_abonplata_textBox.Text = Settings.Default["voda_abonplata_textBox"].ToString();
            obsl_textBox.Text = Settings.Default["obsl_textBox"].ToString();
            musor_textBox.Text = Settings.Default["musor_textBox"].ToString();
            prir_gas_textBox.Text = Settings.Default["prir_gas_textBox"].ToString();
            raspr_prir_gas_textBox.Text = Settings.Default["raspr_prir_gas_textBox"].ToString();
            otoplenie_abonplata_textBox.Text = Settings.Default["otoplenie_abonplata_textBox"].ToString();
            otoplenie_textBox.Text = Settings.Default["otoplenie_textBox"].ToString();

            arenda_2_textBox.Text = Settings.Default["arenda_2_textBox"].ToString();
            svet_tarif_2_textBox.Text = Settings.Default["svet_tarif_2_textBox"].ToString();
            svet_t_2_textBox.Text = Settings.Default["svet_t_2_textBox"].ToString();
            svet_n_2_textBox.Text = Settings.Default["svet_t_2_textBox"].ToString();
            voda_textBox.Text = Settings.Default["voda_textBox"].ToString();
            signal_textBox.Text = Settings.Default["signal_textBox"].ToString();
            #endregion

            #region Прозрачный фон
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            label11.BackColor = Color.Transparent;
            label12.BackColor = Color.Transparent;
            label13.BackColor = Color.Transparent;
            label14.BackColor = Color.Transparent;
            label15.BackColor = Color.Transparent;
            label15.BackColor = Color.Transparent;
            label16.BackColor = Color.Transparent;
            label17.BackColor = Color.Transparent;
            label18.BackColor = Color.Transparent;
            label19.BackColor = Color.Transparent;
            label20.BackColor = Color.Transparent;
            label21.BackColor = Color.Transparent;
            label22.BackColor = Color.Transparent;
            label23.BackColor = Color.Transparent;
            label24.BackColor = Color.Transparent;
            label25.BackColor = Color.Transparent;
            label26.BackColor = Color.Transparent;
            label27.BackColor = Color.Transparent;
            label35.BackColor = Color.Transparent;
            label37.BackColor = Color.Transparent;
            label38.BackColor = Color.Transparent;
            label39.BackColor = Color.Transparent;
            label40.BackColor = Color.Transparent;
            label41.BackColor = Color.Transparent;
            label43.BackColor = Color.Transparent;
            label48.BackColor = Color.Transparent;
            label49.BackColor = Color.Transparent;
            #endregion
        }

        private void copy_as_btn_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(text_as.Text);
            MessageBox.Show("Текст скопирован.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exit_as_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addshablon_as_btn_Click(object sender, EventArgs e)
        {
            double svet_razn, svet_rez_1, svet_rez_2, voda_rez_1, voda_rez_2, OTOPLENIE_POL, SUM;
            string t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11;
            var AR = Convert.ToInt32(arenda_textBox.Text);
            var STarif = Convert.ToDouble(svet_tarif_textBox.Text);
            var ST = Convert.ToInt32(svet_t_textBox.Text);
            var SN = Convert.ToInt32(svet_n_textBox.Text);
            var VT = Convert.ToDouble(voda_t_textBox.Text);
            var VN = Convert.ToDouble(voda_n_textBox.Text);
            var VG = Convert.ToDouble(voda_cena_textBox.Text);
            var VA = Convert.ToDouble(voda_abonplata_textBox.Text);
            var OBSL = Convert.ToDouble(obsl_textBox.Text);
            var MUSOR = Convert.ToDouble(musor_textBox.Text);
            var PG = Convert.ToDouble(prir_gas_textBox.Text);
            var RPG = Convert.ToDouble(raspr_prir_gas_textBox.Text);
            var OA = Convert.ToDouble(otoplenie_abonplata_textBox.Text);
            var OTOPLENIE = Convert.ToDouble(otoplenie_textBox.Text);

            svet_razn = ST - SN;
            //svet_rez_1 — рассчёт потребления до 100 кВт⋅час в месяц
            //svet_rez_1 = svet_razn - 100;
            svet_rez_2 = svet_razn * STarif; //svet_rez_1 * 1.68 + 90

            voda_rez_1 = VT - VN;
            voda_rez_2 = voda_rez_1 * VG;

            //OTOPLENIE_POL = Math.Round(OTOPLENIE / 2, 2);

            SUM = Math.Round(AR + STarif + svet_rez_2 + voda_rez_2 + VA + OBSL + MUSOR + PG + RPG + OA + OTOPLENIE, 0);

            t1 = "Оплатила " + AR + " грн аренда";
            t2 = "Свет (" + ST + " текущее - " + SN + " начальное = " + svet_razn + " кВт) = " + svet_rez_2 + " грн";
            t3 = "Вода (" + VT + " текущее - " + VN + " начальное = " + Math.Round(voda_rez_1, 3) + " куб.) по " + VG + " грн = " + Math.Round(voda_rez_2, 1) + " грн";
            t4 = "Вода абонплата " + VA + " грн";
            t5 = "Обслуживание жилья " + OBSL + " грн";
            t6 = "Вывоз мусора " + MUSOR + " грн";
            t7 = "Природный газ " + PG + " грн";
            t8 = "Распределение природного газа " + RPG + " грн";
            t9 = "Отопление абонплата " + OA + " грн";
            t10 = "Отопление начислено " + OTOPLENIE + " грн";
            t11 = "Всего: " + SUM + " грн";

            text_as.Text = t1 + Environment.NewLine + t2 + Environment.NewLine + t3 + Environment.NewLine +
                           t4 + Environment.NewLine + t5 + Environment.NewLine + t6 + Environment.NewLine +
                           t7 + Environment.NewLine + t8 + Environment.NewLine + t9 + Environment.NewLine +
                           t10 + Environment.NewLine + Environment.NewLine + t11;

            #region Запоминание последних введённых значений
            Settings.Default["arenda_textBox"] = arenda_textBox.Text;
            Settings.Default["svet_tarif_textBox"] = svet_tarif_textBox.Text;
            Settings.Default["svet_t_textBox"] = svet_t_textBox.Text;
            Settings.Default["svet_n_textBox"] = svet_n_textBox.Text;
            Settings.Default["voda_cena_textBox"] = voda_cena_textBox.Text;
            Settings.Default["voda_t_textBox"] = voda_t_textBox.Text;
            Settings.Default["voda_n_textBox"] = voda_n_textBox.Text;
            Settings.Default["voda_abonplata_textBox"] = voda_abonplata_textBox.Text;
            Settings.Default["obsl_textBox"] = obsl_textBox.Text;
            Settings.Default["musor_textBox"] = musor_textBox.Text;
            Settings.Default["prir_gas_textBox"] = prir_gas_textBox.Text;
            Settings.Default["raspr_prir_gas_textBox"] = raspr_prir_gas_textBox.Text;
            Settings.Default["otoplenie_abonplata_textBox"] = otoplenie_abonplata_textBox.Text;
            Settings.Default["otoplenie_textBox"] = otoplenie_textBox.Text;
            Settings.Default.Save();
            #endregion
        }

        private void clear_as_btn_Click(object sender, EventArgs e)
        {
            //Очистка значений в textBox(ах)
            arenda_textBox.Text = "0";
            svet_t_textBox.Text = "0";
            svet_n_textBox.Text = "0";
            voda_t_textBox.Text = "0";
            voda_n_textBox.Text = "0";
            raspr_prir_gas_textBox.Text = "0";
            otoplenie_abonplata_textBox.Text = "0";
            otoplenie_textBox.Text = "0";
            text_as.Text = "";

            arenda_textBox.Focus();  //После очистки формы задаём фокус на элемент arenda_textBox
        }

        private void arenda_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void svet_t_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void svet_n_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void voda_t_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void voda_n_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void voda_abonplata_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void obsl_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void musor_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void prir_gas_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void raspr_prir_gas_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void otoplenie_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void otoplenie_abonplata_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void otoplenie_abonplata_textBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void addshablon_as_2_btn_Click(object sender, EventArgs e)
        {
            int svet_razn, svet_rez, SUM;
            string t1, t2, t3, t4, t5;
            var AR_2 = Convert.ToInt32(arenda_2_textBox.Text);
            var STarif_2 = Convert.ToInt32(svet_tarif_2_textBox.Text);
            var ST_2 = Convert.ToInt32(svet_t_2_textBox.Text);
            var SN_2 = Convert.ToInt32(svet_n_2_textBox.Text);
            var Voda = Convert.ToInt32(voda_textBox.Text);
            var Signal = Convert.ToInt32(signal_textBox.Text);

            svet_razn = ST_2 - SN_2;
            svet_rez = svet_razn * STarif_2;

            SUM = AR_2 + svet_rez + Voda + Signal;

            t1 = "Аренда " + AR_2 + " грн";
            t2 = "Свет (" + ST_2 + " текущее - " + SN_2 + " начальное = " + svet_razn + " кВт) = " + svet_rez + " грн";
            t3 = "Вода " + Voda + " грн";
            t4 = "Сигнализация " + Signal + " грн";
            t5 = "Всего: " + SUM + " грн";

            text_as_2.Text = t1 + Environment.NewLine + t2 + Environment.NewLine + t3 + Environment.NewLine +
                           t4 + Environment.NewLine + Environment.NewLine + t5;

            #region Запоминание последних введённых значений
            Settings.Default["arenda_2_textBox"] = arenda_2_textBox.Text;
            Settings.Default["svet_tarif_2_textBox"] = svet_tarif_2_textBox.Text;
            Settings.Default["svet_t_2_textBox"] = svet_t_2_textBox.Text;
            Settings.Default["svet_n_2_textBox"] = svet_n_2_textBox.Text;
            Settings.Default["voda_textBox"] = voda_textBox.Text;
            Settings.Default["signal_textBox"] = signal_textBox.Text;
            Settings.Default.Save();
            #endregion
        }

        private void arenda_2_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void svet_tarif_2_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void svet_t_2_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void svet_n_2_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void voda_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void signal_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void copy_as_2_btn_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(text_as_2.Text);
            MessageBox.Show("Текст скопирован.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clear_as_2_btn_Click(object sender, EventArgs e)
        {
            //Очистка значений в textBox(ах)
            arenda_2_textBox.Text = "0";
            svet_tarif_2_textBox.Text = "0";
            svet_t_2_textBox.Text = "0";
            svet_n_2_textBox.Text = "0";
            voda_textBox.Text = "0";
            signal_textBox.Text = "0";
            text_as_2.Text = "";

            arenda_2_textBox.Focus();  //После очистки формы задаём фокус на элемент arenda_2_textBox
        }
    }
}
