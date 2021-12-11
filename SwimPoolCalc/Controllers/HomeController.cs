using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace SwimPoolCalc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(CalcController calc)
        {
            return View(calc);
        }
        [HttpPost]
        public ActionResult Calculate(CalcController calculator)
        {
            calculator.Result = CalculateResult(calculator);

            return RedirectToAction("Index", calculator);
        }


        //This starts our functions!
        int beton = 14000; // цена 14000 1куб
        int zakazBetona = 30000; // цена заказа бетона 30 000 - 40 000
        double cenaDoski = 150 * 1000; // кол Досок примерный +-
        int sim = 2000 * 12; // сым акшасы
        double ElectricProvoda = 15000; // цена для одной пачки(ну хз пока)
        int workers = 6500000; // Цена для услуги

        private static double numArmatura(double kg)
        {
            return (81.6 * kg)/1000;
        }

        public static double cenaArmatura(int kg)
        {
            return (237820 * kg) / 1000; // 237820тг - 1т цена в интернете
        }

        public static double vBetonPool(double w, double l, double h)
        { // объем бетона для бассейна
            return (w * l * h) / 4;
        }

        public static double vPool(double w, double l, double h)
        {
            return w * l * h;
        }

        public static double sumKgArma(double v) // 15 для ленточного бетона
        {
            return 20 * v; // возвращает кг Арматур для бетона
        }

        public static double numOfPlitki(double w, double l, double h) // 16000 за кв.м
        {
            double Ss, Sp;
            Ss = (2 * (w + l)) * h; // площадь весь бассейна
            Sp = 0.3 * 0.2; // площадь 1й плитки
            double numPlitki = Ss / Sp;
            int zapasPlitki = (int)numPlitki / 10;
            return numPlitki + zapasPlitki; // кол плиток с запасом
        }

        public static double cenaPlitki(double w, double l, double h)
        {
            double Ss = (2 * (w + l)) * h;
            return 9000 * Ss;
        }

        public static double IzoMaterials(double Ss)
        {
            double S_izo_Mat = 1.2 * 1;
            double Ss_total = Ss + (Ss / 4);
            double numIzoMat = Ss_total / S_izo_Mat;
            return numIzoMat;
        }

        public static double setkiMaterials(double Ss)
        {
            double S_setka_Mat = 0.7 * 0.8;
            double Ss_total = Ss + (Ss / 4);
            double numSetkiMat = Ss_total / S_setka_Mat;
            return numSetkiMat;
        }

        public static double cenaIzoSetkiMaterials(double w, double l, double h) //2500тг 1кв м
        {
            double S1 = l * w;
            double S2 = h * l;
            double S3 = h * w;
            return 2500 * (S1 + S2 + S3 + (S1 / 10 + S2 / 10 + S3 / 10));
        }



    }
}
