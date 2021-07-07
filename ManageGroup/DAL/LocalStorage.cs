using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using ManageGroup.Domain;

namespace ManageGroup.DAL
{
    public class LocalStorage
    {
        private static int id = 0;
        private const string nameFile = "ActivityStorage.xml";

        public List<Activity> Activities { get; set; }
        public List<Status> ActivityStatusList { get; private set; } = Enum.GetValues(typeof(Status))
                                                                                  .Cast<Status>()
                                                                                  .ToList();
        public List<TypeComp> ActivityTypeList { get; private set; } = Enum.GetValues(typeof(TypeComp))
                                                                                  .Cast<TypeComp>()
                                                                                  .ToList();

        public LocalStorage()
        {
            var xmlText = $"<ArrayOf{nameof(Activity)}/>";
            if (File.Exists(nameFile)) xmlText = File.ReadAllText(nameFile);

            var xml = XDocument.Parse(xmlText);
            using (var stream = xml.CreateReader())
            {

                var ser = new XmlSerializer(typeof(List<Activity>));

                Activities = (List<Activity>)ser.Deserialize(stream);
            }


            id = Activities.Count > 0
                    ? Activities.Max(x => x.ID) + 1
                    : 1;
        }

        public void SaveChanges()
        {

            Activities.ForEach(x => x.ID = x.ID > 0 ? x.ID : id++);

            Activities = Activities.OrderBy(x => x.ID).ToList();

            if (!File.Exists(nameFile)) File.Create(nameFile).Close();

            using (var stream = new MemoryStream())
            {
                var ser = new XmlSerializer(typeof(List<Activity>));
                ser.Serialize(stream, Activities);
                stream.Position = 0;
                XDocument.Load(stream).Save(nameFile);
            }
        }
    }
}
