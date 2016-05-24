using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

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
                if (!fsTextBox.Focused)
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
                    valuenm = planckConstantJ / 4.186 * speedOfLight / Convert.ToDouble(JTextBox.Text) * 1e9;
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
                    valuenm = speedOfLight / (Convert.ToDouble(THzTextBox.Text) * 1e9) * 1e9;
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
    }
}



/* This code comes from Academo.org */
//var demo = new Demo({
//    ui: {
//        wavelength: {
//          title: "Wavelength",
//          value: 500,
//          units: "nm",
//          range:[380,780],
//          resolution:1
//        }
//    },
//    color:null,
//    init: function(){
//        $('#demo').append("<div id='color_display'></div>");
//        $('#ui-container').append("<div id='color'></div>");
//        this.update();
//    },
//    update: function(e){
//        this.color = this.nmToRGB(this.ui.wavelength.value);
//        $("#color_display").css("background-color", this.rgbToHex(this.color));
//        $("#color").html("<p><span>Color:</span><br />rgb("+ this.color[0] +","+ this.color[1] + ", "+ this.color[2] +")<br />Hex: " + this.rgbToHex(this.color) + "</p>");
//    },
//    nmToRGB: function(wavelength){
//        var Gamma = 0.80,
//        IntensityMax = 255,
//        factor, red, green, blue;
//        if((wavelength >= 380) && (wavelength<440)){
//            red = -(wavelength - 440) / (440 - 380);
//            green = 0.0;
//            blue = 1.0;
//        }else if((wavelength >= 440) && (wavelength<490)){
//            red = 0.0;
//            green = (wavelength - 440) / (490 - 440);
//            blue = 1.0;
//        }else if((wavelength >= 490) && (wavelength<510)){
//            red = 0.0;
//            green = 1.0;
//            blue = -(wavelength - 510) / (510 - 490);
//        }else if((wavelength >= 510) && (wavelength<580)){
//            red = (wavelength - 510) / (580 - 510);
//            green = 1.0;
//            blue = 0.0;
//        }else if((wavelength >= 580) && (wavelength<645)){
//            red = 1.0;
//            green = -(wavelength - 645) / (645 - 580);
//            blue = 0.0;
//        }else if((wavelength >= 645) && (wavelength<781)){
//            red = 1.0;
//            green = 0.0;
//            blue = 0.0;
//        }else{
//            red = 0.0;
//            green = 0.0;
//            blue = 0.0;
//        };
//        // Let the intensity fall off near the vision limits
//        if((wavelength >= 380) && (wavelength<420)){
//            factor = 0.3 + 0.7*(wavelength - 380) / (420 - 380);
//        }else if((wavelength >= 420) && (wavelength<701)){
//            factor = 1.0;
//        }else if((wavelength >= 701) && (wavelength<781)){
//            factor = 0.3 + 0.7*(780 - wavelength) / (780 - 700);
//        }else{
//            factor = 0.0;
//        };
//        if (red !== 0){
//            red = Math.round(IntensityMax * Math.pow(red * factor, Gamma));
//        }
//        if (green !== 0){
//            green = Math.round(IntensityMax * Math.pow(green * factor, Gamma));
//        }
//        if (blue !== 0){
//            blue = Math.round(IntensityMax * Math.pow(blue * factor, Gamma));
//        }
//        return [red,green,blue];
//    },
//    toHex: function(number){
//        //converts a decimal number into hex format
//        var hex =  number.toString(16);
//        if (hex.length < 2){
//            hex = "0" + hex;
//        }
//        return hex;
//    },
//    rgbToHex: function(color){
//        //takes an 3 element array (r,g,b) and returns a hexadecimal color
//        var hexString = '#';
//        for (var i = 0 ; i < 3 ; i++){
//            hexString += this.toHex(color[i]);
//        }
//        return hexString;
//    },
//    // renderRainbow: function(){
//    //     //render all the colours - used to generate the thumbnail image
//    //     var canvas = document.createElement('canvas');
//    //     var ctx = canvas.getContext("2d");
//    //     canvas.width = 870;
//    //     canvas.height = 400;
//    //     $("#demo").append(canvas);
//    //     for (var i = 0 ; i < canvas.width ; i++){
//    //         ctx.fillStyle = this.rgbToHex(this.nmToRGB(this.map(i, 0, canvas.width, this.ui.wavelength.range[0], this.ui.wavelength.range[1])));
//    //         ctx.fillRect(i, 0, 1, canvas.height);
//    //         ctx.fill();
//    //     }
//    // },
//    // map: function(value, minFrom, maxFrom, minTo, maxTo){
//    //     //http://stackoverflow.com/questions/4154969/how-to-map-numbers-in-range-099-to-range-1-01-0
//    //     return minTo + (maxTo - minTo) * ((value - minFrom) / (maxFrom - minFrom));
//    // }
//});
					