using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            int ddd = 0;
            string txfx = "";
            for (int n=0; n< TextBox1.Text.Length; n=n+1)
            {
                //MessageBox.Show(TextBox1.Text.Substring(n,1));
                if (
                    (TextBox1.Text.Substring(n, 1) == "1") |
                    (TextBox1.Text.Substring(n, 1) == "2") |
                    (TextBox1.Text.Substring(n, 1) == "3") |
                    (TextBox1.Text.Substring(n, 1) == "4") |
                    (TextBox1.Text.Substring(n, 1) == "5") |
                    (TextBox1.Text.Substring(n, 1) == "6") |
                    (TextBox1.Text.Substring(n, 1) == "7") |
                    (TextBox1.Text.Substring(n, 1) == "8") |
                    (TextBox1.Text.Substring(n, 1) == "9") |
                    (TextBox1.Text.Substring(n, 1) == "0") |
                    (TextBox1.Text.Substring(n, 1) == ".")
                    )
                {
                    if ((TextBox1.Text.Substring(n, 1) != ".") | (ddd == 0))
                    {
                        txfx = txfx + TextBox1.Text.Substring(n, 1);
                        if (TextBox1.Text.Substring(n, 1) == ".")
                        {
                            ddd = 1;
                        }
                    }
                    
                }
            }
            if (txfx == "")
            {
                txfx = "0";
            }

            Entry_a = float.Parse(txfx);

            byte[] hexier = BitConverter.GetBytes(Entry_a);

            byte[] hexy = hexier.Reverse().ToArray();

            Aa = hexy[0];
            Ab = hexy[1];
            Ac = hexy[2];
            Ad = hexy[3];

            TextBox1.Text = txfx;
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Any unsaved changes will be lost. Is this OK?", "Warning",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void Form1_Closing(Object sender, CancelEventArgs e)
        {
            DialogResult = MessageBox.Show("Any unsaved changes will be lost. Is this OK?", "Warning",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Any unsaved changes will be lost. Is this OK?", "Warning",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
                OpenFileDialog1.InitialDirectory = "c:\\";
                OpenFileDialog1.Filter = "Basic AI Speed File (*.bas)|*.bas";
                OpenFileDialog1.FilterIndex = 1;
                OpenFileDialog1.RestoreDirectory = true;
                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //MessageBox.Show(OpenFileDialog1.FileName);
                        Ofile = OpenFileDialog1.FileName;
                        using (BinaryReader b = new BinaryReader(
                        File.Open(OpenFileDialog1.FileName, FileMode.Open)))
                        {
                            
                            int length = (int)b.BaseStream.Length;

                            if (length == 20)
                            {
                                Aa = b.ReadByte();
                                Ab = b.ReadByte();
                                Ac = b.ReadByte();
                                Ad = b.ReadByte();
                                Ba = b.ReadByte();
                                Bb = b.ReadByte();
                                Bc = b.ReadByte();
                                Bd = b.ReadByte();
                                Ca = b.ReadByte();
                                Cb = b.ReadByte();
                                Cc = b.ReadByte();
                                Cd = b.ReadByte();
                                Da = b.ReadByte();
                                Db = b.ReadByte();
                                Dc = b.ReadByte();
                                Dd = b.ReadByte();
                                Ea = b.ReadByte();
                                Eb = b.ReadByte();
                                Ec = b.ReadByte();
                                Ed = b.ReadByte();

                                /*
                                MessageBox.Show("Length: " + Convert.ToString(length));
                                MessageBox.Show(Convert.ToString(Aa));
                                MessageBox.Show(Convert.ToString(Ab));
                                MessageBox.Show(Convert.ToString(Ac));
                                MessageBox.Show(Convert.ToString(Ad));
                                MessageBox.Show(Convert.ToString(Ba));
                                MessageBox.Show(Convert.ToString(Bb));
                                MessageBox.Show(Convert.ToString(Bc));
                                MessageBox.Show(Convert.ToString(Bd));
                                MessageBox.Show(Convert.ToString(Ca));
                                MessageBox.Show(Convert.ToString(Cb));
                                MessageBox.Show(Convert.ToString(Cc));
                                MessageBox.Show(Convert.ToString(Cd));
                                MessageBox.Show(Convert.ToString(Da));
                                MessageBox.Show(Convert.ToString(Db));
                                MessageBox.Show(Convert.ToString(Dc));
                                MessageBox.Show(Convert.ToString(Dd));
                                MessageBox.Show(Convert.ToString(Ea));
                                MessageBox.Show(Convert.ToString(Eb));
                                MessageBox.Show(Convert.ToString(Ec));
                                MessageBox.Show(Convert.ToString(Ed));
                                */

                                Sav_aa = Aa;
                                Sav_ab = Ab;
                                Sav_ac = Ac;
                                Sav_ad = Ad;
                                Sav_ba = Ba;
                                Sav_bb = Bb;
                                Sav_bc = Bc;
                                Sav_bd = Bd;
                                Sav_ca = Ca;
                                Sav_cb = Cb;
                                Sav_cc = Cc;
                                Sav_cd = Cd;
                                Sav_da = Da;
                                Sav_db = Db;
                                Sav_dc = Dc;
                                Sav_dd = Dd;
                                Sav_ea = Ea;
                                Sav_eb = Eb;
                                Sav_ec = Ec;
                                Sav_ed = Ed;
                                
                                byte[] Floater = new byte[] { (byte)Aa, (byte)Ab, (byte)Ac, (byte)Ad };
                                var Floaters = Floater.Reverse().ToArray();
                                Entry_a = BitConverter.ToSingle(Floaters, 0);
                                Floater = new byte[] { (byte)Ba, (byte)Bb, (byte)Bc, (byte)Bd };
                                Floaters = Floater.Reverse().ToArray();
                                Entry_b = BitConverter.ToSingle(Floaters, 0);
                                Floater = new byte[] { (byte)Ca, (byte)Cb, (byte)Cc, (byte)Cd };
                                Floaters = Floater.Reverse().ToArray();
                                Entry_c = BitConverter.ToSingle(Floaters, 0);
                                Floater = new byte[] { (byte)Da, (byte)Db, (byte)Dc, (byte)Dd };
                                Floaters = Floater.Reverse().ToArray();
                                Entry_d = BitConverter.ToSingle(Floaters, 0);
                                Floater = new byte[] { (byte)Ea, (byte)Eb, (byte)Ec, (byte)Ed };
                                Floaters = Floater.Reverse().ToArray();
                                Entry_e = BitConverter.ToSingle(Floaters, 0);

                                TextBox1.Text = Entry_a.ToString();
                                textBox2.Text = Entry_b.ToString();
                                textBox3.Text = Entry_c.ToString();
                                textBox4.Text = Entry_d.ToString();
                                textBox5.Text = Entry_e.ToString();

                                Text = Ofile + " - BASic Tool";
                            }
                            else
                            {
                                if (length < 20)
                                    MessageBox.Show("Files must be 20 bytes in size.", "File too small", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if (length > 20)
                                    MessageBox.Show("Files must be 20 bytes in size.", "File too large", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Ofile))
            {
                //File.Delete(Ofile);

                byte[] Savebytes = null;
                Savebytes = new byte[20];
                Savebytes[0] = (byte)Aa;
                Savebytes[1] = (byte)Ab;
                Savebytes[2] = (byte)Ac;
                Savebytes[3] = (byte)Ad;
                Savebytes[4] = (byte)Ba;
                Savebytes[5] = (byte)Bb;
                Savebytes[6] = (byte)Bc;
                Savebytes[7] = (byte)Bd;
                Savebytes[8] = (byte)Ca;
                Savebytes[9] = (byte)Cb;
                Savebytes[10] = (byte)Cc;
                Savebytes[11] = (byte)Cd;
                Savebytes[12] = (byte)Da;
                Savebytes[13] = (byte)Db;
                Savebytes[14] = (byte)Dc;
                Savebytes[15] = (byte)Dd;
                Savebytes[16] = (byte)Ea;
                Savebytes[17] = (byte)Eb;
                Savebytes[18] = (byte)Ec;
                Savebytes[19] = (byte)Ed;

                File.WriteAllBytes(Ofile, Savebytes);

                Sav_aa = Aa;
                Sav_ab = Ab;
                Sav_ac = Ac;
                Sav_ad = Ad;
                Sav_ba = Ba;
                Sav_bb = Bb;
                Sav_bc = Bc;
                Sav_bd = Bd;
                Sav_ca = Ca;
                Sav_cb = Cb;
                Sav_cc = Cc;
                Sav_cd = Cd;
                Sav_da = Da;
                Sav_db = Db;
                Sav_dc = Dc;
                Sav_dd = Dd;
                Sav_ea = Ea;
                Sav_eb = Eb;
                Sav_ec = Ec;
                Sav_ed = Ed;

                Text = Ofile + " - BASic Tool";
            }
            else
            {
                SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
                SaveFileDialog1.InitialDirectory = "c:\\";
                SaveFileDialog1.Filter = "Basic AI Speed File (*.bas)|*.bas";
                SaveFileDialog1.FilterIndex = 1;
                SaveFileDialog1.RestoreDirectory = true;
                if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Ofile = SaveFileDialog1.FileName;

                        byte[] Savebytes = null;
                        Savebytes = new byte[20];
                        Savebytes[0] = (byte)Aa;
                        Savebytes[1] = (byte)Ab;
                        Savebytes[2] = (byte)Ac;
                        Savebytes[3] = (byte)Ad;
                        Savebytes[4] = (byte)Ba;
                        Savebytes[5] = (byte)Bb;
                        Savebytes[6] = (byte)Bc;
                        Savebytes[7] = (byte)Bd;
                        Savebytes[8] = (byte)Ca;
                        Savebytes[9] = (byte)Cb;
                        Savebytes[10] = (byte)Cc;
                        Savebytes[11] = (byte)Cd;
                        Savebytes[12] = (byte)Da;
                        Savebytes[13] = (byte)Db;
                        Savebytes[14] = (byte)Dc;
                        Savebytes[15] = (byte)Dd;
                        Savebytes[16] = (byte)Ea;
                        Savebytes[17] = (byte)Eb;
                        Savebytes[18] = (byte)Ec;
                        Savebytes[19] = (byte)Ed;

                        File.WriteAllBytes(Ofile, Savebytes);

                        Sav_aa = Aa;
                        Sav_ab = Ab;
                        Sav_ac = Ac;
                        Sav_ad = Ad;
                        Sav_ba = Ba;
                        Sav_bb = Bb;
                        Sav_bc = Bc;
                        Sav_bd = Bd;
                        Sav_ca = Ca;
                        Sav_cb = Cb;
                        Sav_cc = Cc;
                        Sav_cd = Cd;
                        Sav_da = Da;
                        Sav_db = Db;
                        Sav_dc = Dc;
                        Sav_dd = Dd;
                        Sav_ea = Ea;
                        Sav_eb = Eb;
                        Sav_ec = Ec;
                        Sav_ed = Ed;

                        Text = Ofile+" - BASic Tool";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
            TextBox1.Text = Entry_a.ToString();
            textBox2.Text = Entry_b.ToString();
            textBox3.Text = Entry_c.ToString();
            textBox4.Text = Entry_d.ToString();
            textBox5.Text = Entry_e.ToString();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.InitialDirectory = "c:\\";
            SaveFileDialog1.Filter = "Basic AI Speed File (*.bas)|*.bas";
            SaveFileDialog1.FilterIndex = 1;
            SaveFileDialog1.RestoreDirectory = true;
            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Ofile = SaveFileDialog1.FileName;

                    byte[] Savebytes = null;
                    Savebytes = new byte[20];
                    Savebytes[0] = (byte)Aa;
                    Savebytes[1] = (byte)Ab;
                    Savebytes[2] = (byte)Ac;
                    Savebytes[3] = (byte)Ad;
                    Savebytes[4] = (byte)Ba;
                    Savebytes[5] = (byte)Bb;
                    Savebytes[6] = (byte)Bc;
                    Savebytes[7] = (byte)Bd;
                    Savebytes[8] = (byte)Ca;
                    Savebytes[9] = (byte)Cb;
                    Savebytes[10] = (byte)Cc;
                    Savebytes[11] = (byte)Cd;
                    Savebytes[12] = (byte)Da;
                    Savebytes[13] = (byte)Db;
                    Savebytes[14] = (byte)Dc;
                    Savebytes[15] = (byte)Dd;
                    Savebytes[16] = (byte)Ea;
                    Savebytes[17] = (byte)Eb;
                    Savebytes[18] = (byte)Ec;
                    Savebytes[19] = (byte)Ed;

                    File.WriteAllBytes(Ofile, Savebytes);

                    Sav_aa = Aa;
                    Sav_ab = Ab;
                    Sav_ac = Ac;
                    Sav_ad = Ad;
                    Sav_ba = Ba;
                    Sav_bb = Bb;
                    Sav_bc = Bc;
                    Sav_bd = Bd;
                    Sav_ca = Ca;
                    Sav_cb = Cb;
                    Sav_cc = Cc;
                    Sav_cd = Cd;
                    Sav_da = Da;
                    Sav_db = Db;
                    Sav_dc = Dc;
                    Sav_dd = Dd;
                    Sav_ea = Ea;
                    Sav_eb = Eb;
                    Sav_ec = Ec;
                    Sav_ed = Ed;

                    Text = Ofile + " - BASic Tool";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            TextBox1.Text = Entry_a.ToString();
            textBox2.Text = Entry_b.ToString();
            textBox3.Text = Entry_c.ToString();
            textBox4.Text = Entry_d.ToString();
            textBox5.Text = Entry_e.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = Ofile + " - BASic Tool";

            TextBox1.Text = Entry_a.ToString();
            textBox2.Text = Entry_b.ToString();
            textBox3.Text = Entry_c.ToString();
            textBox4.Text = Entry_d.ToString();
            textBox5.Text = Entry_e.ToString();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Any unsaved changes will be lost. Is this OK?", "Warning",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                Aa = 0;
                Ab = 0;
                Ac = 0;
                Ad = 0;
                Ba = 0;
                Bb = 0;
                Bc = 0;
                Bd = 0;
                Ca = 0;
                Cb = 0;
                Cc = 0;
                Cd = 0;
                Da = 0;
                Db = 0;
                Dc = 0;
                Dd = 0;
                Ea = 0;
                Eb = 0;
                Ec = 0;
                Ed = 0;

                Sav_aa = 0;
                Sav_ab = 0;
                Sav_ac = 0;
                Sav_ad = 0;
                Sav_ba = 0;
                Sav_bb = 0;
                Sav_bc = 0;
                Sav_bd = 0;
                Sav_ca = 0;
                Sav_cb = 0;
                Sav_cc = 0;
                Sav_cd = 0;
                Sav_da = 0;
                Sav_db = 0;
                Sav_dc = 0;
                Sav_dd = 0;
                Sav_ea = 0;
                Sav_eb = 0;
                Sav_ec = 0;
                Sav_ed = 0;

                string Ofile = "Untitled";

                Text = Ofile + " - BASic Tool";

                Entry_a = 0.0F;
                Entry_b = 0.0F;
                Entry_c = 0.0F;
                Entry_d = 0.0F;
                Entry_e = 0.0F;
            }
            TextBox1.Text = Entry_a.ToString();
            textBox2.Text = Entry_b.ToString();
            textBox3.Text = Entry_c.ToString();
            textBox4.Text = Entry_d.ToString();
            textBox5.Text = Entry_e.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int ddd = 0;
            string txfx = "";
            for (int n = 0; n < textBox2.Text.Length; n = n + 1)
            {
                //MessageBox.Show(textBox2.Text.Substring(n,1));
                if (
                    (textBox2.Text.Substring(n, 1) == "1") |
                    (textBox2.Text.Substring(n, 1) == "2") |
                    (textBox2.Text.Substring(n, 1) == "3") |
                    (textBox2.Text.Substring(n, 1) == "4") |
                    (textBox2.Text.Substring(n, 1) == "5") |
                    (textBox2.Text.Substring(n, 1) == "6") |
                    (textBox2.Text.Substring(n, 1) == "7") |
                    (textBox2.Text.Substring(n, 1) == "8") |
                    (textBox2.Text.Substring(n, 1) == "9") |
                    (textBox2.Text.Substring(n, 1) == "0") |
                    (textBox2.Text.Substring(n, 1) == ".")
                    )
                {
                    if ((textBox2.Text.Substring(n, 1) != ".") | (ddd == 0))
                    {
                        txfx = txfx + textBox2.Text.Substring(n, 1);
                        if (textBox2.Text.Substring(n, 1) == ".")
                        {
                            ddd = 1;
                        }
                    }

                }
            }
            if (txfx == "")
            {
                txfx = "0";
            }

            Entry_b = float.Parse(txfx);

            byte[] hexier = BitConverter.GetBytes(Entry_b);
            byte[] hexy = hexier.Reverse().ToArray();

            Ba = hexy[0];
            Bb = hexy[1];
            Bc = hexy[2];
            Bd = hexy[3];

            textBox2.Text = txfx;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int ddd = 0;
            string txfx = "";
            for (int n = 0; n < textBox3.Text.Length; n = n + 1)
            {
                //MessageBox.Show(textBox3.Text.Substring(n,1));
                if (
                    (textBox3.Text.Substring(n, 1) == "1") |
                    (textBox3.Text.Substring(n, 1) == "2") |
                    (textBox3.Text.Substring(n, 1) == "3") |
                    (textBox3.Text.Substring(n, 1) == "4") |
                    (textBox3.Text.Substring(n, 1) == "5") |
                    (textBox3.Text.Substring(n, 1) == "6") |
                    (textBox3.Text.Substring(n, 1) == "7") |
                    (textBox3.Text.Substring(n, 1) == "8") |
                    (textBox3.Text.Substring(n, 1) == "9") |
                    (textBox3.Text.Substring(n, 1) == "0") |
                    (textBox3.Text.Substring(n, 1) == ".")
                    )
                {
                    if ((textBox3.Text.Substring(n, 1) != ".") | (ddd == 0))
                    {
                        txfx = txfx + textBox3.Text.Substring(n, 1);
                        if (textBox3.Text.Substring(n, 1) == ".")
                        {
                            ddd = 1;
                        }
                    }

                }
            }
            if (txfx == "")
            {
                txfx = "0";
            }

            Entry_c = float.Parse(txfx);

            byte[] hexier = BitConverter.GetBytes(Entry_c);
            byte[] hexy = hexier.Reverse().ToArray();

            Ca = hexy[0];
            Cb = hexy[1];
            Cc = hexy[2];
            Cd = hexy[3];

            textBox3.Text = txfx;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int ddd = 0;
            string txfx = "";
            for (int n = 0; n < textBox4.Text.Length; n = n + 1)
            {
                //MessageBox.Show(textBox4.Text.Substring(n,1));
                if (
                    (textBox4.Text.Substring(n, 1) == "1") |
                    (textBox4.Text.Substring(n, 1) == "2") |
                    (textBox4.Text.Substring(n, 1) == "3") |
                    (textBox4.Text.Substring(n, 1) == "4") |
                    (textBox4.Text.Substring(n, 1) == "5") |
                    (textBox4.Text.Substring(n, 1) == "6") |
                    (textBox4.Text.Substring(n, 1) == "7") |
                    (textBox4.Text.Substring(n, 1) == "8") |
                    (textBox4.Text.Substring(n, 1) == "9") |
                    (textBox4.Text.Substring(n, 1) == "0") |
                    (textBox4.Text.Substring(n, 1) == ".")
                    )
                {
                    if ((textBox4.Text.Substring(n, 1) != ".") | (ddd == 0))
                    {
                        txfx = txfx + textBox4.Text.Substring(n, 1);
                        if (textBox4.Text.Substring(n, 1) == ".")
                        {
                            ddd = 1;
                        }
                    }

                }
            }
            if (txfx == "")
            {
                txfx = "0";
            }

            Entry_d = float.Parse(txfx);

            byte[] hexier = BitConverter.GetBytes(Entry_d);
            byte[] hexy = hexier.Reverse().ToArray();

            Da = hexy[0];
            Db = hexy[1];
            Dc = hexy[2];
            Dd = hexy[3];

            textBox4.Text = txfx;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int ddd = 0;
            string txfx = "";
            for (int n = 0; n < textBox5.Text.Length; n = n + 1)
            {
                //MessageBox.Show(textBox5.Text.Substring(n,1));
                if (
                    (textBox5.Text.Substring(n, 1) == "1") |
                    (textBox5.Text.Substring(n, 1) == "2") |
                    (textBox5.Text.Substring(n, 1) == "3") |
                    (textBox5.Text.Substring(n, 1) == "4") |
                    (textBox5.Text.Substring(n, 1) == "5") |
                    (textBox5.Text.Substring(n, 1) == "6") |
                    (textBox5.Text.Substring(n, 1) == "7") |
                    (textBox5.Text.Substring(n, 1) == "8") |
                    (textBox5.Text.Substring(n, 1) == "9") |
                    (textBox5.Text.Substring(n, 1) == "0") |
                    (textBox5.Text.Substring(n, 1) == ".")
                    )
                {
                    if ((textBox5.Text.Substring(n, 1) != ".") | (ddd == 0))
                    {
                        txfx = txfx + textBox5.Text.Substring(n, 1);
                        if (textBox5.Text.Substring(n, 1) == ".")
                        {
                            ddd = 1;
                        }
                    }

                }
            }
            if (txfx == "")
            {
                txfx = "0";
            }

            Entry_e = float.Parse(txfx);

            byte[] hexier = BitConverter.GetBytes(Entry_e);
            byte[] hexy = hexier.Reverse().ToArray();

            Ea = hexy[0];
            Eb = hexy[1];
            Ec = hexy[2];
            Ed = hexy[3];

            textBox5.Text = txfx;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creator: TheZACAtac\nVersion: v1.0.rc1\nWiki: wiki.tockdom.com/wiki/BASic_Tool", "About BASic Tool",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
