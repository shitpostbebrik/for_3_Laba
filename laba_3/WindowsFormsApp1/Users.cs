using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Security.Principal;

namespace WindowsFormsApp1
{

    public partial class Users : Form
    {
        DataBase dataBase = new DataBase();
        public Users()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("[№]", "№");
            dataGridView1.Columns.Add("Tovar", "Товар");
            dataGridView1.Columns.Add("Kolvo", "Количество");
            dataGridView1.Columns.Add("Cena", "Цена");
            dataGridView1.Columns.Add("Summa", "Сумма");
            

        }

        private decimal sum;

        //public void ReadSingleRows(DataGridView dgw, IDataRecord record)
        //{

        //    dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2) + " кг", record.GetInt32(3) + " руб.", record.GetInt32(4) + " руб.");

        //    sum += record.GetInt32(4);

        //}
        //private void RefreshDataGrid(DataGridView dgw)
        //{
        //    dgw.Rows.Clear();

        //    string stringQuery = $"select * from Tovars";

        //    SqlCommand cmd = new SqlCommand(stringQuery, dataBase.getConnection());

        //    dataBase.openConnection();
        //    SqlDataReader reader = cmd.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        ReadSingleRows(dgw, reader);
        //    }
        //    labelSumma.Text = sum.ToString() + " руб."; // выводим сумму в label

        //    sum = 0;
        //    reader.Close();

            



        //}

        private void Workers_Load(object sender, EventArgs e)
        {
            CreateColumns();
            //RefreshDataGrid(dataGridView1);
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ReadOnly = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.AllowUserToResizeRows = true;
            dataGridView1.RowHeadersWidthSizeMode =
            DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }


        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что измененная ячейка находится в столбце "Summa" (предполагая, что это столбец суммы)
            if (e.ColumnIndex == dataGridView1.Columns["Summa"].Index)
            {
                UpdateTotalSum();
            }
        }
        private void UpdateTotalSum()
        {
            decimal sum = 0;

            // Проходим по строкам и суммируем значения в столбце "Summa"
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                object cellValue = dataGridView1["Summa", i].Value;
                if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal Summa))
                {
                    sum += Summa;
                }
            }

            // Обновляем labelSumma рассчитанной суммой
            labelSumma.Text = sum.ToString("C"); // Формат "C" форматирует валюту
        }

        //private void export_Click(object sender, EventArgs e)
        //{
        //    //Word.Application wordApp = new Word.Application();
        //    //Word.Document doc = wordApp.Documents.Add("C:\\Users\\genry\\Downloads\\5 лаба Лупандин\\WindowsFormsApp1\\document.docx");

        //    //// Заменяем теги на значения из Windows Forms
        //    //ReplaceTagWithValue(doc, "<Postav>", Postav.Text);
        //    //ReplaceTagWithValue(doc, "<Pokup>", Pokup.Text);
        //    //ReplaceTagWithValue(doc, "<Nomer>", labelNomer.Text);
        //    //ReplaceTagWithValue(doc, "<Data>", labelData.Text);

        //    //// Вставляем таблицу из DataGridView
        //    //InsertDataGridViewIntoTable(doc, dataGridView1);

        //    //ReplaceTagWithValue(doc, "<ITOGO>", labelSumma.Text);

        //    //// Сохранение
        //    //doc.SaveAs2("C:\\Users\\genry\\Downloads\\export.docx");

        //    //wordApp.Visible = true;

        //    // Создание нового экземпляра Excel
        //    Excel.Application excelApp = new Excel.Application();

        //    // Добавление новой книги
        //    Excel.Workbook workbook = excelApp.Workbooks.Add();

        //    // Получение первого листа 
        //    Excel.Worksheet worksheet = workbook.Sheets[1];

        //    // Экспорт заголовков
        //    for (int i = 0; i < dataGridView1.ColumnCount; i++)
        //    {
        //        worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
        //    }

        //    // Экспорт данных
        //    for (int i = 0; i < dataGridView1.RowCount; i++)
        //    {
        //        for (int j = 0; j < dataGridView1.ColumnCount; j++)
        //        {
        //            worksheet.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
        //        }
        //    }

        //    // Видимость Excel и сохранение рабочей книги 
        //    excelApp.Visible = true;
        //}

        private void export_Click(object sender, EventArgs e)
        {
            // Создание нового экземпляра Excel
            Excel.Application excelApp = new Excel.Application();

            // Добавление новой книги
            Excel.Workbook workbook = excelApp.Workbooks.Add();

            // Получение первого листа 
            Excel.Worksheet worksheet = workbook.Sheets[1];

            // Экспорт заголовков с рамками
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                // Записываем заголовок в ячейку
                worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;

                // Устанавливаем рамку для заголовка
                worksheet.Range[worksheet.Cells[1, i + 1], worksheet.Cells[2, i + 1]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }

            // Экспорт данных с рамками
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    // Получаем значение ячейки
                    object cellValue = dataGridView1[j, i].Value;

                    // Записываем данные в ячейку (если не null)
                    worksheet.Cells[i + 2, j + 1] = cellValue != null ? cellValue.ToString() : string.Empty;

                    // Устанавливаем рамку для данных
                    worksheet.Cells[i + 2, j + 1].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }
            }


            // Видимость Excel и сохранение рабочей книги 
            excelApp.Visible = true;
        }


        private void InsertDataGridViewIntoTable(Word.Document doc, DataGridView dataGridView)
        {
            // Находим места в шаблоне для вставки таблицы
            Word.Range startRange = doc.Range();
            while (startRange.Find.Execute(FindText: "<TABLE_START>"))
            {
                // Находим конец таблицы
                Word.Range endRange = doc.Range(startRange.End, doc.Content.End);
                if (endRange.Find.Execute(FindText: "<TABLE_END>"))
                {
                    // Вставляем таблицу между <TABLE_START> и <TABLE_END>
                    Word.Table table = doc.Tables.Add(startRange, dataGridView.RowCount + 1, dataGridView.ColumnCount);
                    table.Borders.Enable = 1;

                    // Заполняем заголовки таблицы
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                    {
                        table.Cell(1, j + 1).Range.Text = dataGridView.Columns[j].HeaderText;
                    }

                    // Заполняем данные таблицы
                    for (int i = 0; i < dataGridView.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView.ColumnCount; j++)
                        {
                            object cellValue = dataGridView[j, i].Value;

                            // Check if the cell value is not null before accessing ToString
                            table.Cell(i + 2, j + 1).Range.Text = (cellValue != null) ? cellValue.ToString() : string.Empty;
                        }
                    }


                    // Удаляем теги-заменители
                    startRange.Delete();
                    endRange.Delete();
                }
            }
        }


        private void ReplaceTagWithValue(Word.Document doc, string tag, string value)
        {
            // Заменяем тег на значение
            Word.Range range = doc.Range();
            while (range.Find.Execute(FindText: tag))
            {
                range.Text = value;
            }
        }





        //private void export_Click(object sender, EventArgs e)
        //{
        //    Word.Application wordApp = new Word.Application();
        //    Word.Document doc = wordApp.Documents.Add();


        //    Word.Paragraph headerParagraph = doc.Paragraphs.Add();

        //    // Заголовок
        //    Word.Paragraph header = doc.Paragraphs.Add();
        //    header.Range.Text = $"Расходная накладная № {labelNomer.Text} от {labelData.Text}";
        //    header.Range.Bold = 0;  // Жирный шрифт
        //    header.Range.Underline = 0;  // Подчеркивание
        //    header.Range.InsertParagraphAfter();


        //    // Поставщик
        //    Word.Paragraph postavParagraph = doc.Paragraphs.Add();
        //    postavParagraph.Range.Text = $"Поставщик: {Postav.Text}";
        //    postavParagraph.Range.Bold = 0;
        //    postavParagraph.Range.Underline = 0;
        //    postavParagraph.Range.InsertParagraphAfter();

        //    // Покупатель
        //    Word.Paragraph pokupParagraph = doc.Paragraphs.Add();
        //    pokupParagraph.Range.Text = $"Покупатель: {Pokup.Text}";
        //    pokupParagraph.Range.Bold = 0;
        //    pokupParagraph.Range.Underline = 0;
        //    pokupParagraph.Range.InsertParagraphAfter();

        //    // Таблица
        //    Word.Table table = doc.Tables.Add(doc.Paragraphs.Last.Range, dataGridView1.RowCount + 2, dataGridView1.ColumnCount);

        //    table.Borders.Enable = 1;

        //    // Заголовки таблицы
        //    Word.Row headerRow = table.Rows[1];
        //    headerRow.Range.Font.Bold = 0;
        //    headerRow.Range.Underline = 0;

        //    for (int j = 0; j < dataGridView1.ColumnCount; j++)
        //    {
        //        headerRow.Cells[j + 1].Range.Text = dataGridView1.Columns[j].HeaderText;
        //    }

        //    // Данные таблицы
        //    for (int i = 0; i < dataGridView1.RowCount; i++)
        //    {
        //        Word.Row dataRow = table.Rows[i + 2];
        //        dataRow.Range.Font.Bold = 1;

        //        for (int j = 0; j < dataGridView1.ColumnCount; j++)
        //        {
        //            dataRow.Cells[j + 1].Range.Text = dataGridView1[j, i].Value.ToString();
        //        }
        //    }

        //    // Итого
        //    Word.Paragraph itogo = doc.Paragraphs.Add();
        //    itogo.Range.Text = $"Итого {labelSumma.Text}";
        //    itogo.Range.Bold = 0;
        //    itogo.Range.Underline = 0;
        //    itogo.Range.InsertParagraphAfter();

        //    // Сохранение
        //    doc.SaveAs2("C:\\Users\\genry\\Downloads\\export.docx");

        //    wordApp.Visible = true;
        //}





        

    }
}
