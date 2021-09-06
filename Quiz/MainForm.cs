using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Qwiz
{
    public partial class MainForm : Form
    {
        Random _rand;
        string _questionFile;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                Icon = Icon.FromHandle(new Bitmap(Properties.Resources.qwiz).GetHicon());
                _rand = new Random(DateTime.Now.Millisecond);

                panel1.AutoScroll = true;

                cmbLang.Items.Add(Language.English);
                cmbLang.Items.Add("עברית");

                cmbLang.SelectedIndex = 1;

                CenterToScreen();

                _questionFile = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Questions.xlsx");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void tsStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(_questionFile))
                {
                    throw new Exception("Question file not found - " + _questionFile);
                }

                var (questions, groups) = LoadData();

                if (questions.Length == 0)
                {
                    throw new Exception("No questions found in file - " + _questionFile);
                }

                if (groups.Length == 0)
                {
                    throw new Exception("Enter at least one group");
                }

                Hide();

                new QwizForm(questions, groups, (Language)cmbLang.SelectedIndex, () =>
                {
                    CenterToScreen();
                    Show();
                }).Show();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ShowError(Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Qwiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private (QuestionInfo[], List<string>[]) LoadData()
        {
            var tmpFile = Path.Combine(Path.GetDirectoryName(_questionFile), "_" + Path.GetFileName(_questionFile));

            try
            {
                if (File.Exists(tmpFile))
                {
                    File.Delete(tmpFile);
                }

                File.Copy(_questionFile, tmpFile);

                var info = new FileInfo(tmpFile);
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var xlPackage = new ExcelPackage(info))
                {
                    var questions = ReadQuestions(xlPackage);

                    var list = new List<int>();

                    foreach (var q in questions)
                    {
                        for (var i = 0; i < 4; ++i)
                        {
                            if (q.Answers[i].Correct)
                            {
                                list.Add(i);
                            }
                        }
                    }

                    var groups = ReadGroups(xlPackage);
                    return (Shuffle(questions.ToArray()), groups);
                }
            }
            finally
            {
                if (File.Exists(tmpFile))
                {
                    File.Delete(tmpFile);
                }
            }
        }

        private List<QuestionInfo> ReadQuestions(ExcelPackage xlPackage)
        {
            var questSheet = xlPackage.Workbook.Worksheets.FirstOrDefault(x => x.Name == "Questions");
            if (questSheet == null)
            {
                throw new Exception("Failed to get Questions sheet");
            }

            var questions = new List<QuestionInfo>();

            var totalRows = questSheet.Dimension.End.Row;
            var totalColumns = questSheet.Dimension.End.Column;

            var all = questSheet.Cells.Select(c => c.Value).ToArray();

            for (var i = 2; i <= totalRows; i++)
            {
                var row = questSheet.Cells[i, 1, i, totalColumns]
                    .Select(c => c.Value?.ToString() ?? string.Empty).ToArray();

                if (row.All(c => c.Trim().Length == 0))
                {
                    continue;
                }

                var q = ParseQuestion(row);
                if (q == null)
                {
                    continue;
                }

                if (questSheet.Cells[i, totalColumns].Hyperlink != null)
                {
                    q.PicLink = questSheet.Cells[i, totalColumns].Hyperlink.OriginalString;
                    if (!File.Exists(q.PicLink))
                    {
                        throw new Exception("Failed to find link - " + q.PicLink);
                    }
                }

                questions.Add(q);
            }

            return questions;
        }

        private List<string>[] ReadGroups(ExcelPackage xlPackage)
        {
            var groupSheet = xlPackage.Workbook.Worksheets.FirstOrDefault(x => x.Name == "Groups");
            if (groupSheet == null || groupSheet.Dimension == null)
            {
                throw new Exception("Failed to get Groups sheet");
            }

            var totalRows = groupSheet.Dimension.End.Row;
            var totalColumns = groupSheet.Dimension.End.Column;

            var all = groupSheet.Cells.Select(c => c.Value).ToArray();
            var groups = new List<string>[totalColumns];

            for (var i = 2; i <= totalRows; i++)
            {
                var row = groupSheet.Cells[i, 1, i, totalColumns]
                    .Select(c => c.Value?.ToString() ?? string.Empty).ToArray();

                if (row.All(c => c.Trim().Length == 0))
                {
                    continue;
                }

                if (row.Length != totalColumns)
                {
                    continue;
                }

                for (var j = 0; j < totalColumns; ++j)
                {
                    if (groups[j] == null)
                    {
                        groups[j] = new List<string>();
                    }

                    groups[j].Add(row[j]);
                }
            }

            return groups;
        }

        private T[] Shuffle<T>(T[] arr)
        {
            return arr.OrderBy(c => _rand.Next()).ToArray();
        }

        private QuestionInfo ParseQuestion(string[] sections)
        {
            try
            {
                var question = new QuestionInfo
                {
                    Question = sections[0].Trim(),
                    Answers = new Answer[4],
                };

                for (var i = 0; i < question.Answers.Length; ++i)
                {
                    question.Answers[i] = new Answer
                    {
                        Val = sections[1 + i].Trim(),
                        Correct = i == 0
                    };
                }

                question.Answers = Shuffle(question.Answers);

                return question;
            }
            catch
            {
                return null;
            }
        }

        private void btnQuestions_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(_questionFile))
                {
                    throw new Exception("Failed to find questions file - " + _questionFile);
                }

                Process.Start(_questionFile);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void cmbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cmbLang.SelectedIndex)
                {
                    case (int)Language.English:
                        btnStart.Text = "Start";
                        btnQuestions.Text = "Questions";
                        break;

                    case (int)Language.Hebrew:
                        btnStart.Text = "התחל";
                        btnQuestions.Text = "שאלות";
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }
    }

    public enum Language
    {
        English,
        Hebrew
    }
}
