using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace AbstractShopView
{
    public partial class FormPutOnBonusFine : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IBonusFineService serviceS;

        private readonly ITeacherService serviceC;

        private readonly IMainService serviceM;

        public FormPutOnBonusFine(IBonusFineService serviceS, ITeacherService serviceC, IMainService serviceM)
        {
            InitializeComponent();
            this.serviceS = serviceS;
            this.serviceC = serviceC;
            this.serviceM = serviceM;
        }

        private void FormPutOnStock_Load(object sender, EventArgs e)
        {
            try
            {
                
                
                List<BonusFineViewModel> listS = serviceS.GetList();
                if (listS != null)
                {
                    comboBoxStock.DisplayMember = "BonusFineName";
                    comboBoxStock.ValueMember = "Id";
                    comboBoxStock.DataSource = listS;
                    comboBoxStock.SelectedItem = null;
                }
                List<TeacherViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    comboBoxTeacher.DisplayMember = "TeacherFIO";
                    comboBoxTeacher.ValueMember = "Id";
                    comboBoxTeacher.DataSource = listC;
                    comboBoxTeacher.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            if (comboBoxTeacher.SelectedValue == null)
            {
                MessageBox.Show("Выберите преподавателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStock.SelectedValue == null)
            {
                MessageBox.Show("Выберите бонусы или штрафы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                serviceM.PutTeacherOnBonusFine(new TeacherBonusFineBindingModel
                {
                    TeacherId = Convert.ToInt32(comboBoxTeacher.SelectedValue),
                    BonusFineId = Convert.ToInt32(comboBoxStock.SelectedValue)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        
    }
}
