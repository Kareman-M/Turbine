namespace Turbine.Data
{
    public class FactoryService
    {
        public List<Factory> Factories = new  List<Factory>();

        public List<Factory> Filter(out int length , int pageIndex = 0, string sector = null, string citycode = null)
        {
            var filter = Factories;
            if (!string.IsNullOrEmpty(sector) && sector != "All")
                filter = filter.Where(x => x.Sector.Contains(sector)).ToList();
            if (!string.IsNullOrEmpty(citycode) && citycode != "0")
                filter = filter.Where(x => x.CityCode == citycode).ToList();

            length= filter.Count();

            return filter.Skip(pageIndex * 5).Take(5).ToList();

        }

        public List<string> GetSectors(string cityCode)
        {
            return Factories.Where(x => x.CityCode == cityCode).Select(x => x.Sector).ToList();
        }
        public List<LookUp> GetCities()
        {

            var list = new List<LookUp>(){
                    new  LookUp("مدينة العاشر من رمضان", "1" ),
                   new  LookUp ("مدينة السادس من أكتوبر" ,"2"),
                 new  LookUp  ("مدينة السادات" ,"3"),
                    new  LookUp("مدينة برج العرب" ,"4"),
                  new LookUp ("مدينة بدر"  ,"5"),
                 new  LookUp   ("مدينة العبور "   ,"6"),
                    new  LookUp("مدينة أبو رواش"  ,"7"),
              new LookUp    ("مدينة شبرا الخيمة" ,"8"),
              new LookUp    ("مدينة القاهرة" ,"9"),
              new LookUp    ("مدينة الجيزة"    ,"10"),
              new LookUp    ("مدينة الإسكندرية"    ,"11"),
              new LookUp    ("مدينة العامرية"  ,"12"),
              new LookUp    ("مدينة القليوبية" ,"13"),
              new LookUp   ("مدينة دمياط" ,"14"),
              new LookUp   ( "مدينة قويسنا "   ,"15"),
              new LookUp    ("مدينة المنصورة " ,"16"),
              new LookUp    ("مدينة المنوفية"  ,"17"),
              new LookUp    ("مدينة كفر الشيخ" ,"18"),
              new LookUp    ("مدينة المحلة الكبرى" ,"19"),
              new LookUp    ("مدينة الصالحية الجديدة" ,"20"),
              new LookUp    ("مدينة الشرقية"  ,"21"),
              new LookUp    ("مدينة النوبارية" ,"22"),
              new LookUp   ("مدينة حلوان" ,"23"),
              new LookUp    ("مدينة القناطر" ,"24"),
              new LookUp    ("مدينة طنطا"  ,"25"),
              new LookUp    ("مدينة الدقهلية","26"),
              new LookUp    ("مدينة البحيرة","27"),
              new LookUp    ("مدينة الغربية","28"),
              new LookUp   ( "مدينة كوم أوشيم - الفيوم","29"),
              new LookUp   ( "مدينة 15 مايو " ,"30"),
              new LookUp   (" مدينة شمال سيناء" ,"31"),
              new LookUp    ("مدينة جنوب سيناء","32"),
              new LookUp    ("مدينة السلام"  ,"33"),
              new LookUp    ("مدينة بورسعيد"  ,"34"),
              new LookUp    ("مدينة الإسماعيلية" ,"35"),
              new LookUp    ("مدينة السويس"   ,"36"),
              new LookUp    ("مدينة بني سويف" ,"37"),
              new LookUp    ("مدينة المنيا"   ,"38"),
              new LookUp    ("مدينة أسيوط" ,"39"),
              new LookUp   ("سوهاج ومدينة الكوثر" ,"40"),
              new LookUp  ("مدينة قنا " ,"41"),
              new LookUp   ("مدينة الأقصر" ,"42"),
              new LookUp    ("مدينة أسوان" ,"43"),
              new LookUp    ("مدينة مطروح والساحل" ,"44"),
              new LookUp   ( "مدينة الوادي الجديد" ,"45"),
              new LookUp   (" المناطق الحرة"  ,"46"),
              new LookUp    ("منطقة شق الثعبان"  ,"47"),
              new LookUp    ("منطقة التبين"   ,"48"),
              new LookUp    ("منطقة البساتين" ,"49"),
              new LookUp    ("منطقة جسر السويس" ,"50"),
              new LookUp    ("منطقة الحرفيين"  ,"51"),
              new LookUp    ("منطقة العباسية الصناعية" ,"52"),
              new LookUp   ("منطقة التجمع الصناعية" ,"53"),
              new LookUp    ("مدينة جمصة" ,"45")
               };

            return list;
        }
    }

    public record LookUp(string City, string CityCode);
}
