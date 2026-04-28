using System.ComponentModel;

namespace DigitalProductionProgram.ControlsManagement
{
    public class DropdownSelector : Control
    {
        private readonly ContextMenuStrip dropDownMenu = new();
        private readonly List<string> items = [];
        private bool isHovered;
        private bool isDropDownOpen;
        private int selectedIndex = -1;
        public event EventHandler? SelectedIndexChanged;
        public DropdownSelector()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.Opaque, true);
            BackColor = Color.FromArgb(48, 48, 48);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            TabStop = true;
            Cursor = Cursors.Hand;
            dropDownMenu.ShowImageMargin = false;
            dropDownMenu.ShowCheckMargin = true;
            dropDownMenu.Closed += DropDownMenu_Closed;
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get => selectedIndex;
            set => SetSelectedIndex(value);
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ItemCount => items.Count;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedText => selectedIndex >= 0 && selectedIndex < items.Count ? items[selectedIndex] : string.Empty;
        public void SetItems(IEnumerable<string> values)
        {
            items.Clear();
            items.AddRange(values);
            if (selectedIndex >= items.Count)
                selectedIndex = items.Count - 1;
            if (items.Count == 0)
                selectedIndex = -1;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            var borderColor = isDropDownOpen || Focused ? Color.FromArgb(220, 188, 111) : isHovered ? Color.FromArgb(150, 126, 76) : Color.FromArgb(86, 72, 43);
            using var borderPen = new Pen(borderColor);
            using var arrowBrush = new SolidBrush(borderColor);
            var rect = ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            e.Graphics.DrawRectangle(borderPen, rect);
            var arrowCenterX = Width - 16;
            var arrowCenterY = Height / 2;
            var points = new[]
            {
                new Point(arrowCenterX - 4, arrowCenterY - 2),
                new Point(arrowCenterX + 4, arrowCenterY - 2),
                new Point(arrowCenterX, arrowCenterY + 3)
            };
            e.Graphics.FillPolygon(arrowBrush, points);
            var textRect = new Rectangle(8, 0, Math.Max(0, Width - 30), Height);
            TextRenderer.DrawText(e.Graphics, SelectedText, Font, textRect, ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovered = true;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            if (e.Button == MouseButtons.Left)
                ShowDropDown();
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData is Keys.Enter or Keys.Space or Keys.Down)
            {
                ShowDropDown();
                return true;
            }
            if (keyData == Keys.Up && items.Count > 0)
            {
                SetSelectedIndex(selectedIndex <= 0 ? items.Count - 1 : selectedIndex - 1);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ShowDropDown()
        {
            if (items.Count == 0 || isDropDownOpen)
                return;
            dropDownMenu.Items.Clear();
            for (var i = 0; i < items.Count; i++)
            {
                var menuItem = new ToolStripMenuItem(items[i])
                {
                    Tag = i,
                    Checked = i == selectedIndex,
                    BackColor = BackColor,
                    ForeColor = ForeColor
                };
                menuItem.Click += MenuItem_Click;
                dropDownMenu.Items.Add(menuItem);
            }
            isDropDownOpen = true;
            Invalidate();
            dropDownMenu.Show(this, new Point(0, Height));
        }
        private void MenuItem_Click(object? sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem { Tag: int index })
                return;
            SetSelectedIndex(index);
        }
        private void DropDownMenu_Closed(object? sender, ToolStripDropDownClosedEventArgs e)
        {
            isDropDownOpen = false;
            Invalidate();
        }
        private void SetSelectedIndex(int value)
        {
            if (value < -1 || value >= items.Count || selectedIndex == value)
                return;
            selectedIndex = value;
            Invalidate();
            SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                dropDownMenu.Dispose();
            base.Dispose(disposing);
        }
    }
}
