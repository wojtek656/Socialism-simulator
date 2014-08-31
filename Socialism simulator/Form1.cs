using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socialism_simulator
{
    public partial class Form1 : Form
    {
        Person Cygan = new Person(50, 0, 1);
        Person Student = new Person(300, 1, 2);
        Person PomocnikZyda = new Person(600, 2, 3);
        Person NowyPodatek = new Person(2000, 3, 5);
        Person Urzednik = new Person(4000, 4, 7);
        Person Korpo = new Person(7500, 5, 10);
        Person Kosciol = new Person(10000, 7, 12);
        Person Ofe = new Person(20000, 9, 15);
        Person AmberGold = new Person(50000, 11, 18);
        Person Zus = new Person(200000, 15, 25);
        Person Socialism = new Person(750000);
        Person KontrolaSkarbowa = new Person(500000);
        
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GlobalItems.totalEarned += GlobalItems.plnPerSecond;
            GlobalItems.AddMoney();
            ShowFunnyMsg();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //labels name
            lblYourCash.Text = string.Format("Stan Konta: {0:###,###} ", GlobalItems.yourCash);
            lblMoneyPerClickAndSec.Text = "Liczba PLN na kliknięcie: " + GlobalItems.plnPerClick +
                " / Liczba PLN na sekundę: " + GlobalItems.plnPerSecond;
            lblTotalEarned.Text = string.Format("(Zasiliłeś budżet {0:###,###} PLN)", GlobalItems.totalEarned);

            //Buttons' name
            btnCygan.Text = string.Format("Cygan\n{0:###,###}PLN(+{1}klik, +{2}PLN)\nKupionych: {3}"
                , (int)Cygan.price, Cygan.perClick, Cygan.perSecond, Cygan.bought);
            btnStudent.Text = string.Format("Student\n{0:###,###}PLN(+{1}klik, +{2}PLN)\nKupionych: {3}"
                , (int)Student.price, Student.perClick, Student.perSecond, Student.bought);
            btnPomocnikZyda.Text = string.Format("Pomocnik Żyda\n{0:###,###}PLN(+{1}klik, +{2}PLN)\nKupionych: {3}"
                , (int)PomocnikZyda.price, PomocnikZyda.perClick, PomocnikZyda.perSecond, PomocnikZyda.bought);
            btnNowyPodatek.Text = string.Format("Nowy Podatek\n{0:###,###}PLN(+{1}klik, +{2}PLN)\nKupionych: {3}"
                , (int)NowyPodatek.price, NowyPodatek.perClick, NowyPodatek.perSecond, NowyPodatek.bought);
            btnUrzednik.Text = string.Format("Urzędnik\n{0:###,###}PLN(+{1}klik, +{2}PLN)\nKupionych: {3}"
                , (int)Urzednik.price, Urzednik.perClick, Urzednik.perSecond, Urzednik.bought);
            btnKorpo.Text = string.Format("Otwórz korporację\n{0:###,###}PLN(+{1}klik, +{2}PLN)\nKupionych: {3}"
                , (int)Korpo.price, Korpo.perClick, Korpo.perSecond, Korpo.bought);
            btnKosciol.Text = string.Format("Kościół\n{0:###,###}PLN(+{1}klik, +{2}PLN)\nKupionych: {3}"
                , (int)Kosciol.price, Kosciol.perClick, Kosciol.perSecond, Kosciol.bought);
            btnOfe.Text = string.Format("Nacjonalizuj OFE\n{0:###,###}PLN(+{1}klik, +{2}PLN)\nKupionych: {3}"
                , (int)Ofe.price, Ofe.perClick, Ofe.perSecond, Ofe.bought);
            btnAmberGld.Text = string.Format("Amber Gold\n{0:###,###}PLN(+{1}klik, +{2}PLN)\nKupionych: {3}"
                , (int)AmberGold.price, AmberGold.perClick, AmberGold.perSecond, AmberGold.bought);
            btnZus.Text = string.Format("Zwiększ składkę ZUS\n{0:###,###}PLN(+{1}klik, +{2}PLN)\nKupionych: {3}"
                , (int)Zus.price, Zus.perClick, Zus.perSecond, Zus.bought);
            //End of buttons' name
        }


        private void btnDonate_Click(object sender, EventArgs e)
        {
            GlobalItems.yourCash += GlobalItems.plnPerClick;
            GlobalItems.totalEarned += GlobalItems.plnPerClick;
        }

        private void btnCygan_Click(object sender, EventArgs e)
        {
            Cygan.buyPerson();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Student.buyPerson();
        }

        private void btnZyd_Click(object sender, EventArgs e)
        {
            PomocnikZyda.buyPerson();
        }

        private void btnNowyPodatek_Click(object sender, EventArgs e)
        {
            NowyPodatek.buyPerson();
        }

        private void btnUrzednik_Click(object sender, EventArgs e)
        {
            Urzednik.buyPerson();
        }

        private void btnKorpo_Click(object sender, EventArgs e)
        {
            Korpo.buyPerson();
        }

        private void btnKosciol_Click(object sender, EventArgs e)
        {
            Kosciol.buyPerson();
        }

        private void btnOfe_Click(object sender, EventArgs e)
        {
            Ofe.buyPerson();
        }

        private void btnAmberGld_Click(object sender, EventArgs e)
        {
            AmberGold.buyPerson();
        }

        private void btnZus_Click(object sender, EventArgs e)
        {
            Zus.buyPerson();
        }

        private void btnKontrolaSkarbowa_Click(object sender, EventArgs e)
        {
            KontrolaSkarbowa.fiscalControl();
               if(GlobalItems.yourCash >= KontrolaSkarbowa.price)
               {
                   label1.Visible = true;
                   btnKontrolaSkarbowa.Text = "Już niedaleko!";
                   btnKontrolaSkarbowa.Enabled = false;
               }
        }

        
        private void btnSocjalizm_Click(object sender, EventArgs e)
        {
            Socialism.enterSocialism();
            if (Socialism.tmp)
            {
                lblFunnyText.Text = "Kraj na skraju bankructwa! Polaku obudz się!";
                pictureBox1.Visible = false;
                pictureBox4.Visible = false;

                pictureBox2.Visible = true;
                pictureBox3.Visible = true;

                btnSocjalizm.Text = "Wprowadzasz socjalzm i ogłaszasz się cesarzem";
                btnSocjalizm.Enabled = false;
            }

        }

        private void ShowFunnyMsg()
        {
            lblFunnyText.Text = "Tusk Simulator 2014";
            if (GlobalItems.totalEarned > 200)
                lblFunnyText.Text = "Zapisałeś się do PO";
            if (GlobalItems.totalEarned > 500)
                lblFunnyText.Text = "Okradasz psy i koty w okolicy";
            if (GlobalItems.totalEarned > 1000)
                lblFunnyText.Text = "Kradniesz pieniądze od lokalnych polityków";
            if (GlobalItems.totalEarned > 5000)
                lblFunnyText.Text = "Wygrałeś wybory i zostałeś (p)osłem";
            if (GlobalItems.totalEarned > 5000)
                lblFunnyText.Text = "Wygrałeś wybory i zostałeś (p)osłem";
            if (GlobalItems.totalEarned > 10000)
                lblFunnyText.Text = "Obiecujesz wszystkim darmowe wifi";
            if (GlobalItems.totalEarned > 20000)
                lblFunnyText.Text = "Rozpocząłeś kurs \"Podstawy socjalizmu\"";
            if (GlobalItems.totalEarned > 35000)
                lblFunnyText.Text = "Donald nominował Cię na ministra finansów";
            if (GlobalItems.totalEarned > 50000)
                lblFunnyText.Text = "Kupujesz onet.pl i przejmujesz władze w Polsce";
            if (GlobalItems.totalEarned > 100000)
                lblFunnyText.Text = "Inne partie zazdroszczą Ci sukcesów";
            if (GlobalItems.totalEarned > 200000)
                lblFunnyText.Text = "Socjaliści z innych galaktyk podziwiają Cie";
            if (GlobalItems.totalEarned > 350000)
                lblFunnyText.Text = "Bogacisz sie z każdą sekundą na koszt podatnika!";
            if (GlobalItems.totalEarned > 500000 && !Socialism.tmp)
            {
                lblFunnyText.Text = "Bezrobocie w kraju wzrosło do 40%";
                pictureBox1.Visible = true;
            }
            if (GlobalItems.totalEarned > 750000)
                lblFunnyText.Text = "Rodakom brakuje pieniędzy. Podwajasz pensje minimalna";
            if (GlobalItems.totalEarned > 1000000 && !Socialism.tmp)
            {
                lblFunnyText.Text = "Doprowadziłeś ZUS na skraj bankructwa";
                pictureBox4.Visible = true;
            }
            if (GlobalItems.totalEarned > 1400000)
                lblFunnyText.Text = "Wypłacasz premię dla urzędników";
            if (GlobalItems.totalEarned > 1700000)
                lblFunnyText.Text = "Dług publiczny wynosi już 80% PKb";
            if (GlobalItems.totalEarned > 2000000)
                lblFunnyText.Text = "Podnosisz podatek dochodowy";
        }

     


    }
}
