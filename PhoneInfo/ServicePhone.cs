using PhoneInfo.Module;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PhoneInfo
{
    public class ServicePhone
    {
        public string path = "Phones.xml";

        List<Phone> phones = new List<Phone>();

        public ServicePhone() : this("") { }

        public ServicePhone(string path)
        {
            if (string.IsNullOrEmpty(path))
                this.path = Path.Combine(@"Phones.xml");
            else
                this.path = path;
        }

        public void addPhone()
        {
            Phone phone = new Phone();
            Console.WriteLine("Введите название телефона: ");
            phone.PhoneName = Console.ReadLine();

            Console.WriteLine("Введите модель телефона: ");
            phone.PhoneModel = Console.ReadLine();

            Console.WriteLine("Введите страну производителя: ");
            phone.PhoneCity = Console.ReadLine();

            Console.WriteLine("Введите имей телефона: ");
            phone.PhoneImei = int.Parse(Console.ReadLine());

            if (isExistsPhone(phone))
            {
                phones.Add(phone);
                addPhoneToXml(phone);
                Console.WriteLine("Товар добавлен успешно!!!");
            }
        }

        private bool isExistsPhone(Phone phone)
        {
            if (phones.Where(w => w.PhoneName == phone.PhoneName).Count() > 0)
            {
                Console.WriteLine("Такой телефон уже существует");
                return false;
            }
            return true;
        }

        private void addPhoneToXml(Phone ph)
        {
            XmlDocument doc = getDocument();
            XmlComment xcom;
            XmlElement elem = doc.CreateElement("Phone");

            XmlElement PhoneName = doc.CreateElement("PhoneName");
            PhoneName.InnerText = ph.PhoneName;
            xcom = doc.CreateComment("Название телефона");
            PhoneName.AppendChild(xcom);

            XmlElement PhoneModel = doc.CreateElement("PhoneModel");
            PhoneModel.InnerText = ph.PhoneModel;
            xcom = doc.CreateComment("Модель телефона");
            PhoneModel.AppendChild(xcom);

            XmlElement PhoneCity = doc.CreateElement("PhoneCity");
            PhoneCity.InnerText = ph.PhoneCity;
            xcom = doc.CreateComment("Страна производитель телефона");
            PhoneCity.AppendChild(xcom);

            XmlElement PhoneImei = doc.CreateElement("PhoneImei");
            PhoneImei.InnerText = ph.PhoneImei.ToString();
            xcom = doc.CreateComment("Имей телефона");
            PhoneImei.AppendChild(xcom);

            elem.AppendChild(PhoneName);
            elem.AppendChild(PhoneModel);
            elem.AppendChild(PhoneCity);
            elem.AppendChild(PhoneImei);
            doc.DocumentElement.AppendChild(elem);
            doc.Save(path); 

            XmlElement e1 = doc.CreateElement("e1");
            xcom = doc.CreateComment("Одинокий элемент 1");
            e1.AppendChild(xcom);

            XmlElement e2 = doc.CreateElement("e2");
            xcom = doc.CreateComment("Одинокий элемент 2");
            e2.AppendChild(xcom);

            XmlElement e3 = doc.CreateElement("e3");
            xcom = doc.CreateComment("Одинокий элемент 3");
            e3.AppendChild(xcom);

            XmlElement e4 = doc.CreateElement("e4");
            xcom = doc.CreateComment("Одинокий элемент 4");
            e4.AppendChild(xcom);

            XmlElement e5 = doc.CreateElement("e5");
            xcom = doc.CreateComment("Одинокий элемент 5");
            e5.AppendChild(xcom);

            XmlElement e6 = doc.CreateElement("e6");
            xcom = doc.CreateComment("Одинокий элемент 6");
            e6.AppendChild(xcom);

            elem.AppendChild(e1);
            elem.AppendChild(e2);
            elem.AppendChild(e3);
            elem.AppendChild(e4);
            elem.AppendChild(e5);
            elem.AppendChild(e6);
            doc.DocumentElement.AppendChild(elem);
            doc.Save(path);
        }

        private XmlDocument getDocument()
        {
            XmlDocument xd = new XmlDocument();

            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                xd.Load(path);
            }
            else
            {
                XmlElement xl = xd.CreateElement("Phones");
                xd.AppendChild(xl);
                xd.Save(path);
            }
            return xd;
        }

        public void SearchPhoneByModel(string model)
        {
            XmlDocument xd = getDocument();
            XmlElement root = xd.DocumentElement;

            bool find = false;

            foreach (XmlElement item in root)
            {
                find = false;

                foreach (XmlNode i in item.ChildNodes)
                {
                    if (i.Name == "PhoneModel" && i.InnerText == model)
                        find = true;  // Console.WriteLine("Нет такой модели");
                }
                if (find)
                {
                    XmlElement el = Show(item);
                    break;
                }
            }
        }

        private XmlElement Show(XmlElement pho)
        {
            foreach (XmlElement item in pho.ChildNodes)
            {
                Console.WriteLine(item.Name + " - " + item.InnerText);
                Console.WriteLine();
            }
            return pho;
        }
    }
}
