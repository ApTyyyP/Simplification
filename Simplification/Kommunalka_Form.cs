using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simplification.Properties;  // Библиотека для сохранения введённых данных

namespace Simplification
{
    public partial class Kommunalka_Form : Form
    {
        public Kommunalka_Form()
        {
            InitializeComponent();

            #region Присваивание полей textBox к Параметру TextBoxSave (имена добавлены в Settings.settings)
            LoadSettings();
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

            // Добавление событий для сохранения данных при изменении полей
            arenda_textBox.TextChanged += (s, e) => SaveSettings();
            svet_tarif_textBox.TextChanged += (s, e) => SaveSettings();
            svet_t_textBox.TextChanged += (s, e) => SaveSettings();
            svet_n_textBox.TextChanged += (s, e) => SaveSettings();
            voda_cena_textBox.TextChanged += (s, e) => SaveSettings();
            voda_t_textBox.TextChanged += (s, e) => SaveSettings();
            voda_n_textBox.TextChanged += (s, e) => SaveSettings();
            voda_otvod_textBox.TextChanged += (s, e) => SaveSettings();
            voda_abonplata_textBox.TextChanged += (s, e) => SaveSettings();
            prir_gas_cena_textBox.TextChanged += (s, e) => SaveSettings();
            prir_gas_t_textBox.TextChanged += (s, e) => SaveSettings();
            prir_gas_n_textBox.TextChanged += (s, e) => SaveSettings();
            raspr_prir_gas_textBox.TextChanged += (s, e) => SaveSettings();
            musor_textBox.TextChanged += (s, e) => SaveSettings();
        }

        private void copy_as_btn_Click(object sender, EventArgs e)
        {
            string textData = text_as.Text;
            Clipboard.Clear();
            Clipboard.SetData(DataFormats.Text, (Object)textData);
            MessageBox.Show("Текст скопирован.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exit_as_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string FormatIfNotZero(double value, string text)
        {
            return value == 0 ? string.Empty : text;
        }

        private void LoadSettings()
        {
            var settings = Settings.Default;
            arenda_textBox.Text = settings["arenda_textBox"].ToString();
            svet_tarif_textBox.Text = settings["svet_tarif_textBox"].ToString();
            svet_t_textBox.Text = settings["svet_t_textBox"].ToString();
            svet_n_textBox.Text = settings["svet_n_textBox"].ToString();
            voda_cena_textBox.Text = settings["voda_cena_textBox"].ToString();
            voda_t_textBox.Text = settings["voda_t_textBox"].ToString();
            voda_n_textBox.Text = settings["voda_n_textBox"].ToString();
            voda_otvod_textBox.Text = settings["voda_otvod_textBox"].ToString();
            voda_abonplata_textBox.Text = settings["voda_abonplata_textBox"].ToString();
            prir_gas_cena_textBox.Text = settings["prir_gas_cena_textBox"].ToString();
            prir_gas_t_textBox.Text = settings["prir_gas_t_textBox"].ToString();
            prir_gas_n_textBox.Text = settings["prir_gas_n_textBox"].ToString();
            raspr_prir_gas_textBox.Text = settings["raspr_prir_gas_textBox"].ToString();
            musor_textBox.Text = settings["musor_textBox"].ToString();
        }

        private void SaveSettings()
        {
            var settings = Settings.Default;
            settings["arenda_textBox"] = ParseOrZero(arenda_textBox.Text);
            settings["svet_tarif_textBox"] = ParseOrZero(svet_tarif_textBox.Text);
            settings["svet_t_textBox"] = ParseOrZero(svet_t_textBox.Text);
            settings["svet_n_textBox"] = ParseOrZero(svet_n_textBox.Text);
            settings["voda_cena_textBox"] = ParseOrZero(voda_cena_textBox.Text);
            settings["voda_t_textBox"] = ParseOrZero(voda_t_textBox.Text);
            settings["voda_n_textBox"] = ParseOrZero(voda_n_textBox.Text);
            settings["voda_otvod_textBox"] = ParseOrZero(voda_otvod_textBox.Text);
            settings["voda_abonplata_textBox"] = ParseOrZero(voda_abonplata_textBox.Text);
            settings["prir_gas_cena_textBox"] = ParseOrZero(prir_gas_cena_textBox.Text);
            settings["prir_gas_t_textBox"] = ParseOrZero(prir_gas_t_textBox.Text);
            settings["prir_gas_n_textBox"] = ParseOrZero(prir_gas_n_textBox.Text);
            settings["raspr_prir_gas_textBox"] = ParseOrZero(raspr_prir_gas_textBox.Text);
            settings["musor_textBox"] = ParseOrZero(musor_textBox.Text);
            settings.Save();
        }

        private double ParseOrZero(string text) => double.TryParse(text, out var value) ? value : 0;

        private string FormatCurrency(double value)
        {
            return value.ToString("N0");
        }

        private void addshablon_as_btn_Click(object sender, EventArgs e)
        {
            double AR = ParseOrZero(arenda_textBox.Text);
            double STarif = ParseOrZero(svet_tarif_textBox.Text);
            double ST = ParseOrZero(svet_t_textBox.Text);
            double SN = ParseOrZero(svet_n_textBox.Text);
            double VT = ParseOrZero(voda_t_textBox.Text);
            double VN = ParseOrZero(voda_n_textBox.Text);
            double VO = ParseOrZero(voda_otvod_textBox.Text);
            double VG = ParseOrZero(voda_cena_textBox.Text);
            double PG = ParseOrZero(prir_gas_cena_textBox.Text);
            double PGT = ParseOrZero(prir_gas_t_textBox.Text);
            double PGN = ParseOrZero(prir_gas_n_textBox.Text);
            double RPG = ParseOrZero(raspr_prir_gas_textBox.Text);
            double MUSOR = ParseOrZero(musor_textBox.Text);

            double svet_rez = (ST - SN) * STarif;
            double voda_razn = VT - VN;
            double voda_rez = voda_razn * VG;
            double voda_otvod_rez = (VT - VN) * VO;
            double gas_rez = (PGT - PGN) * PG;

            double total = Math.Round(AR + svet_rez + voda_rez + gas_rez + RPG + MUSOR);

            text_as.Text = $"{DateTime.Now.ToString("MMMM yyyy")}" + Environment.NewLine + Environment.NewLine + string.Join(Environment.NewLine,
                FormatIfNotZero(AR, $"Аренда = {FormatCurrency(AR)} грн"),
                FormatIfNotZero(svet_rez, $"Свет ({ST} текущее — {SN} начальное = {ST - SN} кВт) по {FormatCurrency(STarif)} грн = {FormatCurrency(svet_rez)} грн"),
                FormatIfNotZero(voda_rez, $"Вода ({VT} текущее — {VN} начальное = {voda_razn} куб.) по {FormatCurrency(VG)} грн = {FormatCurrency(voda_rez)} грн"),
                FormatIfNotZero(voda_otvod_rez, $"Водоотвод (за {VT - VN} куб) по {FormatCurrency(VO)} грн = {FormatCurrency(voda_otvod_rez)} грн"),
                FormatIfNotZero(gas_rez, $"Природный газ ({PGT} текущее — {PGN} начальное = {PGT - PGN} куб.) по {FormatCurrency(PG)} грн = {FormatCurrency(gas_rez)} грн"),
                FormatIfNotZero(RPG, $"Распределение природного газа = {FormatCurrency(RPG)} грн"),
                FormatIfNotZero(MUSOR, $"Вывоз мусора = {FormatCurrency(MUSOR)} грн")
            ).Trim() + $"{Environment.NewLine}{Environment.NewLine}Всего: {FormatCurrency(total)} грн";
        }

        // Очистка значений в textBox(ах)
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

            arenda_textBox.Focus();  // После очистки формы задаём фокус на элемент arenda_textBox
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
