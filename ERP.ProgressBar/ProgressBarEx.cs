using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
//If you are using this code to build a Class Library Project instead of just adding it to a Form Project then you
//will need to add a reference to System.Drawing and System.Windows.Forms for the next three Imports. You can do
//that after you create the new Class Library by going to the VB menu and clicking (Project) and then selecting (Add Reference...).
//Then on the (.Net) tab you can find and select (System.Drawing) and (System.Windows.Forms) to add the references.
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ERP.ProgressBar
{
    public class ProgressBarEx : Control
    {
        private Blend bBlend = new Blend();
        private int _Minimum = 0;
        private int _Maximum = 100;
        private int _Value = 0;
        private bool _Border = true;
        private Pen _BorderPen;
        private Color _BorderColor = Color.Black;
        private GradiantArea _GradiantPosition;
        private Color _BackColor;
        private Color _ProgressColor = Color.Lime;
        private SolidBrush _ForeColorBrush;
        private bool _ShowPercentage = false;
        private bool _ShowText = false;
        private ImageLayoutType _ImageLayout = ImageLayoutType.None;
        private Bitmap _Image = null;

        /// <summary>Enum of positions used for the ProgressBar`s GradiantPosition property.</summary>
        public enum GradiantArea : int
        {
            None = 0,
            Top = 1,
            Center = 2,
            Bottom = 3
        }

        /// <summary>Enum of ImageLayout types used for the ProgressBar`s ImageLayout property.</summary>
        public enum ImageLayoutType : int
        {
            None = 0,
            Center = 1,
            Stretch = 2
        }

        public ProgressBarEx()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.TabStop = false;
            this.Size = new Size(200, 23);
            bBlend.Positions = new float[] { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f };
            this.GradiantPosition = GradiantArea.Top; //Sets the bBlend.Factors
            base.BackColor = Color.DarkGray;
            _ForeColorBrush = new SolidBrush(base.ForeColor);
            _BorderPen = new Pen(Color.Black);
        }

        [Category("Appearance"), Description("The foreground color of the ProgressBars text.")]
        [Browsable(true)]
        public override System.Drawing.Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _ForeColorBrush.Color;
                }
                base.ForeColor = value;
                _ForeColorBrush.Color = value;
            }
        }

        [Category("Appearance"), Description("The background color of the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "DarkGray")]
        public override System.Drawing.Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _BackColor;
                }
                base.BackColor = value;
                _BackColor = value;
            }
        }

        [Category("Appearance"), Description("The progress color of the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Lime")]
        public Color ProgressColor
        {
            get { return _ProgressColor; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _ProgressColor;
                }
                _ProgressColor = value;
                this.Refresh();
            }
        }

        [Category("Behavior"), Description("The minimum value of the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(0)]
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum - 1;
                _Minimum = value;
                this.Refresh();
            }
        }

        [Category("Behavior"), Description("The maximum value of the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(100)]
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value <= _Minimum)
                    value = _Minimum + 1;
                _Maximum = value;
                this.Refresh();
            }
        }

        [Category("Behavior"), Description("The current value of the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(0)]
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value < _Minimum)
                    value = _Minimum;
                if (value > _Maximum)
                    value = _Maximum;
                _Value = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Draw a border around the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool Border
        {
            get { return _Border; }
            set
            {
                _Border = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The color of the border around the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _BorderColor;
                }
                _BorderColor = value;
                _BorderPen.Color = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Shows the progress percentge as text in the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(false)]
        public bool ShowPercentage
        {
            get { return _ShowPercentage; }
            set
            {
                _ShowPercentage = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Shows the text of the Text property in the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(false)]
        public bool ShowText
        {
            get { return _ShowText; }
            set
            {
                _ShowText = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Determins the position of the gradiant shine in the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(typeof(GradiantArea), "Top")]
        public GradiantArea GradiantPosition
        {
            get { return _GradiantPosition; }
            set
            {
                _GradiantPosition = value;
                if (value == GradiantArea.None)
                {
                    bBlend.Factors = new float[] { 0f, 0f, 0f, 0f, 0f, 0f }; //Shine None
                }
                else if (value == GradiantArea.Top)
                {
                    bBlend.Factors = new float[] { 0.8f, 0.7f, 0.6f, 0.4f, 0f, 0f }; //Shine Top
                }
                else if (value == GradiantArea.Center)
                {
                    bBlend.Factors = new float[] { 0f, 0.4f, 0.6f, 0.6f, 0.4f, 0f }; //Shine Center
                }
                else
                {
                    bBlend.Factors = new float[] { 0f, 0f, 0.4f, 0.6f, 0.7f, 0.8f }; //Shine Bottom
                }
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("An image to display on the ProgressBarEx.")]
        [Browsable(true)]
        public Bitmap Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Determins how the image is displayed in the ProgressBarEx.")]
        [Browsable(true)]
        [DefaultValue(typeof(ImageLayoutType), "None")]
        public ImageLayoutType ImageLayout
        {
            get { return _ImageLayout; }
            set
            {
                _ImageLayout = value;
                if (_Image != null)
                    this.Refresh();
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Point StartPoint = new Point(0, 0);
            Point EndPoint = new Point(0, this.Height);

            using (LinearGradientBrush _BackColorBrush = new LinearGradientBrush(StartPoint, EndPoint, _BackColor, Color.White))
            {
                _BackColorBrush.Blend = bBlend;
                using (Pen pn = new Pen(_BackColorBrush, this.Width))
                {
                    e.Graphics.DrawLine(pn, 0, Convert.ToInt32(this.Height / 2), this.Width, Convert.ToInt32(this.Height / 2));
                }
            }

            if (_Value > _Minimum)
            {
                int len = Convert.ToInt32(((double)this.Width / (double)(_Maximum - _Minimum)) * _Value);
                using (LinearGradientBrush _ProgressBrush = new LinearGradientBrush(StartPoint, EndPoint, _ProgressColor, Color.White))
                {
                    _ProgressBrush.Blend = bBlend;
                    using (Pen pn2 = new Pen(_ProgressBrush, this.Width))
                    {
                        e.Graphics.DrawLine(pn2, 0, Convert.ToInt32(this.Height / 2), len, Convert.ToInt32(this.Height / 2));
                    }
                }
            }

            if (_Image != null)
            {
                if (_ImageLayout == ImageLayoutType.Stretch)
                {
                    e.Graphics.DrawImage(_Image, 0, 0, this.Width, this.Height);
                }
                else if (_ImageLayout == ImageLayoutType.None)
                {
                    e.Graphics.DrawImage(_Image, 0, 0);
                }
                else
                {
                    int xx = Convert.ToInt32((this.Width / 2) - (_Image.Width / 2));
                    int yy = Convert.ToInt32((this.Height / 2) - (_Image.Height / 2));
                    e.Graphics.DrawImage(_Image, xx, yy);
                }
            }

            if (_ShowPercentage | _ShowText)
            {
                string perc = "";
                if (_ShowText)
                    perc = this.Text;
                if (_ShowPercentage)
                    perc += Convert.ToString(Convert.ToInt32(((double)100 / (double)(_Maximum - _Minimum)) * _Value)) + "%";

                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(perc, this.Font, _ForeColorBrush, new Rectangle(0, 0, this.Width, this.Height), sf);
                }
            }

            if (_Border)
            {
                e.Graphics.DrawRectangle(_BorderPen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            this.Refresh();
            base.OnTextChanged(e);
        }

        protected override void Dispose(bool disposing)
        {
            _ForeColorBrush.Dispose();
            _BorderPen.Dispose();
            base.Dispose(disposing);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete("BackgroundImageLayout is not implemented.", true)]
        public new ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set
            {
                throw new NotImplementedException("BackgroundImageLayout is not implemented.");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete("BackgroundImage is not implemented.", true)]
        public new Image BackgroundImage
        {
            get { return null; }
            set
            {
                throw new NotImplementedException("BackgroundImage is not implemented.");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete("TabStop is not implemented.", true)]
        public new bool TabStop
        {
            get { return false; }
            set
            {
                throw new NotImplementedException("TabStop is not implemented.");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete("TabIndex is not implemented.", true)]
        public new int TabIndex
        {
            get { return base.TabIndex; }
            set
            {
                throw new NotImplementedException("TabIndex is not implemented.");
            }
        }
    }
}
