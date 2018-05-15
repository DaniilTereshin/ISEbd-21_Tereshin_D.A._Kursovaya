﻿using AbstractShopService.BindingModels;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractShopView
{
    public partial class FormCreateZakaz : Form
    {
        public FormCreateZakaz()
        {
            InitializeComponent();
        }

        private void FormCreateZakaz_Load(object sender, EventArgs e)
        {
            try
            {
                List<TeacherViewModel> listC = Task.Run(() => APIClient.GetRequestData<List<TeacherViewModel>>("api/Teacher/GetList")).Result;
                if (listC != null)
                {
                    comboBoxTeacher.DisplayMember = "TeacherFIO";
                    comboBoxTeacher.ValueMember = "Id";
                    comboBoxTeacher.DataSource = listC;
                    comboBoxTeacher.SelectedItem = null;
                }

                List<SectionViewModel> listP = Task.Run(() => APIClient.GetRequestData<List<SectionViewModel>>("api/Section/GetList")).Result;
                if (listP != null)
                {
                    comboBoxProduct.DisplayMember = "SectionName";
                    comboBoxProduct.ValueMember = "Id";
                    comboBoxProduct.DataSource = listP;
                    comboBoxProduct.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxProduct.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxProduct.SelectedValue);
                    SectionViewModel Section = Task.Run(() => APIClient.GetRequestData<SectionViewModel>("api/Section/Get/" + id)).Result;
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * (int)Section.Price).ToString();
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxTeacher.SelectedValue == null)
            {
                MessageBox.Show("Выберите преподавателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите кружок", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int TeacherId = Convert.ToInt32(comboBoxTeacher.SelectedValue);
            int SectionId = Convert.ToInt32(comboBoxProduct.SelectedValue);
            int count = Convert.ToInt32(textBoxCount.Text);
            int sum = Convert.ToInt32(textBoxSum.Text);
            Task task = Task.Run(() => APIClient.PostRequestData("api/Main/CreateZakaz", new ZakazBindingModel
            {
                TeacherId = TeacherId,
                SectionId = SectionId,
                Count = count,
                Sum = sum
            }));

            task.ContinueWith((prevTask) => MessageBox.Show("Сохранение прошло успешно. Обновите список", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information),
                TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) =>
            {
                var ex = (Exception)prevTask.Exception;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }, TaskContinuationOptions.OnlyOnFaulted);

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}