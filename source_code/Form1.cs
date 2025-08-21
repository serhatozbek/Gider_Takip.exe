using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace deneme
{
    public partial class Form1 : Form
    {
        private DateTime aktifTarih;

        public class GoruntulenecekAy
        {
            public string GorunenMetin { get; set; } = string.Empty;
            public DateTime TarihDegeri { get; set; }

            public override string ToString()
            {
                return GorunenMetin;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("GiderAdi", "Gider Adý");
            dataGridView1.Columns.Add("Miktar", "Miktar");
            dataGridView1.Columns.Add("Tarih", "Tarih");
            dataGridView2.Columns.Add("GelirAdi", "Gelir Adý");
            dataGridView2.Columns.Add("Miktar", "Miktar");
            dataGridView2.Columns.Add("Tarih", "Tarih");

            MevcutAylariListBoxaYukle();

            if (lstAylar.Items.Count > 0)
            {
                lstAylar.SelectedIndex = 0;
                VerileriYukle();
            }
        }

        private void MevcutAylariListBoxaYukle()
        {

            DateTime? seciliTarih = null;
            if (lstAylar.SelectedItem is GoruntulenecekAy oncekiSecim)
            {
                seciliTarih = oncekiSecim.TarihDegeri;
            }

            lstAylar.Items.Clear();

            // DÜZELTME: Dosyalarý arayacaðýmýz doðru yolu belirliyoruz.
            string appDataYolu = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string uygulamaKlasoru = Path.Combine(appDataYolu, "GiderTakipProgrami");

            // Klasörün var olduðundan emin olalým, ilk çalýþtýrma için önemli.
            Directory.CreateDirectory(uygulamaKlasoru);

            // Artýk doðru klasördeki dosyalarý arýyoruz.
            var dosyalar = Directory.GetFiles(uygulamaKlasoru, "*_??_????.json");

            List<DateTime> bulunanAylar = new List<DateTime>();

            foreach (var dosyaYolu in dosyalar)
            {
                try
                {
                    string dosyaAdi = Path.GetFileNameWithoutExtension(dosyaYolu);
                    string[] parcalar = dosyaAdi.Split('_');

                    if (parcalar.Length == 3 && int.TryParse(parcalar[1], out int ay) && int.TryParse(parcalar[2], out int yil))
                    {
                        DateTime ayTarihi = new DateTime(yil, ay, 1);
                        if (!bulunanAylar.Contains(ayTarihi))
                        {
                            bulunanAylar.Add(ayTarihi);
                        }
                    }
                }
                catch { /* Hatalý formatlý dosyalarý görmezden gel */ }
            }

            if (bulunanAylar.Count == 0)
            {
                bulunanAylar.Add(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1));
            }

            var siraliAylar = bulunanAylar.OrderByDescending(t => t).ToList();
            foreach (var tarih in siraliAylar)
            {
                lstAylar.Items.Add(new GoruntulenecekAy
                {
                    TarihDegeri = tarih,
                    GorunenMetin = tarih.ToString("MMMM yyyy", new CultureInfo("tr-TR"))
                });
            }

            if (seciliTarih.HasValue)
            {
                for (int i = 0; i < lstAylar.Items.Count; i++)
                {
                    if (lstAylar.Items[i] is GoruntulenecekAy ay && ay.TarihDegeri == seciliTarih.Value)
                    {
                        lstAylar.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void VerileriYukle()
        {
            if (lstAylar.SelectedItem is GoruntulenecekAy secilenAy)
            {
                aktifTarih = secilenAy.TarihDegeri;
                GiderleriYukle();
                GelirleriYukle();
            }
        }

        private void btnAyiYukle_Click(object sender, EventArgs e)
        {
            VerileriYukle();
        }

        #region Dosya Okuma/Yazma ve Grid Yükleme Metotlarý

        private string GetDosyaYolu(string tur, DateTime tarih)
        {
            string appDataYolu = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string uygulamaKlasoru = Path.Combine(appDataYolu, "GiderTakipProgrami");
            Directory.CreateDirectory(uygulamaKlasoru);

            string dosyaAdi = $"{tur}_{tarih:MM_yyyy}.json";

            return Path.Combine(uygulamaKlasoru, dosyaAdi);
        }

        private void GiderleriKaydet(List<Gider> giderler, DateTime tarih)
        {
            string dosyaYolu = GetDosyaYolu("giderler", tarih);
            string jsonVerisi = JsonConvert.SerializeObject(giderler, Formatting.Indented);
            File.WriteAllText(dosyaYolu, jsonVerisi);
        }

        private List<Gider> GiderleriOku(DateTime tarih)
        {
            string dosyaYolu = GetDosyaYolu("giderler", tarih);
            if (File.Exists(dosyaYolu))
            {
                string jsonVerisi = File.ReadAllText(dosyaYolu);
                return JsonConvert.DeserializeObject<List<Gider>>(jsonVerisi) ?? new List<Gider>();
            }
            return new List<Gider>();
        }

        private void GiderleriYukle()
        {
            List<Gider> giderler = GiderleriOku(aktifTarih);
            dataGridView1.Rows.Clear();
            foreach (var gider in giderler)
            {
                dataGridView1.Rows.Add(gider.GiderAdi, gider.Miktar, gider.Tarih.ToShortDateString());
            }
            HesaplaToplamGider();
        }

        private void GelirleriKaydet(List<Gelir> gelirler, DateTime tarih)
        {
            string dosyaYolu = GetDosyaYolu("gelirler", tarih);
            string jsonVerisi = JsonConvert.SerializeObject(gelirler, Formatting.Indented);
            File.WriteAllText(dosyaYolu, jsonVerisi);
        }

        private List<Gelir> GelirleriOku(DateTime tarih)
        {
            string dosyaYolu = GetDosyaYolu("gelirler", tarih);
            if (File.Exists(dosyaYolu))
            {
                string jsonVerisi = File.ReadAllText(dosyaYolu);
                return JsonConvert.DeserializeObject<List<Gelir>>(jsonVerisi) ?? new List<Gelir>();
            }
            return new List<Gelir>();
        }

        private void GelirleriYukle()
        {
            List<Gelir> gelirler = GelirleriOku(aktifTarih);
            dataGridView2.Rows.Clear();
            foreach (var gelir in gelirler)
            {
                dataGridView2.Rows.Add(gelir.GelirAdi, gelir.Miktar, gelir.Tarih.ToShortDateString());
            }
            HesaplaToplamGelir();
        }

        #endregion

        #region Veri Ekleme, Silme ve Hesaplama

        public class Gider
        {
            public string GiderAdi { get; set; } = string.Empty;
            public decimal Miktar { get; set; }
            public DateTime Tarih { get; set; }
        }

        public class Gelir
        {
            public string GelirAdi { get; set; } = string.Empty;
            public decimal Miktar { get; set; }
            public DateTime Tarih { get; set; }
        }

        private void HesaplaToplamGider()
        {
            decimal toplamGider = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                toplamGider += Convert.ToDecimal(row.Cells["Miktar"].Value ?? 0);
            }
            lblToplamGider.Text = "Toplam Gider: " + toplamGider.ToString("C");
        }

        private void HesaplaToplamGelir()
        {
            decimal toplamGelir = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;
                toplamGelir += Convert.ToDecimal(row.Cells["Miktar"].Value ?? 0);
            }
            lblToplamGelir.Text = "Toplam Gelir: " + toplamGelir.ToString("C");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGiderAdi.Text) || !decimal.TryParse(txtMiktar.Text, out decimal miktar))
            {
                MessageBox.Show("Lütfen tüm alanlarý doðru bir þekilde doldurun.");
                return;
            }

            Gider yeniGider = new Gider
            {
                GiderAdi = txtGiderAdi.Text,
                Miktar = miktar,
                Tarih = dateTimePicker1.Value
            };

            DateTime kayitTarihi = new DateTime(yeniGider.Tarih.Year, yeniGider.Tarih.Month, 1);
            List<Gider> giderler = GiderleriOku(kayitTarihi);
            giderler.Add(yeniGider);
            GiderleriKaydet(giderler, kayitTarihi);

            MevcutAylariListBoxaYukle();

            if (kayitTarihi.Month == aktifTarih.Month && kayitTarihi.Year == aktifTarih.Year)
            {
                GiderleriYukle();
            }

            txtGiderAdi.Clear();
            txtMiktar.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGelirAdi.Text) || !decimal.TryParse(txtMiktar1.Text, out decimal miktar))
            {
                MessageBox.Show("Lütfen tüm alanlarý doðru bir þekilde doldurun.");
                return;
            }

            Gelir yeniGelir = new Gelir
            {
                GelirAdi = txtGelirAdi.Text,
                Miktar = miktar,
                Tarih = dateTimePicker1.Value
            };

            DateTime kayitTarihi = new DateTime(yeniGelir.Tarih.Year, yeniGelir.Tarih.Month, 1);
            List<Gelir> gelirler = GelirleriOku(kayitTarihi);
            gelirler.Add(yeniGelir);
            GelirleriKaydet(gelirler, kayitTarihi);

            MevcutAylariListBoxaYukle();

            if (kayitTarihi.Month == aktifTarih.Month && kayitTarihi.Year == aktifTarih.Year)
            {
                GelirleriYukle();
            }

            txtGelirAdi.Clear();
            txtMiktar1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var sonuc = MessageBox.Show("Seçili gider kaydýný/kayýtlarýný silmek istediðinizden emin misiniz?", "Silme Onayý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (sonuc == DialogResult.No) return;

                var seciliIndexler = dataGridView1.SelectedRows.Cast<DataGridViewRow>().Select(row => row.Index).ToList();

                List<Gider> giderler = GiderleriOku(aktifTarih);

                foreach (int index in seciliIndexler.OrderByDescending(i => i))
                {
                    if (index < giderler.Count)
                    {
                        giderler.RemoveAt(index);
                    }
                }

                GiderleriKaydet(giderler, aktifTarih);
                GiderleriYukle();
            }
            else
            {
                MessageBox.Show("Silmek için bir satýr seçin.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var sonuc = MessageBox.Show("Seçili gelir kaydýný/kayýtlarýný silmek istediðinizden emin misiniz?", "Silme Onayý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (sonuc == DialogResult.No) return;

                var seciliIndexler = dataGridView2.SelectedRows.Cast<DataGridViewRow>().Select(row => row.Index).ToList();

                List<Gelir> gelirler = GelirleriOku(aktifTarih);

                foreach (int index in seciliIndexler.OrderByDescending(i => i))
                {
                    if (index < gelirler.Count)
                    {
                        gelirler.RemoveAt(index);
                    }
                }

                GelirleriKaydet(gelirler, aktifTarih);
                GelirleriYukle();
            }
            else
            {
                MessageBox.Show("Silmek için bir satýr seçin.");
            }
        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtMiktar1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}