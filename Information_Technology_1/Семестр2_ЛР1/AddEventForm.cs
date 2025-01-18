using System;
using System.Windows.Forms;
using static Семестр2_ЛР1.OrganiserForm;

namespace Семестр2_ЛР1
{
    public partial class AddEventForm : Form
    {
        public Event NewEvent { get; private set; }

        private Event eventToEdit;

        public AddEventForm(Event existingEvent = null)
        {
            InitializeComponent();
            if (existingEvent != null)
            {
                eventToEdit = existingEvent; // Сохраняем ссылку на существующее событие
                monthCalendarDatePicker.SelectionStart = existingEvent.Date;
                dateTimePickerTime.Value = existingEvent.Time;
                textBoxDescription.Text = existingEvent.Description;
                comboBoxTypeOfTheNewRecord.SelectedItem = existingEvent.Category;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (monthCalendarDatePicker.SelectionStart < DateTime.Now.Date)
            {
                MessageBox.Show("Строить планы на прошлое не стоит.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxDescription.Text) || comboBoxTypeOfTheNewRecord.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Если мы редактируем событие, обновляем его
            if (eventToEdit != null)
            {
                eventToEdit.Date = monthCalendarDatePicker.SelectionStart.Date;
                eventToEdit.Time = dateTimePickerTime.Value;
                eventToEdit.Description = textBoxDescription.Text;
                eventToEdit.Category = comboBoxTypeOfTheNewRecord.SelectedItem.ToString();
            }
            else
            {
                // Если мы добавляем новое событие, создаем новый объект
                NewEvent = new Event
                {
                    Date = monthCalendarDatePicker.SelectionStart.Date,
                    Time = dateTimePickerTime.Value,
                    Description = textBoxDescription.Text,
                    Category = comboBoxTypeOfTheNewRecord.SelectedItem.ToString()
                };
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AddEventForm_Load(object sender, EventArgs e)
        {
            comboBoxTypeOfTheNewRecord.Items.Add("Напоминание");
            comboBoxTypeOfTheNewRecord.Items.Add("Встреча");
            comboBoxTypeOfTheNewRecord.Items.Add("Задача");
        }
    }
}
