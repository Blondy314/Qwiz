﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Qwiz
{
    public partial class QwizForm : Form
    {
        int _index;
        bool _wasCliecked;
        Button[] _buttons;
        private readonly Action _onHome;
        readonly QuestionInfo[] _questions;
        private readonly List<string>[] _groups;
        private readonly Language _language;

        private static int ScoreSize = 20;
        private static int QuestSize = 80;

        public QwizForm(QuestionInfo[] questions, List<string>[] groups, Language language, Action onHome)
        {
            InitializeComponent();

            _onHome = onHome;
            _groups = groups;
            _language = language;
            _questions = questions;

            WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Icon = Icon.FromHandle(new Bitmap(Properties.Resources.qwiz).GetHicon());

                CenterToScreen();

                var scoreItem = new ListViewItem();
                lstGroups.Columns.Add(new ColumnHeader
                {
                    Width = 0
                });

                for (var i = 0; i < _groups.Length; ++i)
                {
                    ColumnHeader col = new ColumnHeader
                    {
                        Text = (_language == Language.Hebrew ? "קבוצה " : "Group ") + (i + 1),
                        TextAlign = HorizontalAlignment.Center,
                        Width = lstGroups.Size.Width / _groups.Length,
                        Tag = 0
                    };

                    lstGroups.Columns.Add(col);

                    scoreItem.SubItems.Add("0");
                }

                scoreItem.UseItemStyleForSubItems = false;
                scoreItem.SubItems[2].Font = scoreItem.SubItems[1].Font = new Font(scoreItem.Font.FontFamily, ScoreSize, FontStyle.Bold);

                lstGroups.Items.Add(scoreItem);
                lstGroups.Items.Add(new ListViewItem());

                splitContainer2.SplitterDistance = splitContainer2.Width - splitContainer2.Width / 4;

                for (var i = 0; i < _groups[0].Count; ++i)
                {
                    var item = new ListViewItem();
                    for (var j = 0; j < _groups.Length; ++j)
                    {
                        item.SubItems.Add(_groups[j].ElementAt(i));
                    }

                    item.UseItemStyleForSubItems = false;
                    lstGroups.Items.Add(item);
                }

                _buttons = new Button[] { btnA, btnB, btnC, btnD };

                LoadQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load questions\n" + ex.Message);
                Close();
            }
        }

        private void LoadQuestion()
        {
            Text = $"Qwiz - Question {_index + 1}";
            tsNext.Enabled = false;
            _wasCliecked = false;

            foreach (var button in _buttons)
            {
                button.Enabled = true;
            }

            HighlightGroup();

            var quest = _questions[_index];

            txtQuest.Text = quest.Question;

            if (quest.PicLink != null)
            {
                txtQuest.BackgroundImage = Image.FromFile(quest.PicLink);
            }

            var space = splitContainer2.Panel2.Height / 4 - 30;

            var width = splitContainer2.Panel2.Width - 50;

            for (var i = 0; i < quest.Answers.Length; ++i)
            {
                _buttons[i].Font = new Font(_buttons[i].Font, FontStyle.Regular);

                _buttons[i].BackColor = Color.CornflowerBlue;
                _buttons[i].Text = quest.Answers[i].Val;
                _buttons[i].Tag = quest.Answers[i];

                _buttons[i].Location = new Point(splitContainer2.Panel1.Width / 2 - (width / 2), _buttons[0].Location.Y + space * i);
                _buttons[i].Size = new Size(width, _buttons[i].Size.Height);
            }

            txtQuest.rtb.SelectAll();
            txtQuest.rtb.Font = new Font(txtQuest.rtb.Font.FontFamily, QuestSize);
            txtQuest.rtb.SelectionAlignment = HorizontalAlignment.Center;
            txtQuest.rtb.DeselectAll();
            
            txtQuest.rtb.BackColor = Color.Black;
            txtQuest.rtb.ForeColor = Color.White;
            txtQuest.rtb.ReadOnly = true;

            lstGroups.Select();
        }

        private void HighlightGroup()
        {
            foreach (var cell in lstGroups.Items[0].SubItems.Cast<ListViewItem.ListViewSubItem>())
            {
                cell.BackColor = Color.Transparent;
            }

            ListViewItem.ListViewSubItem subItem = lstGroups.Items[0].SubItems[_index % _groups.Length + 1];
            subItem.BackColor = Color.LightGreen;
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            try
            {
                if (_wasCliecked)
                {
                    return;
                }

                _wasCliecked = true;

                var btn = (Button)sender;

                var ans = (Answer)btn.Tag;
                btn.BackColor = ans.Correct ? Color.GreenYellow : Color.Salmon;
                btn.Font = new Font(btn.Font, FontStyle.Bold);

                if (!ans.Correct)
                {
                    var correctBtn = _buttons.First(b => ((Answer)b.Tag).Correct);
                    correctBtn.BackColor = Color.GreenYellow;
                }
                else
                {
                    SetScore();
                }

                foreach (var button in _buttons)
                {
                    button.Enabled = false;
                }

                tsNext.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetScore()
        {
            var item = lstGroups.Items[0].SubItems[_index % _groups.Length + 1];
            item.Text = "" + (Convert.ToInt32(item.Text) + 1);
            item.Font = new Font(item.Font.FontFamily, ScoreSize);
        }

        private void tsNext_Click(object sender, EventArgs e)
        {
            ++_index;

            if (_index == _questions.Length)
            {
                MessageBox.Show(this, "The End", "Qwiz", MessageBoxButtons.OK);
                Close();
                return;
            }

            LoadQuestion();
        }

        private void tsHome_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void QuestForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

            if (e.KeyCode == Keys.Space)
            {
                tsNext.PerformClick();
                e.Handled = true;
            }
        }

        private void QuestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onHome();
        }
    }

    public class QuestionInfo
    {
        public string Question;
        public string PicLink;
        public Answer[] Answers;
    }

    public class Answer
    {
        public string Val;
        public bool Correct;
    }
}
