using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProj
{
    internal class VeeamTest : TestBase
    {
        [Test]
        public void AssertRomanianBucharestSales()
        {
            VeeamPage vp = new VeeamPage(driver);

            vp.Search("Sales");
            vp.SelectCountryFromSelectBoxByName("Romania");
            vp.SelectCityFromSelectBoxByName("Bucharest");
            vp.ClickOnFindButton();
            vp.AssertNumberOfSalesCards(29);

        }

        [Test]
        public void AssertUSATexasAustinSales()
        {
            VeeamPage vp = new VeeamPage(driver);

            vp.Search("Sales");
            vp.SelectCountryFromSelectBoxByName("USA");
            vp.SelectStateFromSelectBoxByName("Texas");
            vp.SelectCityFromSelectBoxByName("Austin");
            vp.ClickOnFindButton();
            vp.AssertNumberOfSalesCards(10);

        }
    }
}
