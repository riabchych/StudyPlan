using ClosedXML.Excel;
using System;
using System.IO;
using System.Windows.Forms;

namespace StudyPlan
{
    public class ExportExcel
    {
        /// <summary>
        /// Метод експорту даних в файл Excel зі збереженням форматування
        /// </summary>
        /// <param name="fileName">Шлях до файлу</param>
        /// <param name="sheetName">Назва листа Excel</param>
        /// <param name="dataGridView">Компонент DataGridView</param>
        /// <returns></returns>
        public static bool ExportWithFormatting(string fileName, string sheetName, DataGridView dataGridView)
        {
            try
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add(sheetName);
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dataGridView.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dataGridView[j, i].Value ?? "";

                        if (worksheet.Cell(i + 2, j + 1).Value.ToString().Length > 0)
                        {
                            XLAlignmentHorizontalValues align;

                            switch (dataGridView.Rows[i].Cells[j].Style.Alignment)
                            {
                                case DataGridViewContentAlignment.BottomRight:
                                    align = XLAlignmentHorizontalValues.Right;
                                    break;
                                case DataGridViewContentAlignment.MiddleRight:
                                    align = XLAlignmentHorizontalValues.Right;
                                    break;
                                case DataGridViewContentAlignment.TopRight:
                                    align = XLAlignmentHorizontalValues.Right;
                                    break;

                                case DataGridViewContentAlignment.BottomCenter:
                                    align = XLAlignmentHorizontalValues.Center;
                                    break;
                                case DataGridViewContentAlignment.MiddleCenter:
                                    align = XLAlignmentHorizontalValues.Center;
                                    break;
                                case DataGridViewContentAlignment.TopCenter:
                                    align = XLAlignmentHorizontalValues.Center;
                                    break;
                                default:
                                    align = XLAlignmentHorizontalValues.Left;
                                    break;
                            }

                            worksheet.Cell(i + 2, j + 1).Style.Alignment.Horizontal = align;
                            XLColor xlColor = XLColor.FromColor(dataGridView.Rows[i].Cells[j].Style.SelectionBackColor);
                            _ = worksheet.Cell(i + 2, j + 1).AddConditionalFormat().WhenLessThan(1).Fill.SetBackgroundColor(xlColor);
                            worksheet.Cell(i + 2, j + 1).Style.Font.FontName = dataGridView.Font.Name;
                            worksheet.Cell(i + 2, j + 1).Style.Font.FontSize = dataGridView.Font.Size;
                        }
                    }
                }
                _ = worksheet.Columns().AdjustToContents();
                workbook.SaveAs(fileName);
                return File.Exists(fileName);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.ToString());
            }
            return false;
        }
    }
}
