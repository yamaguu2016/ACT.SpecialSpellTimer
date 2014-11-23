﻿namespace ACT.SpecialSpellTimer
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using ACT.SpecialSpellTimer.Properties;

    /// <summary>
    /// Configパネル オプション
    /// </summary>
    public partial class ConfigPanel
    {
        /// <summary>
        /// オプションのLoad
        /// </summary>
        private void LoadOption()
        {
            this.LoadSettingsOption();

            this.SwitchOverlayButton.Click += (s1, e1) =>
            {
                Settings.Default.OverlayVisible = !Settings.Default.OverlayVisible;
                Settings.Default.Save();
                this.LoadSettingsOption();

                if (Settings.Default.OverlayVisible)
                {
                    SpellTimerCore.Default.ActivatePanels();
                }
            };
        }

        /// <summary>
        /// 適用する Click
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void TekiyoButton_Click(object sender, EventArgs e)
        {
            this.ApplySettingsOption();
        }

        /// <summary>
        /// BarColor Click
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void BarColorButton_Click(object sender, EventArgs e)
        {
            this.ColorDialog.Color = this.PreviewLabel.BackColor;
            if (this.ColorDialog.ShowDialog(this) != DialogResult.Cancel)
            {
                this.PreviewLabel.BackColor = this.ColorDialog.Color;
            }
        }

        /// <summary>
        /// Font Click
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void FontButton_Click(object sender, EventArgs e)
        {
            this.FontDialog.Font = this.PreviewLabel.Font;
            if (this.FontDialog.ShowDialog(this) != DialogResult.Cancel)
            {
                this.PreviewLabel.Font = this.FontDialog.Font;
            }
        }

        /// <summary>
        /// FontColor Click
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void FontColorButton_Click(object sender, EventArgs e)
        {
            this.ColorDialog.Color = this.PreviewLabel.ForeColor;
            if (this.ColorDialog.ShowDialog(this) != DialogResult.Cancel)
            {
                this.PreviewLabel.ForeColor = this.ColorDialog.Color;
            }
        }

        /// <summary>
        /// オプション設定をロードする
        /// </summary>
        private void LoadSettingsOption()
        {
            if (Settings.Default.OverlayVisible)
            {
                this.SwitchOverlayButton.Text = "オーバーレイを隠す";
            }
            else
            {
                this.SwitchOverlayButton.Text = "オーバーレイを表示する";
            }

            this.BarWidthNumericUpDown.Value = Settings.Default.ProgressBarSize.Width;
            this.BarHeightNumericUpDown.Value = Settings.Default.ProgressBarSize.Height;
            this.PreviewLabel.BackColor = Settings.Default.ProgressBarColor;
            this.PreviewLabel.Font = Settings.Default.Font;
            this.PreviewLabel.ForeColor = Settings.Default.FontColor;
            this.OpacityNumericUpDown.Value = Settings.Default.Opacity;
            this.ClickThroughCheckBox.Checked = Settings.Default.ClickThroughEnabled;
            this.AutoSortCheckBox.Checked = Settings.Default.AutoSortEnabled;
            this.AutoSortReverseCheckBox.Checked = Settings.Default.AutoSortReverse;
            this.TimeOfHideNumericUpDown.Value = (decimal)Settings.Default.TimeOfHideSpell;
            this.RefreshIntervalNumericUpDown.Value = Settings.Default.RefreshInterval;
        }

        /// <summary>
        /// 設定を適用する
        /// </summary>
        private void ApplySettingsOption()
        {
            Settings.Default.ProgressBarSize = new Size(
                (int)this.BarWidthNumericUpDown.Value,
                (int)this.BarHeightNumericUpDown.Value);
            Settings.Default.ProgressBarColor = this.PreviewLabel.BackColor;
            Settings.Default.Font = this.PreviewLabel.Font;
            Settings.Default.FontColor = this.PreviewLabel.ForeColor;
            Settings.Default.Opacity = (int)this.OpacityNumericUpDown.Value;
            Settings.Default.ClickThroughEnabled = this.ClickThroughCheckBox.Checked;
            Settings.Default.AutoSortEnabled = this.AutoSortCheckBox.Checked;
            Settings.Default.AutoSortReverse = this.AutoSortReverseCheckBox.Checked;
            Settings.Default.TimeOfHideSpell = (double)this.TimeOfHideNumericUpDown.Value;
            Settings.Default.RefreshInterval = (long)this.RefreshIntervalNumericUpDown.Value;

            // 設定を保存する
            Settings.Default.Save();

            // Windowを一旦すべて閉じる
            SpellTimerCore.Default.ClosePanels();
        }
    }
}