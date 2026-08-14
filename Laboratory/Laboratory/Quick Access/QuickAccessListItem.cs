using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework;

namespace Laboratory.Quick_Access
{
    public sealed partial class QuickAccessListItem : UserControl
    {
        public QuickAccessListItem()
        {
            InitializeComponent();
            this.Click += QuickAccessListItem_Click;
            lblTitle.Click += QuickAccessListItem_Click;
            lblDescription.Click += QuickAccessListItem_Click;
            picBox.Click += QuickAccessListItem_Click;
            pnlIconBackground.Click += QuickAccessListItem_Click;
            pnlUnderline.Click += QuickAccessListItem_Click;
            this.Cursor = Cursors.Hand;
        }

        #region Properties

        public int ItemId { get; set; }
        public Type FormType { get; set; }
        public Action OpenForm { get; set; }
        public event EventHandler ItemClicked;
        private string _title;
        private string _description;
        private Image _icon;
        private Color _iconBackground;

        [Category("Quick Access Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value;
                lblTitle.Text = value;
            }
        }

        [Category("Quick Access Props")]
        public string Description
        {
            get { return _description; }
            set { _description = value;
                lblDescription.Text = value;
            }
        }

        [Category("Quick Access Props")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value;
                picBox.Image = value;
            }
        }

        [Category("Quick Access Props")]
        public Color IconBackground
        {
            get { return _iconBackground; }
            set
            {
                _iconBackground = value;
                pnlIconBackground.BackColor = value;
            }
        }


        #endregion


        private void QuickAccessListItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
            UiHelper.SetRoundedCorners(this, 40);
        }

        private void QuickAccessListItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.Region = null;
        }

        private void QuickAccessListItem_Click(object sender, EventArgs e)
        {
            ItemClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
