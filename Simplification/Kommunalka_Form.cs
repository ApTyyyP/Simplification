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
            voda_otvod_textBox.Text = Settings.Default["voda_otvod_textBox"].ToString();
            voda_abonplata_textBox.Text = Settings.Default["voda_abonplata_textBox"].ToString();
            prir_gas_cena_textBox.Text = Settings.Default["prir_gas_cena_textBox"].ToString();
            prir_gas_t_textBox.Text = Settings.Default["prir_gas_t_textBox"].ToString();
            prir_gas_n_textBox.Text = Settings.Default["prir_gas_t_textBox"].ToString();
            raspr_prir_gas_textBox.Text = Settings.Default["raspr_prir_gas_textBox"].ToString();
            musor_textBox.Text = Settings.Default["musor_textBox"].ToString();
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
            label15.BackColor = Color.Transparent;
            label15.BackColor = Color.Transparent;
            label16.BackColor = Color.Transparent;
            label18.BackColor = Color.Transparent;
            label19.BackColor = Color.Transparent;
            label20.BackColor = Color.Transparent;
            label21.BackColor = Color.Transparent;
            label23.BackColor = Color.Transparent;
            label24.BackColor = Color.Transparent;
            label25.BackColor = Color.Transparent;
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
            double svet_razn, svet_rez, voda_razn, voda_rez, voda_otvod_rez, gas_razn, gas_rez, SUM;
            string t1, t2, t3, t4, t5, t6, t7, t8, t9;
            var AR = Convert.ToDouble(arenda_textBox.Text);
            var STarif = Convert.ToDouble(svet_tarif_textBox.Text);
            var ST = Convert.ToDouble(svet_t_textBox.Text);
            var SN = Convert.ToDouble(svet_n_textBox.Text);
            var VT = Convert.ToDouble(voda_t_textBox.Text);
            var VN = Convert.ToDouble(voda_n_textBox.Text);
            var VO = Convert.ToDouble(voda_otvod_textBox.Text);
            var VG = Convert.ToDouble(voda_cena_textBox.Text);
            var VA = Convert.ToDouble(voda_abonplata_textBox.Text);
            var PG = Convert.ToDouble(prir_gas_cena_textBox.Text);
            var PGT = Convert.ToDouble(prir_gas_t_textBox.Text);
            var PGN = Convert.ToDouble(prir_gas_n_textBox.Text);
            var RPG = Convert.ToDouble(raspr_prir_gas_textBox.Text);
            var MUSOR = Convert.ToDouble(musor_textBox.Text);

            svet_razn = ST - SN;
            svet_rez = svet_razn * Math.Round(STarif, 2);

            voda_razn = VT - VN;
            voda_rez = voda_razn * Math.Round(VG, 3);
            voda_otvod_rez = voda_razn * Math.Round(VO, 1);

            gas_razn = PGT - PGN;
            gas_rez = gas_razn * Math.Round(PG, 5);

            SUM = Math.Round(AR + Math.Round(STarif, 2) + Math.Round(svet_rez, 2) + Math.Round(voda_rez, 3) + Math.Round(voda_otvod_rez, 2) + Math.Round(VA, 2) + Math.Round(gas_rez, 2) + Math.Round(RPG, 2) + Math.Round(MUSOR, 1), 1);

            t1 = "Аренда " + AR + " грн";
            t2 = "Свет (" + ST + " текущее - " + SN + " начальное = " + svet_razn + " кВт) по " + Math.Round(STarif, 2) + " грн = " + Math.Round(svet_rez, 2) + " грн";
            t3 = "Вода (" + VT + " текущее - " + VN + " начальное = " + voda_razn + " куб.) по " + Math.Round(VG, 3) + " грн = " + Math.Round(voda_rez, 3) + " грн";
            t4 = "Водоотвод (за " + voda_razn + " куба) по " + Math.Round(VO, 1) + " грн = " + Math.Round(voda_otvod_rez, 2) + " грн";
            t5 = "Вода абонплата " + Math.Round(VA, 2) + " грн";
            t6 = "Природный газ (" + PGT + " текущее - " + PGN + " начальное = " + gas_razn + " куб.) по " + Math.Round(PG, 5) + " грн = " + Math.Round(gas_rez, 2) + " грн";
            t7 = "Распределение природного газа " + Math.Round(RPG, 2) + " грн";
            t8 = "Вывоз мусора " + Math.Round(MUSOR, 1) + " грн";
            t9 = "Всего: " + Math.Round(SUM, 1) + " грн";

            text_as.Text = t1 + Environment.NewLine + t2 + Environment.NewLine + t3 + Environment.NewLine +
                           t4 + Environment.NewLine + t5 + Environment.NewLine + t6 + Environment.NewLine +
                           t7 + Environment.NewLine + t8 + Environment.NewLine + Environment.NewLine + t9;

            #region Запоминание последних введённых значений
            Settings.Default["arenda_textBox"] = Convert.ToDouble(arenda_textBox.Text);
            Settings.Default["svet_tarif_textBox"] = Convert.ToDouble(svet_tarif_textBox.Text);
            Settings.Default["svet_t_textBox"] = Convert.ToDouble(svet_t_textBox.Text);
            Settings.Default["svet_n_textBox"] = Convert.ToDouble(svet_n_textBox.Text);
            Settings.Default["voda_cena_textBox"] = Convert.ToDouble(voda_cena_textBox.Text);
            Settings.Default["voda_t_textBox"] = Convert.ToDouble(voda_t_textBox.Text);
            Settings.Default["voda_n_textBox"] = Convert.ToDouble(voda_n_textBox.Text);
            Settings.Default["voda_otvod_textBox"] = Convert.ToDouble(voda_otvod_textBox.Text);
            Settings.Default["voda_abonplata_textBox"] = Convert.ToDouble(voda_abonplata_textBox.Text);
            Settings.Default["prir_gas_cena_textBox"] = Convert.ToDouble(prir_gas_cena_textBox.Text);
            Settings.Default["prir_gas_t_textBox"] = Convert.ToDouble(prir_gas_t_textBox.Text);
            Settings.Default["prir_gas_n_textBox"] = Convert.ToDouble(prir_gas_n_textBox.Text);
            Settings.Default["raspr_prir_gas_textBox"] = Convert.ToDouble(raspr_prir_gas_textBox.Text);
            Settings.Default["musor_textBox"] = Convert.ToDouble(musor_textBox.Text);
            Settings.Default.Save();
            #endregion
        }

        //Очистка значений в textBox(ах)
        private void clear_as_btn_Click(object sender, EventArgs e)
        {
            arenda_textBox.Text = "0";
            svet_t_textBox.Text = "0";
            svet_n_textBox.Text = "0";
            voda_t_textBox.Text = "0";
            voda_n_textBox.Text = "0";
            prir_gas_cena_textBox.Text = "0";
            prir_gas_t_textBox.Text = "0";
            prir_gas_n_textBox.Text = "0";
            raspr_prir_gas_textBox.Text = "0";
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

        private void prir_gas_t_textBox_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void prir_gas_n_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }

        private void voda_otvod_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace и запятая в ASCII
            {
                e.Handled = true;
            }
        }
    }
}
