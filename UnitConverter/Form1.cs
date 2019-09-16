using System;
using System.Windows.Forms;

namespace UnitConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private const double speedOfLight = 299792458; // m/s
        private const double planckConstantJ = 6.62607004e-34; // J s
        private const double planckConstanteV = 4.135667516e-15; // eV s

        private  double valueeV;
        private double valuemeV;
        private double valuem;
        private double valueum;
        private double valuenm;
        private double valueA;
        private double valueJ;
        private double valuekJ;
        private double valuecm;
        private double valueGHz;
        private double valueTHz;
        private double valueHz;
        private double valuefs;
        private double values;
        private double valueps;
        private double valueas;

        private int valueBar;
        private int valueBarGral;

        private void CalculateValues()
        {
            try
            {
                valueA = valuenm * 10;
                valueum = valuenm / 1000;
                valuem = valuenm / 1e9;

                valueeV = planckConstanteV * speedOfLight / (valuenm * 1.0e-9);
                valuemeV = valueeV * 1000.0;
                valueJ = planckConstantJ * speedOfLight / (valuenm * 1.0e-9);
                valuekJ = planckConstantJ * speedOfLight / (valuenm * 1.0e-9)/1000;

                valuecm = 1 / (1e-7 * valuenm);
                valueTHz = speedOfLight / (valuenm * 1e-9) * 1e-12;
                valueGHz = speedOfLight / (valuenm * 1e-9) * 1e-9;
                valueHz = speedOfLight / (valuenm * 1e-9);

                valueas = (valuenm * 1e-9) / speedOfLight * 1e18;
                valuefs = (valuenm * 1e-9) / speedOfLight * 1e15;
                valueps = (valuenm * 1e-9) / speedOfLight * 1e12;
                values = (valuenm * 1e-9) / speedOfLight;               

                valueBar = (int)((valuenm - 380) * 1000 / 400);
                valueBarGral = (int)((Math.Log10(valuenm) + 6) * 1000 / (18));

                if (valuenm < 380)
                {
                    valueBar = 0;
                }
                if (valuenm > 780)
                {
                    valueBar = 1000;
                }

                if (valuenm > 100 & valuenm < 1000)
                {
                    trackBarVisible.Visible = true;
                    visibleSpectrumPictureBox.Visible = true;
                }
                if (valuenm < 100 | valuenm > 1000)
                {
                    trackBarVisible.Visible = false;
                    visibleSpectrumPictureBox.Visible = false;
                }
                

                if (Math.Log10(valuenm) < -6)
                {
                    valueBarGral = 0;
                }
                if (Math.Log10(valuenm) > 12)
                {
                    valueBarGral = 1000;
                }

                if (!umTextBox.Focused)
                {
                    umTextBox.Text = String.Format("{0:0.00000}", valueum);
                    if (valueum < 1e-3 | valueps > 1e5)
                    {
                        umTextBox.Text = String.Format("{0:0.00000E+00}", valueum);
                    }
                }
                if (!nmTextBox.Focused)
                {
                    nmTextBox.Text = String.Format("{0:0.00000}", valuenm);
                    if (valuenm < 1e-3 | valuenm > 1e5)
                    {
                        nmTextBox.Text = String.Format("{0:0.00000E+00}", valuenm);
                    }
                }
                if (!mTextBox.Focused)
                {
                    mTextBox.Text = String.Format("{0:0.00000E+00}", valuem);                    
                    if (valuem < 1e-3 | valuem > 1e5)
                    {
                        mTextBox.Text = String.Format("{0:0.00000E+00}", valuem);
                    }
                }
                if (!ATextBox.Focused)
                {
                    ATextBox.Text = String.Format("{0:0.00000}", valueA);
                    if (valueA < 1e-3 | valueA > 1e5)
                    {
                        ATextBox.Text = String.Format("{0:0.00000E+00}", valueA);
                    }
                }
                if (!eVTextBox.Focused)
                {
                    eVTextBox.Text = String.Format("{0:0.00000}", valueeV);                    
                    if (valueeV < 1e-3 | valueeV > 1e5)
                    {
                        eVTextBox.Text = String.Format("{0:0.00000E+00}", valueeV);
                    }
                }
                if (!meVTextBox.Focused)
                {
                    meVTextBox.Text = String.Format("{0:0.00000}", valuemeV);
                    if (valuemeV < 1e-3 | valuemeV > 1e5)
                    {
                        meVTextBox.Text = String.Format("{0:0.00000E+00}", valuemeV);
                    }
                }
                if (!JTextBox.Focused)
                {
                    JTextBox.Text = String.Format("{0:0.00000}", valueJ);                 
                    if (valueJ < 1e-3 | valuemeV > 1e5)
                    {
                        JTextBox.Text = String.Format("{0:0.00000E+00}", valueJ);
                    }
                }
                if (!kJTextBox.Focused)
                {
                    kJTextBox.Text = String.Format("{0:0.00000}", valuekJ);
                    if (valuekJ < 1e-3 | valuekJ > 1e5)
                    {
                        kJTextBox.Text = String.Format("{0:0.00000E+00}", valuekJ);
                    }
                }
                if (!cmTextBox.Focused)
                {
                    cmTextBox.Text = String.Format("{0:0.00000}", valuecm);                    
                    if (valuecm < 1e-3 | valuecm > 1e5)
                    {
                        cmTextBox.Text = String.Format("{0:0.00000E+00}", valuecm);
                    }
                }
                if (!GHzTextBox.Focused)
                {
                    GHzTextBox.Text = String.Format("{0:0.00000}", valueGHz);
                    if (valueGHz < 1e-3 | valueGHz > 1e5)
                    {
                        GHzTextBox.Text = String.Format("{0:0.00000E+00}", valueGHz);
                    }
                }
                if (!THzTextBox.Focused)
                {
                    THzTextBox.Text = String.Format("{0:0.00000}", valueTHz);
                    if (valueTHz < 1e-3 | valueTHz > 1e5)
                    {
                        THzTextBox.Text = String.Format("{0:0.00000E+00}", valueTHz);
                    }
                }
                if (!HzTextBox.Focused)
                {
                    HzTextBox.Text = String.Format("{0:0.00000}", valueHz);
                    if (valueHz < 1e-3 | valueHz > 1e5)
                    {
                        HzTextBox.Text = String.Format("{0:0.00000E+00}", valueHz);
                    }
                }
                if (!sTextBox.Focused)
                {
                    sTextBox.Text = String.Format("{0:0.00000}", values);
                    if(values < 1e-3 | values > 1e5)
                    {
                        sTextBox.Text = String.Format("{0:0.00000E+00}", values);
                    }
                }

                if (!fsTextBox.Focused)
                {
                    fsTextBox.Text = String.Format("{0:0.00000}", valuefs);                  
                    if (valuefs < 1e-3 | valuefs > 1e5)
                    {
                        fsTextBox.Text = String.Format("{0:0.00000E+00}", valuefs);
                    }
                }
                if (!psTextBox.Focused)
                {
                    psTextBox.Text = String.Format("{0:0.00000}", valueps);
                    if (valueps < 1e-3 | valueps > 1e5)
                    {
                        psTextBox.Text = String.Format("{0:0.00000E+00}", valueps);
                    }
                }
                if (!asTextBox.Focused)
                {
                    asTextBox.Text = String.Format("{0:0.00000}", valueas);                  
                    if (valueas < 1e-3 | valueas > 1e5)
                    {
                        asTextBox.Text = String.Format("{0:0.00000E+00}", valueas);
                    }
                }
                if (!trackBarVisible.Focused)
                {
                    trackBarVisible.Value = valueBar;
                }
                if (!trackBarGral.Focused)
                {
                    trackBarGral.Value = valueBarGral;
                }
            }
            catch
            {
                return;
            }
        }

        private void nmTextBox_TextChanged(object sender, EventArgs e)
        {
            if (nmTextBox.Focused)
            {
                try
                {
                    valuenm = Convert.ToDouble(nmTextBox.Text);
                    CalculateValues();                    
                }
                catch
                {
                    return;
                }
            }
        }        
       

        private void trackBarVisible_Scroll(object sender, EventArgs e)
        {
            if (trackBarVisible.Focused)
            {
                try
                {
                    valuenm = Convert.ToDouble(trackBarVisible.Value) * 400 / 1000 + 380;
                    CalculateValues();                    
                }
                catch
                {
                    return;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();            
            int rndValue = rnd.Next(0,1000);
            double wavelength = Convert.ToDouble(rndValue) * 400 / 1000 + 380;
            //double wavelength = Math.Pow(10, Convert.ToDouble(rndValue) * 18 / 1000 - 6);
            nmTextBox.Text = string.Format("{0:0.00000}", wavelength);
            try
            {
                valuenm = wavelength;
                CalculateValues();
            }
            catch
            {
                return;
            }
        }

        private void ATextBox_TextChanged(object sender, EventArgs e)
        {
            if (ATextBox.Focused)
            {
                try
                {
                    valuenm = Convert.ToDouble(ATextBox.Text) / 10.0;
                    CalculateValues();                   
                }
                catch
                {
                    return;
                }
            }
        }

        private void meVTextBox_TextChanged(object sender, EventArgs e)
        {
            if (meVTextBox.Focused)
            {
                try
                {
                    valuenm = planckConstanteV * speedOfLight / (Convert.ToDouble(meVTextBox.Text) * 1e-3 * 1e-9);
                    CalculateValues();
                }
                catch
                {
                    return;
                }
            }
        }

        private void eVTextBox_TextChanged(object sender, EventArgs e)
        {
            if (eVTextBox.Focused)
            {
                try
                {
                    valuenm = planckConstanteV * speedOfLight / ( Convert.ToDouble(eVTextBox.Text) * 1e-9 );
                    CalculateValues();                    
                }
                catch
                {
                    return;
                }
            }
        }

        private void JTextBox_TextChanged(object sender, EventArgs e)
        {
            if (JTextBox.Focused)
            {
                try
                {
                    valuenm = planckConstantJ * speedOfLight / Convert.ToDouble(JTextBox.Text) * 1e9;
                    CalculateValues();
                }
                catch
                {
                    return;
                }
            }

        }

     

       

        private void cmTextBox_TextChanged(object sender, EventArgs e)
        {
            if (cmTextBox.Focused)
            {
                try
                {
                    valuenm = 1 /  Convert.ToDouble(cmTextBox.Text) * 1e7;
                    CalculateValues();
                }
                catch
                {
                    return;
                }
            }
        }

        private void THzTextBox_TextChanged(object sender, EventArgs e)
        {
            if (THzTextBox.Focused)
            {
                try
                {
                    valuenm = speedOfLight /  ( Convert.ToDouble(THzTextBox.Text) * 1e12) * 1e9;
                    CalculateValues();     
                }
                catch
                {
                    return;
                }
            }

        }

        private void fsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (fsTextBox.Focused)
            {
                try
                {
                    valuenm = Convert.ToDouble(fsTextBox.Text) * 1e-15 * speedOfLight * 1e9;
                    CalculateValues();
                }
                catch
                {
                    return;
                }
            }
        }

        private void psTextBox_TextChanged(object sender, EventArgs e)
        {
            if (psTextBox.Focused)
            {
                try
                {
                    valuenm = Convert.ToDouble(psTextBox.Text) * 1e-12 * speedOfLight * 1e9;
                    CalculateValues();                 
                }
                catch
                {
                    return;
                }
            }

        }

        private void calTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void GHzTextBox_TextChanged(object sender, EventArgs e)
        {
            if (GHzTextBox.Focused)
            {
                try
                {
                    valuenm = speedOfLight / (Convert.ToDouble(GHzTextBox.Text) * 1e9) * 1e9;
                    CalculateValues();
                }
                catch
                {
                    return;
                }
            }
        }

        private void nsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (asTextBox.Focused)
            {
                try
                {
                    valuenm = Convert.ToDouble(asTextBox.Text) * 1e-9 * speedOfLight * 1e9;
                    CalculateValues();
                }
                catch
                {
                    return;
                }
            }
        }

        private void umTextBox_TextChanged(object sender, EventArgs e)
        {
            if (umTextBox.Focused)
            {
                try
                {
                    valuenm = Convert.ToDouble(umTextBox.Text) * 1000;
                    CalculateValues();
                }
                catch
                {
                    return;
                }
            }
        }

        private void trackBarGral_Scroll(object sender, EventArgs e)
        {
            if (trackBarGral.Focused)
            {
                try
                {
                    valuenm = Math.Pow(10,Convert.ToDouble(trackBarGral.Value) * 18 / 1000  - 6);
                    CalculateValues();
                }
                catch
                {
                    return;
                }
            }
        }

        private void sTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sTextBox.Focused)
            {
                try
                {
                    valuenm = Convert.ToDouble(sTextBox.Text) * speedOfLight * 1e9;
                    CalculateValues();
                }
                catch
                {
                    return;
                }
            }
        }

        private void HzTextBox_TextChanged(object sender, EventArgs e)
        {
            if (HzTextBox.Focused)
            {
                try
                {
                    valuenm = speedOfLight / (Convert.ToDouble(HzTextBox.Text)) * 1e9;
                    CalculateValues();
                }
                catch
                {
                    return;
                }
            }
        }

        private void kJTextBox_TextChanged(object sender, EventArgs e)
        {
            if (kJTextBox.Focused)
            {
                try
                {
                    valuenm = planckConstantJ * speedOfLight / Convert.ToDouble(kJTextBox.Text) * 1e-3 * 1e9;
                    CalculateValues();
                }
                catch
                {
                    return;
                }
            }
        }

        private void mTextBox_TextChanged(object sender, EventArgs e)
        {
            if (mTextBox.Focused)
            {
                try
                {
                    valuenm = Convert.ToDouble(mTextBox.Text) * 1e9;
                    CalculateValues();
                }
                catch
                {
                    return;
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
	