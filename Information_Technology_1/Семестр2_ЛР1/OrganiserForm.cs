using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Семестр2_ЛР1
{
    public partial class OrganiserForm : Form
    {
        public class Event
        {
            public DateTime Date { get; set; }
            public DateTime Time { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
        }

        private List<Event> eventsList = new List<Event>();
        public OrganiserForm()
        {
            InitializeComponent();
        }

        private void UpdateEventList(string category)
        {
            List<Event> filteredEvents = category == "Показать всё"
                ? eventsList
                : eventsList.Where(e => e.Category == category).ToList();

            UpdateEventList(filteredEvents);
        }

        private void UpdateEventList(List<Event> sortedEvents)
        {
            listViewOrganiser.Items.Clear();

            foreach (var ev in sortedEvents)
            {
                // Определение индекса иконки в зависимости от категории
                int imageIndex = -1;

                switch (ev.Category)
                {
                    case "Напоминание":
                        imageIndex = imageList.Images.IndexOfKey("Reminder");
                        break;
                    case "Встреча":
                        imageIndex = imageList.Images.IndexOfKey("Meeting");
                        break;
                    case "Задача":
                        imageIndex = imageList.Images.IndexOfKey("Task");
                        break;
                    default:
                        imageIndex = -1;  // Если категории нет, не показывать иконку
                        break;
                }

                // Создаем элемент для ListView и добавляем его
                ListViewItem item = new ListViewItem(new string[] {
            ev.Date.ToString("dd.MM.yyyy"),
            ev.Time.ToString("HH:mm"),
            ev.Description,
            ev.Category
        })
                {
                    Tag = ev,
                    ImageIndex = imageIndex  // Устанавливаем соответствующую иконку
                };

                listViewOrganiser.Items.Add(item);
            }
        }



        private void SaveEventsToFile()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Создаем или перезаписываем файл
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine("Дата,Время,Событие,Категория");

                        // Записываем события
                        foreach (var ev in eventsList)
                        {
                            writer.WriteLine($"{ev.Date:yyyy-MM-dd},{ev.Time:HH:mm},{ev.Description},{ev.Category}");
                        }
                    }

                    MessageBox.Show("События успешно сохранены в файл.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось сохранить файл: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadEventsFromFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    var lines = File.ReadAllLines(filePath);

                    eventsList.Clear();

                    // Пропускаем первую строку с заголовками
                    foreach (var line in lines.Skip(1))
                    {
                        var columns = line.Split(',');

                        if (columns.Length == 4)
                        {
                            try
                            {
                                // Преобразуем строковые данные в нужные типы
                                var eventDate = DateTime.Parse(columns[0]);
                                var eventTime = DateTime.Parse(columns[1]);
                                var eventDescription = columns[2];
                                var eventCategory = columns[3];

                                // Создаем новое событие
                                Event newEvent = new Event
                                {
                                    Date = eventDate,
                                    Time = eventTime,
                                    Description = eventDescription,
                                    Category = eventCategory
                                };

                                // Добавляем событие в список
                                eventsList.Add(newEvent);
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Ошибка формата данных в файле.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    // Обновляем отображение событий
                    UpdateEventList("Показать всё");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось загрузить файл: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void DeleteSelectedEvent()
        {
            if (listViewOrganiser.SelectedItems.Count > 0)
            {
                var selectedEvent = (Event)listViewOrganiser.SelectedItems[0].Tag;

                var confirmationMessage = $"Вы уверены, что хотите удалить событие: '{selectedEvent.Date:dd.MM.yyyy}" +
                    $" / {selectedEvent.Time:HH:mm} / {selectedEvent.Description}'?";
                if (MessageBox.Show(confirmationMessage, "Удалить событие", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    eventsList.Remove(selectedEvent);
                    UpdateEventList("Показать всё");
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void OrganiserForm_Load(object sender, EventArgs e)
        {
            comboBoxTypeOfEvents.Items.Add("Показать всё");
            comboBoxTypeOfEvents.Items.Add("Напоминание");
            comboBoxTypeOfEvents.Items.Add("Встреча");
            comboBoxTypeOfEvents.Items.Add("Задача");

            UpdateEventList("Показать всё");
            radioButtonAllEvents.Checked = true;

        }

        private void comboBoxTypeOfEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = comboBoxTypeOfEvents.SelectedItem.ToString();
            UpdateEventList(selectedCategory);
        }

        private void radioButtonAllEvents_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAllEvents.Checked)
            {
                UpdateEventList("Показать всё");
            }
            else if (radioButtonAllByCategory.Checked)
            {
                string selectedCategory;
                if (comboBoxTypeOfEvents.SelectedItem != null)
                {
                    selectedCategory = comboBoxTypeOfEvents.SelectedItem.ToString();
                }
                else
                {
                    selectedCategory = "Показать всё";
                }

                UpdateEventList(selectedCategory);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //Открытие окна добавления события
            AddEventForm FormAddEvent = new AddEventForm();
            if (FormAddEvent.ShowDialog() == DialogResult.OK)
            {
                eventsList.Add(FormAddEvent.NewEvent);
                UpdateEventList("Показать всё");
                radioButtonAllEvents.Checked = true;
            }

        }

        private void EditEvent_Click(object sender, EventArgs e)
        {
            if (listViewOrganiser.SelectedItems.Count > 0)
            {
                // Получаем выбранное событие
                var selectedEvent = (Event)listViewOrganiser.SelectedItems[0].Tag;

                // Создаем форму для редактирования события
                AddEventForm editForm = new AddEventForm(selectedEvent);

                // Проверяем, что пользователь подтвердил изменения
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновляем список событий
                    UpdateEventList("Показать всё");
                }
            }
        }




        private void buttonFind_Click(object sender, EventArgs e)
        {
            string searchQuery = textBoxQuery.Text.Trim();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                // Фильтруем события, где описание (Description) содержит подстроку с игнорированием регистра
                var filteredEvents = eventsList
                    .Where(ev => ev.Description.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0)  // Поиск без учета регистра
                    .ToList();

                // Обновляем ListView с отфильтрованными событиями
                UpdateEventList(filteredEvents);
            }
            else
            {
                // Если запрос пуст, показываем все события
                UpdateEventList("Показать всё");
            }
        }




        private void OrganiserForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveEventsToFile();
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                LoadEventsFromFile();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedEvent();
            }
        }

        private void listViewOrganiser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DeleteEvent_Click(object sender, EventArgs e)
        {
            DeleteSelectedEvent();
        }

        private void contextMenuStripForEachEvent_Click(object sender, EventArgs e)
        {

        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonAllByCategory_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            List<Event> sortedEvents = eventsList.OrderBy(eventItem => eventItem.Description).ToList();

            UpdateEventList(sortedEvents);
        }

        private void tableLayoutPanelOrganizerOperations_Paint(object sender, PaintEventArgs e)
        {
        }

        private void buttonFind_Click_1(object sender, EventArgs e)
        {
        }

        private void textBoxQuery_TextChanged(object sender, EventArgs e)
        {
            // Автоматическое нажатие кнопки поиска при изменении текста для того,
            // чтобы это не пришлось делать вручную
            buttonFind.PerformClick();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
        }
    }
}
